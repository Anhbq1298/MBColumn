using Dapper;
using MBColumn.Application.DTOs.Etabs;
using MBColumn.Application.Services.Etabs;
using Microsoft.Data.Sqlite;

namespace MBColumn.Infrastructure.Etabs;

public sealed class EtabsForceCacheService : IEtabsForceCacheService
{
    private SqliteConnection? db;

    public bool IsBuilt => db is not null;

    public string StatusText { get; private set; } = "Not built";

    public EtabsForceCacheBuildResult Build(IReadOnlyList<EtabsForceResultDto> forces)
    {
        try
        {
            db?.Dispose();
            db = new SqliteConnection("Data Source=:memory:");
            db.Open();

            db.Execute("""
                CREATE TABLE forces (
                    object_name      TEXT NOT NULL,
                    pier_name        TEXT NOT NULL,
                    story_name       TEXT NOT NULL,
                    label            TEXT NOT NULL,
                    etabs_section    TEXT NOT NULL,
                    load_combination TEXT NOT NULL,
                    p  REAL NOT NULL,
                    m2 REAL NOT NULL,
                    m3 REAL NOT NULL,
                    v2 REAL NOT NULL,
                    v3 REAL NOT NULL,
                    station TEXT NOT NULL,
                    status  TEXT NOT NULL
                );
                CREATE INDEX idx_forces_obj ON forces(object_name);
                CREATE INDEX idx_forces_combo ON forces(load_combination);
                """);

            using var tx = db.BeginTransaction();
            foreach (var f in forces)
            {
                db.Execute("""
                    INSERT INTO forces VALUES (
                        @ObjectName, @PierName, @StoryName, @Label, @EtabsSectionName,
                        @LoadCombination, @P, @M2, @M3, @V2, @V3, @Station, @Status)
                    """, f, tx);
            }
            tx.Commit();

            StatusText = $"Cached — {forces.Count:N0} rows";
            return new EtabsForceCacheBuildResult(true, forces.Count, StatusText);
        }
        catch (Exception ex)
        {
            db?.Dispose();
            db = null;
            StatusText = $"Build failed: {ex.Message}";
            return new EtabsForceCacheBuildResult(false, 0, StatusText);
        }
    }

    public IReadOnlyList<EtabsForceResultDto> Query(EtabsForceCacheQuery query)
    {
        if (db is null) return [];

        var conditions = new List<string>();
        var parameters = new DynamicParameters();

        if (query.ObjectNames is { Count: > 0 })
        {
            var names = query.ObjectNames.ToArray();
            conditions.Add($"object_name IN @ObjectNames");
            parameters.Add("ObjectNames", names);
        }

        if (query.LoadCombinations is { Count: > 0 })
        {
            conditions.Add($"load_combination IN @LoadCombinations");
            parameters.Add("LoadCombinations", query.LoadCombinations.ToArray());
        }

        if (query.Stations is { Count: > 0 })
        {
            conditions.Add($"station IN @Stations");
            parameters.Add("Stations", query.Stations.ToArray());
        }

        var where = conditions.Count > 0 ? "WHERE " + string.Join(" AND ", conditions) : "";
        var sql = $"""
            SELECT object_name AS ObjectName,
                   pier_name AS PierName,
                   story_name AS StoryName,
                   label AS Label,
                   etabs_section AS EtabsSectionName,
                   load_combination AS LoadCombination,
                   p AS P, m2 AS M2, m3 AS M3,
                   v2 AS V2, v3 AS V3,
                   station AS Station,
                   status AS Status
            FROM forces {where}
            """;

        return db.Query<EtabsForceResultDto>(sql, parameters).AsList();
    }

    public void Clear()
    {
        db?.Dispose();
        db = null;
        StatusText = "Not built";
    }

    public void Dispose()
    {
        db?.Dispose();
        db = null;
    }
}

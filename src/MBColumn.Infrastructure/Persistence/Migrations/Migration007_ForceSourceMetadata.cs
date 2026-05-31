using Microsoft.Data.Sqlite;

namespace MBColumn.Infrastructure.Persistence.Migrations;

/// <summary>
/// Adds force source traceability columns to DemandCase so each load case knows
/// whether it came from ETABS element forces or design forces, and which combination/location.
/// </summary>
internal sealed class Migration007_ForceSourceMetadata : IDatabaseMigration
{
    public int Version => 7;

    public void Apply(SqliteConnection connection)
    {
        foreach (var ddl in new[]
        {
            "ALTER TABLE DemandCase ADD COLUMN ForceSourceType TEXT;",
            "ALTER TABLE DemandCase ADD COLUMN SourceTableKey TEXT;",
            "ALTER TABLE DemandCase ADD COLUMN SourceCombination TEXT;",
            "ALTER TABLE DemandCase ADD COLUMN SourceLocation TEXT;",
            "ALTER TABLE DemandCase ADD COLUMN ImportedAt TEXT;"
        })
        {
            TryExec(connection, ddl);
        }
    }

    private static void TryExec(SqliteConnection connection, string sql)
    {
        try
        {
            using var cmd = connection.CreateCommand();
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
        }
        catch { }
    }
}

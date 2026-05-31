using Microsoft.Data.Sqlite;

namespace MBColumn.Infrastructure.Persistence.Migrations;

internal static class MigrationRunner
{
    public static void Run(SqliteConnection connection, IReadOnlyList<IDatabaseMigration> migrations)
    {
        var currentVersion = GetCurrentVersion(connection);

        foreach (var migration in migrations.OrderBy(m => m.Version))
        {
            if (migration.Version <= currentVersion) continue;

            migration.Apply(connection);
            RecordVersion(connection, migration.Version);
        }
    }

    private static long GetCurrentVersion(SqliteConnection connection)
    {
        using var cmd = connection.CreateCommand();
        cmd.CommandText = "SELECT MAX(Version) FROM SchemaVersion";
        // MAX() on an empty table returns DBNull.Value, not C# null — ?? does not catch it.
        var raw = cmd.ExecuteScalar();
        return raw is long v ? v : 0L;
    }

    private static void RecordVersion(SqliteConnection connection, int version)
    {
        using var cmd = connection.CreateCommand();
        cmd.CommandText = "INSERT INTO SchemaVersion (Version, AppliedAt) VALUES (@v, @now)";
        cmd.Parameters.AddWithValue("@v", version);
        cmd.Parameters.AddWithValue("@now", DateTime.UtcNow.ToString("O"));
        cmd.ExecuteNonQuery();
    }
}

using Microsoft.Data.Sqlite;

namespace MBColumn.Infrastructure.Persistence;

internal static class DatabaseSchema
{
    private const int CurrentVersion = 1;

    public static void EnsureCreated(SqliteConnection connection, string projectName)
    {
        connection.Open();

        Exec(connection, """
            CREATE TABLE IF NOT EXISTS SchemaVersion (
                Version    INTEGER NOT NULL,
                AppliedAt  TEXT NOT NULL
            )
            """);

        Exec(connection, """
            CREATE TABLE IF NOT EXISTS Project (
                Id          INTEGER PRIMARY KEY,
                Name        TEXT NOT NULL,
                Description TEXT,
                CreatedAt   TEXT NOT NULL,
                ModifiedAt  TEXT NOT NULL
            )
            """);

        Exec(connection, """
            CREATE TABLE IF NOT EXISTS Column (
                Id         INTEGER PRIMARY KEY,
                ProjectId  INTEGER NOT NULL REFERENCES Project(Id) ON DELETE CASCADE,
                Name       TEXT NOT NULL,
                SortOrder  INTEGER NOT NULL DEFAULT 0,
                InputJson  TEXT NOT NULL DEFAULT '{}',
                CreatedAt  TEXT NOT NULL,
                ModifiedAt TEXT NOT NULL
            )
            """);

        using var countCmd = connection.CreateCommand();
        countCmd.CommandText = "SELECT COUNT(*) FROM SchemaVersion";
        long count = (long)(countCmd.ExecuteScalar() ?? 0L);

        if (count == 0)
        {
            var now = DateTime.UtcNow.ToString("O");

            using var vCmd = connection.CreateCommand();
            vCmd.CommandText = "INSERT INTO SchemaVersion (Version, AppliedAt) VALUES (@v, @now)";
            vCmd.Parameters.AddWithValue("@v", CurrentVersion);
            vCmd.Parameters.AddWithValue("@now", now);
            vCmd.ExecuteNonQuery();

            using var pCmd = connection.CreateCommand();
            pCmd.CommandText = "INSERT INTO Project (Name, Description, CreatedAt, ModifiedAt) VALUES (@name, NULL, @now, @now)";
            pCmd.Parameters.AddWithValue("@name", projectName);
            pCmd.Parameters.AddWithValue("@now", now);
            pCmd.ExecuteNonQuery();
        }
    }

    public static void Open(SqliteConnection connection)
    {
        connection.Open();
    }

    private static void Exec(SqliteConnection connection, string sql)
    {
        using var cmd = connection.CreateCommand();
        cmd.CommandText = sql;
        cmd.ExecuteNonQuery();
    }
}

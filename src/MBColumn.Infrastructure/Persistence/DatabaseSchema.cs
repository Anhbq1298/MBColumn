using Microsoft.Data.Sqlite;

namespace MBColumn.Infrastructure.Persistence;

internal static class DatabaseSchema
{
    private const int CurrentVersion = 5;
    public const string AppVersion = "1.0.0";

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
                AppVersion  TEXT NOT NULL DEFAULT '1.0.0',
                CreatedAt   TEXT NOT NULL,
                ModifiedAt  TEXT NOT NULL
            )
            """);

        Exec(connection, """
            CREATE TABLE IF NOT EXISTS SectionGroup (
                Id          INTEGER PRIMARY KEY,
                ProjectId   INTEGER NOT NULL REFERENCES Project(Id) ON DELETE CASCADE,
                Name        TEXT NOT NULL,
                SortOrder   INTEGER NOT NULL DEFAULT 0,
                CreatedAt   TEXT NOT NULL,
                ModifiedAt  TEXT NOT NULL
            )
            """);

        Exec(connection, """
            CREATE TABLE IF NOT EXISTS Column (
                Id         INTEGER PRIMARY KEY,
                ProjectId  INTEGER NOT NULL REFERENCES Project(Id) ON DELETE CASCADE,
                GroupId    INTEGER REFERENCES SectionGroup(Id) ON DELETE SET NULL,
                Name       TEXT NOT NULL,
                SortOrder  INTEGER NOT NULL DEFAULT 0,
                InputJson  TEXT NOT NULL DEFAULT '{}',
                ResultJson TEXT,
                CreatedAt  TEXT NOT NULL,
                ModifiedAt TEXT NOT NULL
            )
            """);

        Exec(connection, """
            CREATE TABLE IF NOT EXISTS DemandCase (
                Id INTEGER PRIMARY KEY,
                ColumnId INTEGER NOT NULL REFERENCES Column(Id) ON DELETE CASCADE,
                IdString TEXT,
                Label TEXT,
                OriginalLoadCaseName TEXT,
                SourceObjectName TEXT,
                SourceObjectLabel TEXT,
                Story TEXT,
                Station TEXT,
                Source TEXT,
                Pu REAL NOT NULL,
                Mux REAL NOT NULL,
                Muy REAL NOT NULL,
                IsActive INTEGER NOT NULL DEFAULT 1
            )
            """);

        using var checkV1Cmd = connection.CreateCommand();
        checkV1Cmd.CommandText = "SELECT COUNT(*) FROM Project";
        long projectCount = (long)(checkV1Cmd.ExecuteScalar() ?? 0L);

        using var countCmd = connection.CreateCommand();
        countCmd.CommandText = "SELECT COUNT(*) FROM SchemaVersion";
        long count = (long)(countCmd.ExecuteScalar() ?? 0L);

        var now = DateTime.UtcNow.ToString("O");

        if (projectCount == 0 && count == 0)
        {
            using var vCmd = connection.CreateCommand();
            vCmd.CommandText = "INSERT INTO SchemaVersion (Version, AppliedAt) VALUES (@v, @now)";
            vCmd.Parameters.AddWithValue("@v", CurrentVersion);
            vCmd.Parameters.AddWithValue("@now", now);
            vCmd.ExecuteNonQuery();

            using var pCmd = connection.CreateCommand();
            pCmd.CommandText = "INSERT INTO Project (Name, Description, AppVersion, CreatedAt, ModifiedAt) VALUES (@name, NULL, @ver, @now, @now)";
            pCmd.Parameters.AddWithValue("@name", projectName);
            pCmd.Parameters.AddWithValue("@ver", AppVersion);
            pCmd.Parameters.AddWithValue("@now", now);
            pCmd.ExecuteNonQuery();
        }
        else
        {
            using var versionCmd = connection.CreateCommand();
            versionCmd.CommandText = "SELECT MAX(Version) FROM SchemaVersion";
            long version = (long)(versionCmd.ExecuteScalar() ?? 0L);

            if (version < 2)
            {
                Exec(connection, "ALTER TABLE Column ADD COLUMN GroupId INTEGER REFERENCES SectionGroup(Id) ON DELETE SET NULL;");

                using var vCmd = connection.CreateCommand();
                vCmd.CommandText = "INSERT INTO SchemaVersion (Version, AppliedAt) VALUES (@v, @now)";
                vCmd.Parameters.AddWithValue("@v", 2);
                vCmd.Parameters.AddWithValue("@now", now);
                vCmd.ExecuteNonQuery();

                version = 2;
            }

            if (version < 3)
            {
                try { Exec(connection, "ALTER TABLE Project ADD COLUMN AppVersion TEXT NOT NULL DEFAULT '1.0.0';"); } catch { }

                using var vCmd = connection.CreateCommand();
                vCmd.CommandText = "INSERT INTO SchemaVersion (Version, AppliedAt) VALUES (@v, @now)";
                vCmd.Parameters.AddWithValue("@v", 3);
                vCmd.Parameters.AddWithValue("@now", now);
                vCmd.ExecuteNonQuery();

                version = 3;
            }

            if (version < 4)
            {
                try { Exec(connection, "ALTER TABLE Column ADD COLUMN ResultJson TEXT;"); } catch { }

                using var vCmd = connection.CreateCommand();
                vCmd.CommandText = "INSERT INTO SchemaVersion (Version, AppliedAt) VALUES (@v, @now)";
                vCmd.Parameters.AddWithValue("@v", 4);
                vCmd.Parameters.AddWithValue("@now", now);
                vCmd.ExecuteNonQuery();
                
                version = 4;
            }

            if (version < 5)
            {
                Exec(connection, """
                    CREATE TABLE IF NOT EXISTS DemandCase (
                        Id INTEGER PRIMARY KEY,
                        ColumnId INTEGER NOT NULL REFERENCES Column(Id) ON DELETE CASCADE,
                        IdString TEXT,
                        Label TEXT,
                        OriginalLoadCaseName TEXT,
                        SourceObjectName TEXT,
                        SourceObjectLabel TEXT,
                        Story TEXT,
                        Station TEXT,
                        Source TEXT,
                        Pu REAL NOT NULL,
                        Mux REAL NOT NULL,
                        Muy REAL NOT NULL,
                        IsActive INTEGER NOT NULL DEFAULT 1
                    )
                    """);

                using var vCmd = connection.CreateCommand();
                vCmd.CommandText = "INSERT INTO SchemaVersion (Version, AppliedAt) VALUES (@v, @now)";
                vCmd.Parameters.AddWithValue("@v", 5);
                vCmd.Parameters.AddWithValue("@now", now);
                vCmd.ExecuteNonQuery();
            }
        }
    }

    public static void Open(SqliteConnection connection)
    {
        if (connection.State != System.Data.ConnectionState.Open)
            connection.Open();
        Exec(connection, "PRAGMA foreign_keys = ON");
        EnsureCreated(connection, "Project");
    }

    public static void OpenResultDb(SqliteConnection connection)
    {
        if (connection.State != System.Data.ConnectionState.Open)
            connection.Open();
        
        Exec(connection, """
            CREATE TABLE IF NOT EXISTS ColumnResult (
                ColumnId INTEGER PRIMARY KEY,
                InputHash TEXT NOT NULL,
                ResultJson TEXT NOT NULL
            )
            """);
    }

    private static void Exec(SqliteConnection connection, string sql)
    {
        using var cmd = connection.CreateCommand();
        cmd.CommandText = sql;
        cmd.ExecuteNonQuery();
    }
}

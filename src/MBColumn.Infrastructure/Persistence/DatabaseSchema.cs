using MBColumn.Infrastructure.Persistence.Migrations;
using Microsoft.Data.Sqlite;

namespace MBColumn.Infrastructure.Persistence;

internal static class DatabaseSchema
{
    private const int CurrentVersion = 9;
    public const string AppVersion = "1.0.0";

    private static readonly IReadOnlyList<IDatabaseMigration> s_migrations =
    [
        new Migration002_SectionGroups(),
        new Migration003_ProjectAppVersion(),
        new Migration004_ResultJson(),
        new Migration005_DemandCase(),
        new Migration006_TopBottomMomentsAndShear(),
        new Migration007_ForceSourceMetadata(),
        new Migration008_EtabsModelInfo(),
        new Migration009_DemandCaseMemberLength()
    ];

    public static void EnsureCreated(SqliteConnection connection, string projectName)
    {
        if (connection.State != System.Data.ConnectionState.Open)
            connection.Open();

        // Always create base tables (idempotent — IF NOT EXISTS)
        CreateBaseTables(connection);

        using var countCmd = connection.CreateCommand();
        countCmd.CommandText = "SELECT COUNT(*) FROM SchemaVersion";
        long schemaRowCount = (long)(countCmd.ExecuteScalar() ?? 0L);

        using var projectCountCmd = connection.CreateCommand();
        projectCountCmd.CommandText = "SELECT COUNT(*) FROM Project";
        long projectCount = (long)(projectCountCmd.ExecuteScalar() ?? 0L);

        var now = DateTime.UtcNow.ToString("O");

        if (projectCount == 0 && schemaRowCount == 0)
        {
            // Brand-new database — seed at current version, no migrations needed
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
            // Existing database — run any pending migrations
            MigrationRunner.Run(connection, s_migrations);
        }

        EnsureCurrentColumns(connection);
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

    private static void CreateBaseTables(SqliteConnection connection)
    {
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
                ModifiedAt  TEXT NOT NULL,
                EtabsModelName TEXT,
                EtabsModelPath TEXT,
                EtabsUnits TEXT,
                EtabsStoryCount INTEGER,
                EtabsPierCount INTEGER,
                EtabsFrameCount INTEGER
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
                IsActive INTEGER NOT NULL DEFAULT 1,
                MxTop REAL,
                MxBottom REAL,
                MyTop REAL,
                MyBottom REAL,
                MxUsed REAL,
                MyUsed REAL,
                Vux REAL NOT NULL DEFAULT 0.0,
                Vuy REAL NOT NULL DEFAULT 0.0,
                ForceSourceType TEXT,
                SourceTableKey TEXT,
                SourceCombination TEXT,
                SourceLocation TEXT,
                ImportedAt TEXT,
                MemberLengthOverride REAL
            )
            """);
    }

    private static void EnsureCurrentColumns(SqliteConnection connection)
    {
        AddColumnIfMissing(connection, "Project", "EtabsModelName", "TEXT");
        AddColumnIfMissing(connection, "Project", "EtabsModelPath", "TEXT");
        AddColumnIfMissing(connection, "Project", "EtabsUnits", "TEXT");
        AddColumnIfMissing(connection, "Project", "EtabsStoryCount", "INTEGER");
        AddColumnIfMissing(connection, "Project", "EtabsPierCount", "INTEGER");
        AddColumnIfMissing(connection, "Project", "EtabsFrameCount", "INTEGER");
        AddColumnIfMissing(connection, "DemandCase", "MemberLengthOverride", "REAL");
    }

    private static void AddColumnIfMissing(SqliteConnection connection, string tableName, string columnName, string columnDefinition)
    {
        if (ColumnExists(connection, tableName, columnName))
            return;

        Exec(connection, $"ALTER TABLE {tableName} ADD COLUMN {columnName} {columnDefinition}");
    }

    private static bool ColumnExists(SqliteConnection connection, string tableName, string columnName)
    {
        using var cmd = connection.CreateCommand();
        cmd.CommandText = $"PRAGMA table_info({tableName})";
        using var reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            if (string.Equals(reader.GetString(1), columnName, StringComparison.OrdinalIgnoreCase))
                return true;
        }

        return false;
    }

    private static void Exec(SqliteConnection connection, string sql)
    {
        using var cmd = connection.CreateCommand();
        cmd.CommandText = sql;
        cmd.ExecuteNonQuery();
    }
}

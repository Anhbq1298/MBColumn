using Microsoft.Data.Sqlite;

namespace MBColumn.Infrastructure.Persistence.Migrations;

internal sealed class Migration005_DemandCase : IDatabaseMigration
{
    public int Version => 5;

    public void Apply(SqliteConnection connection)
    {
        using var cmd = connection.CreateCommand();
        cmd.CommandText = """
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
            """;
        cmd.ExecuteNonQuery();
    }
}

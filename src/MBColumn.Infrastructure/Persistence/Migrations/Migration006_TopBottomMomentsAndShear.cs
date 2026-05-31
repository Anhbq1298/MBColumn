using Microsoft.Data.Sqlite;

namespace MBColumn.Infrastructure.Persistence.Migrations;

internal sealed class Migration006_TopBottomMomentsAndShear : IDatabaseMigration
{
    public int Version => 6;

    public void Apply(SqliteConnection connection)
    {
        foreach (var ddl in new[]
        {
            "ALTER TABLE DemandCase ADD COLUMN MxTop REAL;",
            "ALTER TABLE DemandCase ADD COLUMN MxBottom REAL;",
            "ALTER TABLE DemandCase ADD COLUMN MyTop REAL;",
            "ALTER TABLE DemandCase ADD COLUMN MyBottom REAL;",
            "ALTER TABLE DemandCase ADD COLUMN MxUsed REAL;",
            "ALTER TABLE DemandCase ADD COLUMN MyUsed REAL;",
            "ALTER TABLE DemandCase ADD COLUMN Vux REAL NOT NULL DEFAULT 0.0;",
            "ALTER TABLE DemandCase ADD COLUMN Vuy REAL NOT NULL DEFAULT 0.0;"
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

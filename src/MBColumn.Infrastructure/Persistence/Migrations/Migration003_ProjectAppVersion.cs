using Microsoft.Data.Sqlite;

namespace MBColumn.Infrastructure.Persistence.Migrations;

internal sealed class Migration003_ProjectAppVersion : IDatabaseMigration
{
    public int Version => 3;

    public void Apply(SqliteConnection connection)
    {
        TryExec(connection, "ALTER TABLE Project ADD COLUMN AppVersion TEXT NOT NULL DEFAULT '1.0.0';");
    }

    private static void TryExec(SqliteConnection connection, string sql)
    {
        try
        {
            using var cmd = connection.CreateCommand();
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
        }
        catch { /* column may already exist in older databases */ }
    }
}

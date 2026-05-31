using Microsoft.Data.Sqlite;

namespace MBColumn.Infrastructure.Persistence.Migrations;

internal sealed class Migration004_ResultJson : IDatabaseMigration
{
    public int Version => 4;

    public void Apply(SqliteConnection connection)
    {
        TryExec(connection, "ALTER TABLE Column ADD COLUMN ResultJson TEXT;");
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

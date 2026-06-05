using Microsoft.Data.Sqlite;

namespace MBColumn.Infrastructure.Persistence.Migrations;

internal sealed class Migration008_EtabsModelInfo : IDatabaseMigration
{
    public int Version => 8;

    public void Apply(SqliteConnection connection)
    {
        foreach (var ddl in new[]
        {
            "ALTER TABLE Project ADD COLUMN EtabsModelName TEXT;",
            "ALTER TABLE Project ADD COLUMN EtabsModelPath TEXT;",
            "ALTER TABLE Project ADD COLUMN EtabsUnits TEXT;",
            "ALTER TABLE Project ADD COLUMN EtabsStoryCount INTEGER;",
            "ALTER TABLE Project ADD COLUMN EtabsPierCount INTEGER;",
            "ALTER TABLE Project ADD COLUMN EtabsFrameCount INTEGER;"
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

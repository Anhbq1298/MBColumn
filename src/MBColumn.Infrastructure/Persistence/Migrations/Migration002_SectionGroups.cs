using Microsoft.Data.Sqlite;

namespace MBColumn.Infrastructure.Persistence.Migrations;

internal sealed class Migration002_SectionGroups : IDatabaseMigration
{
    public int Version => 2;

    public void Apply(SqliteConnection connection)
    {
        // TryExec matches Migration003/004/006/007 pattern — absorbs "duplicate column name"
        // if migration is re-entered after a crash before RecordVersion was written.
        TryExec(connection, "ALTER TABLE Column ADD COLUMN GroupId INTEGER REFERENCES SectionGroup(Id) ON DELETE SET NULL;");
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

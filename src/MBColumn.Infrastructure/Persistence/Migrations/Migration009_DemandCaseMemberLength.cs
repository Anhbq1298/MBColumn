using Microsoft.Data.Sqlite;

namespace MBColumn.Infrastructure.Persistence.Migrations;

internal sealed class Migration009_DemandCaseMemberLength : IDatabaseMigration
{
    public int Version => 9;

    public void Apply(SqliteConnection connection)
    {
        TryExec(connection, "ALTER TABLE DemandCase ADD COLUMN MemberLengthOverride REAL;");
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

using Microsoft.Data.Sqlite;

namespace MBColumn.Infrastructure.Persistence.Migrations;

internal sealed class Migration010_EtabsLoadRowMetadata : IDatabaseMigration
{
    public int Version => 10;

    public void Apply(SqliteConnection connection)
    {
        TryExec(connection, "ALTER TABLE DemandCase ADD COLUMN IsEtabsImportedLoad INTEGER NOT NULL DEFAULT 0;");
        TryExec(connection, "ALTER TABLE DemandCase ADD COLUMN EtabsLoadCaseOrCombo TEXT;");
        TryExec(connection, "ALTER TABLE DemandCase ADD COLUMN EtabsFrameId TEXT;");
        TryExec(connection, "ALTER TABLE DemandCase ADD COLUMN EtabsForceStation TEXT;");
        TryExec(connection, "ALTER TABLE DemandCase ADD COLUMN EtabsForceImportedAt TEXT;");
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

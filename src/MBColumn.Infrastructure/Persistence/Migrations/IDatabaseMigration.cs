using Microsoft.Data.Sqlite;

namespace MBColumn.Infrastructure.Persistence.Migrations;

internal interface IDatabaseMigration
{
    int Version { get; }
    void Apply(SqliteConnection connection);
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace Moms.Lookup.Infrastructure.Migrations
{
    public partial class AddLookupOptionsView : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                @"DROP VIEW IF EXISTS ""LookupOptions""");
            migrationBuilder.Sql(@"CREATE VIEW ""LookupOptions""
            As
          SELECT
                o.""Id"",
                i.""Id"" LookUpMasterId,
                i.""Name""  LookupMasterName,
                i.""Alias"" LookupMasterAlias,
                l.""Id"" LookupItemId,
                l.""Name"" LookupItemName,
                l.""Alias"" LookupItemAlias,
                l.""CreateDate"",
                l.""UserId"",
                l.""Void"",
                l.""VoidDate""
            FROM ""LookupMasterItems""  o
                INNER JOIN ""LookupMasters"" i
                ON
                o.""LookupMasterId""=i.""Id""
                INNER JOIN ""LookupItems"" l
                    ON
                l.""Id""=o.""LookupItemId"""
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP VIEW IF EXISTS ""LookupOptions""");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Moms.Lookup.Infrastructure.Migrations
{
    public partial class AddLookupOptionView : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
          /*  migrationBuilder.Sql(@"CREATE VIEW LookupOptions
            As
          SELECT
                o.Id,
                i.Id lookupMasterId,
                i.Name  lookupMasterName,
                i.Alias LookMasterAlias,
                l.Id LookupItemId,
                l.Name LookupItemName,
                l.Alias LookupItemAlias
            FROM public.'LookupMasterItems'  o
                INNER JOIN LookupMaster i
                ON
                o.LookupMasterId=i.Id
                INNER JOIN LookupItems l
                    ON
                l.Id=o.LookupItemId"
            );*/
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP VIEW IF EXISTS lookupoptions");
        }
    }
}

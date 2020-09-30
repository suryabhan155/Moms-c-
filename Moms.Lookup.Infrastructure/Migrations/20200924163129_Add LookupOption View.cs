using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Moms.Lookup.Infrastructure.Migrations
{
    public partial class AddLookupOptionView : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP VIEW IF EXISTS ""lookupoptions""");
            migrationBuilder.Sql(@"CREATE VIEW ""lookupoptions""
            As
          SELECT
                o.""id"",
                i.""id"" lookupmasterid,
                i.""name""  lookupmastername,
                i.""alias"" lookmasteralias,
                l.""id"" lookupItemId,
                l.""name"" lookupitemaame,
                l.""alias"" lookupitemalias
            FROM ""lookupmasteritems""  o
                INNER JOIN ""lookupmaster"" i
                ON
                o.""lookupmasterid""=i.""id""
                INNER JOIN ""lookupitems"" l
                    ON
                l.""id""=o.""lookupitemid"""
            );

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP VIEW IF EXISTS ""lookupoptions""");
        }
    }
}

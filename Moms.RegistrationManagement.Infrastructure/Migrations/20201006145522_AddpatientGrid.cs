using System;
using Microsoft.EntityFrameworkCore.Migrations;
using NpgsqlTypes;

namespace Moms.RegistrationManagement.Infrastructure.Migrations
{
    public partial class AddpatientGrid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                @"DROP VIEW IF EXISTS ""PatientGrids""");

            migrationBuilder.Sql(
                @"CREATE VIEW ""PatientGrids""
                    AS
                    SELECT p.""Id"",
                                p.""FirstName"",
                                p.""MiddleName"",
                                p.""LastName"",
                                p.""DoB"",
                                p.""Sex"" as ""SexId"",
                                (SELECT  i.""Name"" FROM ""LookupItems"" i WHERE i.""Id""=p.""Sex"" limit 1) AS ""Sex"",
                                p.""MaritalStatus"" as ""MaritalStatusId"",
                                (SELECT i.""Name"" FROM ""LookupItems"" i WHERE i.""Id""=p.""MaritalStatus"" limit 1) AS ""MaritalStatus"",
                                    p.""Narrative"",
                                    p.""CreateDate"",
                                p.""Void"",
                                p.""VoidDate"",
                                p.""UserId"" ,
                                p.""SearchVector"" ,
                                p.""IdentificationNumber"",
                                p.""PatientNumber"",
                                p.""Phone"",
                                p.""RegistrationDate""
                                FROM ""Patients"" p;"
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                @"DROP VIEW IF EXISTS ""PatientGrids""");
        }
    }
}

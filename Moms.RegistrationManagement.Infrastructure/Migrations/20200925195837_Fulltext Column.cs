
using Microsoft.EntityFrameworkCore.Migrations;
using Moms.RegistrationManagement.Core.Domain.Patient.Models;
using NpgsqlTypes;

namespace Moms.RegistrationManagement.Infrastructure.Migrations
{
    public partial class FulltextColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<NpgsqlTsVector>(
                name: "SearchVector",
                table: "Patients",
                nullable: true);


            migrationBuilder.Sql(
                @"CREATE TRIGGER patient_search_vector_update BEFORE INSERT OR UPDATE
              ON ""Patients"" FOR EACH ROW EXECUTE PROCEDURE
              tsvector_update_trigger(""SearchVector"", 'pg_catalog.english',
                ""FirstName"",
                ""MiddleName"",
                ""LastName"",
                ""Narrative"",
                ""Phone"",
                ""IdentificationNumber"",
                ""PatientNumber"",
                ""Phone""
              );");



           /* migrationBuilder.Entity<Patient>()
                .HasGeneratedTsVectorColumn(
                    p => b.TsVector,
                    "english",  // Text search config
                    p => new { p.Name, p.Description })  // Included properties
                .HasIndex(b => b.TsVector)
                .HasMethod("GIN");*/

           /* migrationBuilder.CreateIndex(
                name: "IX_Patients_SearchVector",
                table: "Patients",
                column: "SearchVector")
                .Annotation("Npgsql:IndexMethod", "GIN");

            migrationBuilder.Sql(
                @"CREATE TRIGGER user_search_vector_update BEFORE INSERT OR UPDATE
            ON ""Patients"" FOR EACH ROW EXECUTE PROCEDURE
            ts`enter code here`vector_update_trigger(""SearchVector"", 'pg_catalog.english', ""Name"", ""Surname"");");*/
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Patients_SearchVector",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "SearchVector",
                table: "Patients");

            migrationBuilder.Sql("DROP TRIGGER Patient_search_vector_update");
        }
    }
}

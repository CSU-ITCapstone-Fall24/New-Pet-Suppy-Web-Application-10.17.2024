using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Operations.Builders;

internal static class InitMigrationHelpers
{

    private static CreateTableBuilder<object> NewMethod(MigrationBuilder migrationBuilder, CreateTableBuilder<object> tableBuilder, CreateTableBuilder<object> tableBuilderResult, CreateTableBuilder<object> tableBuilderResult, CreateTableBuilder<object> tableBuilderResult1)
    {
        var tableBuilderResult1 = migrationBuilder.CreateTable(
            name: "Puppies",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                BreedName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                PuppyPrice = table.Column<int>(type: "int", nullable: false),
                ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Puppies", x => x.Id);
            });

        return tableBuilderResult1;
    }
}
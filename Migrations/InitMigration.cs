using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.EntityFrameworkCore.Migrations.Operations.Builders;

#nullable disable

namespace Pet_Web_Application_10._12._24_F.Migrations
{
    /// <inheritdoc />
    public partial class InitMigration : Migration
    {
        private static readonly CreateTableBuilder<object> tableBuilder;


        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            NewMethod(migrationBuilder, tableBuilder );
        }

        private void NewMethod(MigrationBuilder migrationBuilder, CreateTableBuilder<object> tableBuilder, object tableBuilderResult1, object tableBuilderResult2)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Puppies");
        }

        public override bool Equals(object obj)
        {
            return obj is InitMigration migration &&
                   EqualityComparer<IModel>.Default.Equals(TargetModel, migration.TargetModel) &&
                   EqualityComparer<IReadOnlyList<MigrationOperation>>.Default.Equals(UpOperations, migration.UpOperations) &&
                   EqualityComparer<IReadOnlyList<MigrationOperation>>.Default.Equals(DownOperations, migration.DownOperations) &&
                   ActiveProvider == migration.ActiveProvider;
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PokemonAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSeededData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Pokemons",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "TeamId", "TrainerId" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "Pokemons",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "TeamId", "TrainerId" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "Pokemons",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "TeamId", "TrainerId" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "Pokemons",
                columns: new[] { "Id", "Level", "Name", "TeamId", "TrainerId", "Type" },
                values: new object[] { 4, 1, "Pikachu", 2, 2, "Electric" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Pokemons",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.UpdateData(
                table: "Pokemons",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "TeamId", "TrainerId" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Pokemons",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "TeamId", "TrainerId" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Pokemons",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "TeamId", "TrainerId" },
                values: new object[] { null, null });
        }
    }
}

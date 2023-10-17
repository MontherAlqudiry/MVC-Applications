using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Demo_API.Migrations
{
    /// <inheritdoc />
    public partial class AddTablePeople : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "Id", "Address", "Age", "ImageUrl", "Name" },
                values: new object[,]
                {
                    { 1, "New york city", 25, "https://images.pexels.com/photos/220453/pexels-photo-220453.jpeg?auto=compress&cs=tinysrgb&dpr=1&w=500", "Jack" },
                    { 2, "Las Vegas", 22, "https://www.google.com/url?sa=i&url=https%3A%2F%2Funsplash.com%2Fs%2Fphotos%2Fperson&psig=AOvVaw3zCQm5ilRKKKhIZfbIhuIt&ust=1697005510532000&source=images&cd=vfe&opi=89978449&ved=0CBEQjRxqFwoTCPiBkafs6oEDFQAAAAAdAAAAABAE", "Rose" },
                    { 3, "Madried", 28, "https://www.google.com/url?sa=i&url=https%3A%2F%2Funsplash.com%2Fs%2Fphotos%2Fprofile-image&psig=AOvVaw3zCQm5ilRKKKhIZfbIhuIt&ust=1697005510532000&source=images&cd=vfe&opi=89978449&ved=0CBEQjRxqFwoTCPiBkafs6oEDFQAAAAAdAAAAABAJ", "Ron" },
                    { 4, "sydney", 23, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSRKouGaC5wkHjgKIuSSZTrTBBQWc5gEIOPFw&usqp=CAU", "Batrisha" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "People");
        }
    }
}

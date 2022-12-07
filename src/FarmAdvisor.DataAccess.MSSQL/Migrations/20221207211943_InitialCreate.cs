using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FarmAdvisor.DataAccess.MSSQL.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Farms",
                columns: table => new
                {
                    FarmId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Postcode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Farms", x => x.FarmId);
                });

            migrationBuilder.CreateTable(
                name: "FarmFeilds",
                columns: table => new
                {
                    FieldId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FarmDtoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Altitude = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Polygon = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FarmFeilds", x => x.FieldId);
                    table.ForeignKey(
                        name: "FK_FarmFeilds_Farms_FarmDtoId",
                        column: x => x.FarmDtoId,
                        principalTable: "Farms",
                        principalColumn: "FarmId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AuthId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FarmId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Users_Farms_FarmId",
                        column: x => x.FarmId,
                        principalTable: "Farms",
                        principalColumn: "FarmId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sensors",
                columns: table => new
                {
                    SensorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SerialNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastCommunication = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BatteryStatus = table.Column<int>(type: "int", nullable: false),
                    OptimalGDD = table.Column<int>(type: "int", nullable: false),
                    CuttingDateCaclculated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastForecastDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Long = table.Column<double>(type: "float", nullable: false),
                    Lat = table.Column<double>(type: "float", nullable: false),
                    State = table.Column<int>(type: "int", nullable: false),
                    FarmFeildId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FarmFieldFieldId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sensors", x => x.SensorId);
                    table.ForeignKey(
                        name: "FK_Sensors_FarmFeilds_FarmFieldFieldId",
                        column: x => x.FarmFieldFieldId,
                        principalTable: "FarmFeilds",
                        principalColumn: "FieldId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_FarmFeilds_FarmDtoId",
                table: "FarmFeilds",
                column: "FarmDtoId");

            migrationBuilder.CreateIndex(
                name: "IX_Sensors_FarmFieldFieldId",
                table: "Sensors",
                column: "FarmFieldFieldId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_FarmId",
                table: "Users",
                column: "FarmId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sensors");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "FarmFeilds");

            migrationBuilder.DropTable(
                name: "Farms");
        }
    }
}

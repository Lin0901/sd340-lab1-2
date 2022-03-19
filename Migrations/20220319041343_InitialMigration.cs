using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAnnotations.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: true),
                    LastName = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Room",
                columns: table => new
                {
                    RoomNumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Capacity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room", x => x.RoomNumber);
                });

            migrationBuilder.CreateTable(
                name: "Credit",
                columns: table => new
                {
                    CreditNumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsValid = table.Column<bool>(type: "bit", nullable: false),
                    HolderName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Credit", x => x.CreditNumber);
                    table.ForeignKey(
                        name: "FK_Credit_Client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Client",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CurrentBooking",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CurrentClientId = table.Column<int>(type: "int", nullable: false),
                    CurrentRoomNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrentBooking", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CurrentBooking_Client_CurrentClientId",
                        column: x => x.CurrentClientId,
                        principalTable: "Client",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CurrentBooking_Room_CurrentRoomNumber",
                        column: x => x.CurrentRoomNumber,
                        principalTable: "Room",
                        principalColumn: "RoomNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PreviousBooking",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PreviousClientId = table.Column<int>(type: "int", nullable: false),
                    PreviousRoomNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PreviousBooking", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PreviousBooking_Client_PreviousClientId",
                        column: x => x.PreviousClientId,
                        principalTable: "Client",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PreviousBooking_Room_PreviousRoomNumber",
                        column: x => x.PreviousRoomNumber,
                        principalTable: "Room",
                        principalColumn: "RoomNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Credit_ClientId",
                table: "Credit",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_CurrentBooking_CurrentClientId",
                table: "CurrentBooking",
                column: "CurrentClientId");

            migrationBuilder.CreateIndex(
                name: "IX_CurrentBooking_CurrentRoomNumber",
                table: "CurrentBooking",
                column: "CurrentRoomNumber");

            migrationBuilder.CreateIndex(
                name: "IX_PreviousBooking_PreviousClientId",
                table: "PreviousBooking",
                column: "PreviousClientId");

            migrationBuilder.CreateIndex(
                name: "IX_PreviousBooking_PreviousRoomNumber",
                table: "PreviousBooking",
                column: "PreviousRoomNumber");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Credit");

            migrationBuilder.DropTable(
                name: "CurrentBooking");

            migrationBuilder.DropTable(
                name: "PreviousBooking");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "Room");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InnoloftAPI.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreatefordb676345 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EventParticipants",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EventID = table.Column<int>(type: "INTEGER", nullable: false),
                    ParticipantID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventParticipants", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OwnerId = table.Column<int>(type: "INTEGER", nullable: false),
                    StartDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EndDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdateEventDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreateEventDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Timezone = table.Column<string>(type: "TEXT", nullable: false),
                    EventTitle = table.Column<string>(type: "TEXT", nullable: false),
                    EventDescription = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Participants",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Username = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Phone = table.Column<string>(type: "TEXT", nullable: false),
                    Website = table.Column<string>(type: "TEXT", nullable: false),
                    AddressStreet = table.Column<string>(type: "TEXT", nullable: false),
                    AddressSuite = table.Column<string>(type: "TEXT", nullable: false),
                    AddressCity = table.Column<string>(type: "TEXT", nullable: false),
                    AddressZipcode = table.Column<string>(type: "TEXT", nullable: false),
                    GeoLat = table.Column<string>(type: "TEXT", nullable: false),
                    GeoLng = table.Column<string>(type: "TEXT", nullable: false),
                    CompanyName = table.Column<string>(type: "TEXT", nullable: false),
                    CompanyCatchPhrase = table.Column<string>(type: "TEXT", nullable: false),
                    CompanyBs = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participants", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventParticipants");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Participants");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectEstimator.Api.Data.Migrations
{
    public partial class InitialRateProfiles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                "RateProfiles",
                table => new
                {
                    Id = table.Column<Guid>(),
                    Active = table.Column<bool>(),
                    BuildingPlumbing = table.Column<int>(),
                    CoreExteriorDoors = table.Column<int>(),
                    CoreInteriorDoors = table.Column<int>(),
                    CoreLobbyMain = table.Column<int>(),
                    CoreLobbyUpper = table.Column<int>(),
                    CoreRestroom = table.Column<int>(),
                    CoreVestibules = table.Column<int>(),
                    CurtainWallSystem = table.Column<int>(),
                    DesignEng = table.Column<double>(),
                    ElecServ = table.Column<int>(),
                    ElevatorPitConcrete = table.Column<int>(),
                    ElevatorShaftWalls = table.Column<int>(),
                    EntryCanopyRoof = table.Column<int>(),
                    EntryCanopySteel = table.Column<int>(),
                    FireAlarm = table.Column<double>(),
                    FireProtectionSystems = table.Column<double>(),
                    FireProtectionSystemsUnderCanopies = table.Column<int>(),
                    HvacDesign = table.Column<double>(),
                    HydraulicElevator = table.Column<int>(),
                    JanitorClosetPlumbing = table.Column<int>(),
                    JanitorClosets = table.Column<int>(),
                    MechScreen = table.Column<double>(),
                    MepRooms = table.Column<int>(),
                    MepShaftWalls = table.Column<int>(),
                    MiscExteriorWindowAndWallFlashings = table.Column<double>(),
                    MiscellaneousSteel = table.Column<int>(),
                    RestroomPlumbingFixtures = table.Column<int>(),
                    RoofRelatedSheetMetals = table.Column<double>(),
                    RoughCarpentry = table.Column<double>(),
                    ScPaint = table.Column<double>(),
                    Skylights = table.Column<int>(),
                    SlabPrep = table.Column<double>(),
                    StairWellWalls = table.Column<int>(),
                    StorefrontWindowSystems = table.Column<int>(),
                    StructuralExcav = table.Column<double>(),
                    UpgradeElevatorCabFinish = table.Column<int>(),
                    WaterBelGradeWall = table.Column<int>(),
                    WaterproofElevatorPit = table.Column<int>()
                },
                constraints: table => { table.PrimaryKey("PK_RateProfiles", x => x.Id); });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "RateProfiles");
        }
    }
}
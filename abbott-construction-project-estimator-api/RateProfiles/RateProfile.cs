using System;
using System.ComponentModel.DataAnnotations;

namespace ProjectEstimator.Api.RateProfiles
{
    public class RateProfile
    {
        public Guid Id { get; set; }
        [Required] public bool Active { get; set; }

        // The rate properties in alphabetical order (the order matters for the generated schema).
        [Required] public int BuildingPlumbing { get; set; }
        [Required] public int CoreExteriorDoors { get; set; }
        [Required] public int CoreInteriorDoors { get; set; }
        [Required] public int CoreLobbyMain { get; set; }
        [Required] public int CoreLobbyUpper { get; set; }
        [Required] public int CoreRestroom { get; set; }
        [Required] public int CoreVestibules { get; set; }
        [Required] public int CurtainWallSystem { get; set; }
        [Required] public double DesignEng { get; set; }
        [Required] public int ElecServ { get; set; }
        [Required] public int ElevatorPitConcrete { get; set; }
        [Required] public int ElevatorShaftWalls { get; set; }
        [Required] public int EntryCanopyRoof { get; set; }
        [Required] public int EntryCanopySteel { get; set; }
        [Required] public double FireAlarm { get; set; }
        [Required] public double FireProtectionSystems { get; set; }
        [Required] public int FireProtectionSystemsUnderCanopies { get; set; }
        [Required] public double HvacDesign { get; set; }
        [Required] public int HydraulicElevator { get; set; }
        [Required] public int JanitorClosetPlumbing { get; set; }
        [Required] public int JanitorClosets { get; set; }
        [Required] public double MechScreen { get; set; }
        [Required] public int MepRooms { get; set; }
        [Required] public int MepShaftWalls { get; set; }
        [Required] public double MiscExteriorWindowAndWallFlashings { get; set; }
        [Required] public int MiscellaneousSteel { get; set; }
        [Required] public int RestroomPlumbingFixtures { get; set; }
        [Required] public double RoofRelatedSheetMetals { get; set; }
        [Required] public double RoughCarpentry { get; set; }
        [Required] public double ScPaint { get; set; }
        [Required] public int Skylights { get; set; }
        [Required] public double SlabPrep { get; set; }
        [Required] public int StairWellWalls { get; set; }
        [Required] public int StorefrontWindowSystems { get; set; }
        [Required] public double StructuralExcav { get; set; }
        [Required] public int UpgradeElevatorCabFinish { get; set; }
        [Required] public int WaterBelGradeWall { get; set; }
        [Required] public int WaterproofElevatorPit { get; set; }
    }
}
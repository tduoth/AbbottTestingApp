using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProjectEstimator.Api.Library;
using ProjectEstimator.Api.RateProfiles;
using ProjectEstimator.Api.Users;

namespace ProjectEstimator.Api.Data
{
    public static class DbInitializer
    {
        public static async Task SeedIdentityAsync(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            // Create role(s) first.
            if (!await roleManager.RoleExistsAsync(Roles.Administrator))
                await roleManager.CreateAsync(new IdentityRole {Name = Roles.Administrator});
            
            // Prompt to create the first Administrator user.
            if (!await userManager.Users.AnyAsync())
            {
                // Add some delay so the prompt shows up after all the Microsoft.Hosting info output.
                await Task.Delay(TimeSpan.FromSeconds(1));
                
                while(true)
                {
                    Console.WriteLine($"Please create the first {Roles.Administrator} user below.");
                    
                    // Ask for email address
                    Console.Write("Enter an email address for the admin account: ");
                    var email = Console.ReadLine();

                    // Ask for password
                    Console.Write("Enter a password for the admin account: ");
                    var password = ConsoleUtility.GetHiddenConsoleInput();

                    // Create the user
                    var user = new IdentityUser {Email = email, EmailConfirmed = true, UserName = email};
                    Console.WriteLine(); // CreateAsync() may show a warning, so a new line would make it look better.
                    var userCreationResult = await userManager.CreateAsync(user, password);
                    
                    // Restart prompt on failed attempt.
                    // Could be caused by an invalid email address or not meeting password complexity requirements. 
                    if (!userCreationResult.Succeeded)
                    {
                        Console.WriteLine(Environment.NewLine + "INPUT ERROR: User could not be created. Please try again.");
                        continue;
                    }

                    // User was created with no issues, so add the user to the Administrator role.
                    await userManager.AddToRoleAsync(user, Roles.Administrator);

                    // End the prompting.
                    Console.WriteLine("User created successfully.");
                    break;
                }
            }
        }
        
        public static async Task SeedRateProfileAsync(AppDbContext db)
        {
            if (await db.RateProfiles.AnyAsync()) return;

            await db.RateProfiles.AddAsync(new RateProfile
            {
                Active = true,
                BuildingPlumbing = 3,
                CoreExteriorDoors = 5500,
                CoreInteriorDoors = 2500,
                CoreLobbyMain = 60000,
                CoreLobbyUpper = 30000,
                CoreRestroom = 35000,
                CoreVestibules = 40000,
                CurtainWallSystem = 110,
                DesignEng = 0.75,
                ElecServ = 21,
                ElevatorPitConcrete = 6500,
                ElevatorShaftWalls = 18,
                EntryCanopyRoof = 50,
                EntryCanopySteel = 30,
                FireAlarm = 2.5,
                FireProtectionSystems = 3.5,
                FireProtectionSystemsUnderCanopies = 6,
                HvacDesign = 0.75,
                HydraulicElevator = 55000,
                JanitorClosetPlumbing = 3500,
                JanitorClosets = 12,
                MechScreen = 0.65,
                MepRooms = 12,
                MepShaftWalls = 16,
                MiscExteriorWindowAndWallFlashings = 1.5,
                MiscellaneousSteel = 1,
                RestroomPlumbingFixtures = 4500,
                RoofRelatedSheetMetals = 2.5,
                RoughCarpentry = 0.75,
                ScPaint = 0.65,
                Skylights = 145,
                SlabPrep = 1.5,
                StairWellWalls = 12,
                StorefrontWindowSystems = 85,
                StructuralExcav = 3.5,
                UpgradeElevatorCabFinish = 10000,
                WaterBelGradeWall = 8,
                WaterproofElevatorPit = 4500
            });

            await db.SaveChangesAsync();
        }
    }
}
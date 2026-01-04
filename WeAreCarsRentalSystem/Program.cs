using System;

namespace WeAreCarsRentalSystem
{
    class Program
    {
        // Fixed staff credentials
        private const string VALID_USERNAME = "sta001";
        private const string VALID_PASSWORD = "givemethekeys123";

        // Pricing constants
        private const decimal DAILY_RENTAL_RATE = 25.00m;
        private const decimal FAMILY_CAR_SURCHARGE = 50.00m;
        private const decimal SPORTS_CAR_SURCHARGE = 75.00m;
        private const decimal SUV_SURCHARGE = 65.00m;
        private const decimal HYBRID_SURCHARGE = 30.00m;
        private const decimal ELECTRIC_SURCHARGE = 50.00m;
        private const decimal UNLIMITED_MILEAGE_DAILY = 10.00m;
        private const decimal BREAKDOWN_COVER_DAILY = 2.00m;

        static void Main(string[] args)
        {
            DisplayWelcomeScreen();

            if (!StaffLogin())
            {
                Console.WriteLine("\nAccess denied. Exiting application.");
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
                return;
            }

            ProcessBooking();

            Console.WriteLine("\nThank you for using WeAreCars Rental System!");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        static void DisplayWelcomeScreen()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("?????????????????????????????????????????????????????????");
            Console.WriteLine("?                                                       ?");
            Console.WriteLine("?           WEARECARE RENTAL SYSTEM                     ?");
            Console.WriteLine("?                                                       ?");
            Console.WriteLine("?           Welcome to WeAreCars!                       ?");
            Console.WriteLine("?                                                       ?");
            Console.WriteLine("?????????????????????????????????????????????????????????");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine("Instructions:");
            Console.WriteLine("  1. Staff must login with valid credentials");
            Console.WriteLine("  2. Enter customer details and rental preferences");
            Console.WriteLine("  3. Review and confirm the booking");
            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        static bool StaffLogin()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("??? STAFF LOGIN ???");
            Console.ResetColor();
            Console.WriteLine();

            Console.Write("Username: ");
            string? username = Console.ReadLine();

            Console.Write("Password: ");
            string? password = ReadPassword();
            Console.WriteLine();

            if (username == VALID_USERNAME && password == VALID_PASSWORD)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n? Login successful!");
                Console.ResetColor();
                System.Threading.Thread.Sleep(1000);
                return true;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n? Invalid username or password.");
                Console.ResetColor();
                return false;
            }
        }

        static string ReadPassword()
        {
            string password = "";
            ConsoleKeyInfo key;

            do
            {
                key = Console.ReadKey(true);

                if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                {
                    password += key.KeyChar;
                    Console.Write("*");
                }
                else if (key.Key == ConsoleKey.Backspace && password.Length > 0)
                {
                    password = password.Substring(0, password.Length - 1);
                    Console.Write("\b \b");
                }
            } while (key.Key != ConsoleKey.Enter);

            return password;
        }

        static void ProcessBooking()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("??? NEW BOOKING ???");
            Console.ResetColor();
            Console.WriteLine();

            // Customer details
            string firstName = GetValidStringInput("Customer First Name: ");
            string surname = GetValidStringInput("Customer Surname: ");
            string address = GetValidStringInput("Customer Address: ");
            
            int age = GetValidAge();
            if (age < 18)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n? Customer must be 18 or over to rent a vehicle.");
                Console.ResetColor();
                Console.WriteLine("Booking cancelled.");
                return;
            }

            bool hasValidLicence = GetValidLicence();
            if (!hasValidLicence)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n? A valid driving licence is required to rent a vehicle.");
                Console.ResetColor();
                Console.WriteLine("Booking cancelled.");
                return;
            }

            // Rental details
            int rentalDays = GetValidRentalDays();
            
            Console.WriteLine();
            Console.WriteLine("??? CAR TYPE SELECTION ???");
            Console.WriteLine("1. City car (+£0)");
            Console.WriteLine("2. Family car (+£50)");
            Console.WriteLine("3. Sports car (+£75)");
            Console.WriteLine("4. SUV (+£65)");
            int carTypeChoice = GetValidMenuChoice(1, 4, "Select car type (1-4): ");
            string carType = GetCarTypeName(carTypeChoice);
            decimal carTypeSurcharge = GetCarTypeSurcharge(carTypeChoice);

            Console.WriteLine();
            Console.WriteLine("??? FUEL TYPE SELECTION ???");
            Console.WriteLine("1. Petrol (+£0)");
            Console.WriteLine("2. Diesel (+£0)");
            Console.WriteLine("3. Hybrid (+£30)");
            Console.WriteLine("4. Electric (+£50)");
            int fuelTypeChoice = GetValidMenuChoice(1, 4, "Select fuel type (1-4): ");
            string fuelType = GetFuelTypeName(fuelTypeChoice);
            decimal fuelTypeSurcharge = GetFuelTypeSurcharge(fuelTypeChoice);

            Console.WriteLine();
            Console.WriteLine("??? OPTIONAL EXTRAS ???");
            bool unlimitedMileage = GetYesNoChoice($"Unlimited mileage (+£{UNLIMITED_MILEAGE_DAILY} per day)? (Y/N): ");
            bool breakdownCover = GetYesNoChoice($"Breakdown cover (+£{BREAKDOWN_COVER_DAILY} per day)? (Y/N): ");

            // Calculate total cost
            decimal baseCost = DAILY_RENTAL_RATE * rentalDays;
            decimal carCost = carTypeSurcharge;
            decimal fuelCost = fuelTypeSurcharge;
            decimal mileageCost = unlimitedMileage ? UNLIMITED_MILEAGE_DAILY * rentalDays : 0;
            decimal breakdownCost = breakdownCover ? BREAKDOWN_COVER_DAILY * rentalDays : 0;
            decimal totalCost = baseCost + carCost + fuelCost + mileageCost + breakdownCost;

            // Display summary
            DisplayBookingSummary(firstName, surname, address, age, rentalDays, carType, fuelType, 
                                  unlimitedMileage, breakdownCover, baseCost, carCost, fuelCost, 
                                  mileageCost, breakdownCost, totalCost);

            // Confirm booking
            Console.WriteLine();
            bool confirmBooking = GetYesNoChoice("Confirm booking? (Y/N): ");
            
            if (confirmBooking)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n? Booking confirmed successfully!");
                Console.ResetColor();
                Console.WriteLine($"Booking reference: BK{DateTime.Now:yyyyMMddHHmmss}");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nBooking cancelled by user.");
                Console.ResetColor();
            }
        }

        static string GetValidStringInput(string prompt)
        {
            string? input;
            do
            {
                Console.Write(prompt);
                input = Console.ReadLine()?.Trim();
                
                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("? This field cannot be empty. Please try again.");
                    Console.ResetColor();
                }
            } while (string.IsNullOrWhiteSpace(input));

            return input;
        }

        static int GetValidAge()
        {
            int age;
            do
            {
                Console.Write("Customer Age: ");
                string? input = Console.ReadLine();

                if (int.TryParse(input, out age) && age > 0 && age <= 120)
                {
                    return age;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("? Please enter a valid age (1-120).");
                    Console.ResetColor();
                }
            } while (true);
        }

        static bool GetValidLicence()
        {
            do
            {
                Console.Write("Valid driving licence? (Y/N): ");
                string? input = Console.ReadLine()?.Trim().ToUpper();

                if (input == "Y" || input == "YES")
                {
                    return true;
                }
                else if (input == "N" || input == "NO")
                {
                    return false;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("? Please enter Y for Yes or N for No.");
                    Console.ResetColor();
                }
            } while (true);
        }

        static int GetValidRentalDays()
        {
            int days;
            do
            {
                Console.Write("Number of rental days (1-28): ");
                string? input = Console.ReadLine();

                if (int.TryParse(input, out days) && days >= 1 && days <= 28)
                {
                    return days;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("? Please enter a number between 1 and 28.");
                    Console.ResetColor();
                }
            } while (true);
        }

        static int GetValidMenuChoice(int min, int max, string prompt)
        {
            int choice;
            do
            {
                Console.Write(prompt);
                string? input = Console.ReadLine();

                if (int.TryParse(input, out choice) && choice >= min && choice <= max)
                {
                    return choice;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"? Please enter a number between {min} and {max}.");
                    Console.ResetColor();
                }
            } while (true);
        }

        static bool GetYesNoChoice(string prompt)
        {
            do
            {
                Console.Write(prompt);
                string? input = Console.ReadLine()?.Trim().ToUpper();

                if (input == "Y" || input == "YES")
                {
                    return true;
                }
                else if (input == "N" || input == "NO")
                {
                    return false;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("? Please enter Y for Yes or N for No.");
                    Console.ResetColor();
                }
            } while (true);
        }

        static string GetCarTypeName(int choice)
        {
            return choice switch
            {
                1 => "City car",
                2 => "Family car",
                3 => "Sports car",
                4 => "SUV",
                _ => "Unknown"
            };
        }

        static decimal GetCarTypeSurcharge(int choice)
        {
            return choice switch
            {
                1 => 0,
                2 => FAMILY_CAR_SURCHARGE,
                3 => SPORTS_CAR_SURCHARGE,
                4 => SUV_SURCHARGE,
                _ => 0
            };
        }

        static string GetFuelTypeName(int choice)
        {
            return choice switch
            {
                1 => "Petrol",
                2 => "Diesel",
                3 => "Hybrid",
                4 => "Electric",
                _ => "Unknown"
            };
        }

        static decimal GetFuelTypeSurcharge(int choice)
        {
            return choice switch
            {
                1 => 0,
                2 => 0,
                3 => HYBRID_SURCHARGE,
                4 => ELECTRIC_SURCHARGE,
                _ => 0
            };
        }

        static void DisplayBookingSummary(string firstName, string surname, string address, int age, 
                                          int rentalDays, string carType, string fuelType, 
                                          bool unlimitedMileage, bool breakdownCover,
                                          decimal baseCost, decimal carCost, decimal fuelCost, 
                                          decimal mileageCost, decimal breakdownCost, decimal totalCost)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("?????????????????????????????????????????????????????????");
            Console.WriteLine("?               BOOKING SUMMARY                         ?");
            Console.WriteLine("?????????????????????????????????????????????????????????");
            Console.ResetColor();
            Console.WriteLine();

            Console.WriteLine("CUSTOMER DETAILS:");
            Console.WriteLine($"  Name:    {firstName} {surname}");
            Console.WriteLine($"  Address: {address}");
            Console.WriteLine($"  Age:     {age}");
            Console.WriteLine();

            Console.WriteLine("RENTAL DETAILS:");
            Console.WriteLine($"  Duration:  {rentalDays} day(s)");
            Console.WriteLine($"  Car Type:  {carType}");
            Console.WriteLine($"  Fuel Type: {fuelType}");
            Console.WriteLine();

            Console.WriteLine("OPTIONAL EXTRAS:");
            Console.WriteLine($"  Unlimited Mileage: {(unlimitedMileage ? "Yes" : "No")}");
            Console.WriteLine($"  Breakdown Cover:   {(breakdownCover ? "Yes" : "No")}");
            Console.WriteLine();

            Console.WriteLine("COST BREAKDOWN:");
            Console.WriteLine($"  Base rental ({rentalDays} days @ £{DAILY_RENTAL_RATE}/day): £{baseCost:F2}");
            
            if (carCost > 0)
                Console.WriteLine($"  Car type surcharge:                    £{carCost:F2}");
            
            if (fuelCost > 0)
                Console.WriteLine($"  Fuel type surcharge:                   £{fuelCost:F2}");
            
            if (mileageCost > 0)
                Console.WriteLine($"  Unlimited mileage ({rentalDays} days):         £{mileageCost:F2}");
            
            if (breakdownCost > 0)
                Console.WriteLine($"  Breakdown cover ({rentalDays} days):           £{breakdownCost:F2}");

            Console.WriteLine("  " + new string('-', 50));
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"  TOTAL COST:                            £{totalCost:F2}");
            Console.ResetColor();
        }
    }
}

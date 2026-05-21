using System;

namespace GalacticCargoScanner
{
    class CargoItem
    {
        public string CargoId { get; set; }
        public double CargoWeight { get; set; }
        public string CargoType { get; set; }
        public double InspectionFee { get; set; }
        public bool IsApproved { get; set; }
    }

    class Program
    {
        static void PrintCargoReport(CargoItem cargo)
        {
            Console.WriteLine("\n=== CARGO INSPECTION REPORT ===");
            Console.WriteLine($"Cargo ID: {cargo.CargoId}");
            Console.WriteLine($"Cargo Weight: {cargo.CargoWeight} tons");
            Console.WriteLine($"Cargo Type: {cargo.CargoType}");
            Console.WriteLine($"Base Inspection Fee: {cargo.InspectionFee:C}");
            Console.WriteLine($"Status: {(cargo.IsApproved ? "Approved" : "REJECTED/SEIZED")}");
            Console.WriteLine("================================");
        }

        static void Main(string[] args)
        {
            Console.WriteLine("\n\n=== GALACTIC CARGO SCANNER v1.0 ===");
            Console.WriteLine("Initializing security protocols...");

            bool keepRunning = true; 

            while (keepRunning)
            {
                CargoItem cargo = new CargoItem();
                Console.Write("Enter Cargo ID (e.g., CRG-101): ");
                cargo.CargoId = Console.ReadLine();
                Console.WriteLine();
                Console.WriteLine("Enter Cargo Weight (In Tons): ");
                string weight = Console.ReadLine();
                cargo.CargoWeight = Convert.ToDouble(weight);


                Console.WriteLine("\nSelect Cargo Type:");
                Console.WriteLine("1. Minerals (Safe)");
                Console.WriteLine("2. Bio-Matter (Requires Review)");
                Console.WriteLine("3. Kyber Crystals (Restricted)");
                Console.Write("Enter choice (1-3): ");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        cargo.CargoType = "Minerals";
                        break;
                    case "2":
                        cargo.CargoType = "Bio-Matter";
                        break;
                    case "3":
                        cargo.CargoType = "Kyber Crystals";
                        break;
                    default:
                        cargo.CargoType = "Unknown/Contraband";
                        break;
                }

                if (cargo.CargoType == "Minerals")
                {
                    cargo.InspectionFee = cargo.CargoWeight * 100.00;
                    cargo.IsApproved = true;
                }
                else if (cargo.CargoType == "Bio-Matter")
                {
                    cargo.InspectionFee = cargo.CargoWeight * 250.00;
                    cargo.IsApproved = true;
                }
                else
                {
                    cargo.InspectionFee = cargo.CargoWeight * 500.00;
                    cargo.IsApproved = false;
                }



                PrintCargoReport(cargo);
                Console.WriteLine("\nWould you like to scan another Cargo Item? (y/n)");
                string userResponse = Console.ReadLine().ToLower();
                if (userResponse != "y")
                {
                  keepRunning = false;
                }
               
            }

            Console.WriteLine("Exiting system. Safe travels through the stars!");

        }
    }
}
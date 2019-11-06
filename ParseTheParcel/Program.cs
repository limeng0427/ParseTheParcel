using TradeMe.ParseTheParcel.Data.Models;
using TradeMe.ParseTheParcel.Business;
using System;
using TradeMe.ParseTheParcel.Data.DataAccess;

namespace ParseTheParcel
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to use Parse the Parcel Service.");
            Console.WriteLine("Please provide the required dimension parameters and weight, we will find the right package and price for you.");

            while (true)
            {
                double[] dimension = new double[3];
                Console.WriteLine("Please Input Height (unit:mm):");

                if(!double.TryParse(Console.ReadLine(), out dimension[0]))
                {
                    Console.WriteLine($"Invalid Height Value, Please start over");
                    continue;
                }
                Console.WriteLine("Please Input Width (unit:mm):");
                if (!double.TryParse(Console.ReadLine(), out dimension[1]))
                {
                    Console.WriteLine($"Invalid Width Value, Please start over");
                    continue;
                }
                Console.WriteLine("Please Input Breadth (unit:mm):");
                if (!double.TryParse(Console.ReadLine(), out dimension[2]))
                {
                    Console.WriteLine($"Invalid Breadth Value, Please start over");
                    continue;
                }
                Console.WriteLine("Please Input Weight (unit:kg):");
                double weight = 0;
                if (!double.TryParse(Console.ReadLine(), out weight))
                {
                    Console.WriteLine($"Invalid Weight Value, Please start over");
                    continue;
                }

               
                Parcel parcel = new Parcel(dimension, weight);

                if (!parcel.ValidateParcel())
                {
                    Console.WriteLine("Parameter cannot be zero. Please try again.");
                    continue;
                }
                IRepository _ds = null;
                PackageTypeRetrivingMethod retrivingMethod = PackageTypeRetrivingMethod.FromCode;
                switch (retrivingMethod)
                {
                    case PackageTypeRetrivingMethod.FromCode:
                        _ds = new PackageListFromCodeDataSource();
                        break;
                    case PackageTypeRetrivingMethod.FromDatabase:
                        _ds = new PackageListFromDatabaseDataSource();
                        break;
                    case PackageTypeRetrivingMethod.FromJsonFile:
                        _ds = new PackageListFromJsonFileDataSource();
                        break;
                }
                var packageController = new PackageController(_ds);

                var package = packageController.MatchParcelPackage(parcel);

                if (package == null)
                {
                    Console.WriteLine($"Oversize / overweight parcel, please reduce the size or weight.");
                }
                else
                {
                    parcel.Package = package;
                    Console.WriteLine($"Parcel Packaged with {parcel.Package.PackageTypeName}, Price: ${parcel.PackagePrice}");
                }
                Console.WriteLine("");
            }
        }
    }
}

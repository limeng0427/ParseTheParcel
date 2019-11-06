using System;
using System.Collections.Generic;
using System.Text;
using TradeMe.ParseTheParcel.Data.Models;

namespace TradeMe.ParseTheParcel.Data.DataAccess
{
    public class PackageListFromCodeDataSource : IRepository
    {
        public ICollection<Package> ListPackage()
        {
            ICollection<Package> packages = new List<Package>();
            packages.Add(new Package(150, 200, 300, 25, 5M, "Small"));
            packages.Add(new Package(200, 300, 400, 25, 7.5M, "Medium"));
            packages.Add(new Package(250, 400, 600, 25, 8.5M, "Large"));
            return packages;
        }
    }

    public class PackageListFromDatabaseDataSource : IRepository
    {
        public ICollection<Package> ListPackage()
        {
            throw new NotImplementedException("Use Entity Framework to retrieve Package Type Information");
        }
    }

    public class PackageListFromJsonFileDataSource : IRepository
    {
        public ICollection<Package> ListPackage()
        {
            throw new NotImplementedException("Use JSON Reader to retrieve Package Type Information");
        }
    }
}

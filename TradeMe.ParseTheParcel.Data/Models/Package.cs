using System;
using System.Collections.Generic;
using System.Text;

namespace TradeMe.ParseTheParcel.Data.Models
{
    public enum PackageType
    {
        Small = 1,
        Medium = 2,
        Large = 3,
    }


    public class Package: IPackage
    {
        #region Properties
        public PackageType PackageType { get; set; }
        public string PackageTypeName { get; set; }
        public double MaxHeight { get; set; }
        public double MaxLength { get; set; }
        public double MaxBreadth { get; set; }

        public double MaxWeight { get; set; }
        public decimal Price { get; set; }
        #endregion

        #region Method
        public Package(double maxHeight, double maxLength, double maxBreadth, double maxWeight, decimal price, string packageTypeName)
        {
            MaxHeight = maxHeight;
            MaxLength = maxLength;
            MaxBreadth = maxBreadth;
            MaxWeight = maxWeight;
            Price = price;
            PackageTypeName = packageTypeName;
            bool ignoreCase = true;
            Enum.TryParse<PackageType>(packageTypeName, ignoreCase, out PackageType PackageType);
        }
        #endregion
    }

}

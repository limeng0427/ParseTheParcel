using System;
using System.Collections.Generic;
using System.Text;

namespace TradeMe.ParseTheParcel.Data.Models
{
    public interface IPackage
    {
        #region Properties
        PackageType PackageType { get; set; }
        string PackageTypeName { get; set; }
        double MaxHeight { get; set; }
        double MaxLength { get; set; }
        double MaxBreadth { get; set; }

        double MaxWeight { get; set; }
        decimal Price { get; set; }
        #endregion

        #region Method
        #endregion
    }
}

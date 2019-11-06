using System;
using System.Collections.Generic;
using System.Linq;
using TradeMe.ParseTheParcel.Data.DataAccess;
using TradeMe.ParseTheParcel.Data.Models;
using TradeMe.ParseTheParcel.Utilities;

namespace TradeMe.ParseTheParcel.Business
{
    public enum PackageTypeRetrivingMethod
    {
        FromCode,
        FromDatabase,
        FromJsonFile
    }
    public class PackageController
    {
        IRepository repository;
        public PackageController(IRepository repository)
        {
            this.repository = repository;
        }
        public ICollection<Package> ListPackage()
        {
            return this.repository.ListPackage();
        }

        public IPackage MatchParcelPackage(IParcel parcel)
        {
            IPackage targetPackage = null;
            foreach (var p in ListPackage().OrderBy(l => l.Price))
            {
                if (IsPackageFitParcel(p, parcel))
                {
                    targetPackage = p;
                    break;
                }
            }
            if(targetPackage == null)
            {
                new LogManager().Log($"MatchParcelPackage(). Unable to find a matching package for parcel({parcel.Length}*{parcel.Height}*{parcel.Breadth} {parcel.Weight}kg)");
            }
            else
            {
                new LogManager().Log($"MatchParcelPackage(). Package {targetPackage.PackageTypeName}(${targetPackage.Price}) is used for parcel({parcel.Length}*{parcel.Height}*{parcel.Breadth} {parcel.Weight}kg)");
            }
            return targetPackage;
        }

        public bool IsPackageFitParcel(IPackage package, IParcel parcel)
        {
            if (!parcel.ValidateParcel())
                return false;
            return parcel.Height <= package.MaxHeight && parcel.Length <= package.MaxLength && parcel.Breadth <= package.MaxBreadth && parcel.Weight <= package.MaxWeight;
        }
    }
}

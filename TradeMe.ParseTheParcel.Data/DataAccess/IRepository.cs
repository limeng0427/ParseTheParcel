using System;
using System.Collections.Generic;
using System.Text;
using TradeMe.ParseTheParcel.Data.Models;

namespace TradeMe.ParseTheParcel.Data.DataAccess
{
    public interface IRepository
    {
        ICollection<Package> ListPackage();
    }
}

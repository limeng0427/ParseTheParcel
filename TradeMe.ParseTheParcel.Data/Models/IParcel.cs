using System;
using System.Collections.Generic;
using System.Text;

namespace TradeMe.ParseTheParcel.Data.Models
{
    public interface IParcel
    {
        #region Properties
        double Height { get; set; }
        double Length { get; set; }
        double Breadth { get; set; }
        double Weight { get; set; }
        ParcelStatus ParcelStatus { get; set; }
        public bool ValidateParcel();
        public bool Update();
        public bool Delete();
        public bool Archive();
        #endregion

        #region Method
        #endregion
    }
}

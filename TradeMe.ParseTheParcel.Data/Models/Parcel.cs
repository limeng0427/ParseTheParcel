using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace TradeMe.ParseTheParcel.Data.Models
{
    public class Parcel: IParcel
    {

        #region Properties
        public double Height { get; set; }
        public double Length { get; set; }
        public double Breadth { get; set; }
        public double Weight { get; set; }
        public ParcelStatus ParcelStatus { get; set; } = ParcelStatus.Pending;



        public IPackage Package { get; set; }
        #endregion

        #region Method
        public decimal PackagePrice
        {
            get
            {
                return Package == null ? 0 : Package.Price;
            }
            private set
            {
            }
        }

        public Parcel( double[] dimentions, double weight)
        {
            dimentions = dimentions.OrderBy(l=>l).ToArray();
            Height = dimentions[0];
            Length = dimentions[1];
            Breadth = dimentions[2];
            Weight = weight;
        }

        public bool Update()
        {
            throw new NotImplementedException();
        }

        public bool Delete()
        {
            throw new NotImplementedException();
        }

        public bool Archive()
        {
            throw new NotImplementedException();
        }

        public bool ValidateParcel()
        {
            return Height > 0 && Length > 0 && Breadth > 0 && Weight > 0;
        }
        #endregion
    }
}

using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using TradeMe.ParseTheParcel.Data.DataAccess;
using TradeMe.ParseTheParcel.Data.Models;
using TradeMe.ParseTheParcel.Business;
using Xunit;

namespace TradeMe.ParseTheParcel.Tests
{
    public class PackageControllerTest
    {
        #region MatchParcelPackage
        [Fact]
        public void MatchParcelPackage_NormalParameters_ReturnRightPackage()
        {
            // range
            ICollection<Package> packages = new List<Package>();
            packages.Add(new Package(150, 200, 300, 25, 5M, "Small"));
            packages.Add(new Package(200, 300, 400, 25, 7.5M, "Medium"));
            packages.Add(new Package(250, 400, 600, 25, 8.5M, "Large"));
            var repository = new Mock<IRepository>();
            repository
                .Setup(m => m.ListPackage())
                .Returns(packages); ;

            var controller = new PackageController(repository.Object);
            double[] dimension = { 100, 150, 200 };
            double weight = 20;
            Parcel parcel = new Parcel(dimension, weight);
            // act
            IPackage package = controller.MatchParcelPackage(parcel);
            // assert
            Assert.Equal("Small", package.PackageTypeName);
            Assert.Equal(5M, package.Price);
        }

        [Fact]
        public void MatchParcelPackage_NormalParametersWithWrongOrder_ReturnRightPackage()
        {
            // range
            ICollection<Package> packages = new List<Package>();
            packages.Add(new Package(150, 200, 300, 25, 5M, "Small"));
            packages.Add(new Package(200, 300, 400, 25, 7.5M, "Medium"));
            packages.Add(new Package(250, 400, 600, 25, 8.5M, "Large"));
            var repository = new Mock<IRepository>();
            repository
                .Setup(m => m.ListPackage())
                .Returns(packages); ;

            var controller = new PackageController(repository.Object);
            double[] dimension = { 500, 300, 250 };
            double weight = 20D;
            Parcel parcel = new Parcel(dimension, weight);
            // act
            IPackage package = controller.MatchParcelPackage(parcel);
            // assert
            Assert.Equal("Large", package.PackageTypeName);
            Assert.Equal(8.5M, package.Price);
        }

        [Fact]
        public void MatchParcelPackage_BoundaryParameters_ReturnRightPackage()
        {
            // range
            ICollection<Package> packages = new List<Package>();
            packages.Add(new Package(150, 200, 300, 25, 5M, "Small"));
            packages.Add(new Package(200, 300, 400, 25, 7.5M, "Medium"));
            packages.Add(new Package(250, 400, 600, 25, 8.5M, "Large"));
            var repository = new Mock<IRepository>();
            repository
                .Setup(m => m.ListPackage())
                .Returns(packages); ;

            var controller = new PackageController(repository.Object);
            double[] dimension = { 200, 300, 400 };
            double weight = 25D;
            Parcel parcel = new Parcel(dimension, weight);
            // act
            IPackage package = controller.MatchParcelPackage(parcel);
            // assert
            Assert.Equal("Medium", package.PackageTypeName);
            Assert.Equal(7.5M, package.Price);
        }

        [Fact]
        public void MatchParcelPackage_ZeroParameters_ReturnNull()
        {
            // range
            ICollection<Package> packages = new List<Package>();
            packages.Add(new Package(150, 200, 300, 25, 5M, "Small"));
            packages.Add(new Package(200, 300, 400, 25, 7.5M, "Medium"));
            packages.Add(new Package(250, 400, 600, 25, 8.5M, "Large"));
            var repository = new Mock<IRepository>();
            repository
                .Setup(m => m.ListPackage())
                .Returns(packages); ;

            var controller = new PackageController(repository.Object);
            double[] dimension = { 0, 300, 400 };
            double weight = 25D;
            Parcel parcel = new Parcel(dimension, weight);
            // act
            IPackage package = controller.MatchParcelPackage(parcel);
            // assert
            Assert.Null(package);
        }
        [Fact]
        public void MatchParcelPackage_OverSizeParameters_ReturnNull()
        {
            // range
            ICollection<Package> packages = new List<Package>();
            packages.Add(new Package(150, 200, 300, 25, 5M, "Small"));
            packages.Add(new Package(200, 300, 400, 25, 7.5M, "Medium"));
            packages.Add(new Package(250, 400, 600, 25, 8.5M, "Large"));
            var repository = new Mock<IRepository>();
            repository
                .Setup(m => m.ListPackage())
                .Returns(packages); ;

            var controller = new PackageController(repository.Object);
            double[] dimension = { 250, 900, 1100 };
            double weight = 25D;
            Parcel parcel = new Parcel(dimension, weight);
            // act
            IPackage package = controller.MatchParcelPackage(parcel);
            // assert
            Assert.Null(package);
        }

        [Fact]
        public void MatchParcelPackage_OverWeightParameters_ReturnNull()
        {
            // range
            ICollection<Package> packages = new List<Package>();
            packages.Add(new Package(150, 200, 300, 25, 5M, "Small"));
            packages.Add(new Package(200, 300, 400, 25, 7.5M, "Medium"));
            packages.Add(new Package(250, 400, 600, 25, 8.5M, "Large"));
            var repository = new Mock<IRepository>();
            repository
                .Setup(m => m.ListPackage())
                .Returns(packages); ;

            var controller = new PackageController(repository.Object);
            double[] dimension = { 250, 900, 1100 };
            double weight = 50D;
            Parcel parcel = new Parcel(dimension, weight);
            // act
            IPackage package = controller.MatchParcelPackage(parcel);
            // assert
            Assert.Null(package);
        }

        #endregion

        #region IsPackageFitParcel
        
        [Fact]
        public void IsPackageFitParcel_NormalParameters_ReturnTrue()
        {
            // range
            ICollection<Package> packages = new List<Package>();
            var repository = new Mock<IRepository>();
            var controller = new PackageController(repository.Object);
            double[] dimension = { 100, 150, 200 };
            double weight = 20;
            IParcel parcel = new Parcel(dimension, weight);
            IPackage package = new Package(150, 200, 300, 25, 5M, "Small");
            // act
            bool isFit = controller.IsPackageFitParcel(package, parcel);
            // assert
            Assert.True(isFit);
        }

        [Fact]
        public void IsPackageFitParcel_NormalParametersWithWrongOrder_ReturnTrue()
        {
            // range
            ICollection<Package> packages = new List<Package>();
            var repository = new Mock<IRepository>();
            var controller = new PackageController(repository.Object);
            double[] dimension = { 500, 300, 250 };
            double weight = 20D;
            IParcel parcel = new Parcel(dimension, weight);
            IPackage package = new Package(250, 400, 600, 25, 8.5M, "Large");
            // act
            bool isFit = controller.IsPackageFitParcel(package, parcel);
            // assert
            Assert.True(isFit);
        }

        [Fact]
        public void IsPackageFitParcel_BoundaryParameters_ReturnTrue()
        {
            // range
            ICollection<Package> packages = new List<Package>();
            var repository = new Mock<IRepository>();
            var controller = new PackageController(repository.Object);
            double[] dimension = { 200, 300, 400 };
            double weight = 20D;
            IParcel parcel = new Parcel(dimension, weight);
            IPackage package = new Package(200, 300, 400, 25, 7.5M, "Medium");
            // act
            bool isFit = controller.IsPackageFitParcel(package, parcel);
            // assert
            Assert.True(isFit);
        }

        [Fact]
        public void IsPackageFitParcel_ZeroParameters_ReturnFalse()
        {
            // range
            ICollection<Package> packages = new List<Package>();
            var repository = new Mock<IRepository>();
            var controller = new PackageController(repository.Object);
            double[] dimension = { 0, 50, 100 };
            double weight = 20D;
            IParcel parcel = new Parcel(dimension, weight);
            IPackage package = new Package(250, 400, 600, 25, 8.5M, "Large");
            // act
            bool isFit = controller.IsPackageFitParcel(package, parcel);
            // assert
            Assert.False(isFit);
        }
        [Fact]
        public void IsPackageFitParcel_OverSizeParameters_ReturnFalse()
        {
            // range
            ICollection<Package> packages = new List<Package>();
            var repository = new Mock<IRepository>();
            var controller = new PackageController(repository.Object);
            double[] dimension = { 500, 600, 700 };
            double weight = 20D;
            IParcel parcel = new Parcel(dimension, weight);
            IPackage package = new Package(250, 400, 600, 25, 8.5M, "Large");
            // act
            bool isFit = controller.IsPackageFitParcel(package, parcel);
            // assert
            Assert.False(isFit);
        }
        [Fact]
        public void IsPackageFitParcel_OverWeightParameters_ReturnFalse()
        {
            // range
            ICollection<Package> packages = new List<Package>();
            var repository = new Mock<IRepository>();
            var controller = new PackageController(repository.Object);
            double[] dimension = { 240, 390, 590 };
            double weight = 30D;
            IParcel parcel = new Parcel(dimension, weight);
            IPackage package = new Package(250, 400, 600, 25, 8.5M, "Large");
            // act
            bool isFit = controller.IsPackageFitParcel(package, parcel);
            // assert
            Assert.False(isFit);
        }

        #endregion
    }
}

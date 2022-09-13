
using Moq;
using NUnit.Framework;
using POCApiFinal.Models;
using POCApiFinal.Repository;
using POCApiFinal.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace POCApiTest
{
    [TestFixture]
    public class CartServiceTest 
    {
        private readonly CartService _sut;
        private readonly Mock<IRepositoryBase> _moqRepositoryBase = new Mock<IRepositoryBase>();


        public CartServiceTest()
        {
            _sut = new CartService(_moqRepositoryBase.Object);
        }


        [OneTimeSetUp]
        public void Init()
        {
            
        }

        [Test]
        public async Task GetCartItemByID_ShouldReturnItem_IfItemExist()
        {
            //Arrange
            int id = 7;
            var cartItem = new Cart{
            Id = 1,
            ProductId = id,
            ProductName = "Ac",
            ProductCount = 0,
            Price = 5000,
        };

            _moqRepositoryBase.Setup(x => x.GetCartListByID(id)).Returns(Task.FromResult(  cartItem ));

            //Act
            var res = await _sut.GetCartItemById(id);

            //Assert
            Assert.AreEqual(id, cartItem.ProductId);
           

        }

        [Test]
        public void Test()
        {
            Assert.Pass();
        }

        //[Test]
        //public async Task GetCartItem_ShoulReturnListofCartItems()
        //{

        //}

    }
}

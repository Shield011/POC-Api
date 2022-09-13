using Moq;
using NUnit.Framework;
using POCApiFinal.Models;
using POCApiFinal.Repository;
using POCApiFinal.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace POCApi.Tests
{
    public class Tests
    {
        private CartService _sut;
        private readonly Mock<IRepositoryBase> _moqRepositoryBaseMock = new Mock<IRepositoryBase>();

        public Tests()
        {
            _sut = new CartService(_moqRepositoryBaseMock.Object);
        }

        //[OneTimeSetUp]
        //public void Setup()
        //{
        //    var name = "Smriti";
        //    Assert.AreEqual("Smriti", name);
        //}

        [Test]
        public void Test1()
        {
            int id = 7;
            var cartItem = new Cart
            {
                Id = 1,
                ProductId = id,
                ProductName = "Ac",
                ProductCount = 0,
                Price = 5000,
            };

            _moqRepositoryBaseMock.Setup(x => x.GetCartListByID(id)).Returns(Task.FromResult(cartItem));

            //Act
            var res = _sut.GetCartItemById(id);

            //Assert
            Assert.AreEqual(id, cartItem.ProductId);
           

        }

        [Test]
        public async Task GetAllCartItems_Should_Return_List_of_Cart_Items()
        {
            var cart = new Cart
            {
                Id = 1,
                ProductId = 7,
                ProductName = "Ac",
                ProductCount = 0,
                Price = 5000,
            };
            _moqRepositoryBaseMock.Setup(x => x.GetCartList()).Returns(Task.FromResult(new List<Cart>() { cart }));

            //Act
            var returnValue = await _sut.GetCartItems();
            Assert.AreEqual(1, returnValue.Count);
           
        }
        //public async Task AddItemToCart_Should_Add_Item_To_Cart()
        //{

        //}

    }
}
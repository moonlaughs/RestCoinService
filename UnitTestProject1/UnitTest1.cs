using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestCoinService.Controllers;
using RestCoinService.Model;
using System.Collections.Generic;
using System.Linq;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        private readonly BidsController _controller = new BidsController();

        [TestInitialize]
        public void Init()
        {
            _controller.ReInitialize();
        }

        [TestMethod]
        public void TestGet()
        {
            IEnumerable<Bid> bids = _controller.Get();
            Assert.AreEqual(4, bids.Count());

            Bid bid = _controller.Get(1);
            Assert.AreEqual("Mike", bid.Name);

            bid = _controller.Get(100);
            Assert.IsNull(bid);
        }

        [TestMethod]
        public void TestDelete()
        {
            _controller.Delete(1);
            Assert.AreEqual(3, _controller.Get().Count());

            _controller.Delete(100);
            Assert.AreEqual(3, _controller.Get().Count());
        }

        [TestMethod]
        public void TestPost()
        {
            Bid newBid = new Bid
            {
                Item = "item",
                Price = 24,
                Name = "Patryk"
            };
            _controller.Post(newBid);
            Assert.AreEqual(5, newBid.Id);
        }

        [TestMethod]
        public void TestPut()
        {
            Bid newBid = new Bid
            {
                Item = "itemupdateTest",
                Price = 24,
                Name = "Patryk"
            };
            Bid bid = _controller.Put(4, newBid);
            Assert.AreEqual("itemupdateTest", bid.Item);

            Bid b5 = _controller.Get(4);
            Assert.AreEqual("itemupdateTest", b5.Item);

            Bid b = _controller.Put(100, newBid);
            Assert.IsNull(b);
        }
    }
}

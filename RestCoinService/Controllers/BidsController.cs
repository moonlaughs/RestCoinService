using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestCoinService.Model;

namespace RestCoinService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BidsController : ControllerBase
    {
        static readonly HttpClient Client = new HttpClient();
        private static string _uri = "http://localhost:58162/api/bids";
        private static List<Bid> listOfBids;
        private static int _nextId;

        static BidsController()
        {
            Initialize();
        }

        public void ReInitialize()
        {
            Initialize();
        }

        private static void Initialize()
        {
            listOfBids = new List<Bid>();
            Bid b1 = new Bid(1, "Gold DK 1640", 2500, "Mike");
            Bid b2 = new Bid(2, "Gold NL 1764", 5000, "Anbo");
            Bid b3 = new Bid(3, "Gold FR1644", 35000, "Hammer");
            Bid b4 = new Bid(4, "Silver GR 333", 2500, "Mike");
            listOfBids.Add(b1);
            listOfBids.Add(b2);
            listOfBids.Add(b3);
            listOfBids.Add(b4);
            _nextId = 5;
        }

        

        // GET: api/Bids
        [HttpGet]
        public IEnumerable<Bid> Get()
        {
            return listOfBids;
        }

        // GET: api/Bids/5
        [HttpGet("{id}", Name = "Get")]
        public Bid Get(int id)
        {
            Bid obj = listOfBids.Find(b => b.Id == id);
            return obj;
        }

        // POST: api/Bids
        [HttpPost]
        public void Post([FromBody] Bid newBid)
        {
            newBid.Id = _nextId;
            _nextId++;
            listOfBids.Add(newBid);
        }

        // PUT: api/Bids/5
        [HttpPut("{id}")]
        public Bid Put(int id, [FromBody] Bid value)
        {
            Bid b = listOfBids.FirstOrDefault(bid => bid.Id == id);
            if (b == null) return null;
            b.Item = value.Item;
            b.Price = value.Price;
            b.Name = value.Name;
            return b;
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Bid obj = listOfBids.Find(b => b.Id == id);
            listOfBids.Remove(obj);
        }

        //[HttpDelete("{id}")]
        //public int Delete(int id)
        //{
        //    int howMany = _students.RemoveAll(student => student.Id == id);
        //    return howMany;
        //}
    }
}

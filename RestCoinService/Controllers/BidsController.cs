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

        private static List<Bid> listOfBids = new List<Bid>()
        {
            new Bid(1, "Gold DK 1640", 2500, "Mike"),
            new Bid(2, "Gold NL 1764", 5000, "Anbo"),
            new Bid(3, "Gold FR1644", 35000, "Hammer"),
            new Bid(4, "Silver GR 333", 2500, "Mike")
        };

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
            listOfBids.Add(newBid);
        }

        // PUT: api/Bids/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Bid obj = listOfBids.Find(b => b.Id == id);
            listOfBids.Remove(obj);
        }
    }
}

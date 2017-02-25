using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HelloMeow.Controllers
{
    [Route("api/[controller]")]
    public class CatsController : Controller
    {
        public static List<string> _Data;

        static CatsController()
        {
            _Data = new List<string>();
        }

        [HttpGet("add/{cat}")]
        public string Add_Cat(string cat)
        {
            if (_Data.Contains(cat))
            {
                return "Cat already exists.";
            }

            _Data.Add(cat);

            return "Cat added to horde.";
        }

        [HttpGet("remove/{cat}")]
        public string Remove_Cat(string cat)
        {
            if (!_Data.Contains(cat))
            {
                return "Cat does not exist.";
            }

            _Data.Remove(cat);

            return "Cat has been removed.";
        }

        [HttpGet]
        public string List_Cats()
        {
            return String.Join("\n", _Data.ToArray());
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

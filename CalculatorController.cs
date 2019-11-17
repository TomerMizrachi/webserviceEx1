///Tomer mizrachi 200542561
///excercises 2,6,12,16,17

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace OnlineCalculator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        // GET api/calculator
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/calculator/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }
       
        ///GET api/calculator/GetFiveRandomNumbers
        [HttpGet("GetFiveRandomNumbers")]

        public List<int> GetFiveRandomNumbers()

        {
            var numbers = new List<int>();

            var rnd = new Random();

            int count = 0;

            while (count < 5)
            {

                int newNum = rnd.Next(1, 21); // generate a random number between 1- 20

                if (!numbers.Contains(newNum))
                {

                    numbers.Add(newNum);

                    count++;

                }

            }

            return numbers;

        }
        //ex2
        // GET api/calculator/SwapTheString

        [HttpGet("SwapTheString")]

        public string SwapTheString(string sentence)

        {
            if (sentence != null) 
            {
                string[] results = sentence.Split(' ');
                //
                // Concatenate all the elements into a StringBuilder.
                //
                StringBuilder strinbuilder = new StringBuilder();
                for(int i = results.Length -1; i >= 0 ; i--)
                {
                    strinbuilder.Append(results[i]);
                    strinbuilder.Append(' ');
                }
                return strinbuilder.ToString();
            }
            return "there is no string value sent from url";
        }
        //ex6
        // GET api/calculator/Recurings

        [HttpGet("Recurings")]

        public int Recurings(string sentence)

        {
            int count = 0;
            int max = 1;
            if (sentence != null)
            {
                string[] results = sentence.Split(' ');
                for(int i = 0; i < results.Length - 1; i++)
                {
                    count = 0;
                    for(int j = 0; j < results.Length; j++)
                    {
                        if (results[i].Equals(results[j]))
                            count++;
                    }
                    if (count > max)
                        max = count;
                }
                return max;
            }
            return 0;
        }
        //ex12
        // GET api/calculator/Cutcut

        [HttpGet("Cutcut")]

        public string Cutcut(string sentence)
        {
            if (sentence != null)
            {
                string results = "";
                for(int i = 1; i < sentence.Length-1;i++)
                {
                    results += sentence[i]; 
                }

                return results;
            }
            return "there is no string value sent from url";
        }
        //ex16
        // GET api/calculator/MinNum

        [HttpGet("MinNum")]

        public string MinNum(int num1, int num2, int num3, int num4)
        {
            int min = Math.Min(num1, Math.Min(num2, Math.Min(num3,num4)));
            return min.ToString();  
        }

        //ex17
        // GET api/calculator/AddIntoStr
        [HttpGet("AddIntoStr")]
        public String AddIntoStr(int num, String str)
        {
            if (num < 0 || num > str.Length)
            {
                return "unvalid number";
            }
            return str.Insert(num, num.ToString());
        }

        // POST api/calculator
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }
        // PUT api/calculator/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/calculator/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

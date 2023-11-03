using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplicationPractice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class GetController : ControllerBase
    {

        //1. 參數放入路徑，單個參數 ->From Route (參數會是required)
        //https://localhost:7275/api/Get/route/joan
        [HttpGet("route/{name}")]
        public string GetRoute([FromRoute] string name)
        {
            return name;
        }

        //2. 參數放入路徑，多個參數 -> From Route (參數會是required)
        //https://localhost:7275/api/Get/joan/27
        [HttpGet("route/{name}/{age}")]
        public string GetMultiRoute([FromRoute] string name, [FromRoute] int age)
        {
            return string.Format("name:{0}, age:{1}", name, age);
        }

        //3. 用問號? key value去帶入參數 -> From Query
        //https://localhost:7275/api/Get?name=joan&age=27
        [HttpGet("query")]
        public string GetQuery([FromQuery] string name, [FromQuery] int age)
        {
            return string.Format("name:{0}, age:{1}", name, age);
        }

        //4. 從header去帶入參數
        //'https://localhost:7275/api/Get/header'
        //'accept: text/plain'
        //'name: joan'
        //'age: 28'
         [HttpGet("header")]
        public string GetHeader([FromHeader] string name, [FromHeader] int age)
        {
            return string.Format("name:{0}, age:{1}", name, age);
        }

        //5. Query + Route + Header
        //https://localhost:7275/api/Get/all/joan/27?name2=herry&age2=23
        //'name3: joyce'
        //'age3: 30'
        [HttpGet("all/{name}/{age}")]
        public string GetAll(
            [FromRoute] string name, [FromRoute] int age,
            [FromQuery] string name2, [FromQuery] int age2,
            [FromHeader] string name3, [FromHeader] int age3
            )
        {
            string route= string.Format("name:{0}, age:{1}", name, age);
            string query= string.Format("name:{0}, age:{1}", name2, age2);
            string header= string.Format("name:{0}, age:{1}", name3, age3);

            return string.Format("{0}\n {1}\n {2}", route, query, header);
        }


    }
}

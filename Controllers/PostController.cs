using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Nodes;
using WebApplicationPractice.Models;


namespace WebApplicationPractice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {

        //1. FromForm => key+value format
        [HttpPost("form")]
        public Student post1([FromForm] Student student)
        {
            string name = student.name;
            int age=student.age;

            Student newStudent = new Student();
            newStudent.name = name + "_server";
            newStudent.age = age+20;
            return newStudent;
        }

        //2. FromBody => json format
        [HttpPost("class")]
        public Student post2([FromBody] Student student)
        {
            string name = student.name;
            int age = student.age;

            Student newStudent = new Student();
            newStudent.name = name + "_server";
            newStudent.age = age+13;
            return newStudent;
        }
        
        //3. Return format change from "Student" to "IActionResult: Ok"
        [HttpPost("iAction")]
        public IActionResult post3([FromBody] Student student)
        {
            string name = student.name;
            int age = student.age;

            Student newStudent = new Student();
            newStudent.name = name + "_server";
            newStudent.age = age + 13;  
            return Ok(newStudent);

            //Ok ->Code: 200
            //BadRequest ->Code:400
            
        }

        //4. IActionResult(BadRequest, Ok),  try-catch
        [HttpPost("iAction2")]
        public IActionResult post4([FromBody] Student student)
        {
           
            try
            {
                string name = student.name;
                int age = student.age;
                if (age < 18) throw new Exception("not adult yet");
               
                    Student newStudent = new Student();
                    newStudent.name = name + "_server";
                    newStudent.age = age + 10;
                    return Ok(newStudent);
                
            } catch (Exception e)
            {
                return BadRequest(e.Message); //if age<18, it will catch "not adult yet"
            }
        }

        //5. JsonObject
        [HttpPost("iAction3")]
        public IActionResult post5([FromBody] JsonObject obj)
        {
            try
            {
                string name = obj.ContainsKey("name") ? obj["name"].GetValue<string>() : null;
                int age = obj.ContainsKey("age") ? obj["age"].GetValue<int>() : 0;

                Student newStudent = new Student();
                newStudent.name = name + "_server";
                newStudent.age = age + 10;
                return Ok(newStudent);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
          
        }
    }

}

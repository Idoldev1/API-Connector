using System;
using System.Text;
using API_Consumation.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace API_Consumation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmployeeController : Controller
{





    [Route("GetAllEmployee")]
    [HttpGet]
    public async Task<IActionResult> GetAllEmployee()
    {

        using (var client = new HttpClient())
        {

            client.BaseAddress = new Uri("https://dummy.restapiexample.com/api/v1/");

            using (HttpResponseMessage response = await client.GetAsync("employees"))
            {
                var responseContent = response.Content.ReadAsStringAsync().Result;

                response.EnsureSuccessStatusCode();

                return Ok(responseContent);

            }
        }
    }


    public async Task<IActionResult> AddEmployee()
    {
        using (var client = new HttpClient())
        {
            client.BaseAddress = new Uri("https://dummy.restapiexample.com/api/v1/");
            var postData = new
            {
                id = 25,
                employee_name = "Test",
                employee_age = 23,
                employee_salary = 123
            };

            var content = new StringContent(JsonConvert.SerializeObject(postData), Encoding.UTF8, "application/json");

            using (HttpResponseMessage response = await client.PostAsync("create", content))
            {
                var responseContent = response.Content.ReadAsStringAsync().Result;
                response.EnsureSuccessStatusCode();
                
                return Ok(responseContent);
            }
        }

    }


    public async Task<IActionResult> UpdateEmployee()
    {
        using (var client = new HttpClient())
        {
            client.BaseAddress = new Uri("https://dummy.restapiexample.com/api/v1/");
            var postData = new
            {
                id = 25,
                employee_name = "Test",
                employee_age = 23,
                employee_salary = 123
            };

            var content = new StringContent(JsonConvert.SerializeObject(postData), Encoding.UTF8, "application/json");

            using (HttpResponseMessage response = await client.PutAsync("update/21", content))
            {
                var responseContent = response.Content.ReadAsStringAsync().Result;
                response.EnsureSuccessStatusCode();
                
                return Ok(responseContent);
            }
        }
    }


    public async Task<IActionResult> DeleteEmployee()
    {
        using (var client = new HttpClient())
        {
            client.BaseAddress = new Uri("https://dummy.restapiexample.com/api/v1/");

            using (HttpResponseMessage response = await client.DeleteAsync("delete/2"))
            {
                var responseContent = response.Content.ReadAsStringAsync().Result;
                response.EnsureSuccessStatusCode();

                return Ok(responseContent);
            }
        }
    }
}
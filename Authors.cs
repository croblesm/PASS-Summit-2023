using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace AuthorFunctions
{
    public static class Authors
    {

    // Visit https://aka.ms/sqlbindingsinput to learn how to use this input binding
    [FunctionName("GetAuthors")]
        public static IActionResult RunGetAuthor(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "authors")] HttpRequest req,
            [Sql("SELECT * FROM [dbo].[Authors]",
            "SqlConnectionString")] IEnumerable<Object> result,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger with SQL Input Binding function processed a request.");

            return new OkObjectResult(result);
        }

        // Visit https://aka.ms/sqlbindingsoutput to learn how to use this output binding
        [FunctionName("AddAuthors")]
        public static async Task<IActionResult> RunAddAuthor(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "authors")] HttpRequest req,
            [Sql("[dbo].[Authors]", "SqlConnectionString")] IAsyncCollector<Author> output,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger with SQL Output Binding function processed a request.");

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            
            try
            {
                Author newAuthor = JsonConvert.DeserializeObject<Author>(requestBody);
                newAuthor.Id = Guid.NewGuid();
                await output.AddAsync(newAuthor);
                return new CreatedResult(req.Path, newAuthor);
            }
            catch (Exception ex)
            {
                // Log the exception or return an error response
                Console.WriteLine(ex.Message);
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }
    }

    public class Author
    {
        public Guid? Id { get; set; }
        public string first_name { get; set; }
        public string middle_name { get; set; }
        public string last_name { get; set; }
    }
}
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.Json;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace VKLabb3FuncNy
{
    public class CrudAPI
    {
        private readonly ILogger<CrudAPI> _logger;
        private readonly AppDbContext _appDbContext;

        public CrudAPI(ILogger<CrudAPI> logger, AppDbContext appDbContext)
        {
            _logger = logger;
            _appDbContext = appDbContext;
        }

        [Function("CrudAPI")]
        public async Task<IActionResult> GetProducts([HttpTrigger(AuthorizationLevel.Function, "get", Route = "Products")] HttpRequest req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");
            var products = await _appDbContext.Products.ToListAsync();
            return new OkObjectResult(products);

        }



        [Function("Post")]
        public async Task<IActionResult> PostProduct([HttpTrigger(AuthorizationLevel.Function, "post", Route = "Product")] HttpRequest req)
        {
            string requestData = await new StreamReader(req.Body).ReadToEndAsync();
            var data = JsonConvert.DeserializeObject<Product>(requestData);

            _appDbContext.Products.Add(data);
            await _appDbContext.SaveChangesAsync();
            return new OkObjectResult(data);
        }


    }
}

using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Template.Web.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Template.Web.Controllers
{
    
    public class InventoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]        
        public async Task<IActionResult> GetAll()
        {
            ResponseData<List<Inventory>> inventory = new ResponseData<List<Inventory>>();
            using (var client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync("https://localhost:7030/api/Inventory/GetAll");
                var resData = await response.Content.ReadAsStringAsync();
                inventory = JsonConvert.DeserializeObject<ResponseData<List<Inventory>>>(resData);
            }
            return View(inventory.Data);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ResponseData<Inventory> responseData = new ResponseData<Inventory>()
            {
                Data = new Inventory() // Ensure Data is initialized
            };
            
            using (var client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync("https://localhost:7030/api/Item/GetAll");
                var resData = await response.Content.ReadAsStringAsync();
                responseData.Data.ItemList = JsonConvert.DeserializeObject<ResponseData<List<Item>>>(resData).Data.ToList();
                
            }
            if(responseData.Data.ItemList.Count > 0)
            {
                responseData.Data.PricePerUnit = responseData.Data.ItemList.FirstOrDefault().PricePerUnit;
                responseData.Data.TotalUnit = 1;
                responseData.Data.TotalPrice = responseData.Data.PricePerUnit * responseData.Data.TotalUnit;
            }
            return View(responseData.Data);
        }
        [HttpPost]
        public async Task<IActionResult> Create(Inventory model)
        {
            ResponseData<List<Inventory>> inventory = new ResponseData<List<Inventory>>();
            using (var client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync("https://localhost:7030/api/Inventory/GetAll");
                var resData = await response.Content.ReadAsStringAsync();
                inventory = JsonConvert.DeserializeObject<ResponseData<List<Inventory>>>(resData);
            }
            return View(inventory.Data);
        }
    }
}

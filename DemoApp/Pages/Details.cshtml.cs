using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace DemoApp.Pages
{
    public class DetailsModel : PageModel
    {
        [BindProperty]
        public DemoApp.Models.Task Task { get; set; }
        public void OnGet(int? Id)
        {
            if (Id != null)
            {
                var client = new HttpClient();
                string path = "http://localhost:7071/api/task/" + Convert.ToString(Id);
                var response = client.GetAsync(path).GetAwaiter().GetResult();
                if (response.IsSuccessStatusCode)
                {
                    var Task1 = JsonConvert.DeserializeObject<List<DemoApp.Models.Task>>(response.Content.ReadAsStringAsync().GetAwaiter().GetResult().ToString());
                    Task = new DemoApp.Models.Task()
                    {
                        Description = Task1.FirstOrDefault().Description,
                        CreatedOn = Task1.FirstOrDefault().CreatedOn,
                        Status = Task1.FirstOrDefault().Status,
                        Id = Task1.FirstOrDefault().Id,
                    };
                }
            }
        }
    }
}

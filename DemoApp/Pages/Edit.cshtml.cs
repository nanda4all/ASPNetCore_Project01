using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace DemoApp.Pages
{
    public class EditModel : PageModel
    {
        private readonly IConfiguration _configuration;
        public EditModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [BindProperty]
        public DemoApp.Models.Task Task { get; set; }

        public void OnGet(int? Id)
        {
            if (Id != null)
            {
                var client = new HttpClient();
                string path = $"{_configuration["AppSettings:BaseAPI"]}api/task/{Id}";
                var response = client.GetAsync(path).GetAwaiter().GetResult();
                if (response.IsSuccessStatusCode)
                {
                    var Task1 = JsonConvert.DeserializeObject<List<DemoApp.Models.Task>>(response.Content.ReadAsStringAsync().GetAwaiter().GetResult().ToString());
                    Task = new DemoApp.Models.Task()
                    {
                        Description = Task1.FirstOrDefault().Description,
                        CreatedOn = Task1.FirstOrDefault().CreatedOn,
                        Status = Task1.FirstOrDefault().Status,
                        Id= Task1.FirstOrDefault().Id,
                    };
                }
            }
        }
        public ActionResult OnPost()
        {
            var json = JsonConvert.SerializeObject(Task);
            var client = new HttpClient();
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
            string path = $"{_configuration["AppSettings:BaseAPI"]}api/task/{Task.Id}";
            var res = client.PutAsync(path, content).GetAwaiter().GetResult();
            return RedirectToPage("Dashboard");
        }
    }
}

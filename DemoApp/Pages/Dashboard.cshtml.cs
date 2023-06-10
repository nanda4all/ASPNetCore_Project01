using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace DemoApp.Pages
{
    public class DashboardModel : PageModel
    {
        private readonly IConfiguration _configuration;
        public DashboardModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public List<DemoApp.Models.Task> TaskList { get; set; }
        public void OnGet()
        {
            TaskList = new List<DemoApp.Models.Task>();
            var client = new HttpClient();
            string path = $"{_configuration["AppSettings:BaseAPI"]}api/task";
            var response = client.GetAsync(path).GetAwaiter().GetResult();
            if (response.IsSuccessStatusCode)
            {
                TaskList = JsonConvert.DeserializeObject<List<DemoApp.Models.Task>>(response.Content.ReadAsStringAsync().GetAwaiter().GetResult().ToString());

            }
        }
    }
}

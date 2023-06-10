using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace DemoApp.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly IConfiguration _configuration;
        public DeleteModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [BindProperty]
        public DemoApp.Models.Task Task { get; set; }
        public ActionResult OnGet(int? Id)
        {
            if (Id != null)
            {
                var client = new HttpClient();
                string path = $"{_configuration["AppSettings:BaseAPI"]}api/task/{Id}";
                var response = client.DeleteAsync(path).GetAwaiter().GetResult();
               
            }
            return RedirectToPage("Dashboard");
        }
    }
}

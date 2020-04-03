using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace frontend.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public async Task OnGet()
        {
            using (var httpclient = new HttpClient())
            {
                using (var response = await httpclient.GetAsync("http://backend:80/api/test/get/1996"))
                //using (var response = await httpclient.getasync("https://localhost:44375/api/test/get/fe3"))
                {
                    string apiresponse = await response.Content.ReadAsStringAsync();
                    ViewData["Message"] = apiresponse;
                }
            }
        }
    }
}

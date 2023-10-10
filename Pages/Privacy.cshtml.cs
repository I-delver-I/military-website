using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;

namespace MilitaryWebsite.Pages
{
    public class PrivacyModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;

        public PrivacyModel(ILogger<PrivacyModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            var dateTime = DateTime.Now.ToString("f", new System.Globalization.CultureInfo("en-US"));
            ViewData["TimeStamp"] = dateTime;
        }
    }
}

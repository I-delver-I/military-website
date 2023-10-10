using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using MilitaryWebsite.DB;
using MilitaryWebsite.Models;

namespace MilitaryWebsite.Pages
{
    public class PersonnelModel : PageModel
    {
        private readonly ILogger<PersonnelModel> _logger;
        private readonly AppDb _db;
        
        public List<Serviceman> Servicemen;
        public List<Absence> CurrentAbsentServicemen;
        
        public PersonnelModel(ILogger<PersonnelModel> logger, AppDb db)
        {
            _logger = logger;
            _db = db;
        }

        public async Task OnGet()
        {
            Servicemen = await _db.GetServicemen();

            var currentDate = DateTime.Now;
            CurrentAbsentServicemen = (await _db.GetAbsenceList()).Where(absence => absence.EndDate >= currentDate)
                .ToList();
        }
    }
}
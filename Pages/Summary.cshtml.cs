using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MilitaryWebsite.DB;
using MilitaryWebsite.Models;

namespace MilitaryWebsite.Pages
{
    public class Summary : PageModel
    {
        private readonly AppDb _db;
        
        [BindProperty]
        public string SelectedUnitName { get; set; }

        public List<Serviceman> ServicemenInUnit = new();
        public List<Absence> AbsencesInUnit = new();
        public List<string> UnitNames = new();
        
        public Summary(AppDb db)
        {
            _db = db;
        }
        
        public async Task OnGet()
        {
            UnitNames = await _db.GetUnitNames();
        }

        public async Task OnPost()
        {
            if (!string.IsNullOrEmpty(SelectedUnitName))
            {
                ServicemenInUnit = await _db.GetServicemenInUnit(SelectedUnitName);
                AbsencesInUnit = await _db.GetAbsentServicemenInUnit(SelectedUnitName);
            }
            
            UnitNames = await _db.GetUnitNames();
        }
    }
}
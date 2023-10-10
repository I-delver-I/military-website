using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MilitaryWebsite.DB;
using MilitaryWebsite.Models;

namespace MilitaryWebsite.Pages
{
    public class AbsenceModel : PageModel
    {
        private readonly AppDb _db;
        
        public List<Absence> AbsenceList;

        public AbsenceModel(AppDb db)
        {
            _db = db;
        }

        public async Task OnGet()
        {
            AbsenceList = await _db.GetAbsenceList();
        }
    }
}


using GISSA.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;


namespace GISSA.Pages
{
    public class Index_AdminModel : PageModel
    {
        private readonly ILogger<Index_AdminModel> _logger;
        private readonly App_DB_Context _db;

        public Index_AdminModel(ILogger<Index_AdminModel> logger, App_DB_Context bd)
        {
            _logger = logger;
            _db = bd;
        }
        public DataTable? Resultado { get; set; }
        public void OnGet()
        {
            Resultado  = _db.ExecuteReader("test_obtenerUsuarios");
        }
        


    }

}

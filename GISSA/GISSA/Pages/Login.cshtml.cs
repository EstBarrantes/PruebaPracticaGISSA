using GISSA.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
using System.Data.SqlClient;

namespace GISSA.Pages
{
    public class LoginModel : PageModel
    {
        private readonly ILogger<LoginModel> _logger;
        private readonly App_DB_Context _db;

        public LoginModel(ILogger<LoginModel> logger, App_DB_Context bd)
        {
            _logger = logger;
            _db = bd;
        }

        public DataTable? Resultado { get; set; }
        public string MSJ_Error { get; set; }
        [BindProperty] public string nombre_usuario { get; set; }
        [BindProperty] public string clave { get; set; }

        public void OnGet()
        {
           
        }

        
        public IActionResult OnPostLogin()
        {
            SqlParameter[] parameters = new SqlParameter[] { 
                new SqlParameter("@Usuario", nombre_usuario), 
                new SqlParameter("@password ", clave) 
            };

            Resultado = _db.ExecuteReader("Test_Login_Usuario",parameters );
            if (Resultado.Rows.Count > 0)
            {
                String tipo_usuario = Resultado.Rows[0]["tipo_usuario"].ToString();
                if (tipo_usuario=="Admin")
                {
                    return RedirectToPage("/Index_Admin");
                }
                else
                {
                    return RedirectToPage("/Index");
                }
                
            }
            else {
                TempData["error"] = "Contraseña o Usuario Incorrectos - Por Favor vuelva a intentarlo";
                return Page();
            }

        }
    }
}

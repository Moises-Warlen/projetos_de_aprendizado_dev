using EmprestimosSMN.Data;
using EmprestimosSMN.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmprestimosSMN.Controllers
{
    public class UsuarioController : Controller
    {

        readonly private ApplicationDbContext _db;

        public UsuarioController(ApplicationDbContext db)
        {
            _db = db;
        }
       
      
        public IActionResult Login(UsuarioMoldel usuarioTela)
        {
            UsuarioMoldel usuarioBanco = _db.Usuarios.FirstOrDefault(x => x.Nome == usuarioTela.Nome);

            if (usuarioBanco == null)
            {
                return NotFound();
            }

            if (usuarioBanco.senha != usuarioTela.senha)
            {
                return NotFound();
            }

            return RedirectToAction("Index","Emprestimo");

        }



        public IActionResult Index()
        {
            return View();
        }
    }
}

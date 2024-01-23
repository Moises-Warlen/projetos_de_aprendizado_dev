using EmprestimosSMN.Data;
using EmprestimosSMN.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmprestimosSMN.Controllers
{
    public class EmprestimoController : Controller
    {
        readonly private ApplicationDbContext _db;

        public EmprestimoController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<EmprestimoModel> emprestimos = _db.Emprestimos;
            return View(emprestimos);
        }

        public IActionResult Cadastrar()
        {

            return View();
        }


        [HttpPost]
        public IActionResult Cadastrar(EmprestimoModel emprestimos)
        {

            if (ModelState.IsValid)
            {
                _db.Emprestimos.Add(emprestimos);
                _db.SaveChanges();
                TempData["MensagemSucesso"] = "Cadastro realizado com sucesso!";
                return RedirectToAction("Index");
            }
            return View();

        }
        [HttpGet]

        public IActionResult Editar(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            EmprestimoModel emprestimo = _db.Emprestimos.FirstOrDefault(x => x.Id == id);

            if (emprestimo == null)
            {
                return NotFound();
            }

            return View(emprestimo);
        }

        [HttpPost]
        public IActionResult Editar(EmprestimoModel emprestimos)
        {

            if (ModelState.IsValid)
            {
                _db.Emprestimos.Update(emprestimos);
                _db.SaveChanges();
                TempData["MensagemSucesso"] = "Editado  com sucesso!";
                return RedirectToAction("Index");
            }
            TempData["MensagemErro"] = "algum erro ocorreu ao realizar a edição!";
            return View(emprestimos);
        }

        [HttpGet]
        public IActionResult Excluir(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            EmprestimoModel emprestimo = _db.Emprestimos.FirstOrDefault(x => x.Id == id);

            if (emprestimo == null)
            {
                return NotFound();
            }
            return View(emprestimo);
        }


        [HttpPost]
        public IActionResult Excluir(EmprestimoModel emprestimos)
        {

            if (emprestimos == null)
            {
                return NotFound();
            }

            _db.Emprestimos.Remove(emprestimos);
            _db.SaveChanges();
            TempData["MensagemSucesso"] = "Removido  com sucesso!";
            return RedirectToAction("Index");
        }
    }
}

        

    


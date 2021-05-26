using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PracticaN3.Data;
using PracticaN3.Models;

namespace PracticaN3.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly BuscoContext _context;
        public CategoriaController(BuscoContext context){
            _context = context;
        }

        public IActionResult Categorias(){
            var categoria = _context.Categorias.Include(x => x.Producto).OrderBy(r => r.id).ToList();
            return View(categoria);
        }

        public IActionResult NuevaCategoria(){
            return View();
        }

        [HttpPost]
        public IActionResult NuevaCategoria(Categoria c){
            if(ModelState.IsValid){
                _context.Add (c);
                _context.SaveChanges();
                return RedirectToAction("Categorias");
            }
            return View(c);
        }

        [HttpPost]
        public IActionResult BorrarCategoria(int id){
           
            var categoria= _context.Categorias.Find(id);
            _context.Remove(categoria);
            _context.SaveChanges();

            return RedirectToAction("Categorias");
        }


    }
}
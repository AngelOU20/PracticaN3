using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PracticaN3.Data;
using PracticaN3.Models;

namespace PracticaN3.Controllers
{
    public class ProductoController : Controller
    {
        private readonly BuscoContext _context;
        public ProductoController(BuscoContext context){
            _context = context;
        }

        public IActionResult Productos(){
            var producto = _context.Productos.Include(x => x.categoria).OrderBy(r => r.id).ToList();
            return View(producto);
        }

        public IActionResult NuevoProducto(){
            ViewBag.categoria=_context.Categorias.ToList().Select(r => new SelectListItem(r.NombreCategoria, r.id.ToString()));
            return View();
        }

        [HttpPost]
        public IActionResult NuevoProducto(Producto p){
            if(ModelState.IsValid){
                _context.Add (p);
                _context.SaveChanges();
                return RedirectToAction("Productos");
            }
            return View(p);
        }

        [HttpPost]
        public IActionResult BorrarProducto(int id){
           
            var producto= _context.Productos.Find(id);
            _context.Remove(producto);
            _context.SaveChanges();

            return RedirectToAction("Productos");
        }

        public IActionResult EditarProducto(int id) {
            var producto = _context.Productos.Find(id);
            ViewBag.categoria=_context.Categorias.ToList().Select(r => new SelectListItem(r.NombreCategoria, r.id.ToString()));
            return View(producto);
        }

        [HttpPost]
        public IActionResult EditarProducto(Producto p) {
            if (ModelState.IsValid) {
                var producto = _context.Productos.Find(p.id);  
                producto.NombreProducto = p.NombreProducto;
                producto.Foto = p.Foto;
                producto.Descripcion = p.Descripcion;
                producto.Precio = p.Precio;
                producto.Celular = p.Celular;
                producto.LugarCompra = p.LugarCompra;
                producto.NombreComprador = p.NombreComprador;
                producto.CategoriaId=p.CategoriaId;
                _context.SaveChanges();
                return RedirectToAction("Productos");
            }
            return View(p);
        }

    }
}
using CrudSegundoParcial.Data;
using CrudSegundoParcial.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudSegundoParcial.Controllers
{
    public class ProductosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductosController(ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Productos> list = await _context.Productos.Where(x => x.Estado_Id ==1).Include(x => x.Marcas).Include(x => x.Estados).ToListAsync();
            return View(list);
        }
        public IActionResult Create()
        {
            IEnumerable<SelectListItem> lst = _context
                .Marcas
                .Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Marca })
                .ToList();

            ViewBag.lst = lst;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Productos _productos)
        {
            _productos.Estado_Id = 1;
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Productos.Add(_productos);
                    await _context.SaveChangesAsync();

                    TempData["mensaje"] = "Producto creado correctamente";
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {
                    throw;
                }
            }

            return View();
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var data = _context.Productos.Find(id);

            if (data == null)
            {
                return NotFound();
            }
            ViewBag.listMarcas = await _context.Marcas.OrderBy(x => x.Marca).ToListAsync();
            return View(data);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Productos _productos)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Productos.Update(_productos);
                    await _context.SaveChangesAsync();
                    TempData["mensaje"] = "Producto actualizado correctamente.";
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {

                    throw;
                }
            }

            return View();
        }
        public async Task<IActionResult> Eliminar(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var data = _context.Productos.Find(id);

            if (data == null)
            {
                return NotFound();
            }
            else
            {
                data.Estado_Id = 2;
            }

            try
            {
                _context.Productos.Update(data);
                await _context.SaveChangesAsync();
                TempData["mensaje"] = "Producto eliminado correctamente.";
                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                throw;
            }
            return View();
        }
    }
}

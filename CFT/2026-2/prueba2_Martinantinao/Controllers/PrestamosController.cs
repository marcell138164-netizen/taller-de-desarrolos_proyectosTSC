using Microsoft.AspNetCore.Mvc;
using prueba2_Martinantinao.Models;

namespace prueba2_Martinantinao.Controllers;

public class PrestamosController : Controller
{
    private static List<PrestamoEquipo> prestamos = new()
    {
        new PrestamoEquipo { Id = 1, Solicitante = "Ana Pérez", Equipo = "Notebook Lenovo",
            FechaPrestamo = DateTime.Today, Dias = 5, Devuelto = false },
        new PrestamoEquipo { Id = 2, Solicitante = "Luis Soto", Equipo = "Proyector Epson",
            FechaPrestamo = DateTime.Today.AddDays(-2), Dias = 3, Devuelto = true },
        new PrestamoEquipo { Id = 3, Solicitante = "María López", Equipo = "Tablet Samsung",
            FechaPrestamo = DateTime.Today.AddDays(-1), Dias = 10, Devuelto = false }
    };

    private static int ObtenerNuevoId()
    {
        if (prestamos.Count == 0) return 1;
        return prestamos.Max(p => p.Id) + 1;
    }

    public IActionResult Index()
    {
        return View(prestamos);
    }

    public IActionResult Details(int id)
    {
        var prestamo = prestamos.FirstOrDefault(p => p.Id == id);
        if (prestamo == null) return NotFound();
        return View(prestamo);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(PrestamoEquipo prestamo)
    {
        if (!ModelState.IsValid) return View(prestamo);

        prestamo.Id = ObtenerNuevoId();
        prestamos.Add(prestamo);
        TempData["Mensaje"] = "Préstamo creado correctamente.";
        return RedirectToAction(nameof(Index));
    }

    public IActionResult Edit(int id)
    {
        var prestamo = prestamos.FirstOrDefault(p => p.Id == id);
        if (prestamo == null) return NotFound();
        return View(prestamo);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(PrestamoEquipo prestamo)
    {
        if (!ModelState.IsValid) return View(prestamo);

        var actual = prestamos.FirstOrDefault(p => p.Id == prestamo.Id);
        if (actual == null) return NotFound();

        actual.Solicitante = prestamo.Solicitante;
        actual.Equipo = prestamo.Equipo;
        actual.FechaPrestamo = prestamo.FechaPrestamo;
        actual.Dias = prestamo.Dias;
        actual.Devuelto = prestamo.Devuelto;

        TempData["Mensaje"] = "Préstamo actualizado correctamente.";
        return RedirectToAction(nameof(Index));
    }

    public IActionResult Delete(int id)
    {
        var prestamo = prestamos.FirstOrDefault(p => p.Id == id);
        if (prestamo == null) return NotFound();
        return View(prestamo);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmed(int id)
    {
        var prestamo = prestamos.FirstOrDefault(p => p.Id == id);
        if (prestamo == null) return NotFound();

        prestamos.Remove(prestamo);
        TempData["Mensaje"] = "Préstamo eliminado correctamente.";
        return RedirectToAction(nameof(Index));
    }
}
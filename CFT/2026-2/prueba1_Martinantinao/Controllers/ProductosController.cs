using Microsoft.AspNetCore.Mvc;
using prueba1_Martinantinao.Models;

    namespace prueba1_Martinantinao.Controllers;


    public class ProductosController : Controller
{
    private static List<Producto> Productos= new()
    {
        new Producto(1, "Notebook 15\"", "Computacion",549990m, 8),
        new Producto(2, "Mouse inalambrico", "accesorios",12990m, 25),
        new Producto(3, "Monitor 24\"", "Computacion",119990m,0),
        new Producto(4, "Teclado mecanico","accesorios",39990,5)
    
};
public IActionResult Index()
{
    ViewData["Titulo"] = "catalogo de productos";
    return View(Productos);
}
public IActionResult Details(int Id)
{
    Producto? ProductoEncontrado = null;
    
    foreach(Producto producto in Productos)
    {
        if(producto.Id == Id)
        {
            ProductoEncontrado = producto;
            break;
        }
    }
        if (ProductoEncontrado == null)
    {
         return RedirectToAction("index");
    
    }
        ViewBag.Mensaje = "detalle del producto seleccionado";
       return View(ProductoEncontrado);
    
 }
}

using Microsoft.AspNetCore.Mvc;
using myprojectpharmacy.Models;

public class SupplierController : Controller
{
    private readonly SupplierRepository _repository;

    public SupplierController(IConfiguration configuration)
    {
        var connString = configuration.GetConnectionString("DefaultConnection");
        _repository = new SupplierRepository(connString);
    }

    public IActionResult Index()
    {
        var suppliers = _repository.GetAllSuppliers();
        return View(suppliers);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Supplier supplier)
    {
        if (ModelState.IsValid)
        {
            _repository.AddSupplier(supplier);
            return RedirectToAction("Index");
        }
        return View(supplier);
    }
}

using System.ComponentModel.DataAnnotations;
using Finerp_web.Data.Inventories;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace Finerp_web.Controllers;

public class InventoryController : Controller
{
    private readonly InventoryRepository _inventoryRepository;
    private readonly IValidator<Inventory> _inventoryValidator;

    public InventoryController(InventoryRepository inventoryRepository, IValidator<Inventory> inventoryValidator)
    {
        _inventoryRepository = inventoryRepository;
        _inventoryValidator = inventoryValidator;
    }

    public IActionResult Index()
    {
        var inventories = _inventoryRepository.GetAllInventory();
        return View(inventories);
    }

    public IActionResult Detail(int inventoryId)
    {
        Inventory inventory = new Inventory();
        if (inventoryId != 0)
            inventory = _inventoryRepository.GetInventoryById(inventoryId);
        return View(inventory);
    }

    [HttpPost]
    public IActionResult Detail(Inventory inventory, IFormFile photo)
    {
        var validation =   _inventoryValidator.Validate(inventory);
        
        if(validation.IsValid == false)
        {
            foreach (var error in validation.Errors)
            {
                ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                return View("Detail", inventory);
            }
        }
        if (photo != null)
        {
            using (var memoryStream = new MemoryStream())
            {
                photo.CopyTo(memoryStream);
                inventory.photo = memoryStream.ToArray();
            }
        }
        
        if (inventory.InventoryId == 0)
        {
            _inventoryRepository.AddInventory(inventory);
        }
        else
        {
            _inventoryRepository.UpdateInventory(inventory);
        }


        return
            RedirectToAction(
                "Index"); // İşlem tamamlandıktan sonra yönlendirme yapılabilir, örneğin Index sayfasına yönlendirme yapılıyor.
    }

    [HttpPost]
    public IActionResult Delete(Inventory inventory)
    {
        _inventoryRepository.DeleteInventory(inventory.InventoryId);


        return
            RedirectToAction(
                "Index"); // İşlem tamamlandıktan sonra yönlendirme yapılabilir, örneğin Index sayfasına yönlendirme yapılıyor.
    }
    
} 
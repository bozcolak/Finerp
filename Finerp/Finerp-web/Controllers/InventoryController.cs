using Finerp_web.Data.Inventories;
using Microsoft.AspNetCore.Mvc;

namespace Finerp_web.Controllers;

public class InventoryController : Controller
{
    private readonly InventoryRepository _inventoryRepository;

    public InventoryController(InventoryRepository inventoryRepository)
    {
        _inventoryRepository = inventoryRepository;
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
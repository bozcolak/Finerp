using Microsoft.EntityFrameworkCore;

namespace Finerp_web.Data.Inventories;

public class InventoryRepository
{
    private readonly ApplicationDbContext _context;

    public InventoryRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public List<Inventory> GetAllInventory()
    {
        return _context.Inventories.ToList();
    }

    public Inventory GetInventoryById(int inventoryId)
    {
        return _context.Inventories.FirstOrDefault(c => c.InventoryId == inventoryId);
    }

    public void AddInventory(Inventory inventory)
    {
        _context.Inventories.Add(inventory);
        _context.SaveChanges();
    }

    public void UpdateInventory(Inventory inventory)
    {
        _context.Entry(inventory).State = EntityState.Modified;
        _context.SaveChanges();
    }

    public void DeleteInventory(int inventoryId)
    {
        var inventory = _context.Inventories.Find(inventoryId);
        if (inventory != null)
        {
            _context.Inventories.Remove(inventory);
            _context.SaveChanges();
        }
    }
}
using FluentValidation;

namespace Finerp_web.Data.Inventories;

public class Inventory
{
    public int InventoryId { get; set; }
    public string name { get; set; }
    public string description { get; set; }
    public int stock { get; set; }
    public byte[] photo { get; set; }
    public DateTime createDate { get; set; }
    public DateTime lastUpdateDate { get; set; }
    public int createUserId { get; set; }
    public int modifyUserId { get; set; }
    public string GetBase64Image()
    {
        if (photo != null)
        {
            return $"data:image/jpeg;base64,{Convert.ToBase64String(photo)}";
        }

        return null;
    }
    public class InventoryValidator :AbstractValidator<Inventory>
    {
        public InventoryValidator()
        {
            RuleFor(x => x.name).Length(0,255);
        }
    }
}
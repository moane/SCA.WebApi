namespace SCA.AssetRegisterApi.Models;

public class AssetType
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int NumberMaintenanceDays { get; set; }
    public bool NeedMaintenance { get; set; }
    public bool Status { get; set; }

    public ICollection<Asset>? Assets { get; set; }
}

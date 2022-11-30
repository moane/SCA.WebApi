using AutoMapper.Configuration.Annotations;

namespace SCA.AssetRegisterApi.Models;

public class Asset
{
    public int Id { get; set; }
    public string? Name { get; set; }

    public DateTime AcquisitionDate { get; set; }
    public DateTime OperationDate { get; set; }
    public bool NeedMaintenance { get; set; }
    public bool Status { get; set; }

   
    public AssetType? AssetType { get; set; }

    public int AssetTypeId { get; set; }
}

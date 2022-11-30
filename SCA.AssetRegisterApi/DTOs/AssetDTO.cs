using SCA.AssetRegisterApi.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SCA.AssetRegisterApi.DTOs
{
    public class AssetDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="O nome é obrigatório")]
        [MinLength(3)]
        [MaxLength(100)]
        public string? Name { get; set; }

        [Required(ErrorMessage = "A data de aquisição é obrigatória")]
        public DateTime AcquisitionDate { get; set; }

        [Required(ErrorMessage = "A data início de operação é obrigatória")]
        public DateTime OperationDate { get; set; }

        [DefaultValue(true)]
        public bool NeedMaintenance { get; set; }

        [DefaultValue(true)]
        public bool Status { get; set; }

        [JsonIgnore]
        public AssetType? AssetType { get; set; }

        public int AssetTypeId { get; set; }

        public string? AssetTypeName { get; set; }
    }
}

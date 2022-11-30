using SCA.AssetRegisterApi.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SCA.AssetRegisterApi.DTOs
{
    public class AssetTypeDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório")]
        [MinLength(3)]
        [MaxLength(100)]
        public string? Name { get; set; }

        [Required(ErrorMessage = "O intervalo de manutenção em dias é obrigatório")]       
        public int NumberMaintenanceDays { get; set; }

        public bool NeedMaintenance { get; set; }

        [ReadOnly(true)]
        public bool Status { get; set; }

        [JsonIgnore]
        public ICollection<Asset>? Assets { get; set; }
    }
}

using Microsoft.AspNetCore.Mvc;
using SCA.AssetRegisterApi.DTOs;
using SCA.AssetRegisterApi.Services.Contracts;

namespace SCA.AssetRegisterApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssetTypeController : ControllerBase
    {
        private readonly IAssetTypeService _assetTypeService;

        public AssetTypeController(IAssetTypeService assetTypeService)
        {
            _assetTypeService = assetTypeService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AssetTypeDTO>>> Get()
        {
            try
            {
                var assetTypesDto = await _assetTypeService.GetAll();

                if (assetTypesDto is null)
                    return NotFound("Tipo de ativo não encontrado");

                return Ok(assetTypesDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
           
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<AssetTypeDTO>> Get(int id)
        {
            try
            {
                var assetTypesDto = await _assetTypeService.GetById(id);

                if (assetTypesDto is null)
                    return NotFound("Tipo de ativo não encontrado");

                return Ok(assetTypesDto);

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] AssetTypeDTO assetTypeDto)
        {
            if (!ModelState.IsValid)
                return BadRequest("Dados invalidos");
            try
            {
                var result = await _assetTypeService.CreateAssetType(assetTypeDto);

                if (result is null)
                    return NotFound("Tipo de ativo não encontrado");

                return Ok(result);
            }
            catch (Exception ex)
            {
                //escrever log de exceção 
                return BadRequest(ex);
            }
            
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] AssetTypeDTO assetTypeDto)
        {
            if (assetTypeDto is null)
                return BadRequest("Dados invalidos");

            try
            {
                var result = await _assetTypeService.UpdateAssetType(assetTypeDto);

                if (result is null)
                    return NotFound("Tipo de ativo não encontrado");

                return Ok(result);
            }
            catch (Exception ex)
            {

                //escrever log de exceção 
                return BadRequest(ex);
            }
           
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<AssetTypeDTO>> Delete(int id )
        {
            try
            {
                AssetTypeDTO assetTypeDto = await _assetTypeService.GetById(id);

                if (assetTypeDto is null)
                    return BadRequest("Ativo não encontrado");


                await _assetTypeService.DeleteAssetType(assetTypeDto.Id);


                return Ok(assetTypeDto);
            }
            catch (Exception ex)
            {
                //escrever log de exceção 
                return BadRequest(ex);
            }
           
        }
    }
}

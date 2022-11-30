using Microsoft.AspNetCore.Mvc;
using SCA.AssetRegisterApi.DTOs;
using SCA.AssetRegisterApi.Services.Contracts;

namespace SCA.AssetRegisterApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssetController : ControllerBase
    {
        private readonly IAssetService _AssetService;

        public AssetController(IAssetService AssetService)
        {
            _AssetService = AssetService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AssetDTO>>> Get()
        {
            try
            {
                var AssetsDto = await _AssetService.GetAll();

                if (AssetsDto is null)
                    return NotFound("Ativo não encontrado");

                return Ok(AssetsDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
           
        }



        [HttpGet("{id}")]
        public async Task<ActionResult<AssetDTO>> Get(int id)
        {
            try
            {
                var AssetsDto = await _AssetService.GetById(id);

                if (AssetsDto is null)
                    return NotFound("Ativo não encontrado");

                return Ok(AssetsDto);

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] AssetDTO AssetDto)
        {
            if (!ModelState.IsValid)
                return BadRequest("Dados invalidos");
            try
            {
                var result = await _AssetService.CreateAsset(AssetDto);

                if (result is null)
                    return NotFound("Ativo não encontrado");

                return Ok(result);
            }
            catch (Exception ex)
            {
                //escrever log de exceção 
                
                return BadRequest(ex);
            }
            
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] AssetDTO AssetDto)
        {
            if (AssetDto is null)
                return BadRequest("Dados invalidos");

            try
            {
                var result = await _AssetService.UpdateAsset(AssetDto);

                if (result is null)
                    return NotFound("Ativo não encontrado");

                return Ok(result);
            }
            catch (Exception ex)
            {

                //escrever log de exceção 
                return BadRequest(ex);
            }
           
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<AssetDTO>> Delete(int id )
        {
            try
            {
                AssetDTO AssetDto = await _AssetService.GetById(id);

                if (AssetDto is null)
                    return BadRequest("Ativo não encontrado");


                await _AssetService.DeleteAsset(AssetDto.Id);


                return Ok(AssetDto);
            }
            catch (Exception ex)
            {
                //escrever log de exceção 
                return BadRequest(ex);
            }
           
        }
    }
}

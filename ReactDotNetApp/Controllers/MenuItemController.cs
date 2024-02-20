using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReactDotNetApp.DTO.MenuDto;
using ReactDotNetApp.Models;
using ReactDotNetApp.Repositories.Interfaces;
using ReactDotNetApp.Services;
using ReactDotNetApp.Static;

namespace ReactDotNetApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuItemController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILogger<MenuItemController> _logger;
        private readonly IBlobService _blobService;
        private readonly IMenuItemRepository _menuItemRepository;

        public MenuItemController(ILogger<MenuItemController> logger, IMapper mapper, IMenuItemRepository menuItemRepository, IBlobService blobService)
        {
            _logger = logger;
            _mapper = mapper;
            _blobService = blobService;
            _menuItemRepository = menuItemRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MenuItemDto>>> GetMenuItems()
        {
            _logger.LogInformation($"Request to {nameof(GetMenuItems)}");

            try
            {
                var menuItemDtos = await _menuItemRepository.GetAllAsync();

                return Ok(menuItemDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error performing GET in {nameof(GetMenuItems)}");

                return StatusCode(500, Messages.Error500Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MenuItemDto>> GetMenuItem(int id)
        {
            try
            {
                var menuItem = await _menuItemRepository.GetAsync(id);

                var menuItemDto = _mapper.Map<MenuItemDto>(menuItem);

                if (menuItemDto == null)
                {
                    return NotFound();
                }

                return menuItemDto;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error performing GET in {nameof(GetMenuItem)}");

                return StatusCode(500, Messages.Error500Message);
            }
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<MenuItem>> PostMenuItem([FromForm] MenuItemCreateDto menuItemCreateDto)
        {
            try
            {
                var file = menuItemCreateDto.File;

                if (file == null || file.Length == 0)
                {
                    return BadRequest();
                }

                string fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";

                menuItemCreateDto.Image = await _blobService.UploadBlob(fileName, AzureStorage.Container, file);

                var menuItem = _mapper.Map<MenuItem>(menuItemCreateDto);

                await _menuItemRepository.AddAsync(menuItem);

                return CreatedAtAction("GetMenuItem", new { id = menuItem.Id }, menuItem);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error performing GET in {nameof(PostMenuItem)}");

                return StatusCode(500, Messages.Error500Message);
            }
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> PutMenuItem(int id, [FromForm] MenuItemUpdateDto menuItemUpdateDto)
        {
            try
            {
                if (id != menuItemUpdateDto.Id) { return BadRequest(); }

                var menuItem = await _menuItemRepository.GetAsync(id);

                if (menuItem == null) { return NotFound(); }

                _mapper.Map(menuItemUpdateDto, menuItem);

                var file = menuItemUpdateDto.File;

                if (file != null && file.Length > 0)
                {
                    string menuItemFileName = menuItem.Image.Split('/').Last();

                    await _blobService.DeleteBlob(menuItemFileName, AzureStorage.Container);

                    string fileName = $"{Guid.NewGuid()}{Path.GetExtension(menuItemUpdateDto.File.FileName)}";

                    menuItem.Image = await _blobService.UploadBlob(fileName, AzureStorage.Container, menuItemUpdateDto.File);
                }                

                try
                {
                    await _menuItemRepository.UpdateAsync(menuItem);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await MenuItemExistsAsync(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error performing GET in {nameof(PutMenuItem)}");

                return StatusCode(500, Messages.Error500Message);
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteMenuItem(int id)
        {
            try
            {
                var menuItem = await _menuItemRepository.GetAsync(id);

                if (menuItem == null)
                {
                    return NotFound();
                }

                string menuItemFileName = menuItem.Image.Split('/').Last();

                await _blobService.DeleteBlob(menuItemFileName, AzureStorage.Container);

                // int milliSeconds = 2000; Thread.Sleep(milliSeconds);

                await _menuItemRepository.DeleteAsync(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error performing GET in {nameof(DeleteMenuItem)}");

                return StatusCode(500, Messages.Error500Message);
            }
        }

        private async Task<bool> MenuItemExistsAsync(int id)
        {
            return await _menuItemRepository.EntityExists(id);
        }
    }
}

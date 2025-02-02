using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnionDemoProject.Application.Features.CQRSDesignPattern.Commands;
using OnionDemoProject.Application.Features.CQRSDesignPattern.Handlers;

namespace OnionDemoProject.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly CreateCategoryCommandHandler _createCategoryCommandHandler;
        private readonly GetCategoryQueryCommandHandler _getCategoryQueryCommandHandler;
        private readonly RemoveCategoryCommandHandler _removeCategoryCommandHandler;
        private readonly UpdateCategoryCommandHandler _updateCategoryCommandHandler;
        private readonly GetCategoryByIdQueryCommandHandler _getCategoryByIdQueryCommandHandler;

        public CategoriesController(CreateCategoryCommandHandler createCategoryCommandHandler, GetCategoryQueryCommandHandler getCategoryQueryCommandHandler, RemoveCategoryCommandHandler removeCategoryCommandHandler, UpdateCategoryCommandHandler updateCategoryCommandHandler, GetCategoryByIdQueryCommandHandler getCategoryByIdQueryCommandHandler)
        {
            _createCategoryCommandHandler = createCategoryCommandHandler;
            _getCategoryQueryCommandHandler = getCategoryQueryCommandHandler;
            _removeCategoryCommandHandler = removeCategoryCommandHandler;
            _updateCategoryCommandHandler = updateCategoryCommandHandler;
            _getCategoryByIdQueryCommandHandler = getCategoryByIdQueryCommandHandler;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategoryAsync()
        {
            return Ok(await _getCategoryQueryCommandHandler.Handle());
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategoryAsync(CreateCategoryCommand command)
        {
            await _createCategoryCommandHandler.Handle(command);
            return Ok("Ekleme Yapıldı");
        }
    }
}

using OnionDemoProject.Application.Features.CQRSDesignPattern.Commands;
using OnionDemoProject.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionDemoProject.Application.Features.CQRSDesignPattern.Handlers
{
    public class CreateCategoryCommandHandler
    {
        private readonly OnionDemoProjectContext _context;

        public CreateCategoryCommandHandler(OnionDemoProjectContext context)
        {
            _context = context;
        }

        public async Task Handle(CreateCategoryCommand command)
        {
            _context.Categories.Add(new Domain.Entities.Category
            {
                CategoryName = command.CategoryName
            });
            await _context.SaveChangesAsync();
        }
    }
}

using OnionDemoProject.Application.Features.CQRSDesignPattern.Commands;
using OnionDemoProject.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionDemoProject.Application.Features.CQRSDesignPattern.Handlers
{
    public class UpdateCategoryCommandHandler
    {
        private readonly OnionDemoProjectContext _context;

        public UpdateCategoryCommandHandler(OnionDemoProjectContext context)
        {
            _context = context;
        }

        public async Task Handle(UpdateCategoryCommand command)
        {
            var value = await _context.Categories.FindAsync(command.CategoryId);
            value.CategoryName = command.CategoryName;
            await _context.SaveChangesAsync();
        }
    }
}

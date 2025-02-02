using OnionDemoProject.Application.Features.CQRSDesignPattern.Commands;
using OnionDemoProject.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionDemoProject.Application.Features.CQRSDesignPattern.Handlers
{
    public class RemoveCategoryCommandHandler
    {
        private readonly OnionDemoProjectContext _context;

        public RemoveCategoryCommandHandler(OnionDemoProjectContext context)
        {
            _context = context;
        }

        public async Task Handle(RemoveCategoryCommand command)
        {
            var value = _context.Categories.Find(command.CategoryId);
            _context.Categories.Remove(value);
            await _context.SaveChangesAsync();
            
        }
    }
}

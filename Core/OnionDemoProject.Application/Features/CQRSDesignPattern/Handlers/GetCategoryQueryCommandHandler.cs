using OnionDemoProject.Application.Features.CQRSDesignPattern.Results;
using OnionDemoProject.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace OnionDemoProject.Application.Features.CQRSDesignPattern.Handlers
{
    public class GetCategoryQueryCommandHandler
    {
        private readonly OnionDemoProjectContext _context;

        public GetCategoryQueryCommandHandler(OnionDemoProjectContext context)
        {
            _context = context;
        }

        public async Task<List<GetCategoryQueryResult>> Handle()
        {
            var values =await  _context.Categories.ToListAsync();
            return values.Select(x => new GetCategoryQueryResult
            {
                CategoryId = x.CategoryId,
                CategoryName = x.CategoryName
            }).ToList();
        }
    }
}

using OnionDemoProject.Application.Features.CQRSDesignPattern.Queries;
using OnionDemoProject.Application.Features.CQRSDesignPattern.Results;
using OnionDemoProject.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionDemoProject.Application.Features.CQRSDesignPattern.Handlers
{
    public class GetCategoryByIdQueryCommandHandler
    {
        private readonly OnionDemoProjectContext _context;

        public GetCategoryByIdQueryCommandHandler(OnionDemoProjectContext context)
        {
            _context = context;
        }
        public async Task<GetCategoryByIdQueryResult> Handle(GetCategoryByIdQuery query)
        {
            var values =await _context.Categories.FindAsync(query.CategoryId);
            return new GetCategoryByIdQueryResult
            {
                CategoryId = values.CategoryId,
                CategoryName = values.CategoryName
            };
        }
    }
}

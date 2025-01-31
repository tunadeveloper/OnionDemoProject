﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionDemoProject.Application.Features.CQRSDesignPattern.Queries
{
    public class GetCategoryByIdQuery
    {
        public int CategoryId { get; set; }

        public GetCategoryByIdQuery(int categoryId)
        {
            CategoryId = categoryId;
        }
    }
}

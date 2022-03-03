using ClinicAPIv1.Helpers;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace ClinicAPIv1.Extensions
{
    public static class HttpExtensions
    {
        public static void AddPagination(this HttpResponse response, int currentPage, int itemsPerPage, 
            int totalItems, int totalPages)
        {
            var pagination = new Pagination(currentPage, itemsPerPage, totalItems, totalPages);

            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
            
            response.Headers.Add("Pagination", JsonSerializer.Serialize(pagination));
            response.Headers.Add("Access-Control-Expose-Headers", "Pagination");
        }
    }
}

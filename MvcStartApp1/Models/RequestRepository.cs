using Microsoft.EntityFrameworkCore;
using MvcStartApp1.Models.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcStartApp1.Models
{
    public class RequestRepository : IRequestRepository
    {
        // ссылка на контекст
        private readonly BlogContext _context;

        // Метод-конструктор для инициализации
        public RequestRepository(BlogContext context)
        {
            _context = context;
        }

        public async Task AddRequest(Request request)
        {
            var entry = _context.Entry(request);

            if (entry.State == EntityState.Detached)
                await _context.UserRequests.AddAsync(request);

            await _context.SaveChangesAsync();
        }

        public async Task<Request[]> GetRequests()
        {
            return await _context.UserRequests.ToArrayAsync();
        }
    }
}

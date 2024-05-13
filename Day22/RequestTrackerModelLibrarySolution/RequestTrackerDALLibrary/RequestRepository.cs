﻿using Microsoft.EntityFrameworkCore;
using RequestTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RequestTrackerDALLibrary
{
    public class RequestRepository : IRepository<int, Request>
    {
        private readonly RequestTrackerContext _context;

        public RequestRepository(RequestTrackerContext context)
        {
            _context = context;
        }

        public async Task<Request> Add(Request entity)
        {
            _context.Requests.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<Request> DeleteByKey(int key)
        {
            var request = await GetByKey(key);
            if (request != null)
            {
                _context.Requests.Remove(request);
                await _context.SaveChangesAsync();
            }
            return request;
        }

        public async Task<Request> GetByKey(int key)
        {
            var request = await _context.Requests.Include(r => r.RequestSolutions)
        .FirstOrDefaultAsync(r => r.RequestNumber == key);

            return request;
        }

        public async Task<IList<Request>> GetAll()
        {
            return await _context.Requests.ToListAsync();
        }

        public async Task<Request> Update(Request entity)
        {
            var request = await GetByKey(entity.RequestNumber);
            if (request != null)
            {
                _context.Entry<Request>(entity).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            return entity;
        }
    }
}

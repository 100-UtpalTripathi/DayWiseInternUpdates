using Microsoft.EntityFrameworkCore;
using RequestTrackerModelLibrary;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RequestTrackerDALLibrary
{
    public class RequestSolutionRepository : IRepository<int, RequestSolution>
    {
        private readonly RequestTrackerContext _context;

        public RequestSolutionRepository(RequestTrackerContext context)
        {
            _context = context;
        }

        public async Task<RequestSolution> Add(RequestSolution entity)
        {
            _context.RequestSolutions.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<RequestSolution> DeleteByKey(int key)
        {
            var solution = await GetByKey(key);
            if (solution != null)
            {
                _context.RequestSolutions.Remove(solution);
                await _context.SaveChangesAsync();
            }
            return solution;
        }

        public async Task<RequestSolution> GetByKey(int key)
        {
            var solution = await _context.RequestSolutions.FindAsync(key);
            return solution;
        }

        public async Task<IList<RequestSolution>> GetAll()
        {
            return await _context.RequestSolutions.ToListAsync();
        }

        public async Task<RequestSolution> Update(RequestSolution entity)
        {
            var solution = await GetByKey(entity.SolutionId);
            if (solution != null)
            {
                _context.Entry<RequestSolution>(entity).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            return entity;
        }
    }
}

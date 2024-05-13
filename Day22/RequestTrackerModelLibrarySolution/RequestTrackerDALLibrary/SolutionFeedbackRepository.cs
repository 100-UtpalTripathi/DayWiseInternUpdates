using Microsoft.EntityFrameworkCore;
using RequestTrackerModelLibrary;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RequestTrackerDALLibrary
{
    public class SolutionFeedbackRepository : IRepository<int, SolutionFeedback>
    {
        private readonly RequestTrackerContext _context;

        public SolutionFeedbackRepository(RequestTrackerContext context)
        {
            _context = context;
        }

        public async Task<SolutionFeedback> Add(SolutionFeedback entity)
        {
            _context.SolutionFeedbacks.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<SolutionFeedback> DeleteByKey(int key)
        {
            var feedback = await GetByKey(key);
            if (feedback != null)
            {
                _context.SolutionFeedbacks.Remove(feedback);
                await _context.SaveChangesAsync();
            }
            return feedback;
        }

        public async Task<SolutionFeedback> GetByKey(int key)
        {
            var feedback = await _context.SolutionFeedbacks.FindAsync(key);
            return feedback;
        }

        public async Task<IList<SolutionFeedback>> GetAll()
        {
            return await _context.SolutionFeedbacks.ToListAsync();
        }

        public async Task<SolutionFeedback> Update(SolutionFeedback entity)
        {
            var feedback = await GetByKey(entity.FeedbackId);
            if (feedback != null)
            {
                _context.Entry<SolutionFeedback>(entity).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            return entity;
        }
    }
}

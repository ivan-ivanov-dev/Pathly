using Microsoft.EntityFrameworkCore;
using Pathly.Data;
using Pathly.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pathly.Services.Implementation
{
    public class SettingsService : ISettingsService
    {
        private readonly ApplicationDbContext _context;
        public SettingsService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> DeleteUserDataAsync(string userId)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                var goals = _context.Goals.Where(g => g.UserId == userId);
                var userGoalIds = await goals.Select(g => g.Id).ToListAsync();

                var roadmaps = _context.Roadmaps.Where(r => userGoalIds.Contains(r.GoalId));
                var userRoadmapIds = await roadmaps.Select(r => r.Id).ToListAsync();

                _context.Tags.RemoveRange(_context.Tags.Where(t => t.UserId == userId));
                _context.Tasks.RemoveRange(_context.Tasks.Where(t => t.UserId == userId));
                _context.Actions.RemoveRange(_context.Actions.Where(a => userRoadmapIds.Contains(a.RoadmapId)));
                _context.Roadmaps.RemoveRange(roadmaps);
                _context.Goals.RemoveRange(goals);

                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
                return true;
            }
            catch
            {
                await transaction.RollbackAsync();
                return false;
            }
        }
    }
}

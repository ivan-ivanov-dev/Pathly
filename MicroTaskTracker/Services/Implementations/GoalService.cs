using Microsoft.EntityFrameworkCore;
using MicroTaskTracker.Data;
using MicroTaskTracker.Models.DBModels;
using MicroTaskTracker.Models.ViewModels.Goals;
using MicroTaskTracker.Services.Interfaces;

namespace MicroTaskTracker.Services.Implementations
{
    public class GoalService : IGoalService
    {
        private readonly ApplicationDbContext _context; 
        public GoalService(ApplicationDbContext context) 
        { 
            _context = context; 
        }
        public async Task CreateAsync(GoalCreateViewModel model, string userId)
        {
            var goal = new Goal
            {
                Title = model.Title,
                ShortDescription = model.ShortDescription,
                TargetDate = model.TargetDate,
                IsActive = model.IsActive,
                UserId = userId
            };

            _context.Goals.Add(goal);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int id, string userId)
        {
            var goal = await _context.Goals.FirstOrDefaultAsync(g => g.Id == id);
            if (goal == null)
            {
                return false;
            }
            if(goal.UserId != userId)
            {
                throw new UnauthorizedAccessException("You do not have permission to delete this goal.");
            }

            _context.Goals.Remove(goal);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<GoalViewModel>> GetAllGoalsAsync(string userId)
        {
            var goals = await _context.Goals
                .Where(g => g.UserId == userId) 
                .Select(g => new GoalViewModel 
                { 
                    Id = g.Id, 
                    Title = g.Title, 
                    ShortDescription = g.ShortDescription, 
                    TargetDate = g.TargetDate, 
                    IsActive = g.IsActive }
                ).ToListAsync(); 
            
            return goals;
        }

        public async Task UpdateAsync(int id, GoalEditViewModel model, string userId)
        {
            var goal = await _context.Goals.FirstOrDefaultAsync(g => g.Id == id);
            if (goal == null)
            {
                throw new InvalidOperationException("Goal not found.");
            }

            if(goal.UserId != userId)
            {
                throw new UnauthorizedAccessException("You do not have permission to edit this goal.");
            }

            goal.Title = model.Title;
            goal.ShortDescription = model.ShortDescription;
            goal.TargetDate = model.TargetDate;
            goal.IsActive = model.IsActive;

            _context.Goals.Update(goal);
            await _context.SaveChangesAsync();
        }
    }
}

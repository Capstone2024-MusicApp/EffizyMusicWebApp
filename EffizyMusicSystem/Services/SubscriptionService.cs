using EffizyMusicSystem.DAL;
using EffizyMusicSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EffizyMusicSystem.Services
{
    public class SubscriptionService
    {
        private readonly EffizyMusicContext _context;

        public SubscriptionService(EffizyMusicContext context)
        {
            _context = context;
        }

        public async Task<List<SubscriptionPlan>> GetAllSubscriptions()
        {
            try
            {
                return await _context.Subscriptions.ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error getting all subscriptions: " + ex.Message);
                return null;
            }
        }

        public async Task<List<SubscriptionPlan>> GetSubscriptionsByCourseID(int courseID)
        {
            var subscriptions = await _context.Subscriptions
                                            .Where(s => s.CourseID == courseID)
                                            .ToListAsync();

            return subscriptions ?? new List<SubscriptionPlan>();
        }
        public async Task<List<SubscriptionPlan>> GetSubscriptionsAsync()
        {
            return await _context.Subscriptions.Include(s => s.Course).ToListAsync();
        }

        public async Task<SubscriptionPlan> GetSubscriptionByIdAsync(int id)
        {
            return await _context.Subscriptions.Include(s => s.Course).FirstOrDefaultAsync(s => s.SubscriptionID == id);
        }

        public async Task AddSubscriptionAsync(SubscriptionPlan subscription)
        {
            _context.Subscriptions.Add(subscription);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateSubscriptionAsync(SubscriptionPlan subscription)
        {
            _context.Entry(subscription).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteSubscriptionAsync(int id)
        {
            var subscription = await _context.Subscriptions.FindAsync(id);
            if (subscription != null)
            {
                _context.Subscriptions.Remove(subscription);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<bool> CheckExistingSubscriptionAsync(string description, int courseID)
        {
            // Check if a subscription of the same type and course already exists
            bool existingSubscription = await _context.Subscriptions
                .AnyAsync(s => s.Description == description && s.CourseID == courseID);

            return existingSubscription;
        }
    }
}

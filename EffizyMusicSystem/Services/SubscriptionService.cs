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

        public async Task<List<Subscription>> GetAllSubscriptions()
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

        public async Task<List<Subscription>> GetSubscriptionsByCourseID(int courseID)
        {
            // Query the database to get subscriptions by courseID
            var subscriptions = await _context.Subscriptions
                                            .Where(s => s.CourseID == courseID)
                                            .ToListAsync();

            return subscriptions ?? new List<Subscription>();
        }
    }
}

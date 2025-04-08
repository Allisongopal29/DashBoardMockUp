using System.Collections.Generic;
using System.Threading.Tasks;
using DashBoardMockUp.Models;

namespace DashBoardMockUp.Data
{
    public class MockApiService
    {
        public Task<DashboardData> GetDashboardDataAsync()
        {
            // Mock data
            return Task.FromResult(new DashboardData
            {
                TotalSales = 3656,
                AverageSale = 244,
                TransactionCount = 15
            });
        }

        public Task<List<MenuItem>> GetMenuItemsAsync()
        {
            return Task.FromResult(new List<MenuItem>
            {
                new MenuItem { Text = "Dashboard", Icon = "home" },
                new MenuItem { Text = "Configuration", Icon = "cog" },
                new MenuItem { Text = "System admin", Icon = "users" },
                new MenuItem { Text = "Subscriber setup", Icon = "user-plus" },
                new MenuItem { Text = "Feature requests", Icon = "lightbulb-o" },
                new MenuItem { Text = "Reports", Icon = "chart-bar" }
            });
        }

        public Task<List<string>> GetCountriesAsync()
        {
            return Task.FromResult(new List<string> { "South Africa" });
        }

        public Task<List<string>> GetBrandsAsync()
        {
            return Task.FromResult(new List<string> { "Debonairs" });
        }

        public Task<List<string>> GetLocationsAsync()
        {
            return Task.FromResult(new List<string> { "[60195] Pietermaritzburg" });
        }
    }
}

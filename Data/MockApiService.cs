using System.Collections.Generic;
using System.Threading.Tasks;
using DashBoardMockUp.Models;

namespace DashBoardMockUp.Data
{
    public class MockApiService
    {
        public Task<List<string>> GetCountriesAsync()
        {
            return Task.FromResult(new List<string>
        {
            "South Africa",
            "Nigeria",
            "Kenya",
            "Egypt",
            "United States",
            "United Kingdom",
            "Germany",
            "India",
            "China",
            "Brazil"
        });
        }

        public Task<List<string>> GetBrandsAsync()
        {
            return Task.FromResult(new List<string>
        {
            "Debonairs",
            "KFC",
            "McDonald's",
            "Pizza Hut",
            "Steers",
            "Nando's",
            "Burger King",
            "Domino's",
            "Roman's Pizza",
            "Chicken Licken"
        });
        }

        public Task<List<string>> GetLocationsAsync()
        {
            return Task.FromResult(new List<string>
        {
            "[60195] Pietermaritzburg",
            "[60201] Durban",
            "[60205] Johannesburg",
            "[60209] Cape Town",
            "[60212] Pretoria",
            "[60218] Bloemfontein",
            "[60220] Nelspruit",
            "[60225] Port Elizabeth",
            "[60230] East London",
            "[60235] Polokwane"
        });
        }
    }
}

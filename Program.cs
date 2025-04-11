using DashBoardMockUp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Services
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<MockApiService>();
builder.Services.AddHttpClient();
builder.Services.AddTelerikBlazor();

// Set Base Address for API
builder.Services.AddHttpClient("API", client =>
{
    client.BaseAddress = new Uri("https://localhost:7145/");  // Match this to your actual running port
});

// CORS Fix: Missing closing brackets and clearer setup
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

// Middleware
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseCors("AllowAll");

app.MapControllers();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();


// --------------------------- API Controllers ---------------------------

[ApiController]
[Route("api/[controller]")]
public class CountriesController : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<Country>> GetCountries()
    {
        var countries = DataProvider.GetCountries();
        return Ok(countries);
    }
}

[ApiController]
[Route("api/[controller]")]
public class BrandsController : ControllerBase
{
    [HttpGet("{countryId}")]
    public ActionResult<IEnumerable<Brand>> GetBrands(string countryId)
    {
        var brands = DataProvider.GetBrands(countryId);
        return Ok(brands);
    }
}

[ApiController]
[Route("api/[controller]")]
public class LocationsController : ControllerBase
{
    [HttpGet("{countryId}")]
    public ActionResult<IEnumerable<Location>> GetLocations(string countryId)
    {
        var locations = DataProvider.GetLocations(countryId);
        return Ok(locations);
    }
}


// --------------------------- Models ---------------------------

public class Country
{
    public string Id { get; set; }
    public string Name { get; set; }
}

public class Brand
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string CountryId { get; set; }
}

public class Location
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string CountryId { get; set; }
}


// --------------------------- Data Provider ---------------------------

public static class DataProvider
{
    private static List<Country> _countries = new()
    {
        new Country { Id = "ZA", Name = "South Africa" },
        new Country { Id = "NG", Name = "Nigeria" },
        new Country { Id = "KE", Name = "Kenya" },
        new Country { Id = "EG", Name = "Egypt" },
        new Country { Id = "US", Name = "United States" },
        new Country { Id = "UK", Name = "United Kingdom" },
        new Country { Id = "DE", Name = "Germany" },
        new Country { Id = "IN", Name = "India" },
        new Country { Id = "CN", Name = "China" },
        new Country { Id = "BR", Name = "Brazil" }
    };

    private static List<Brand> _brands = new()
    {
        new Brand { Id = "DB", Name = "Debonairs", CountryId = "ZA" },
        new Brand { Id = "KF", Name = "KFC", CountryId = "ZA" },
        new Brand { Id = "MC", Name = "McDonald's", CountryId = "US" },
        new Brand { Id = "PH", Name = "Pizza Hut", CountryId = "US" },
        new Brand { Id = "ST", Name = "Steers", CountryId = "ZA" },
        new Brand { Id = "ND", Name = "Nando's", CountryId = "ZA" },
        new Brand { Id = "BK", Name = "Burger King", CountryId = "US" },
        new Brand { Id = "DM", Name = "Domino's", CountryId = "US" },
        new Brand { Id = "RP", Name = "Roman's Pizza", CountryId = "ZA" },
        new Brand { Id = "CL", Name = "Chicken Licken", CountryId = "ZA" },
        new Brand { Id = "NB", Name = "Nigerian Breweries", CountryId = "NG" }
    };

    private static List<Location> _locations = new()
    {
        new Location { Id = "PMB", Name = "[60195] Pietermaritzburg", CountryId = "ZA" },
        new Location { Id = "DUR", Name = "[60201] Durban", CountryId = "ZA" },
        new Location { Id = "JHB", Name = "[60205] Johannesburg", CountryId = "ZA" },
        new Location { Id = "CT", Name = "[60209] Cape Town", CountryId = "ZA" },
        new Location { Id = "PTA", Name = "[60212] Pretoria", CountryId = "ZA" },
        new Location { Id = "BFN", Name = "[60218] Bloemfontein", CountryId = "ZA" },
        new Location { Id = "NEL", Name = "[60220] Nelspruit", CountryId = "ZA" },
        new Location { Id = "PE", Name = "[60225] Port Elizabeth", CountryId = "ZA" },
        new Location { Id = "EL", Name = "[60230] East London", CountryId = "ZA" },
        new Location { Id = "PLK", Name = "[60235] Polokwane", CountryId = "ZA" },
        new Location { Id = "LAG", Name = "[100001] Lagos", CountryId = "NG" },
        new Location { Id = "ABJ", Name = "[900001] Abuja", CountryId = "NG" }
    };

    public static List<Country> GetCountries() => _countries;
    public static List<Brand> GetBrands(string countryId) => _brands.Where(b => b.CountryId == countryId).ToList();
    public static List<Location> GetLocations(string countryId) => _locations.Where(l => l.CountryId == countryId).ToList();
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class LocationsController : ControllerBase
{
    private readonly AppDbContext _context;

    public LocationsController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetLocations()
    {
        var points = await _context.Locations
            .Select(l => new
            {
                l.Id,
                l.Name,
                l.Type,
                Latitude = l.Geom.Y,
                Longitude = l.Geom.X
            })
            .ToListAsync();

        return Ok(points);
    }
    // DTO Class
    public class KecamatanSummaryDto
    {
        public string Kecamatan { get; set; } = "";
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int Negeri { get; set; }
        public int Swasta { get; set; }
        public int A { get; set; }
        public int B { get; set; }
        public int C { get; set; }
        public int ISO2000 { get; set; }
        public int ISO2008 { get; set; }
        public int Jumlah { get; set; }
    }
    [HttpGet("summary")]
    public IActionResult GetKecamatans()
    {
        var data = new List<KecamatanSummaryDto>
        {
            new() { Kecamatan = "Kec. Tanah Sareal", Latitude = -6.5734, Longitude = 106.7842, Negeri = 0, Swasta = 10, A = 0, B = 2, C = 3, ISO2000 = 0, ISO2008 = 0, Jumlah = 10 },
            new() { Kecamatan = "Kec. Kota Bogor Tengah", Latitude = -6.5950, Longitude = 106.7980, Negeri = 0, Swasta = 8, A = 0, B = 1, C = 4, ISO2000 = 0, ISO2008 = 0, Jumlah = 8 },
            new() { Kecamatan = "Kec. Kota Bogor Selatan", Latitude = -6.6486, Longitude = 106.8152, Negeri = 0, Swasta = 7, A = 0, B = 0, C = 2, ISO2000 = 0, ISO2008 = 0, Jumlah = 7 },
            new() { Kecamatan = "Kec. Kota Bogor Barat", Latitude = -6.6050, Longitude = 106.7571, Negeri = 0, Swasta = 5, A = 0, B = 1, C = 2, ISO2000 = 0, ISO2008 = 0, Jumlah = 5 },
            new() { Kecamatan = "Kec. Kota Bogor Utara", Latitude = -6.5709, Longitude = 106.8018, Negeri = 0, Swasta = 5, A = 0, B = 0, C = 1, ISO2000 = 0, ISO2008 = 0, Jumlah = 5 },
            new() { Kecamatan = "Kec. Kota Bogor Timur", Latitude = -6.6003, Longitude = 106.8216, Negeri = 0, Swasta = 2, A = 0, B = 1, C = 0, ISO2000 = 0, ISO2008 = 0, Jumlah = 2 }
        };

        return Ok(data);
    }

}

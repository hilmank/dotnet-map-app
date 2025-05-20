Sure! Here's the **full `README.md` content in Markdown format**. You can copy and paste it directly into your `README.md` file:

---

````markdown
# Interactive Map Application

An interactive web-based map application built with ASP.NET Core (Backend) and Leaflet.js (Frontend). It visualizes geospatial data (e.g., schools, districts) on a map, powered by PostGIS or static GeoJSON files.

---

## 🧭 Features

- 🗺️ Dynamic map rendering using Leaflet.js
- 📍 Display spatial points and polygon overlays
- 🔄 Backend API built with ASP.NET Core & Entity Framework Core
- 🌍 Supports both PostGIS and GeoJSON as spatial data sources
- 📁 Organized folder structure for maintainability

---

## 🚀 Getting Started

### Prerequisites

- [.NET SDK 9.0+](https://dotnet.microsoft.com/download)
- PostgreSQL with PostGIS extension (if using spatial DB)
- Visual Studio 2022+ or VS Code
- A modern web browser

### Setup Instructions

1. **Clone the repository** (or extract ZIP):
   ```bash
   git clone https://your-repo-url.git
   cd map
````

2. **Configure the backend API**:

   * Edit `Backend/appsettings.json`:

     ```json
     "ConnectionStrings": {
       "DefaultConnection": "Host=localhost;Database=MapDb;Username=postgres;Password=yourpassword"
     }
     ```

3. **Run the API service**:

   ```bash
   dotnet run --project Backend
   ```

4. **View the map**:

   * Open the `index.html` in your browser (if a frontend exists), or integrate the API into a map viewer.

---

## 🗂️ Folder Structure

```
map/
├── map.sln                     # Visual Studio Solution
├── .vscode/                   # Editor settings
├── Backend/                   # ASP.NET Core backend
│   ├── AppDbContext.cs
│   ├── Program.cs
│   ├── appsettings.json
│   ├── Backend.csproj
│   └── Controllers/
│       └── LocationController.cs
```

---

## 🌍 Sample Spatial Data Sources

### 🔸 1. PostGIS Integration

To pull spatial data from PostGIS, use this example:

```sql
CREATE TABLE locations (
    id SERIAL PRIMARY KEY,
    name TEXT,
    type TEXT,
    geometry GEOMETRY(Point, 4326)
);
```

Insert sample:

```sql
INSERT INTO locations (name, type, geometry)
VALUES
  ('SMP 1 Bogor', 'SMP', ST_GeomFromText('POINT(106.806039 -6.595038)', 4326));
```

Your backend can return GeoJSON like this:

```csharp
[HttpGet("summary")]
public async Task<IActionResult> GetLocations()
{
    var sql = "SELECT id, name, type, ST_AsGeoJSON(geometry) as geojson FROM locations";
    var results = await _connection.QueryAsync<LocationDto>(sql);
    return Ok(results);
}
```

Then render it with Leaflet:

```javascript
fetch('/api/locations/summary')
  .then(res => res.json())
  .then(data => {
    data.forEach(loc => {
      const geo = JSON.parse(loc.geojson);
      L.geoJSON(geo).bindPopup(`${loc.name} (${loc.type})`).addTo(map);
    });
  });
```

---

### 🔸 2. Static GeoJSON File

To display district boundaries or similar shapes:

1. Save the GeoJSON file in `wwwroot/data/`:

   ```
   wwwroot/data/kecamatan_bogor.geojson
   ```

2. Add this in your `index.html`:

```html
<script>
  fetch('/data/kecamatan_bogor.geojson')
    .then(res => res.json())
    .then(data => {
      L.geoJSON(data, {
        style: {
          color: '#3388ff',
          weight: 2
        }
      }).addTo(map);
    });
</script>
```

---

## 📦 Dependencies

* [.NET 9.0](https://dotnet.microsoft.com/download)
* ASP.NET Core Web API
* Dapper / Entity Framework Core
* PostgreSQL + PostGIS
* Leaflet.js
* D3.js (optional, for color scales or data visualization)

---

## 📄 License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.

---

## ✨ Screenshots (Optional)

![image](https://github.com/user-attachments/assets/8463edad-054c-4921-89f2-fbe068924ec2)


---


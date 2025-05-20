using NetTopologySuite.Geometries;

public class Location
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string Type { get; set; } = "";
    public Point Geom { get; set; } = default!;
}

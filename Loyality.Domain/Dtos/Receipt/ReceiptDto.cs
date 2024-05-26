namespace Loyality.Domain.Dtos.Receipt;

public class ReceiptDto
{
    public string? Locale { get; set; }
    public string? Description { get; set; }
    public BoundingPoly? BoundingPoly { get; set; }
}

public class BoundingPoly
{
    public List<Vertex>? Vertices { get; set; }
}

public class Vertex
{
    public int X { get; set; }
    public int Y { get; set; }
    
    
}

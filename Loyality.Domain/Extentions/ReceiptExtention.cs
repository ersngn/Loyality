using Loyality.Domain.Dtos.Receipt;

namespace Loyality.Domain.Extentions;

public static class ReceiptExtention
{
    public static List<string> GetReceiptDescription(List<ReceiptDto> receipts)
    {
        var lines = receipts
            .Where(r => r.Locale == null && string.IsNullOrWhiteSpace(r.Locale))
            .Select(r => new SortedReceiptDto
            {
                Description = r.Description,
                MinX = r.BoundingPoly.Vertices.Min(v => v.X),
                MaxX = r.BoundingPoly.Vertices.Max(v=>v.X),
                MinY = r.BoundingPoly.Vertices.Min(v=>v.Y)
            }).OrderBy(e=>e.MinY).ToList();
        
        var sortedlines = new List<SortedReceiptDto>();
        

        for (int i = 0; i < lines.Count; i++)
        {
            if (i == 0)
            {
                sortedlines.Add(lines[i]);
                continue;
            }

            if (lines[i].MinX < sortedlines.Last().MaxX)
                sortedlines.Add(lines[i]);
            else 
                sortedlines.Last().Description=string.Concat(sortedlines.Last().Description," ", lines[i].Description);
        }

        var result = sortedlines.Select(e => e.Description).ToList();

        return result;
    }
}
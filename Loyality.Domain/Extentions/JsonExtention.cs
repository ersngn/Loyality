using Newtonsoft.Json;

namespace Loyality.Domain.Extentions;

public static class JsonExtention<T> where T: class,new()
{
    public static T? DeserilizeJsonString(string text)
    {
        var result = JsonConvert.DeserializeObject<T>(text);
        return result;
    }
}
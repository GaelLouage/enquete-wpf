using Newtonsoft.Json;

namespace Enquete.Models;

public class EnqueteEntity
{
    [JsonProperty("geboorteJaar")]
    public int GeboorteJaar { get; set; }

    [JsonProperty("geslacht")]
    public string Geslacht { get; set; }

    [JsonProperty("vervoersMiddel")]
    public string VervoersMiddel { get; set; }
}
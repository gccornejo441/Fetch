using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Fetch.Models
{
    public class Movies
    {
        [JsonPropertyName("tconst")]
        public string Tconst { get; set; }

        [JsonPropertyName("title_type")]
        public string TitleType { get; set; }

        [JsonPropertyName("primary_title")]
        public string PrimaryTitle { get; set; }

        [JsonPropertyName("original_title")]
        public string OriginalTitle { get; set; }

        [JsonPropertyName("year")]
        public int Year { get; set; }

        [JsonPropertyName("runtime_minutes")]
        public object RuntimeMinutes { get; set; }

        [JsonPropertyName("genres")]
        public string Genres { get; set; }

        [JsonPropertyName("simple_title")]
        public string SimpleTitle { get; set; }

        [JsonPropertyName("average_rating")]
        public double AverageRating { get; set; }

        [JsonPropertyName("num_votes")]
        public int NumVotes { get; set; }

        [JsonPropertyName("christmas")]
        public string Christmas { get; set; }

        [JsonPropertyName("hanukkah")]
        public string Hanukkah { get; set; }

        [JsonPropertyName("kwanzaa")]
        public string Kwanzaa { get; set; }

        [JsonPropertyName("holiday")]
        public string Holiday { get; set; }
    }


}

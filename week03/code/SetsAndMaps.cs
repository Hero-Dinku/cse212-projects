using System.Text.Json;

public static class SetsAndMaps
{
    public static string[] FindPairs(string[] words)
    {
        HashSet<string> seen = new HashSet<string>();
        List<string> pairs = new List<string>();
        
        foreach (string word in words)
        {
            if (word[0] == word[1])
            {
                continue;
            }
            
            string reversed = $"{word[1]}{word[0]}";
            
            if (seen.Contains(reversed))
            {
                pairs.Add($"{reversed} & {word}");
            }
            
            seen.Add(word);
        }
        
        return pairs.ToArray();
    }

    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        var degrees = new Dictionary<string, int>();
        foreach (var line in File.ReadLines(filename))
        {
            var fields = line.Split(",");
            
            if (fields.Length >= 4)
            {
                string degree = fields[3].Trim();
                
                if (degrees.ContainsKey(degree))
                {
                    degrees[degree]++;
                }
                else
                {
                    degrees[degree] = 1;
                }
            }
        }

        return degrees;
    }

    public static bool IsAnagram(string word1, string word2)
    {
        string cleanWord1 = word1.Replace(" ", "").ToLower();
        string cleanWord2 = word2.Replace(" ", "").ToLower();
        
        if (cleanWord1.Length != cleanWord2.Length)
        {
            return false;
        }
        
        Dictionary<char, int> charCount = new Dictionary<char, int>();
        
        foreach (char c in cleanWord1)
        {
            if (charCount.ContainsKey(c))
            {
                charCount[c]++;
            }
            else
            {
                charCount[c] = 1;
            }
        }
        
        foreach (char c in cleanWord2)
        {
            if (!charCount.ContainsKey(c))
            {
                return false;
            }
            
            charCount[c]--;
            
            if (charCount[c] == 0)
            {
                charCount.Remove(c);
            }
        }
        
        return charCount.Count == 0;
    }

    public static string[] EarthquakeDailySummary()
    {
        const string uri = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";
        using var client = new HttpClient();
        using var getRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
        using var jsonStream = client.Send(getRequestMessage).Content.ReadAsStream();
        using var reader = new StreamReader(jsonStream);
        var json = reader.ReadToEnd();
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        var featureCollection = JsonSerializer.Deserialize<FeatureCollection>(json, options);
        
        List<string> summaries = new List<string>();
        
        if (featureCollection?.Features != null)
        {
            foreach (var feature in featureCollection.Features)
            {
                if (feature.Properties != null)
                {
                    summaries.Add($"{feature.Properties.Place} - Mag {feature.Properties.Mag}");
                }
            }
        }
        
        return summaries.ToArray();
    }
}

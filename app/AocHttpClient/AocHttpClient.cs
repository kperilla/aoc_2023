namespace AdventOfCodeRunner
{
    public class AocHttpClient
    {
        public static async Task<string> MakeGetRequest(string url, string sessionKey)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Cookie", "session=" + sessionKey);
                try
                {
                    // Making the GET request
                    HttpResponseMessage response = await httpClient.GetAsync(url);

                    // Checking if the request was successful (status code 200 OK)
                    if (response.IsSuccessStatusCode)
                    {
                        // Reading the content of the response
                        string content = await response.Content.ReadAsStringAsync();
                        return content;
                    }
                    else
                    {
                        Console.WriteLine($"HTTP request failed with status code {response.StatusCode}");
                        return string.Empty;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                    throw;
                }
            }
        }
    }
}
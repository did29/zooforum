using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

public class DogApiClient
    {
        private const string BaseUrl = "https://dog.ceo/api/";

        public async Task<string> GetRandomDogImageAsync()
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync($"{BaseUrl}breeds/image/random");

                if (response.IsSuccessStatusCode)
                {
                    var imageResponse = await response.Content.ReadAsStringAsync();
                    var dogImage = JsonConvert.DeserializeObject<DogImageResponse>(imageResponse);
                    return dogImage?.Message;
                }

                // Handle error cases
                return null;
            }
        }
    }

    public class DogImageResponse
    {
        public string Message { get; set; }
    }

}
}

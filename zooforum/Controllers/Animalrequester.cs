using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.Net.Http.Headers;


namespace zooforum
{
    public class AnimalRequester
    {
        private readonly string dogApiKey;

        private readonly HttpClient httpClient;

        private const string DOG_URL = "https://api.thedogapi.com/";

        public AnimalRequester(string apiKey)
        {
            httpClient = new HttpClient { BaseAddress = new Uri(DOG_URL) };
            dogApiKey = apiKey;
            httpClient.DefaultRequestHeaders.Authorization
                = new AuthenticationHeaderValue("live_facp0Z1QxYUgk18rlw5tYEMzZfvPWVkgTa27FZKs89l6beF6edNsglX5TugU8LJV", dogApiKey);
        }

        public async Task<string> GetRandomDogImageAsync(string apiKey)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("live_facp0Z1QxYUgk18rlw5tYEMzZfvPWVkgTa27FZKs89l6beF6edNsglX5TugU8LJV", apiKey); 
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


        public async Task<List<DogBreed>> GetBreedsAsync(DogBreedSearchParams searchParams)
        {
            string queryString = Utility.GetQueryString(searchParams);
            string jsonReply = string.Empty;

            using (HttpResponseMessage response = await httpClient.GetAsync($"v1/breeds?{queryString}"))
            {
                jsonReply = await response.Content.ReadAsStringAsync();
            }
            List<DogBreed> breedsReply = JsonConvert.DeserializeObject<List<DogBreed>>(jsonReply);

            return breedsReply;
        }

   
        public async Task<List<DogBreed>> GetBreedAsync(string breedName)
        {
            string jsonReply = string.Empty;

            using (HttpResponseMessage response = await httpClient.GetAsync($"v1/breeds/search?q={breedName}"))
            {
                jsonReply = await response.Content.ReadAsStringAsync();
            }
            List<DogBreed> breedsReply = JsonConvert.DeserializeObject<List<DogBreed>>(jsonReply);

            return breedsReply;
        }
    }
}
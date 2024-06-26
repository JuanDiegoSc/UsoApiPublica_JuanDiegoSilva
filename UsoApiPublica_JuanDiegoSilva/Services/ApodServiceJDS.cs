using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsoApiPublica_JuanDiegoSilva.Models;
using Windows.Media.Protection.PlayReady;

namespace UsoApiPublica_JuanDiegoSilva.Services
{
    public class ApodServiceJDS
    {
        public async Task<ApodJDS> GetImage_JDS(DateTime dt)
        {
            ApodJDS dto = null;
            HttpResponseMessage response;
            string requestUrl = $"https://api.nasa.gov/planetary/apod?date={dt.ToString("yyyy MMdd")}&api_key= eECk6iuObvyAmoPtQrsAV3fx4O1fpAtx6isgf6fI";
            try
            {

                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, requestUrl);
                HttpClient client = new HttpClient();
                response = await client.SendAsync(request);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    dto = JsonConvert.DeserializeObject<ApodJDS>(json);
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                throw;
            }
            return dto;

        }
    }
}

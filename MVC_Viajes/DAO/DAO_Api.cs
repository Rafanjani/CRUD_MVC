using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Viajes.DAO
{
    public class DAO_Api
    {
        private static string _URL;
        private static HttpClient _client;

        static DAO_Api()
        {
            IndicateURL();
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            _client = new HttpClient();
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _client.BaseAddress = new Uri(_URL);
        }

        private static void IndicateURL()
        {
            _URL = Properties.Resource.API_URL;
        }

        public static async Task<TEntity> GetAsync<TEntity>(string URLPath) //GET
        {
            TEntity responseEntity = default;

            try
            {
                HttpResponseMessage response = await _client.GetAsync(URLPath);

                if (response.IsSuccessStatusCode)
                {
                    responseEntity = await response.Content.ReadAsAsync<TEntity>();
                }
            }
            catch (Exception ex)
            {

            }

            return responseEntity;
        }

        public static async Task<TEntity> PostAsync<TEntity>(string URLPath, TEntity entity) //POST
        {
            TEntity responseEntity = default;

            try
            {
                HttpResponseMessage response = await _client.PostAsJsonAsync(URLPath, entity);

                if (response.IsSuccessStatusCode)
                {
                    responseEntity = await response.Content.ReadAsAsync<TEntity>();
                }
            }
            catch (Exception ex)
            {

            }

            return responseEntity;
        }

        public static async Task<TEntity> PutAsync<TEntity>(string URLPath, TEntity entity) //PUT
        {
            TEntity responseEntity = default;

            try
            {
                HttpResponseMessage response = await _client.PutAsJsonAsync(URLPath, entity);

                if (response.IsSuccessStatusCode)
                {
                    responseEntity = await response.Content.ReadAsAsync<TEntity>();
                }
            }
            catch (Exception ex)
            {

            }

            return responseEntity;
        }

        public static async Task<TEntity> DeleteAsync<TEntity>(string URLPath) //Delete
        {
            TEntity responseEntity = default;

            try
            {
                HttpResponseMessage response = await _client.DeleteAsync(URLPath);

                if (response.IsSuccessStatusCode)
                {
                    responseEntity = await response.Content.ReadAsAsync<TEntity>();
                }
            }
            catch (Exception ex)
            {

            }

            return responseEntity;
        }
    }
}

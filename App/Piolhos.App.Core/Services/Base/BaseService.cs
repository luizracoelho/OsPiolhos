using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Piolhos.App.Core.Services.Base
{
    public class BaseService<T> where T : class
    {
        /// <summary>
        /// Método que retorna a Uri para conexão com a REST Api
        /// </summary>
        /// <param name="action">Action da Api</param>
        /// <returns>Uri</returns>
        private Uri GetUri(string action)
        {
            string _dev = $"http://192.168.15.14/Piolhos/api/";
            string _dist = $"http://onsoft.ddns.net:8081/ospiolhos/api/";

            string _baseUrl = _dist;
            return new Uri($"{_baseUrl}{action}");
        }

        /// <summary>
        /// Retorna uma lista da API
        /// </summary>
        /// <param name="url">URL da API</param>
        /// <returns>Lista</returns>
        public virtual async Task<List<T>> ListAsync(string url)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var response = await client.GetAsync(GetUri(url));
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        var result = JsonConvert.DeserializeObject<List<T>>(content);

                        return result;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Retorna uma entidade da API
        /// </summary>
        /// <param name="url">URL da API</param>
        /// <returns>Entidade</returns>
        public virtual async Task<T> GetAsync(string url)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var response = await client.GetAsync(GetUri(url));
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        var result = JsonConvert.DeserializeObject<T>(content);

                        return result;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public virtual async Task<bool> PostAsync(string url, T entidade)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                    var json = JsonConvert.SerializeObject(entidade);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    var response = await client.PostAsync(GetUri(url), content);

                    return response.IsSuccessStatusCode ? true : false;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public virtual async Task<TResult> PostWithReturnAsync<TResult>(string url, T entidade) where TResult : class
        {
            try
            {
                using (var client = new HttpClient())
                {
                    //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                    var json = JsonConvert.SerializeObject(entidade);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    var response = await client.PostAsync(GetUri(url), content);

                    if (response.IsSuccessStatusCode)
                    {
                        var respContent = await response.Content.ReadAsStringAsync();
                        var result = JsonConvert.DeserializeObject<TResult>(respContent);

                        return result;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public virtual async Task<bool> PostWithReturnBooleanAsync(string url, T entidade)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                    var json = JsonConvert.SerializeObject(entidade);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    var response = await client.PostAsync(GetUri(url), content);

                    if (response.IsSuccessStatusCode)
                    {
                        var respContent = await response.Content.ReadAsStringAsync();
                        var result = Convert.ToBoolean(respContent);

                        return result;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

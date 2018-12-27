using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SertzHir.Core;
using SertzHir.Core.Interfaces;

namespace SertzHir.Common
{
    public class ApiHandler:IApiHandler
    {
       

        private string _apiBaseUri;

        public ApiHandler()
        {
            
            _apiBaseUri = ConfigurationManager.AppSettings["WebApiUri"];
        }
        public async Task<T> GetAsync<T>(string routePrefix, string route, Dictionary<string, string> urlParameters, string personId)
        {
            try
            {
                var handler = new HttpClientHandler()
                {
                    UseDefaultCredentials = true

                };

                using (var client = new HttpClient(handler))
                {
                    
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    //Get dictionary values
                    var urlParams = "";
                    foreach (KeyValuePair<string, string> entry in urlParameters)
                    {
                        urlParams += urlParams.Length > 0 ? "&" : "";
                        urlParams += entry.Key.Trim() + "=" + entry.Value.Trim();
                    }

                    client.DefaultRequestHeaders.Add("_userId", personId);

                    var rawResult = client.GetAsync(CreateApiUrl(routePrefix, route, urlParams)).Result;

                    if (rawResult.StatusCode == HttpStatusCode.OK)
                    {
                        var jsonResult = await rawResult.Content.ReadAsStringAsync();
                        var apiResult = JsonConvert.DeserializeObject<T>(jsonResult);
                        return apiResult;
                    }
                    else
                    {
                        var jsonResult = await rawResult.Content.ReadAsStringAsync();
                        var apiResult = JsonConvert.DeserializeObject<Result>(jsonResult);
                        throw new InvalidOperationException("Status: " + rawResult.ReasonPhrase + "\n" + "Message: " + apiResult.Message);

                    }

                }
            }
            catch (Exception e)
            {
                throw new InvalidOperationException("Error");

            }
        }


        public async Task<T> GetAsync<T>(string routePrefix, string route, Dictionary<string, string> urlParameters)
        {
            try
            {
            
                using (var client = new HttpClient())
                {

                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    //Get dictionary values
                    var urlParams = "";
                    foreach (KeyValuePair<string, string> entry in urlParameters)
                    {
                        urlParams += urlParams.Length > 0 ? "&" : "";
                        urlParams += entry.Key.Trim() + "=" + entry.Value.Trim();
                    }

                    var rawResult = client.GetAsync(CreateApiUrl(routePrefix, route, urlParams)).Result;

                    if (rawResult.StatusCode == HttpStatusCode.OK)
                    {
                        var jsonResult = await rawResult.Content.ReadAsStringAsync();
                        var apiResult = JsonConvert.DeserializeObject<T>(jsonResult);
                        return apiResult;
                    }
                    else
                    {
                        var jsonResult = await rawResult.Content.ReadAsStringAsync();
                        var apiResult = JsonConvert.DeserializeObject<Result>(jsonResult);
                        throw new InvalidOperationException("Status: " + rawResult.ReasonPhrase + "\n" + "Message: " + apiResult.Message);

                    }

                }
            }
            catch (Exception e)
            {
                throw new InvalidOperationException("Error");

            }
        }
        public async Task<T> GetAsync<T>(string routePrefix, string route)
        {
            try
            {
                using (var client = new HttpClient())
                {

                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                   
                    var rawResult = client.GetAsync(CreateApiUrl(routePrefix, route)).Result;

                    if (rawResult.StatusCode == HttpStatusCode.OK)
                    {
                        var jsonResult = await rawResult.Content.ReadAsStringAsync();
                        var apiResult = JsonConvert.DeserializeObject<T>(jsonResult);
                        return apiResult;
                    }
                    else
                    {
                        var jsonResult = await rawResult.Content.ReadAsStringAsync();
                        var apiResult = JsonConvert.DeserializeObject<Result>(jsonResult);
                        throw new InvalidOperationException("Status: " + rawResult.ReasonPhrase + "\n" + "Message: " + apiResult.Message);

                    }

                }
            }
            catch (Exception e)
            {
                throw new InvalidOperationException("Error");

            }
        }

        public async Task<T> PostAsync<T>(string routePrefix, string route,Object obj)
        {
            try
            {
              

                using (var client = new HttpClient())
                {

                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                   
                    StringContent content = new StringContent(JsonConvert.SerializeObject(obj),Encoding.UTF8, "application/json");
                    var rawResult = client.PostAsync(CreateApiUrl(routePrefix, route),content).Result;

                    if (rawResult.StatusCode == HttpStatusCode.OK)
                    {
                        var jsonResult = await rawResult.Content.ReadAsStringAsync();
                        var apiResult = JsonConvert.DeserializeObject<T>(jsonResult);
                        return apiResult;
                    }
                    else
                    {
                        var jsonResult = await rawResult.Content.ReadAsStringAsync();
                        var apiResult = JsonConvert.DeserializeObject<Result>(jsonResult);
                        throw new InvalidOperationException("Status: " + rawResult.ReasonPhrase + "\n" + "Message: " + apiResult.Message);

                    }

                }
            }
            catch (Exception e)
            {
                throw new InvalidOperationException("Error");

            }
        }

        public async Task<T> PutAsync<T>(string routePrefix, string route, Object obj)
        {
            try
            {

                using (var client = new HttpClient())
                {

                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    StringContent content = new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");
                    var rawResult = client.PutAsync(CreateApiUrl(routePrefix, route), content).Result;

                    if (rawResult.StatusCode == HttpStatusCode.OK)
                    {
                        var jsonResult = await rawResult.Content.ReadAsStringAsync();
                        var apiResult = JsonConvert.DeserializeObject<T>(jsonResult);
                        return apiResult;
                    }
                    else
                    {
                        var jsonResult = await rawResult.Content.ReadAsStringAsync();
                        var apiResult = JsonConvert.DeserializeObject<Result>(jsonResult);
                        throw new InvalidOperationException("Status: " + rawResult.ReasonPhrase + "\n" + "Message: " + apiResult.Message);
                    }
                }
            }
            catch (Exception e)
            {
                throw new InvalidOperationException("Error");

            }
        }

        private string CreateApiUrl(string routePrefix, string route, string urlParameters)
        {
            return _apiBaseUri + "/" + routePrefix + "/" + route + "?" + urlParameters;
        }

        private string CreateApiUrl(string routePrefix, string route)
        {
            return _apiBaseUri + "/" + routePrefix + "/" + route;
        }
    }

   
}

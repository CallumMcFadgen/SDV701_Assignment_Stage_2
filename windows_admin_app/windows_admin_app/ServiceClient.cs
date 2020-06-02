using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;     // just for testing, will need to be removed later on (no UI elements in a biz class)

namespace windows_admin_app
{
    public static class ServiceClient
    {
        #region GET ROUTES
        internal async static Task<List<string>> GetAuthorNamesAsync()
        {
            using (HttpClient lcHttpClient = new HttpClient())
                return JsonConvert.DeserializeObject<List<string>>
                (await lcHttpClient.GetStringAsync("http://localhost:60064/api/store/GetAuthorNames/"));
        }

        internal async static Task<clsAuthor> GetAuthorAsync(string prAuthorName)
        {
            using (HttpClient lcHttpClient = new HttpClient())
                return JsonConvert.DeserializeObject<clsAuthor>
                (await lcHttpClient.GetStringAsync
                ("http://localhost:60064/api/store/GetAuthor?Name=" + prAuthorName));
        }
        #endregion

        #region GENERIC INSERT/UPDATE METHOD
        private async static Task<string> InsertOrUpdateAsync<TItem>(TItem prItem, string prUrl, string prRequest)
        {
            using (HttpRequestMessage lcReqMessage = new HttpRequestMessage(new HttpMethod(prRequest), prUrl))
            using (lcReqMessage.Content =
            new StringContent(JsonConvert.SerializeObject(prItem), Encoding.UTF8, "application/json"))
            using (HttpClient lcHttpClient = new HttpClient())
            {
                HttpResponseMessage lcRespMessage = await lcHttpClient.SendAsync(lcReqMessage);
                return await lcRespMessage.Content.ReadAsStringAsync();
            }
        }
        #endregion

        #region POST ROUTES
        internal async static Task<string> InsertAuthorAsync(clsAuthor prAuthor)
        {
            return await InsertOrUpdateAsync(prAuthor, "http://localhost:60064/api/store/PostAuthor", "POST");
        }
        #endregion

        #region PUT ROUTES
        internal async static Task<string> UpdateAuthorAsync(clsAuthor prAuthor)
        {
            return await InsertOrUpdateAsync(prAuthor, "http://localhost:60064/api/store/PutAuthor", "PUT");
        } 
        #endregion
    }
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ProjetPhoneDaveMuret.DataAccess
{
    class ConnectionDataAccess
    {
        public ConnectionDataAccess()
        {

        }

        public async Task<List<String>> getAsyncUserInfos(String userName, String pwd)
        {
            var url = new Uri("http://webapiphone.azurewebsites.net/api/administrateurs/VerifierIdentifiant/?login=" + userName + "&password=" + pwd);

            HttpClient client = new HttpClient();
            var json = await client.GetStringAsync(url);

            return JsonConvert.DeserializeObject<List<String>>(json);
        }
        
    }
}

using CRMPromeServices.Controllers;
using CRMPromeServices.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CRMPromeServices.Services
{
    public class MailAzureService
    {
        private HttpClient _httpClient;
        private string logicAppUri;

        /*
         * logicAppUri
         Opción 1:CONVENIENTE ---> Api Key Vault. Chequear si desde el 200 (local o al IIS) puedo obtener variables de nuestra
         nube Azure.

        Opción 2: Web.Config (appSettings).
         */

        public MailAzureService()
        {
            //Inyección de dependencia (inyección de servicios en Entity Framework 4.6.2)
            this._httpClient = new HttpClient();
            this.logicAppUri = "https://prod-08.eastus2.logic.azure.com:443/workflows/58f13f2db7db4b2cb4640a8af3cbd2d1/triggers/manual/paths/invoke?api-version=2016-10-01&sp=%2Ftriggers%2Fmanual%2Frun&sv=1.0&sig=4esKB41M8jjlu5HYNxcOLyGBIkEr7Dsd6r172aXAgqo";

            //recibo la info desde crm
            string jsonFromJs = @"{
    ""properties"": {
        ""properties"": {
                ""properties"": {
                    ""Customer"": {
                        ""type"": ""Matias""
                    },
                ""Email"": {
                        ""type"": ""mmoralez@provinciamicrocreditos.com""
                },
                ""Observation"": {
                        ""type"": ""observacion""
                },
                ""Resolution"": {
                        ""type"": ""A""
                }
                },
            ""type"": ""object""
        },
        ""type"": {
                ""type"": ""string""
        }
        },
    ""type"": ""object""
}";

            //EmailModel emailToSend = new EmailModel();
            //emailToSend = JsonConvert.DeserializeObject<EmailModel>(jsonFromJs);
            _ = SendMail(jsonFromJs);
        }

        public async Task SendMail(string email)
        {
            try
            {
                using (this._httpClient)
                {
                    //Serializar el mail a json
                    //string json = JsonConvert.SerializeObject(email, Formatting.Indented);
                    string json = email;
                    HttpContent httpContent = new StringContent(json, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await this._httpClient.PostAsync(logicAppUri, httpContent);
                    //await this._httpClient.PostAsync(this.logicAppUri, httpContent);

                    if (response.IsSuccessStatusCode)
                    {
                        Console.WriteLine("Llamada a la Logic App exitosa.");
                        string responseBody = await response.Content.ReadAsStringAsync();
                        Console.WriteLine("Respuesta: " + responseBody);
                    }
                    else
                    {
                        Console.WriteLine("Error en la llamada a la Logic App. Código de estado: " + response.StatusCode);
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error en el envío de mail " + e.Message);
            }
        }

        public static implicit operator MailAzureService(APIResponse v)
        {
            throw new NotImplementedException();
        }
    }
}
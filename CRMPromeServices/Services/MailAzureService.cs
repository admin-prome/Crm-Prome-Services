using CRMPromeServices.Controllers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
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
            //instanciar logAppUri
        }


        public void SendMail(EmailModel email)
        {

            try
            {


                //Serializar el mail a json
                string json = JSONConverter.(email);
                

                HttpContent httpContent = new StringContent(json, Encoding.UTF8, "application/json");
                this._httpClient.PostAsync(this.logicAppUri, httpContent);
                //Validarel Post Async...Qué hacer si retorna un error?--> Tirar excepción
            }
            catch (Exception e)
            {
                throw new Exception("Error en el envío de mail " + e.Message);
            }


        }






    }
}
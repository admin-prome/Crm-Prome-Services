using CRMPromeServices.Models;
using CRMPromeServices.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace CRMPromeServices.Controllers
{

    [Route("api/[controller]")]
    public class MailServiceController : ApiController
    {
        //Propiedades (Atributos)
        private APIResponse _response;
        private MailAzureService _mailAzureService;


        //Constructor
        public MailServiceController()
        {
            this._response = new APIResponse();
            this._mailAzureService = new MailAzureService();
        }

        [HttpGet]
        [Route("elget")]
        public IHttpActionResult miString()
        {
            return Ok("todo ok");
        }

        [HttpPost]
        //public IHttpActionResult SendMailFogaba(EmailModel email)
        public async Task<IHttpActionResult> SendMailFogabaAsync(string email)
        {
            try
            {
               /* if (!ValidateMail(email))
                {
                    //validar información de negocio
                    throw new Exception("Datos inválidos!");

                }*/
                await this._mailAzureService.SendMail(email);
                _response.IsSuccess = true;
                _response.StatusCode = HttpStatusCode.OK;    

                return Ok(_response);
            }
            catch(Exception e)
            {
                return BadRequest("Error interno. Contactar a soporte." + e.Message);
            }
        }

        private bool ValidateMail(EmailModel email)
        {
            throw new NotImplementedException();
        }
    }
}

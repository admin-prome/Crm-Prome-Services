using CRMPromeServices.Models;
using CRMPromeServices.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CRMPromeServices.Controllers
{
    public class MailServiceController : ApiController
    {
        //Propiedades (Atributos)
        private APIResponse _response;
        private MailAzureService _mailAzureService;


        //Constructor
        public MailServiceController()
        {
            this._mailAzureService = new MailAzureService();
        }


       
        public IHttpActionResult SendMailFogaba(EmailModel email)
        {
            try
            {
                if (!ValidateMail(email))
                {
                    //validar información de negocio
                    throw new Exception("Datos inválidos!");

                }
                this._mailAzureService.SendMail(email);
                _response.IsSuccess = true;
                _response.StatusCode = HttpStatusCode.OK;    

                return Ok(_response);
            }
            catch(Exception e)
            {
                return BadRequest("Error interno. Contactar a soporte.");
            }
        }

        private bool ValidateMail(EmailModel email)
        {
            throw new NotImplementedException();
        }
    }
}

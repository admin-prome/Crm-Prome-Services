using System.Collections.Generic;

namespace CRMPromeServices.Controllers
{
    public class EmailModel
    {
        private string cc { get; set; }
        private string cco { get; set; }
        private string subject { get; set; }
        private string body { get; set; }


        public EmailModel()
        {

        }

        public EmailModel(string cc, string cco, string subj, string body)
        {
            this.cc = cc;
            this.cco = cco;
            this.subject = subj;
            this.body = body;
        }
    }
}
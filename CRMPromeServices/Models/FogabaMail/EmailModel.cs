using System.Collections.Generic;

namespace CRMPromeServices.Controllers
{
    public class EmailModel
    {

        private string from { get; set; }
        private List<string> cc { get; set; }
        private List<string> cco { get; set; }
        private string subject { get; set; }
        private string body { get; set; }


        public EmailModel(string from, List<string> cc, List<string> cco, string subj, string body)
        {
            this.from = from;
            this.cc = cc;
            this.cco = cco;
            this.subject = subj;
            this.body = body;
        }
    }
}
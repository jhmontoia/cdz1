using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace cdz.services.Model
{
    [DataContract]
    public class ResponseAtividades
    {
        [DataMember]
        public string Id { get; set; }
        [DataMember]
        public string NomeAtividade { get; set; }
        [DataMember]
        public string DataCriacao { get; set; }
    }
}
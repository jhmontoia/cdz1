using cdz.services.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace cdz.services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        List<ResponseAtividades> PesquisarProfissional(string Nome);

        [OperationContract]
        void IncluirAtividade(string NomeAtividade);

    }
}

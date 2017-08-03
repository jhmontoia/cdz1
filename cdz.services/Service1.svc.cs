﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Table;
using System.Configuration;
using cdz.services.Model;

namespace cdz.services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public void IncluirAtividade(string NomeAtividade)
        {
            CloudStorageAccount conta = CloudStorageAccount.Parse(ConfigurationManager.AppSettings["cConStorage"]);
            CloudTableClient tableClient = conta.CreateCloudTableClient();

            CloudTable tableAtividade = tableClient.GetTableReference("atividade");

            tableAtividade.CreateIfNotExists();

            Ze ze = new Ze("Ze", Guid.NewGuid().ToString())
            {
                Atividade = NomeAtividade
            };

            try
            {
                tableAtividade.Execute(TableOperation.Insert(ze));
            }
            catch
            {
                throw;
            }
        }

        public List<ResponseAtividades> PesquisarProfissional(string Nome)
        {
            StorageCredentials creds = new StorageCredentials("cadeozeaj", "3zGc79XwsOyU40Y1LPcsRfUAPixeLIaBJLKBIs/ozpjtroiLoqYa4JEjqgRhlBOSNMbmS1YKdsbawf1rQKE5yg==");

            CloudStorageAccount account = new CloudStorageAccount(creds, useHttps: true);
            CloudTableClient client = account.CreateCloudTableClient();
            CloudTable table = client.GetTableReference("atividade");

            TableQuery<Ze> query = new TableQuery<Ze>();
            var retorno = table.ExecuteQuery<Ze>(query).ToList();
            var response = new List<ResponseAtividades>();

            foreach (Ze item in retorno)
            {
                response.Add(new ResponseAtividades
                {
                    Id = item.RowKey,
                    DataCriacao = item.Timestamp.ToString("dd/MM/yyyy hh:mm:ss"),
                    NomeAtividade = item.Atividade.ToString()
                });

            }

            return response;
        }
    }
}

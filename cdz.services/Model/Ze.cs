using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace cdz.services.Model
{
    public class Ze : TableEntity
    {
        public Ze()
        {

        }
        public Ze(string pk, string rowKey)
        {
            PartitionKey = pk;
            RowKey = rowKey;
        }
        public string Atividade { get; set; }
    }
}
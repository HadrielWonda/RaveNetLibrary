using System;
using System.Collections.Generic;
using System.Text;
using RaveNetLibrary.Payments;
using Newtonsoft.Json;

namespace RaveNetLibrary;

    public class TransactionResponseData: PayResponseData
    {

        [JsonProperty("transaction_type")]
        public string TransactionType { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }
        [JsonProperty("flwMeta")]
        public FlwMeta FlwMeta { get; set; }
    }


﻿
using Newtonsoft.Json;

namespace RaveNetLibrary.Payments;

   public class RaveChargeToken
    {
        [JsonProperty("embed_token")]
        public string EmbedToken { get; set; }
        [JsonProperty("user_token")]
        public string UserToken { get; set; }
    }


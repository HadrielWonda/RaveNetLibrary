﻿using Newtonsoft.Json;

namespace RaveNetLibrary.Payments;

    public class CardResponseData : PayResponseData
    {
        /// <summary>
        /// Represnts the mode of authentication for given transaction
        /// values could be "PIN"
        /// </summary>
        [JsonProperty("suggested_auth")]
        public string SuggestedAuth { get; set; }
        [JsonProperty("authModelUsed")]
        public string AuthModelUsed { get; set; }

    }


﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RaveNetLibrary;

   public class RaveTransaction
    {
        public RaveTransaction(RavePayConfig config)
        {
            Config = config;
            ApiRequest = new RavePayApiRequest<RaveApiResponse<TransactionResponseData>, TransactionResponseData>(config);
        }

        public RavePayConfig Config { get; }
        private IRavePayApiRequest<RaveApiResponse<TransactionResponseData>, TransactionResponseData> ApiRequest { get; }

        public async Task<RaveApiResponse<TransactionResponseData>> TransactionVerification(VerifyTransactoinParams verifyParams)
        {
            var requestBody = new StringContent(JsonConvert.SerializeObject(verifyParams), Encoding.UTF8,
                "application/json");

            var requestMessage =
                new HttpRequestMessage(HttpMethod.Post, Enpoints.Verify) { Content = requestBody };
            var result = await ApiRequest.Request(requestMessage);
            return result;
        }

        public async Task<RaveApiResponse<IEnumerable<TransactionResponseData>>> XqueryTransactionVeriication(VerifyTransactoinParams verifyParams)
        {
            var requestBody = new StringContent(JsonConvert.SerializeObject(verifyParams), Encoding.UTF8,
                "application/json");

            var requestMessage =
                new HttpRequestMessage(HttpMethod.Post, Enpoints.Xquery) { Content = requestBody };
            
            var privateRequest = new RavePayApiRequest<RaveApiResponse<IEnumerable<TransactionResponseData>>, IEnumerable<TransactionResponseData>>(Config);

            var result = await privateRequest.Request(requestMessage);
            return result;
        }

      
    }


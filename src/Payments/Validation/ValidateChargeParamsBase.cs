using  Newtonsoft.Json;

namespace RaveNetLibrary.Payments;

    public abstract class ValidateChargeParamsBase: IValidateChargeParams
    {
        protected ValidateChargeParamsBase(string pbfPubKey)
        {
            PbfPubKey = pbfPubKey;
        }

        
        [JsonProperty("PBFPubKey")]
        public string PbfPubKey { get; set; }
    }


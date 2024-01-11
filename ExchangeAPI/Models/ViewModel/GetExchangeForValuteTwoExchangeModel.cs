using ExchangeAPI.Models.Enums;
using System.Text.Json.Serialization;

namespace ExchangeAPI.Models.ViewModel
{
    public class GetExchangeForValuteTwoExchangeModel
    {
        public double Amount { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Currencies CurrencyOne { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Currencies CurrencyTwo { get; set; }
    }
}

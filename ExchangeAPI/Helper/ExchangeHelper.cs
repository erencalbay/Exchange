using ExchangeAPI.Models.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Reflection;
using System.Text.Json.Nodes;

namespace ExchangeAPI.Helper
{
    public class ExchangeHelper
    {
        public static IConfiguration _configuration { get; set; }

        public ExchangeHelper(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public static double GetExchangePropertyValue(ConversionRate conversionRate, string propertyName)
        {
            PropertyInfo property = conversionRate.GetType().GetProperty(propertyName);
            if (property != null)
            {
                return (double)(property.GetValue(conversionRate) ?? 0.0);
            }
            return 0.0;
        }
        public static ExchangeEntity GetDeserializeAPI(string token, string typeOne = "TRY")
        {            
            String URLString = $"https://v6.exchangerate-api.com/v6/{token}/latest/USD";
            if (typeOne!="None")
                URLString = $"https://v6.exchangerate-api.com/v6/{token}/latest/" + typeOne;
            var webClient = new System.Net.WebClient();
            var json = webClient.DownloadString(URLString);
            ExchangeEntity Test = JsonConvert.DeserializeObject<ExchangeEntity>(json);
            return(Test);
        }

        public static ConversionRate GetExchangeCurrencies(ExchangeEntity exchangeEntity)
        {
            PropertyInfo property = exchangeEntity.GetType().GetProperty("conversion_rates");
            return (ConversionRate)(property.GetValue(exchangeEntity));
        }
    }
}

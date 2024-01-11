using ExchangeAPI.Helper;
using ExchangeAPI.Models.Entities;
using ExchangeAPI.Models.Enums;
using ExchangeAPI.Models.ViewModel;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections;
using System.Reflection;
using System.Text.Json;

namespace ExchangeAPI.Controllers
{
    [ApiController]
    [Route("api")]
    public class ExchangeController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public ExchangeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet("InstantExchangeRate")]
        public IActionResult GetInstantExchangeRate()
        {

            //appsettings'ten token alınır
            string token = _configuration.GetSection("TokenOption")
                .GetSection("Token").Value;

            //API cevabı
            var APIresult = ExchangeHelper.GetDeserializeAPI(token,"TRY");
            var result = ExchangeHelper.GetExchangeCurrencies(APIresult);
            return Ok(result);
        }
        
        [HttpGet("Exchange")]
        public IActionResult GetExchangeForValueTwoExchange([FromQuery] GetExchangeForValuteTwoExchangeModel model)
        {
            var APIresult = ExchangeHelper.GetDeserializeAPI(model.CurrencyOne.ToString());
            var result = ExchangeHelper.GetExchangePropertyValue(APIresult.conversion_rates, model.CurrencyTwo.ToString()) * model.Amount;
            return Ok(result);
        }

        [HttpGet("SupportedCurrencies")]
        public IActionResult GetSupportedCurrencies()
        {
            Currencies[] currencies = (Currencies[])Enum.GetValues(typeof(Currencies));
            return Ok(currencies);
        }
    }
}

using ExchangeAPI.Helper;
using ExchangeAPI.Models.Entities;
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

        [HttpGet]
        public IActionResult GetSupportedExchanges()
        {
            var APIresult = ExchangeHelper.GetDeserializeAPI();
            var result = ExchangeHelper.GetExchangeCurrencies(APIresult);
            return Ok(result);
        }

        [HttpGet("{amount}/{typeOne}/{typeTwo}")]
        public IActionResult GetExchangeForValueTwoExchange(double amount, string typeOne = "USD", string typeTwo = "TRY")
        {
            var APIresult = ExchangeHelper.GetDeserializeAPI(typeOne);
            var result = ExchangeHelper.GetExchangePropertyValue(APIresult.conversion_rates, typeTwo) * amount;
            return Ok(result);
        }
    }
}

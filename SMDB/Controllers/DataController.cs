using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http; 
using Newtonsoft.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using SMDP.SMDPModels;
using Microsoft.AspNetCore.Authorization;
using SMDP;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using SMDP.Repository;
using System.Security.Cryptography;
using SMDP.SMDPModels;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace SMDP.Controllers
{
    
    [ApiController]
    [Route("[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]


    public class DataController : ControllerBase
    {
        private readonly MarketRepository _smdps;

        private LogSingleton _logger;       
        public DataController()
        {
            _logger = LogSingleton.Instance;
            _smdps = new MarketRepository(new SMDPModels.SmdpContext());
        }

        [ProducesResponseType(typeof(List<DailyPrice>), 200)]
        [HttpGet("/DailyPrice")]       
        public dynamic DailyPrice(long a)
         {
            string userAgent = Request.Headers["User-Agent"].ToString();
            string method = Request.Method.ToString();
            
            _logger.WriteRequest(userAgent);
            _logger.WriteKind(method);
            return _smdps.DailyPrice(a);
         }

        [ProducesResponseType(typeof(List<Fund>), 200)]
        [HttpGet("/Fund")]
        public dynamic Fund()
        {
            string userAgent = Request.Headers["User-Agent"].ToString();
            string method = Request.Method.ToString();
            
            _logger.WriteRequest(userAgent);
            _logger.WriteKind(method);
            return _smdps.Fund();
        }

        [ProducesResponseType(typeof(List<Industry>), 200)]
        [HttpGet("/Industry")]    
        
        public dynamic Industry()
        {
            string userAgent = Request.Headers["User-Agent"].ToString();
            string method = Request.Method.ToString();

            _logger.WriteRequest(userAgent);
            _logger.WriteKind(method);
            return _smdps.Industry();
        }

        [ProducesResponseType(typeof(List<Instrument>), 200)]
        [HttpGet("/Instrument")]        
        public dynamic Instrument()
        {
            string userAgent = Request.Headers["User-Agent"].ToString();
            string method = Request.Method.ToString();
            
            _logger.WriteRequest(userAgent);
            _logger.WriteKind(method);
            
            return _smdps.Instrument();
        }

        [ProducesResponseType(typeof(List<LetterType>), 200)]
        [HttpGet("/LetterType")]
        public dynamic LetterType()
        {
            string userAgent = Request.Headers["User-Agent"].ToString();
            string method = Request.Method.ToString();
            
            _logger.WriteRequest(userAgent);
            _logger.WriteKind(method);
            var a = _smdps.Lettertype();
            return a;
        }

    }
}
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace NotatnikMechanika.Shared
{
    public static class ResponseBuilder
    {
        public class Response
        {
            internal Response() { }
            public bool Successful { get; set; }
            public List<string> ErrorMessages { get; set; }    
        }

        public class Response<ResponseModel> : Response
        {
            internal Response() { }
            public ResponseModel Content { get; set; }
        }

        public static Response SuccessEmptyResponse => new Response { Successful = true };

        public static Response<ResponseModel> BadRequestResponse<ResponseModel>(List<string> errorMessages)
        {
            return new Response<ResponseModel> { Successful = false, ErrorMessages = errorMessages };
        }

        public static Response BadRequestResponse(List<string> errorMessages)
        {
            return new Response { Successful = false, ErrorMessages = errorMessages };
        }

        public static Response<ResponseModel> CreateResponse<ResponseModel>(ResponseModel model)
        {
            return new Response<ResponseModel> { Successful = true, Content = model };
        }

        public static async Task<Response<ResponseModel>> ParseResponse<ResponseModel>(HttpResponseMessage message)
        {
            string responseString = await message.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Response<ResponseModel>>(responseString);
        }

        public static async Task<Response> ParseResponse(HttpResponseMessage message)
        {
            string responseString = await message.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Response>(responseString);
        }
    }
}

using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace NotatnikMechanika.Shared
{
    public static class ResponseBuilder
    {
        public enum ResponseResult
        {
            Successful,
            BadRequest,
            BadModelState
        }

        public class Response
        {
            internal Response() { }
            public ResponseResult ResponseResult { get; set; }
            public List<string> ErrorMessages { get; set; }
        }

        public class Response<ResponseModel> : Response
        {
            internal Response() { }
            public ResponseModel Content { get; set; }
        }

        public static Response SuccessEmptyResponse => new Response { ResponseResult = ResponseResult.Successful };


        public static Response BadModelStateResponse()
        {
            return new Response { ResponseResult = ResponseResult.BadModelState };
        }

        public static Response<ResponseModel> BadModelStateResponse<ResponseModel>()
        {
            return new Response<ResponseModel> { ResponseResult = ResponseResult.BadModelState };
        }

        public static Response<ResponseModel> BadRequestResponse<ResponseModel>(List<string> errorMessages)
        {
            return new Response<ResponseModel> { ResponseResult = ResponseResult.BadRequest, ErrorMessages = errorMessages };
        }

        public static Response BadRequestResponse(List<string> errorMessages)
        {
            return new Response { ResponseResult = ResponseResult.BadRequest, ErrorMessages = errorMessages };
        }

        public static Response<ResponseModel> CreateResponse<ResponseModel>(ResponseModel model)
        {
            return new Response<ResponseModel> { ResponseResult = ResponseResult.Successful, Content = model };
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

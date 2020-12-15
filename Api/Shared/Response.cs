using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace NotatnikMechanika.Shared
{
    public static class ResponseBuilder
    {
        public enum ResponseType
        {
            Successful,
            Failure, //Błąd obsługi danych po stronie serwera
            Unauthorized,
            BadModelState, // Błąd walidacji
        }

        public class Response
        {
            internal Response() { }

            public int? ResourceId { get; set; }
            public ResponseType ResponseType { get; set; }
            public List<string> ErrorMessages { get; set; }
        }

        public class Response<ResponseModel> : Response
        {
            internal Response() { }
            public ResponseModel Content { get; set; }
        }

        public static Response<ResponseModel> FailureResponse<ResponseModel>(ResponseType responseType, List<string> errorMessages = null)
        {
            return new Response<ResponseModel> { ResponseType = responseType, ErrorMessages = errorMessages };
        }

        public static Response FailureResponse(ResponseType responseType, List<string> errorMessages = null)
        {
            return new Response { ResponseType = responseType, ErrorMessages = errorMessages };
        }

        #region Api

        public static Response SuccessResponse(int? resourceId = null)
        {
            return new Response
            {
                ResponseType = ResponseType.Successful, 
                ResourceId = resourceId 
            };
        }

        public static Response<ResponseModel> SuccessResponse<ResponseModel>(ResponseModel model)
        {
            return new Response<ResponseModel> { ResponseType = ResponseType.Successful, Content = model };
        }

        #endregion

        #region Client

        public static async Task<Response<ResponseModel>> ParseResponse<ResponseModel>(HttpResponseMessage message)
        {
            if (message.IsSuccessStatusCode)
            {
                string responseString = await message.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Response<ResponseModel>>(responseString)
                    ?? FailureResponse<ResponseModel>(ResponseType.Failure, new List<string> { { "Validation error" } });
            }
            else if (message.StatusCode == HttpStatusCode.Unauthorized)
            {
                return FailureResponse<ResponseModel>(ResponseType.Unauthorized);
            }
            else
            {
                return FailureResponse<ResponseModel>(ResponseType.Failure, new List<string> { { message.ReasonPhrase } });
            }
        }

        public static async Task<Response> ParseResponse(HttpResponseMessage message)
        {
            if (message.IsSuccessStatusCode)
            {
                string responseString = await message.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Response>(responseString)
                    ?? FailureResponse(ResponseType.Failure, new List<string> { { "Validation error" } });
            }
            else if (message.StatusCode == HttpStatusCode.Unauthorized)
            {
                return FailureResponse(ResponseType.Unauthorized);
            }
            else
            {
                return FailureResponse(ResponseType.Failure, new List<string> { { message.ReasonPhrase } });
            }
        }

        #endregion
    }
}

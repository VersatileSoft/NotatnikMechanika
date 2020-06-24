using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NotatnikMechanika.Core.Model
{
    public sealed class Response<ResponseModel>
    {
        public ResponseModel Content { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public List<string> ErrorMessages { get; set; }

        private Response() { }

        public static Response<ResponseModel> GetBadModelState(List<string> errorMessages)
        {
            return new Response<ResponseModel> { StatusCode = HttpStatusCode.BadRequest, ErrorMessages = errorMessages };
        }

        public static async Task<Response<ResponseModel>> GetResponse(HttpResponseMessage message)
        {
            var responseString = await message.Content.ReadAsStringAsync();

            if (message.StatusCode == HttpStatusCode.OK)
            {
                return new Response<ResponseModel> { StatusCode = HttpStatusCode.OK, Content = JsonConvert.DeserializeObject<ResponseModel>(responseString) };
            }
            else
            {
                return new Response<ResponseModel> { StatusCode = message.StatusCode, ErrorMessages = new List<string> { responseString } };
            }
        }
    }
}

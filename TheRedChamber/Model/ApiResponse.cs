using System.Net;

namespace TheRedChamber.Model
{
    public class ApiResponse
    {
        public ApiResponse()
        {
            ErrorMessages = new List<string>();
        }
        public HttpStatusCode StatusCode { get; set; }
        public bool IsSuccess { get; set; } = true; //true by default
        public List<string> ErrorMessages { get; set; }
        public object Result { get; set; }
    }
}

namespace BackOfficePOS.Errors
{
    public class ApiException : ApiResponse
    {
        public string Details { get; set;}
        public ApiException(int statusCode, string? errorMessage = null, string details = null) : 
            base(statusCode, errorMessage)
        {
            Details = details;
        }
    }
}

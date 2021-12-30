namespace BackOfficePOS.Errors
{
    public class ApiResponse
    {
        public ApiResponse(int statusCode, string? errorMessage = null)
        {
            StatusCode = statusCode;
            ErrorMessage = errorMessage ?? GetDefaulMessageForStatusCode(statusCode);
        }

      
        public int StatusCode { get; set; }
        public string? ErrorMessage { get; set; }

        private string? GetDefaulMessageForStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "400 Bad Request",
                401 => "401 UnAuthorize",
                404 => "404 Resource not fount",
                500 => "Error are the path to the Dark side",
                _ => null,
            };
        }

    }
}

namespace EXAMEN.Data.ApiResponse.Responses
{
    public class OkResponse<T> : ApiResponse<T>
    {
        public OkResponse(T data, string message = "Success") : base(data, message)
        {
            StatusCode = 200;
        }
    }

    public class NotFoundResponse<T> : ApiResponse<T>
    {
        public NotFoundResponse(string message = "Resource not found") : base(default, message)
        {
            StatusCode = 404;
        }
    }

    public class InternalServerErrorResponse<T> : ApiResponse<T>
    {
        public InternalServerErrorResponse(string message = "Internal Server Error") : base(default, message)
        {
            StatusCode = 500;
        }
    }

}

namespace EXAMEN.Data.ApiResponse
{
    public class ApiResponse<T>
    {
        public int StatusCode { get; protected set; }
        public string Message { get; set; }
        public T Data { get; set; }

        protected ApiResponse(T data, string message)
        {
            Data = data;
            Message = message;
        }
    }

}

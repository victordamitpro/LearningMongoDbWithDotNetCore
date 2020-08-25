namespace Electric.Application.Responses
{
    public class Response<T>
    {
        public T Data { get; set; }

        public string ErrorMessage { get; set; }
    }
}

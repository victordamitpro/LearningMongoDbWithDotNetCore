namespace ElectricWebApp.Models
{
    public class ResponseDataModel<T>
    {
        public T Data { get; set; }
        public string ErrorMessage { get; set; }
    }
}

namespace Template.Web
{
    public class ResponseData
    {
        public int? Status { get; set; }
        public string? Message { get; set; }


    }
    public class ResponseData<T>
    {
        public int? Status { get; set; }
        public string? Message { get; set; }
        public T? Data { get; set; }
    }
}

namespace Template.API.Core
{
    public class FieldError
    {
        public string Property { get; set; }
        public string[]? Errors { get; set; }

        public FieldError(string property, string error)
        {
            Property = property;
            Errors = new string[] { error };
           
        }
        public FieldError(string property, string[] error)
        {
            Property = property;
            Errors = error;            
        }
    }
}

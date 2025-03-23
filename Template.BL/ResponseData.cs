using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.BL
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

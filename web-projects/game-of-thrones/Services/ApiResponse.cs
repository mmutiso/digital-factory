using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameOfThrones.Services
{
    public class ApiResponse<T>
    {
        public T HttpResponse { get; set; }
        public string LinkHeader { get; set; }
    }
}

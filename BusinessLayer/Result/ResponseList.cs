using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Result
{
    public class ResponseList<T> : Response
    {

        public List<T> ResultList { get; set; }
        public ResponseList(bool status, string message,List<T> list) : base(status, message) 
        {
            ResultList = list ?? new List<T>();
        }

    }
}

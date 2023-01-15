using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace kwetter_user.Services
{
    public class ValuesServices
    {
        public IEnumerable<string> GetValues() => new string[] { "Value1","Value2","Value3"};
        public string GetValue() => GetValues().First();
    }
}
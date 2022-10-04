using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Test.Infrastructura
{
    internal static class JsonCompare
    {
        public static void Compare(object expect, object actual)
        {
            string expectStr = JsonConvert.SerializeObject(expect);
            string actualStr = JsonConvert.SerializeObject(actual);
            Assert.AreEqual(expectStr, actualStr);
        }
    }
}

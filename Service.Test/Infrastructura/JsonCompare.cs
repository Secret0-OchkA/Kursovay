using Newtonsoft.Json;

namespace Service.Test.Infrastructura
{
    internal static class JsonCompare
    {
        public static void Compare(object expect, object actual)
        {
            string expectStr = JsonConvert.SerializeObject(expect);
            string actualStr = JsonConvert.SerializeObject(actual);
            Assert.NotNull(expect);
            Assert.NotNull(actual);
            Assert.AreEqual(expectStr, actualStr);
        }
    }
}

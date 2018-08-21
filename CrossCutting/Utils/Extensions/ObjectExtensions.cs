using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Solution.CrossCutting.Utils;

namespace System
{
    public static class ObjectExtensions
    {
        public static byte[] ToBytes(this object obj)
        {
            if (obj == null)
            {
                return default;
            }

            using (var memoryStream = new MemoryStream())
            {
                new BinaryFormatter().Serialize(memoryStream, obj);

                return memoryStream.ToArray().Compress();
            }
        }
    }
}

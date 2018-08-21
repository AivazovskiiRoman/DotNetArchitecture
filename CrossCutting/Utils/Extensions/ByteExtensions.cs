using System.IO;
using System.IO.Compression;
using System.Runtime.Serialization.Formatters.Binary;

namespace Solution.CrossCutting.Utils
{
    public static class ByteExtensions
    {
        public static byte[] Compress(this byte[] bytes)
        {
            using (var outputStream = new MemoryStream())
            {
                using (var gZipStream = new GZipStream(outputStream, CompressionMode.Compress))
                {
                    gZipStream.Write(bytes, 0, bytes.Length);
                }

                return outputStream.ToArray();
            }
        }

        public static byte[] Decompress(this byte[] bytes)
        {
            using (var outputStream = new MemoryStream())
            {
                using (var inputStream = new MemoryStream(bytes))
                using (var gZipStream = new GZipStream(inputStream, CompressionMode.Decompress))
                {
                    gZipStream.CopyTo(outputStream);
                }

                return outputStream.ToArray();
            }
        }

        public static T ToObject<T>(this byte[] bytes)
        {
            using (var memoryStream = new MemoryStream())
            {
                var decompressed = bytes.Decompress();

                memoryStream.Write(decompressed, 0, decompressed.Length);

                memoryStream.Seek(0, SeekOrigin.Begin);

                return (T)new BinaryFormatter().Deserialize(memoryStream);
            }
        }
    }
}

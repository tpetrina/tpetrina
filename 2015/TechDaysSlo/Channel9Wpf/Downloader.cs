using System;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Channel9Wpf
{
    class Downloader
    {
        static string Url = "http://channel9.msdn.com/Events/Build/2014/RSS";

        public static async Task<rss> DownloadAsync()
        {
            try
            {
                var client = new HttpClient();
                var data = await client.GetStreamAsync(Url);
                var serializer = new XmlSerializer(typeof(rss));

                using (var ms = new MemoryStream())
                using (var file = File.OpenWrite("cache"))
                {
                    await data.CopyToAsync(ms);
                    ms.Seek(0, SeekOrigin.Begin);
                    var result = serializer.Deserialize(ms) as rss;

                    ms.Seek(0, SeekOrigin.Begin);
                    await ms.CopyToAsync(file);
                    return result;
                }
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                return null;
            }
        }
    }
}

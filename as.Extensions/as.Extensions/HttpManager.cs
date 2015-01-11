using System;
using System.IO;
using System.Net;
using System.Text;
using System.Xml.Serialization;

namespace @as.Extensions
{
    /// <summary>
    /// Http Manager
    /// </summary>
    public class HttpManager<T>
    {
        private Encoding encoding = Encoding.UTF8;

        /// <summary>
        /// Deserialize Uri Stream Content
        /// </summary>
        /// <param name="uri"></param>
        /// <returns></returns>
        public T Deserialize(Uri uri)
        {
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(uri);
            HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream(), encoding))
            {
                return getDeserialize(streamReader);
            }
        }

        /// <summary>
        /// get Deserialize Stream Reader
        /// </summary>
        /// <param name="streamReader"></param>
        /// <returns></returns>
        private T getDeserialize(StreamReader streamReader)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            return (T)xmlSerializer.Deserialize(streamReader);
        }
    }
}

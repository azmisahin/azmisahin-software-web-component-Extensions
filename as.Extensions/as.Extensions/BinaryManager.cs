using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace @as.Extensions
{
    /// <summary>
    /// Binary Manager
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BinaryManager<T>
    {
        /// <summary>
        /// Write Object [Class] Data File Write
        /// </summary>
        /// <param name="data"></param>
        /// <param name="name"></param>
        public void writeDataFile(T data, string name)
        {
            FileStream fileStream = new FileStream(name, FileMode.Create);
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            binaryFormatter.Serialize(fileStream, data);
            fileStream.Close();
        }

        /// <summary>
        /// Read Object [Class] Data File Read
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public T readDataFile(string name)
        {
            FileStream fileStream = new FileStream(name, FileMode.Open);
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            T data = (T)binaryFormatter.Deserialize(fileStream);
            fileStream.Close();
            return data;
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace @as.Extensions
{
    /// <summary>
    /// Assembly Manager
    /// </summary>
    public class AssemblyManager<T>
    {
        /// <summary>
        /// Result
        /// </summary>
        public class Result
        {
            public Assembly assembly { get; set; }
            public T instance { get; set; }
        }

        /// <summary>
        /// Results
        /// </summary>
        public List<Result> results { get; set; }

        /// <summary>
        /// Get All Assembly This Project Binary Folder
        /// </summary>
        /// <returns></returns>
        public List<Result> getProjectAssembly(object[] param)
        {
            string assemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string[] assemblyFiles = Directory.GetFiles(assemblyPath, "*.dll");//"As.*.dll"
            foreach (var item in assemblyFiles)
            {
                Assembly loadingAssembly = Assembly.LoadFile(item);

                #region Types
                IEnumerable<Type> types = getAssemblyType(loadingAssembly);
                #endregion

                #region Search
                foreach (Type itemType in types)
                {
                    System.Diagnostics.Trace.Write(string.Format("Loding {0}", itemType.FullName));
                    
                    #region Activator                    
                    T runResult = (T)Activator.CreateInstance(itemType, param);
                    #endregion

                    #region Adding Results
                    Result result = new Result();
                    result.assembly = loadingAssembly;
                    result.instance = runResult;
                    results = results == null ? new List<Result>() : results;
                    results.Add(result);
                    #endregion
                }
                #endregion
            }
            return results;
        }

        /// <summary>
        /// For T Base
        /// </summary>
        /// <returns></returns>
        private IEnumerable<Type> getAssemblyType(Assembly assembly)
        {
            var results = assembly.GetTypes()
                .Where(t => t.IsSubclassOf(typeof(T)));
            return results;
        }
    }
}

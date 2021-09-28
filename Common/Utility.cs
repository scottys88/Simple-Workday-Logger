using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Common
{
    public static class Utility
    {
        public static string GenerateID()
        {
            return Guid.NewGuid().ToString();
        }

        /// <summary>
        /// Pass in a list of anytype to generate Loggable List
        /// </summary>
        /// <typeparam name="T">Generic type to be cast as ILoggable</typeparam>
        /// <param name="list">The list of the generic</param>
        /// <param name="list">Bool of if the method should also log when creating the list</param>
        /// <returns>List ILoggalble</returns>
        public static List<ILoggable> CastToILoggable<T>(List<T> list, bool shouldLog = true)
        {
            List<ILoggable> loggableList = new List<ILoggable>();
            foreach (T item in list)
            {
                var loggableItem = item as ILoggable;
                loggableList.Add(loggableItem);
                if(shouldLog)
                {
                    Debug.WriteLine(loggableItem.Log());
                }
            }

            return loggableList;
        }

        public static void WriteToFile(List<ILoggable> itemsToLog)
        {
            foreach (var item in itemsToLog)
            {
                Console.WriteLine(item.Log());
            }
        }

        public static DateTimeOffset GetDate()
        {
            return new DateTimeOffset(DateTime.UtcNow).Date;
        }
    }
}

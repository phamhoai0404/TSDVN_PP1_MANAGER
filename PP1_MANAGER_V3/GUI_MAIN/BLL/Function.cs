using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace GUI_MAIN.BLL
{
    public class MyFunction
    {
        public static string ConvertLocalToNetwork(string path)
        {
            string s = path;
            int index = s.IndexOf(':') + 1;
            string rootPath = GetUNCPath(s.Substring(0, index));
            string directory = s.Substring(index);
            return rootPath + directory;
        }

        /// <summary>
        /// Chuyen doi tu (vd P: => \\192.168.3.6\public)
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private static string GetUNCPath(string path)
        {
            try
            {
                if (path.StartsWith(@"\\"))
                {
                    return path;
                }

                ManagementObject mo = new ManagementObject();
                mo.Path = new ManagementPath(String.Format("Win32_LogicalDisk='{0}'", path));

                // DriveType 4 = Network Drive
                if (Convert.ToUInt32(mo["DriveType"]) == 4)
                {
                    return Convert.ToString(mo["ProviderName"]);
                }
                else
                {
                    return path;
                }
            }
            catch
            {
                return path;
            }

        }
    }
}

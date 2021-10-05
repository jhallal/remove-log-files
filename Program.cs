using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoveLogFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var files = new DirectoryInfo(ConfigurationManager.AppSettings["WebLogs"].ToString()).GetFiles("*.log");
                foreach (var file in files)
                {
                    if (file.CreationTimeUtc < DateTime.Now.AddMonths(-6))
                    {
                        File.Delete(file.FullName);
                    }
                }
            }
            catch(Exception ex)
            { 
                //Log the exception
            }
        }
    }
}

using System;
using System.Management;
using System.Diagnostics;

namespace ProcessNamewithUserName
{
    class Program
    {
        static void Main(string[] args)
        {
            string query = "Select * From Win32_Process";
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);
            ManagementObjectCollection processList = searcher.Get();

            Console.WriteLine("Process Name" + "   " + "Process Name" + "           " + "UserName");
            Console.WriteLine("===================================================================");

            foreach (ManagementObject result in processList)
            {
                string[] argList = new string[] { string.Empty, string.Empty };
                int returnVal = Convert.ToInt32(result.InvokeMethod("GetOwner", argList));
               
                if (returnVal == 0)
                {
                    Console.WriteLine(result["ProcessId"] + "             " +  result["Name"] + "  -->  " + argList[1] + "\\" + argList[0]);
                }              
            }           
            Console.ReadLine();
        }
    }
}

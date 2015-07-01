using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic
{
    public class Logger
    {
        static string directoryPath = string.Format( "{0}LogFile", AppDomain.CurrentDomain.BaseDirectory.ToString());
        static string filePath = string.Format(directoryPath + "\\LogFile.txt");

        public static void Write(Exception exception)
        {
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
                File.Create(filePath);
            }
            try
            {
                using (StreamWriter file = File.AppendText(filePath))
                {
                    file.WriteLine(DateTime.Now + exception.Message + exception.StackTrace);
                    file.Close();
                }        
            }
            catch (IOException)
            {
                // aca me tira un error de IOException al momento de escribir por primera vez en el archivo creado.
                // por lo tanto la primera excepcion que se produce no me la registra.
                return;
            }
        }      
    }
}

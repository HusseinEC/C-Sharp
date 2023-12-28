using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Interfaces
{

    public class FileService
    {
        private readonly string _filePath = @"c:\Projects\contacts.json";

        // Detta sparar innehåll inom filen och kopplar de till sitt filepath så att den kan återupphämtas smidigt.
        public bool SaveConentToFile(string content)
        {
            try
            {
                using (var sw = new StreamWriter(_filePath))
                {
                    sw.WriteLine(content);
                }

                return true;
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }
            return false;
        }

        // Medans den här återupphämtar innehållet som var sparad inom filen.
        public string GetContentFromFile()
        {
            try
            {
                if (File.Exists(_filePath))
                {
                    using var sr = new StreamReader(_filePath);
                    return sr.ReadToEnd();
                }
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }
            return null!;
        }
    }
}

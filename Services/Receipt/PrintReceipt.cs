using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Theater_App.Services.Receipt
{
    public class PrintReceipt
    {
        //Should be changed depending on the machine where the code will be run
        private string fileName = @"E:\Study\Senai\Eng_Soft\";
        public bool Print(string fileName, string statement)
        {
            fileName = this.fileName + fileName.Trim();
            
            try
            {
                // Check if file already exists. If yes, delete it.     
                if (File.Exists(fileName))
                {
                    File.Delete(fileName);
                }

                // Create a new file     
                using (FileStream fs = File.Create(fileName))
                {
                    byte[] content = new UTF8Encoding(true).GetBytes(statement);
                    fs.Write(content, 0, content.Length);
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}

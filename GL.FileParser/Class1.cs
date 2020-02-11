using System;
using System.IO;
using System.Text;

namespace GL.FileParser
{
    public class FileParser
    {
        public string FilePath { get; set; }

        public string GetContent()
        {
            try
            {
                using(StreamReader sr = new StreamReader(FilePath))
                {
                    return sr.ReadToEnd();
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine("Could not get content");
                Console.WriteLine(ex.Message);
                return ex.Message;
            }
        }

        public string GetContentWithoutUnicode()
        {
            try
            {
                var i = File.OpenRead(FilePath);
                byte[] b = new byte[1];
                UTF8Encoding temp = new UTF8Encoding(true);
                string result = "";

                while (i.Read(b, 0, b.Length) > 0)
                {
                    var s = temp.GetChars(b);

                    foreach (var c in s)
                    {
                        if ((int)c < 0x80)
                            result = result + new string(new[] { c });
                    }
                }

                return result;
            }
            catch (IOException ex)
            {
                Console.WriteLine("Could not get content");
                Console.WriteLine(ex.Message);
                return ex.Message;
            }
        }

        public void SaveContent(string content)
        {
            try
            {
                using (FileStream fs = File.Create(FilePath)) {
                    AddText(fs, content);
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine("Could not save content");
                Console.WriteLine(ex.Message);
            }
        }

        private static void AddText(FileStream fs, string value)
        {
            byte[] info = new UTF8Encoding(true).GetBytes(value);
            fs.Write(info, 0, info.Length);
        }
    }
}

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
            return GetContent(true);    
        }
        public string GetContentWithoutUnicode()
        {
            return GetContent(false);
        }
        
        public string GetContent(bool withUnicode)
        {
            try
            {
                using(StreamReader sr = new StreamReader(FilePath))
                {
                    if(withUnicode)
                    {
                        return sr.ReadToEnd();
                    }
                    var sb = new StringBuilder();
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        foreach (var c in value)
                        {
                            if ( c < 0x80)
                            {
                                sb.Append(c);
                            }
                        }
                        sb.AppendLine();
                    }
                    return sb.ToString();
                }
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
                    byte[] info = new UTF8Encoding(true).GetBytes(value);
                    fs.Write(info, 0, info.Length);
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine("Could not save content");
                Console.WriteLine(ex.Message);
            }
        }
    }
}

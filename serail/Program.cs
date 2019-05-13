using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;

namespace serail
{
    
    
    public class Song
    {
        [XmlElement("Title")]
        public string Title;
        [XmlElement("Duration")]
        public int Duration;

       
        [XmlIgnore]
        public string Lyrics;
    }
    class Program
    {
        static void Main(string[] args)
        {
        
        Song[] arr = new Song[]
           {
                new Song() {
                    Title = "Title 1",
                    Duration = 247,
                    Lyrics = "Lyrics 1"
                },
                new Song() {
                    Title = "Title 2",
                    Duration = 456,
                    Lyrics = "Lyrics 2"
                }
           };

            XmlSerializer xmlSerializer = new XmlSerializer(arr.GetType()); // homework
            string result;
            using (StringWriter textWriter = new StringWriter())
            {
                xmlSerializer.Serialize(textWriter, arr);
                result = textWriter.ToString();
            }
            Console.WriteLine(result);
            Song[] songarray;
            using (StringReader rdr = new StringReader(result))// homework
            {
                songarray = (Song[])xmlSerializer.Deserialize(rdr);
            }
            Console.WriteLine(songarray.Length + "   " + songarray[0].Title + "  " + songarray[1].Title);
            XmlWriterSettings set = new XmlWriterSettings();
            set.Indent = true;
            set.Encoding = Encoding.UTF8;
            using (FileStream fs = new FileStream(@"D:\ДЗ\serial\serail\files\NNN.xml", FileMode.Create))// homework
            {
                using (XmlWriter wrt = XmlWriter.Create(fs, set))
                {
                    xmlSerializer.Serialize(wrt, arr);
                }
            }
            Song[] arrFromFile;
            using (FileStream fs = new FileStream(@"D:\ДЗ\serial\serail\files\NNN.xml", FileMode.Open, FileAccess.ReadWrite))// homework
            {
                using (XmlReader wrt = XmlReader.Create(fs))
                {
                   arrFromFile = (Song[])xmlSerializer.Deserialize(wrt);
                }
            }
            foreach (Song item in arrFromFile)// homework
            {
                Console.WriteLine(item.Title);
            }
            Console.ReadLine();
        }
    }
}

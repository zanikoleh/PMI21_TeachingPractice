namespace PMI21_TeachingPractice
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;

    public class Program
    {
        public static void Main(string[] args)
        {
            string[] buf = File.ReadAllLines(@"../../data/Data.txt");
            int size = buf.Length;
            List<Order> orders = new List<Order>();
            for (int i = 0; i < buf.Length; i++)
            {
                buf[i] = buf[i].PadRight(buf[i].Length + 1, ' ');
                Order temp = new Order();
                temp.MakeOrder(buf[i]);
                orders.Add(temp);
            }

            for (int i = 0; i < orders.Count; i++)
            {
                orders[i].Write();
            }

            string curFile = @"../../data/Result.xml";
            if (!File.Exists(curFile))
            {
                XmlWriter fs = XmlWriter.Create(curFile);
                fs.WriteStartElement("head");
                fs.WriteFullEndElement();
                fs.Close();
            }

            XmlDocument document = new XmlDocument();
            document.Load(curFile);
            XmlElement root = document.DocumentElement;
            orders[0].AddProduct(1);
            orders[0].RemoveProduct(1);
            for (int i = 0; i < orders.Count; i++)
            {
                orders[i].SaveOrder(document);
            }

            document.Save(@"../../data/Result.txt");
            Console.ReadKey();
        }
    }
}

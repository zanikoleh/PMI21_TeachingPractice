namespace PMI21_TeachingPractice
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml;
    using System.Xml.Linq;

    public class Check
    {
        private int idOrder;
        private int idUser;
        private DateTime time;
        public Check()
        {
            this.idOrder = 0;
            this.idUser = 0;
            this.time = new DateTime();
        }
        public Check(int idOrderVal, int idUserVal)
        {
            this.idOrder = idOrderVal;
            this.idUser = idUserVal;
            time = new DateTime();
        }
        public int IdUser
        {
            get
            {
                return this.idUser;
            }
        }
        public int IdOrder
        {
            get
            {
                return this.idOrder;
            }
        }
        public DateTime Time
        {
            get
            {
                return this.time;
            }
        }
        public void Save(string path)
        {
            this.time = DateTime.Now;
            if (!File.Exists(path))
            {
                XmlWriter writer = XmlWriter.Create(path);
                writer.WriteStartElement("head");
                writer.WriteFullEndElement();
                writer.Close();
            }
            XmlDocument doc = new XmlDocument();
            doc.Load(path);
            XmlNode root = doc.DocumentElement;
            XmlElement newOrder = doc.CreateElement("OrderId");
            XmlElement newUser = doc.CreateElement("UserId");
            XmlElement newTime = doc.CreateElement("Time");
            XmlText orderId = doc.CreateTextNode(this.IdOrder.ToString());
            XmlText userId = doc.CreateTextNode(this.IdUser.ToString());
            XmlText checkTime = doc.CreateTextNode(this.time.ToString("o"));
            newOrder.AppendChild(orderId);
            newUser.AppendChild(userId);
            newTime.AppendChild(checkTime);
            root.InsertAfter(newOrder, root.LastChild);
            root.InsertAfter(newUser, root.LastChild);
            root.InsertAfter(newTime, root.LastChild);
            doc.Save(path);
        }
        public void SaveCheckDB(XmlDocument doc)
        {
            XmlNode root = doc.DocumentElement;
            XmlElement newID = doc.CreateElement("OrderId");
            XmlAttribute attrID = doc.CreateAttribute("order_id");
            attrID.Value = this.IdOrder.ToString();
            newID.SetAttributeNode(attrID);
            root.InsertAfter(newID, root.LastChild);
            XmlElement userID = doc.CreateElement("UserId");
            XmlElement time = doc.CreateElement("Time");
            XmlText uIDval = doc.CreateTextNode(this.IdUser.ToString());
            XmlText timeVal = doc.CreateTextNode(this.Time.ToString("o"));
            userID.AppendChild(uIDval);
            time.AppendChild(timeVal);
            root.InsertAfter(userID, root.LastChild);
            root.InsertAfter(time, root.LastChild);
        }
    }
}
//-----------------------------------------------------------------------
// <copyright file="History.cs" company="PMI21_TeachingPractice">
//     Copyright PMI21_TeachingPractice. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace History_TP
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml;
    using System.Xml.Linq;

    /// <summary>
    /// Class to read info from lists of orders and to create list of clients with their orders
    /// </summary>
    private class History
    {
        /// <summary>
        /// Dictionary of client's id-orders
        /// </summary>
        private Dictionary<int, List<Product>> ordersList;

        /// <summary>
        /// Initializes a new instance of the <see cref="History"/> class with default values
        /// </summary>
        public History()
        {
            this.ordersList = new Dictionary<int, List<Product>>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="History"/> class with parameters values
        /// </summary>
        /// <param name="ordList">dictionary of history</param>
        public History(Dictionary<int, List<Product>> ordList)
        {
            this.ordersList = new Dictionary<int, List<Product>>(ordList);
        }

        /// <summary>
        /// Gets orders list
        /// </summary>
        public Dictionary<int, List<Product>> OrdersList
        {
            get
            {
                return this.ordersList;
            }
        }

        /// <summary>
        /// Read orders from XML
        /// </summary>
        /// <param name="path">URL of XML</param>
        public void Read(string path)
        {
            int id = -1;
            int prodID = 0;
            int prodPrice = -1;
            XmlTextReader raeder = new XmlTextReader(path);

            while (raeder.Read())
            {
                if (raeder.Name == "userId" && raeder.HasAttributes)
                {
                    id = Convert.ToInt32(raeder.GetAttribute("name_id"));

                    if (!this.ordersList.ContainsKey(id))
                    {
                        this.ordersList.Add(Convert.ToInt32(raeder.GetAttribute("name_id")), new List<Product>());
                    }
                }

                if (raeder.Name == "id")
                {
                    prodID = raeder.ReadElementContentAsInt();
                }

                if (raeder.Name == "price")
                {
                    prodPrice = raeder.ReadElementContentAsInt();
                    this.ordersList[id].Add(new Product(prodID, "unknown_name", prodPrice));
                }
            }
        }

        /// <summary>
        /// Read orders from XML
        /// </summary>
        /// <param name="reader">Text reader from file</param>
        public void Read(XmlReader reader)
        {
            int id = -1;
            int prodID = 0;
            int prodPrice = -1;
            while (reader.Read())
            {
                if (reader.Name == "userId" && reader.HasAttributes)
                {
                    id = Convert.ToInt32(reader.GetAttribute("name_id"));

                    if (!this.ordersList.ContainsKey(id))
                    {
                        this.ordersList.Add(Convert.ToInt32(reader.GetAttribute("name_id")), new List<Product>());
                    }
                }

                if (reader.Name == "id")
                {
                    prodID = reader.ReadElementContentAsInt();
                }

                if (reader.Name == "price")
                {
                    prodPrice = reader.ReadElementContentAsInt();
                    this.ordersList[id].Add(new Product(prodID, "unknown_name", prodPrice));
                }
            }
        }

        /// <summary>
        /// Write History stats to XML
        /// </summary>
        /// <param name="path">Path of XML</param>
        public void Write(string path)
        {
            XmlWriter writer = XmlWriter.Create(path);
            writer.WriteStartElement("head");
            writer.WriteFullEndElement();
            writer.Close();
            XmlDocument doc = new XmlDocument();
            doc.Load(path);

            foreach (KeyValuePair<int, List<Product>> user in this.ordersList)
            {
                XmlNode root = doc.DocumentElement;
                XmlElement userId = doc.CreateElement("userId");
                XmlAttribute userIdVal = doc.CreateAttribute("ID");
                userIdVal.Value = Convert.ToString(user.Key);
                userId.SetAttributeNode(userIdVal);
                root.InsertAfter(userId, root.LastChild);

                foreach (Product prod in user.Value)
                {
                    prod.WriteXml(doc, userId);
                }

                doc.Save(path);
                writer.Close();
            }
        }
    }
}

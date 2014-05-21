//-----------------------------------------------------------------------
// <copyright file="Order.cs" company="PMI21_TeachingPractice">
//     Copyright PMI21_TeachingPractice. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
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
    using PMI21_TeachingPractice;

    /// <summary>
    /// describes order of products
    /// </summary>
    public class Order
    {
        /// <summary>
        /// id of user
        /// </summary>
        private int id;

        /// <summary>
        /// the list of products
        /// </summary>
        private Dictionary<int,int> products;

        /// <summary>
        /// Initializes a new instance of the <see cref="Order"/> class
        /// </summary>
        public Order()
        {
            this.id = 0;
            this.products = new Dictionary<int,int>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Order"/> class
        /// </summary>
        /// <param name="identifier">id of user</param>
        /// <param name="products"> list of products</param>
        public Order(int identifier, Dictionary<int,int> products)
        {
            this.id = identifier;
            this.products = products;
        }

        /// <summary>
        /// Gets or sets id
        /// </summary>
        public int ID
        {
            get
            {
                return this.id;
            }

            set
            {
                this.id = value;
            }
        }

        /// <summary>
        /// Gets or sets list of products
        /// </summary>
        public Dictionary<int,int> List
        {
            get
            {
                return this.products;
            }

            set
            {
                this.products = value;
            }
        }

        /// <summary>
        /// makes order from text file
        /// </summary>
        /// <param name="fullOrder">line of order </param>
        public void MakeOrder(string fullOrder)
        {
            int productID, productAmount;
            int counter = 0;
            this.id = int.Parse(fullOrder.Substring(0, fullOrder.IndexOf(' ')));
            fullOrder = fullOrder.Remove(0, fullOrder.IndexOf(' ') + 1);
            for (int i = 0; i < fullOrder.Length; i++)
            {
                if (fullOrder[i].Equals(' '))
                {
                    counter++;
                }

                if (counter == 2)
                {
                    productID = int.Parse(fullOrder.Substring(0, fullOrder.IndexOf(' ')));
                    fullOrder = fullOrder.Remove(0, fullOrder.IndexOf(' ') + 1);
                    productAmount = int.Parse(fullOrder.Substring(0, fullOrder.IndexOf(' ')));
                    fullOrder = fullOrder.Remove(0, fullOrder.IndexOf(' ') + 1);
                    this.products.Add(productID,productAmount);
                    counter = 0;
                    i = -1;
                }
            }
        }

        /// <summary>
        /// Adds product to order
        /// </summary>
        /// <param name="identifier">id of product</param>
        /// <param name="amount">amount of product`s</param>
        public void AddProduct(int identifier, int amount)
        {
            this.products.Add(identifier,amount);
        }

        /// <summary>
        /// Removes product with id
        /// </summary>
        /// <param name="id">id of product to remove</param>
        /// <returns>true if removed product with id exists false if it does not exist</returns>
        public bool RemoveProduct(int id)
        {
            return this.products.Remove(id);
        }

        /// <summary>
        /// writes to console
        /// </summary>
        public void Write()
        {
            Console.Write("{0}\r\n", this.id);
            foreach (KeyValuePair<int, int> pair in this.products)
            {
                Console.Write("{0} , {1}", pair.Key, pair.Value);
                Console.Write("\r\n");
            }
        }

        /// <summary>
        /// writes to xml document
        /// </summary>
        /// <param name="doc"> xml document</param>
        public void SaveOrder(XmlDocument doc)
        {
            Product temp = new Product();
            XmlNode root = doc.DocumentElement;
            XmlElement newID = doc.CreateElement("orderId");
            XmlAttribute attrID = doc.CreateAttribute("name_id");
            attrID.Value = Convert.ToString(this.id);
            newID.SetAttributeNode(attrID);
            root.InsertAfter(newID, root.LastChild);

            foreach (KeyValuePair<int, int> pair in this.products)
            {
                XmlElement newProduct = doc.CreateElement("Product");
                XmlElement newId = doc.CreateElement("id");
                XmlText identifier = doc.CreateTextNode(pair.Key.ToString());
                newId.AppendChild(identifier);
                XmlElement newPrice = doc.CreateElement("price");
                XmlText cost = doc.CreateTextNode((temp.PriceById(pair.Key)*pair.Value).ToString());
                newPrice.AppendChild(cost);
                newProduct.AppendChild(newId);
                newProduct.AppendChild(newPrice);
                XmlElement newAmount = doc.CreateElement("amount");
                XmlText amountStr = doc.CreateTextNode(pair.Value.ToString());
                newAmount.AppendChild(amountStr);
                newProduct.AppendChild(newAmount);

                newProduct.AppendChild(newProduct);
            }
        }

        /// <summary>
        /// gets order by id
        /// </summary>
        /// <param name="identifier"> id of order</param>
        /// <returns>order with id</returns>
        public Order ReturnOrderById(int identifier)
        {
            int id = -1;
            int prodID = 0;
            int prodAmount = 0;
            XmlTextReader reader = new XmlTextReader("Result.xml");
            Order tempOrder = new Order();
            tempOrder.ID = identifier;
            while (reader.Read())
            {
                if (reader.Name == "orderId" && reader.HasAttributes)
                {
                    id = Convert.ToInt32(reader.GetAttribute("name_id"));
                    if (id == identifier)
                    {
                        while (reader.Read())
                        {
                            if (reader.Name == "id")
                            {
                                prodID = reader.ReadElementContentAsInt();
                            }

                            if (reader.Name == "amount")
                            {
                                prodAmount = reader.ReadElementContentAsInt();
                                tempOrder.AddProduct(prodID, prodAmount);
                            }

                            if (reader.Name == "orderId")
                            {
                                return tempOrder;
                            }
                        }
                    }
                }
            }

            return tempOrder;
        }
    }
}

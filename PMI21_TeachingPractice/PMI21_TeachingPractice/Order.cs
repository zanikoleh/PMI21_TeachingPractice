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
        private List<Product> products;

        /// <summary>
        /// Initializes a new instance of the <see cref="Order"/> class
        /// </summary>
        public Order()
        {
            this.id = 0;
            this.products = new List<Product>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Order"/> class
        /// </summary>
        /// <param name="identifier">id of user</param>
        /// <param name="products"> list of products</param>
        public Order(int identifier, List<Product> products)
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
        public List<Product> List
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
            int productID;
            string productName;
            double productPrice;
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
                    productName = fullOrder.Substring(0, fullOrder.IndexOf(' '));
                    fullOrder = fullOrder.Remove(0, fullOrder.IndexOf(' ') + 1);
                    productPrice = double.Parse(fullOrder.Substring(0, fullOrder.IndexOf(' ')));
                    fullOrder = fullOrder.Remove(0, fullOrder.IndexOf(' ') + 1);
                    Product temp = new Product(productID, productName, productPrice);
                    this.products.Add(temp);
                    counter = 0;
                    i = -1;
                }
            }
        }

        /// <summary>
        /// writes to console
        /// </summary>
        public void Write()
        {
            Console.Write(this.id);
            for (int i = 0; i < this.products.Count; i++)
            {
                ((Product)this.products[i]).Write();
            }
        }

        /// <summary>
        /// writes to xml document
        /// </summary>
        /// <param name="doc"> xml document</param>
        public void Write(XmlDocument doc)
        {
            XmlNode root = doc.DocumentElement;
            XmlElement newID = doc.CreateElement("userId");
            XmlAttribute attrID = doc.CreateAttribute("name_id");
            attrID.Value = Convert.ToString(this.id);
            newID.SetAttributeNode(attrID);
            root.InsertAfter(newID, root.LastChild);
            for (int i = 0; i < this.products.Count; i++)
            {
                ((Product)this.products[i]).WriteXml(doc, newID);
            }
        }
    }
}

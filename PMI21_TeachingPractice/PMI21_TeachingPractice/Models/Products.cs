//-----------------------------------------------------------------------
// <copyright file="Products.cs" company="PMI21_TeachingPractice">
//     Copyright PMI21_TeachingPractice. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace PMI21_TeachingPractice
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Xml;

    /// <summary>
    /// Class which represents product.
    /// </summary>
    public class Products
    {
        /// <summary>
        /// Information about product.
        /// </summary>
        private Product product;

        /// <summary>
        /// Available amount of product.
        /// </summary>
        private int amount;

        /// <summary>
        /// Initializes a new instance of the <see cref="Products" /> class with default values: (0, "Product", 0, 0).
        /// </summary>
        public Products()
        {
            this.product = new Product();
            this.amount = 0;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Products" /> class with values from parameters of constructor.
        /// </summary>
        /// <param name="id">ID of product.</param>
        /// <param name="name">Name of product.</param>
        /// <param name="price">Price of product.</param>
        /// <param name="amount">Amount of product</param>
        public Products(int id, string name, double price, int amount)
        {
            this.product = new Product(id, name, price);
            this.amount = amount;
        }

        public static int IdByName(string name)
        {
            DataBase dataBase;
            dataBase = DataBase.GetInstance();
            dataBase.Load();
            foreach (Products prod in dataBase.Products)
            {
                if (prod.PropProduct.Name == name)
                {
                    return prod.PropProduct.Id;
                }
            }
            Console.WriteLine("No such ID in Base!");
            return 0;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Products" /> class with values from parameters of constructor.
        /// </summary>
        /// <param name="product">Previous information about product.</param>
        /// <param name="amount">Amount of product</param>
        public Products(Product product, int amount)
        {
            this.product = product;
            this.amount = amount;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Products" /> class with values from Product from parameters box.
        /// </summary>
        /// <param name="p">Object of class Product.</param>
        public Products(Products p)
        {
            this.product = p.product;
            this.amount = p.amount;
        }

        /// <summary>
        /// Gets or sets amount of product.
        /// </summary>
        public int Amount
        {
            get
            {
                return this.amount;
            }

            set
            {
                this.amount = value;
            }
        }

        public Product PropProduct 
        {
            get
            {
                return this.product;
            }
            set
            {
                this.product = value;
            }
        }
        /// <summary>
        /// Sets fields for object from Xml file.
        /// </summary>
        /// <param name="reader">Reader module of file with data.</param>
        public void Read(XmlTextReader reader)
        {
            while (reader.Read())
            {
                this.product.Read(reader);

                if (reader.Name == "amount")
                {
                    this.amount = reader.ReadElementContentAsInt();
                    break;
                }
            }
        }

        /// <summary>
        /// Fills xml file with data.
        /// </summary>
        /// <param name="writer">Writer module of file which will be filled with data.</param>
        public void Write(XmlTextWriter writer)
        {
            this.product.Write(writer);
            writer.WriteStartElement("amount");
            writer.WriteValue(this.amount);
            writer.WriteEndElement();
        }

        /// <summary>
        /// writes data to xml
        /// </summary>
        /// <param name="doc">document to add</param>
        /// <param name="root">root to add</param>
        public void WriteXml(XmlDocument doc, XmlNode root)
        {
            XmlElement newProduct = doc.CreateElement("Product");
            XmlElement newId = doc.CreateElement("id");
            XmlText identifier = doc.CreateTextNode(this.product.Id.ToString());
            newId.AppendChild(identifier);
            XmlElement newPrice = doc.CreateElement("price");
            XmlText cost = doc.CreateTextNode(this.product.Price.ToString());
            newPrice.AppendChild(cost);
            newProduct.AppendChild(newId);
            newProduct.AppendChild(newPrice);
            XmlElement newAmount = doc.CreateElement("amount");
            XmlText amountStr = doc.CreateTextNode(this.amount.ToString());
            newAmount.AppendChild(amountStr);
            newProduct.AppendChild(newAmount);

            root.InsertAfter(newProduct, root.LastChild);
        }

        /// <summary>
        /// Writes data to console.
        /// </summary>
        public void Write()
        {
            this.product.Write();
            Console.WriteLine(this.amount);
        }

        /// <summary>
        /// Method converts an object to its string representation so that it is suitable for display.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            return this.product.ToString() + " " + this.amount.ToString();
        }

        public void SaveProductDB(XmlDocument doc)
        {
            XmlNode root = doc.DocumentElement;
            XmlElement newProduct = doc.CreateElement("Product");
            XmlElement prodId = doc.CreateElement("product_id");
            XmlElement prodName = doc.CreateElement("ProductName");
            XmlElement prodPrice = doc.CreateElement("ProductPrice");
            XmlElement prodAmount = doc.CreateElement("ProductAmount");
            XmlText pName = doc.CreateTextNode(this.product.Name);
            XmlText pPrice = doc.CreateTextNode(this.product.Price.ToString());
            XmlText pId = doc.CreateTextNode(this.product.Id.ToString());
            XmlText pAmount = doc.CreateTextNode(this.Amount.ToString());
            prodName.AppendChild(pName);
            prodPrice.AppendChild(pPrice);
            prodId.AppendChild(pId);
            prodAmount.AppendChild(pAmount);
            newProduct.AppendChild(prodId);
            newProduct.AppendChild(prodName);
            newProduct.AppendChild(prodPrice);
            newProduct.AppendChild(prodAmount);
            root.InsertAfter(newProduct, root.LastChild);
        }
    }
}

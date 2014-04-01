//-----------------------------------------------------------------------
// <copyright file="Product.cs" company="PMI21_TeachingPractice">
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
    public class Product
    {
        /// <summary>
        /// ID of product. For database.
        /// </summary>
        private int id;

        /// <summary>
        /// Name of product. For user.
        /// </summary>
        private string name;

        /// <summary>
        /// Price of product.
        /// </summary>
        private double price;

        /// <summary>
        /// Initializes a new instance of the <see cref="Product" /> class with default values: (0, "Product", 0).
        /// </summary>
        public Product()
        {
            this.id = 0;
            this.name = "Product";
            this.price = 0;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Product" /> class with values from parameters of constructor.
        /// </summary>
        /// <param name="id">ID of product.</param>
        /// <param name="name">Name of product.</param>
        /// <param name="price">Price of product.</param>
        public Product(int id, string name, double price)
        {
            this.id = id;
            this.name = name;
            this.price = price;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Product" /> class with values from Product from parameters box.
        /// </summary>
        /// <param name="p">Object of class Product.</param>
        public Product(Product p)
        {
            this.id = p.id;
            this.name = p.name;
            this.price = p.price;
        }

        /// <summary>
        /// Gets or sets ID.
        /// </summary>
        public int Id
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
        /// Gets or sets price of product
        /// </summary>
        public double Price
        {
            get
            {
                return this.price;
            }

            set
            {
                this.price = value;
            }
        }

        /// <summary>
        /// Gets or sets name of product
        /// </summary>
        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                this.name = value;
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
                if (reader.Name == "id")
                {
                    this.id = reader.ReadElementContentAsInt();
                }

                if (reader.Name == "name")
                {
                    this.name = reader.ReadElementContentAsString();
                }

                if (reader.Name == "price")
                {
                    this.price = reader.ReadElementContentAsDouble();
                    break;
                }
            }
        }

        /// <summary>
        /// Gets price by id
        /// </summary>
        /// <param name="id"> id of searching product</param>
        /// <param name="reader">fie to read</param>
        /// <returns>price of product with searching id</returns>
        public double PriceById(int id, XmlTextReader reader)
        {
            while (reader.Read())
            {
                if (reader.Name == "id")
                {
                    this.id = reader.ReadElementContentAsInt();
                }

                if (reader.Name == "name")
                {
                    this.name = reader.ReadElementContentAsString();
                }

                if (reader.Name == "price")
                {
                    this.price = reader.ReadElementContentAsDouble();
                    if (id == this.id)
                    {
                        return this.price;
                    }
                }
            }

            return 0.0;
        }

        /// <summary>
        /// Fills xml file with data.
        /// </summary>
        /// <param name="writer">Writer module of file which will be filled with data.</param>
        public void Write(XmlTextWriter writer)
        {
            writer.WriteStartElement("id");
            writer.WriteValue(this.id);
            writer.WriteEndElement();
            writer.WriteStartElement("name");
            writer.WriteValue(this.name);
            writer.WriteEndElement();
            writer.WriteStartElement("price");
            writer.WriteValue(this.price);
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
            XmlText identifier = doc.CreateTextNode(this.id.ToString());
            newId.AppendChild(identifier);
            XmlElement newPrice = doc.CreateElement("price");
            XmlText cost = doc.CreateTextNode(this.price.ToString());
            newPrice.AppendChild(cost);
            newProduct.AppendChild(newId);
            newProduct.AppendChild(newPrice);
            root.InsertAfter(newProduct, root.LastChild);
        }

        /// <summary>
        /// Writes data to console.
        /// </summary>
        public void Write()
        {
            Console.Write("{0} ", this.id);
            Console.Write(this.name);
            Console.Write("{0} ", this.price);
        }
    }
}
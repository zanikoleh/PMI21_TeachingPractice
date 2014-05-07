using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace PMI21_TeachingPractice
{
    class DataBase
    {
        private List<Order> orders;
        private List<Product> products;
        private List<User> users;
        private List<Check> checks;
        Dictionary<int, List<int>> usersOrders;
        private string ordersPath;
        private string productsPath;
        private string usersPath;
        private string checksPath;
        private static DataBase DBInstance = null;
        private DataBase()
        {
            this.orders = new List<Order>();
            this.products = new List<Product>();
            this.users = new List<User>();
            this.checks = new List<Check>();
            this.usersOrders = new Dictionary<int, List<int>>();
            this.ordersPath = " ";
            this.productsPath = " ";
            this.usersPath = " ";
            this.checksPath = " ";
        }
        public static DataBase GetInstance()
        {
            if (DBInstance == null)
            {
                DBInstance = new DataBase();
            }
            return DBInstance;
        }
        public static DataBase Instance
        {
            get
            {
                if (DBInstance == null)
                {
                    DBInstance = new DataBase();
                }
                return DBInstance;
            }
        }
        public List<Order> Orders
        {
            get
            {
                return this.orders;
            }
        }
        public List<Product> Products
        {
            get
            {
                return this.products;
            }
        }
        public List<User> Users
        {
            get
            {
                return this.users;
            }
        }
        public List<Check> Checks
        {
            get
            {
                return this.checks;
            }
        }
        public string OrdersPath
        {
            get
            {
                return this.ordersPath;
            }
        }
        public string ProductsPath
        {
            get
            {
                return this.productsPath;
            }
        }
        public string UsersPath
        {
            get
            {
                return this.usersPath;
            }
        }
        public string ChecksPath
        {
            get
            {
                return this.checksPath;
            }
        }
        public void SetConnections(string path)
        {
            XmlTextReader reader = new XmlTextReader(path);
            while (reader.Read())
            {
                if (reader.Name == "OrdersPath")
                {
                    string temp = reader.ReadElementContentAsString();
                    if (Path.IsPathRooted(temp))
                    {
                        this.ordersPath = temp;
                    }
                    else
                    {
                        throw new ArgumentException("String is not a path");
                    }
                }
                if (reader.Name == "ProductsPath")
                {
                    string temp = reader.ReadElementContentAsString();
                    if (Path.IsPathRooted(temp))
                    {
                        this.productsPath = temp;
                    }
                    else
                    {
                        throw new ArgumentException("String is not a path");
                    }
                }
                if (reader.Name == "UsersPath")
                {
                    string temp = reader.ReadElementContentAsString();
                    if (Path.IsPathRooted(temp))
                    {
                        this.usersPath = temp;
                    }
                    else
                    {
                        throw new ArgumentException("String is not a path");
                    }
                }
                if (reader.Name == "ChecksPath")
                {
                    string temp = reader.ReadElementContentAsString();
                    if (Path.IsPathRooted(temp))
                    {
                        this.checksPath = temp;
                    }
                    else
                    {
                        throw new ArgumentException("String is not a path");
                    }
                }
            }
        }
        public void Add(Order newOrder)
        {
            this.orders.Add(newOrder);
        }
        public void Add(Product newProduct)
        {
            this.products.Add(newProduct);
        }
        public void Add(User newUser)
        {
            this.users.Add(newUser);
        }
        public void Add(Check newCheck)
        {
            this.checks.Add(newCheck);
        }
        public void CommitOrders()
        {
            XmlWriter ordersWriter = XmlWriter.Create(this.OrdersPath);
            ordersWriter.WriteStartElement("head");
            ordersWriter.WriteFullEndElement();
            ordersWriter.Close();
            XmlDocument docOrder = new XmlDocument();
            docOrder.Load(OrdersPath);
            foreach (Order ord in this.Orders)
            {
                ord.SaveOrder(docOrder);
            }
            docOrder.Save(this.OrdersPath);
        }
        public void CommitProducts()
        {
            XmlWriter productsWriter = XmlWriter.Create(this.ProductsPath);
            productsWriter.WriteStartElement("head");
            productsWriter.WriteFullEndElement();
            productsWriter.Close();
            XmlDocument docProduct = new XmlDocument();
            docProduct.Load(ProductsPath);
            foreach (Product prd in this.Products)
            {
                DataBase.SaveProductDB(docProduct, prd);
            }
            docProduct.Save(this.ProductsPath);
        }
        public void CommitUsers()
        {
            XmlWriter usersWriter = XmlWriter.Create(this.UsersPath);
            usersWriter.WriteStartElement("head");
            usersWriter.WriteFullEndElement();
            usersWriter.Close();
            XmlDocument docUser = new XmlDocument();
            docUser.Load(UsersPath);
            foreach (User usr in this.Users)
            {
                DataBase.SaveUserDB(docUser, usr);
            }
            docUser.Save(this.UsersPath);
        }

        public void CommitCkecks()
        {
            XmlWriter checksWriter = XmlWriter.Create(this.ChecksPath);
            checksWriter.WriteStartElement("head");
            checksWriter.WriteFullEndElement();
            checksWriter.Close();
            XmlDocument docCheck = new XmlDocument();
            docCheck.Load(this.ChecksPath);
            foreach (Check ch in this.Checks)
            {
                ch.SaveCheckDB(docCheck);
            }
            docCheck.Save(this.ChecksPath);
        }
        public void Commit()
        {
            this.CommitOrders();
            this.CommitProducts();
            this.CommitUsers();
            this.CommitCkecks();
        }
        public void LoadOrders()
        {
            int id = -1;
            int amount = -1;
            int price = -1;
            Dictionary<int, int> dict = new Dictionary<int, int>(); 
            XmlTextReader reader = new XmlTextReader(this.OrdersPath);
            int i = 0;
            while (reader.Read())
            {
                if (reader.Name == "userId" && reader.HasAttributes)
                {
                    if (i != 0)
                    {
                        this.orders.Add(new Order(id, dict));
                        dict.Clear();
                        Console.WriteLine(i);
                    }
                    i++;
                    id = Convert.ToInt32(reader.GetAttribute("name_id"));
                }
                if (reader.Name == "amount")
                {
                    amount = reader.ReadElementContentAsInt();
                }
                if (reader.Name == "price")
                {
                    price = reader.ReadElementContentAsInt();
                    dict[price] = amount;
                }
            }
            this.orders.Add(new Order(id, dict));
            reader.Close();
        }
        public void LoadProducts()
        {
            XmlTextReader reader = new XmlTextReader(this.ProductsPath);
            Product p = new Product();
            int id = -1;
            string name = "no_name";
            double price = -1.0;
            while (reader.Read())
            {
                if (reader.Name == "ProductId" && reader.HasAttributes)
                {
                    id = Convert.ToInt32(reader.GetAttribute("product_id"));
                }
                if (reader.Name == "ProductName")
                {
                    name = reader.ReadElementContentAsString();
                }
                if (reader.Name == "ProductPrice")
                {
                    price = reader.ReadElementContentAsDouble();
                    this.products.Add(new Product(id, name, price));
                    Console.WriteLine(1);
                }
            }
            reader.Close();
        }
        public void LoadUsers()
        {
            XmlTextReader reader = new XmlTextReader(this.UsersPath);
            int id = -1;
            string login = "no_login";
            string password = "no_password";
            List<int> roles = new List<int>();
            while (reader.Read())
            {
                if (reader.Name == "UserId" && reader.HasAttributes)
                {
                    id = Convert.ToInt32(reader.GetAttribute("user_id"));
                }
                if (reader.Name == "UserLogin")
                {
                    login = reader.ReadElementContentAsString();
                }
                if (reader.Name == "UserPassword")
                {
                    password = reader.ReadElementContentAsString();
                }
                if (reader.Name == "UserRole")
                {
                    string line = reader.ReadElementContentAsString();
                    List<int> tempList = new List<int>();
                    while (line.IndexOf("|") != -1)
                    {
                        roles.Add(Convert.ToInt32(line.Substring(0, line.IndexOf("|"))));
                        line = line.Remove(0, line.IndexOf("|") + 1);
                    }
                    this.users.Add(new User(id, login, password, roles));
                }
            }
            reader.Close();
        }

        public Order GetOrderById(int id)
        {
            Order retOrd = new Order();
            bool found = false;
            foreach (Order ord in this.Orders)
            {
                if (ord.ID == id)
                {
                    retOrd = ord;
                    found = true;
                    break;
                }
                else
                {
                    continue;
                }
            }
            if (found)
            {
                return retOrd;
            }
            else
            {
                throw new ArgumentException("No user with id: >" + id.ToString() + "< found");
            }
        }
        public User GetUserById(int id)
        {
            User retUsr = new User();
            bool found = false;
            foreach (User usr in this.Users)
            {
                if (usr.Id == id)
                {
                    retUsr = usr;
                    found = true;
                    break;
                }
                else
                {
                    continue;
                }
            }
            if (found)
            {
                return retUsr;
            }
            else
            {
                throw new ArgumentException("No order with id: >" + id.ToString() + "< found");
            }
        }
        public Product GetProductById(int id)
        {
            Product retPrd = new Product();
            bool found = false;
            foreach (Product prd in this.Products)
            {
                if (prd.Id == id)
                {
                    retPrd = prd;
                    found = true;
                    break;
                }
                else
                {
                    continue;
                }
            }
            if (found)
            {
                return retPrd;
            }
            else
            {
                throw new ArgumentException("No product with id: >" + id.ToString() + "< found");
            }
        }

        /// <summary>
        /// return price of product by id
        /// </summary>
        /// <param name="id">id of product</param>
        /// <returns></returns>
        public double GetPriceById(int id)
        {
            double price = 0;
            bool found = false;
            foreach (Product prd in this.Products)
            {
                if (prd.Id == id)
                {
                    price = prd.Price;
                    found = true;
                    break;
                }
                else
                {
                    continue;
                }
            }
            if (found)
            {
                return price;
            }
            else
            {
                throw new ArgumentException("No product with id: >" + id.ToString() + "< found");
            }
        }

        private static void SaveUserDB(XmlDocument doc, User myUser)
        {
            XmlNode root = doc.DocumentElement;
            XmlElement newID = doc.CreateElement("UserId");
            XmlAttribute attrID = doc.CreateAttribute("user_id");
            attrID.Value = myUser.Id.ToString();
            newID.SetAttributeNode(attrID);
            root.InsertAfter(newID, root.LastChild);
            XmlElement uLogin = doc.CreateElement("UserLogin");
            XmlElement uPassword = doc.CreateElement("UserPassword");
            XmlElement uRole = doc.CreateElement("UserRole");
            XmlText usLog = doc.CreateTextNode(myUser.Login);
            XmlText usPass = doc.CreateTextNode(myUser.Password);
            string temp = "";
            foreach (int i in myUser.RolesId)
            {
                temp = temp + i.ToString() + "|";
            }
            XmlText usRole = doc.CreateTextNode(temp);
            uLogin.AppendChild(usLog);
            uPassword.AppendChild(usPass);
            uRole.AppendChild(usRole);
            root.InsertAfter(uLogin, root.LastChild);
            root.InsertAfter(uPassword, root.LastChild);
            root.InsertAfter(uRole, root.LastChild);
        }
        private static void SaveProductDB(XmlDocument doc, Product myProduct)
        {
            XmlNode root = doc.DocumentElement;
            XmlElement newID = doc.CreateElement("ProductId");
            XmlAttribute attrID = doc.CreateAttribute("product_id");
            attrID.Value = myProduct.Id.ToString();
            newID.SetAttributeNode(attrID);
            root.InsertAfter(newID, root.LastChild);
            XmlElement prodName = doc.CreateElement("ProductName");
            XmlElement prodPrice = doc.CreateElement("ProductPrice");
            XmlText pName = doc.CreateTextNode(myProduct.Name);
            XmlText pPrice = doc.CreateTextNode(myProduct.Price.ToString());
            prodName.AppendChild(pName);
            prodPrice.AppendChild(pPrice);
            root.InsertAfter(prodName, root.LastChild);
            root.InsertAfter(prodPrice, root.LastChild);
        }
    }
}

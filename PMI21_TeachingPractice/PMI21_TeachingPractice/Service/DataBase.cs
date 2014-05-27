//-----------------------------------------------------------------------
// <copyright file="DataBase.cs" company="PMI21_TeachingPractice">
//     Copyright PMI21_TeachingPractice. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
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

    /// <summary>
    /// Class which represents Data Base.
    /// </summary>
    public class DataBase
    {
        /// <summary>
        /// Instance of Data Base
        /// </summary>
        private static DataBase dataBaseInstance = null;

        /// <summary>
        /// List of orders.
        /// </summary>
        private List<Order> orders;

        /// <summary>
        /// List of products.
        /// </summary>
        private List<Products> products;

        /// <summary>
        /// List of roles.
        /// </summary>
        private List<Role> roles;

        /// <summary>
        /// List of users.
        /// </summary>
        private List<User> users;

        /// <summary>
        /// List of checks.
        /// </summary>
        private List<Check> checks;

        /// <summary>
        /// Path to orders
        /// </summary>
        private string ordersPath;

        /// <summary>
        /// Path to products
        /// </summary>
        private string productsPath;

        /// <summary>
        /// Path to users
        /// </summary>
        private string usersPath;

        /// <summary>
        /// Path to checks
        /// </summary>
        private string checksPath;

        /// <summary>
        /// Path to roles
        /// </summary>
        private string rolesPath;

        /// <summary>
        /// Users orders
        /// </summary>
        private Dictionary<int, List<int>> usersOrders;

        /// <summary>
        /// Initializes a new instance of the <see cref="DataBase" /> .
        /// </summary>
        private DataBase()
        {
            this.orders = new List<Order>();
            this.products = new List<Products>();
            this.users = new List<User>();
            this.ordersPath = string.Empty;
            this.productsPath = string.Empty;
            this.usersPath = string.Empty;
            this.checksPath = string.Empty;
            this.checks = new List<Check>();
            this.usersOrders = new Dictionary<int, List<int>>();
            this.roles = new List<Role>();
        }

        /// <summary>
        /// Gets instance of Data Base.
        /// </summary>
        public static DataBase Instance
        {
            get
            {
                if (dataBaseInstance == null)
                {
                    dataBaseInstance = new DataBase();
                }

                return dataBaseInstance;
            }
        }

        /// <summary>
        /// Gets list of Orders.
        /// </summary>
        public List<Order> Orders
        {
            get
            {
                return this.orders;
            }
        }

        /// <summary>
        /// Gets list of Products.
        /// </summary>
        public List<Products> Products
        {
            get
            {
                return this.products;
            }
        }

        /// <summary>
        ///  Gets list of Users.
        /// </summary>
        public List<User> Users
        {
            get
            {
                return this.users;
            }
        }

        /// <summary>
        ///  Gets list of Checks.
        /// </summary>
        public List<Check> Checks
        {
            get
            {
                return this.checks;
            }
        }

        /// <summary>
        ///  Gets list of Roles.
        /// </summary>
        public List<Role> Roles
        {
            get
            {
                return this.roles;
            }
        }

        /// <summary>
        /// Gets path to orders.
        /// </summary>
        private string OrdersPath
        {
            get
            {
                return this.ordersPath;
            }
        }

        /// <summary>
        /// Gets path to products.
        /// </summary>
        private string ProductsPath
        {
            get
            {
                return this.productsPath;
            }
        }

        /// <summary>
        /// Gets path to users.
        /// </summary>
        private string UsersPath
        {
            get
            {
                return this.usersPath;
            }
        }

        /// <summary>
        /// Gets path to checks.
        /// </summary>
        private string ChecksPath
        {
            get
            {
                return this.checksPath;
            }
        }

        /// <summary>
        /// Gets path to roles.
        /// </summary>
        private string RolesPath
        {
            get
            {
                return this.rolesPath;
            }
        }

        /// <summary>
        /// Get instance of Data Base
        /// </summary>
        /// <returns>instance of Data Base</returns>
        public static DataBase GetInstance()
        {
            if (dataBaseInstance == null)
            {
                dataBaseInstance = new DataBase();
            }

            return dataBaseInstance;
        }

        /// <summary>
        /// Set connections.
        /// </summary
        /// <param name="path">Path to file.</param>
        public void SetConnections(string path)
        {
            XmlTextReader reader = new XmlTextReader(path);
            while (reader.Read())
            {
                if (reader.Name == "OrdersPath")
                {
                    string temp = reader.ReadElementContentAsString();
                    if (File.Exists(temp))            
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
                    if (File.Exists(temp))                    
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
                    if (File.Exists(temp))                    
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
                    if (File.Exists(temp))                   
                    {
                        this.checksPath = temp;
                    }
                    else
                    {
                        throw new ArgumentException("String is not a path");
                    }
                }

                if (reader.Name == "RolesPath")
                {
                    string temp = reader.ReadElementContentAsString();
                    if (File.Exists(temp))
                    {
                        this.rolesPath = temp;
                    }
                    else
                    {
                        throw new ArgumentException("String is not a path");
                    }
                }
            }
        }

        /// <summary>
        /// Add new order to Data Base
        /// </summary>
        /// <param name="newOrder">New order.</param>
        public void Add(Order newOrder)
        {
            this.orders.Add(newOrder);
        }

        /// <summary>
        /// Add new product to Data Base
        /// </summary>
        /// <param name="newProduct">New product.</param>
        public void Add(Products newProduct)
        {
            this.products.Add(newProduct);
        }

        /// <summary>
        /// Add new user to Data Base
        /// </summary>
        /// <param name="newUser">New user.</param>
        public void Add(User newUser)
        {
            this.users.Add(newUser);
        }

        /// <summary>
        /// Add new check to Data Base
        /// </summary>
        /// <param name="newCheck">New check.</param>
        public void Add(Check newCheck)
        {
            this.checks.Add(newCheck);
        }

        /// <summary>
        /// Add new check to Data Base
        /// </summary>
        /// <param name="newCheck">New check.</param>
        public void Add(Role newRole)
        {
            this.roles.Add(newRole);
        }

        /// <summary>
        /// Method Commit
        /// </summary>
        public void Commit()
        {
            this.CommitProducts();
            this.CommitOrders();
            this.CommitUsers();
            this.CommitChecks();
            this.CommitRoles();
        }

        /// <summary>
        /// Load data of orders,users and products
        /// </summary>
        public void Load()
        {
            this.LoadOrders();
            this.LoadProducts();
            this.LoadUsers();
            this.LoadRoles();
        }

        /// <summary>
        /// return order by id
        /// </summary>
        /// <param name="id">id of order</param>
        /// <returns> Order</returns>
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

        /// <summary>
        /// return user by id
        /// </summary>
        /// <param name = "id">id of user</param>
        /// <returns>user</returns>
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


        /// <summary>
        /// return userID by name
        /// </summary>
        /// <param name = "id">name of user</param>
        /// <returns>userID</returns>
        public int GetUserIdByName(string name)
        {
            User retUsr = new User();
            bool found = false;
            foreach (User usr in this.Users)
            {
                if (usr.Login == name)
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
                return retUsr.Id;
            }
            else
            {
                throw new ArgumentException("No order with name: >" + name + "< found");
            }
        }


        /// <summary>
        /// return product by id
        /// </summary>
        /// <param name="id">id of product</param>
        /// <returns>product</returns>
        public Product GetProductById(int id)
        {
            Product getPrd = new Product();
            bool found = false;
            foreach (Products prd in this.Products)
            {
                if (prd.PropProduct.Id == id)
                {
                    getPrd = prd.PropProduct;
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
                return getPrd;
            }
            else
            {
                throw new ArgumentException("No product with id: >" + id.ToString() + "< found");
            }
        }

        /// <summary>
        /// return role by id
        /// </summary>
        /// <param name="id">id of role</param>
        /// <returns>role</returns>
        public Role GetRoleById(int id)
        {
            Role getRol = new Role();
            bool found = false;
            //foreach (Role rol in this.Roles)
            //{
            //    if (rol.Id == id)
            //    {
            //        getRol = rol;
            //        found = true;
            //        break;
            //    }
            //    else
            //    {
            //        continue;
            //    }
            //}
            if (id == 1) getRol = new Role(id, "Admin");
            else
                if (id == 2) getRol = new Role(id, "Client");
                else
                    if (id == 3) getRol = new Role(id, "TradeAgent");
            if (id >= 1 && id <= 3) found = true;
            if (found)
            {
                return getRol;
            }
            else
            {
                throw new ArgumentException("No role with id: >" + id.ToString() + "< found");
            }
        }

        /// <summary>
        /// return price of product by id
        /// </summary>
        /// <param name = "id"> id of product</param>
        /// <returns>price</returns>
        public double GetPriceById(int id)
        {
            double price = 0;
            bool found = false;
            foreach (Products prd in this.Products)
            {
                if (prd.PropProduct.Id == id)
                {
                    price = prd.PropProduct.Price;
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

        /// <summary>
        /// return name of product by id
        /// </summary>
        /// <param name="id">id of product</param>
        /// <returns>name</returns>
        public string GetNameById(int id)
        {
            string name = string.Empty;
            bool found = false;
            foreach (Products prd in this.Products)
            {
                if (prd.PropProduct.Id == id)
                {
                    name = prd.PropProduct.Name;
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
                return name;
            }
            else
            {
                throw new ArgumentException("No product with id: >" + id.ToString() + "< found");
            }
        }

        /// <summary>
        /// return id of product by login
        /// </summary>
        /// <param name = "login" > login </param>
        /// <returns>id of product</returns>
        public int GetIdByLogin(string login)
        {
            int ident = 0;
            /// User retUsr = new User();
            bool found = false;
            foreach (User usr in this.Users)
            {
                if (usr.Login == login)
                {
                    ident = usr.Id;
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
                return ident;
            }
            else
            {
                throw new ArgumentException("No order with login: >" + login + "< found");
            }
        }

        /// <summary>
        /// Commit orders
        /// </summary>
        public void CommitOrders()
        {
            XmlWriter ordersWriter = XmlWriter.Create(this.OrdersPath);
            ordersWriter.WriteStartElement("head");
            ordersWriter.WriteFullEndElement();
            ordersWriter.Close();
            XmlDocument docOrder = new XmlDocument();
            docOrder.Load(this.OrdersPath);
            foreach (Order ord in this.Orders)
            {
                ord.SaveOrder(docOrder);
            }

            docOrder.Save(this.OrdersPath);
        }

        /// <summary>
        /// Commit products
        /// </summary>
        public void CommitProducts()
        {
            XmlWriter productsWriter = XmlWriter.Create(this.ProductsPath);
            productsWriter.WriteStartElement("head");
            productsWriter.WriteFullEndElement();
            productsWriter.Close();
            XmlDocument docProduct = new XmlDocument();
            docProduct.Load(this.ProductsPath);
            foreach (Products prd in this.Products)
            {
                DataBase.SaveProductDB(docProduct, prd.PropProduct);
            }

            docProduct.Save(this.ProductsPath);
        }

        /// <summary>
        /// Commit users
        /// </summary>
        public void CommitUsers()
        {
            XmlWriter usersWriter = XmlWriter.Create(this.UsersPath);
            usersWriter.WriteStartElement("head");
            usersWriter.WriteFullEndElement();
            usersWriter.Close();
            XmlDocument docUser = new XmlDocument();
            docUser.Load(this.UsersPath);
            foreach (User usr in this.Users)
            {
                DataBase.SaveUserDB(docUser, usr);
            }

            docUser.Save(this.UsersPath);
        }

        /// <summary>
        /// Commit checks
        /// </summary>
        public void CommitChecks()
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

        /// <summary>
        /// commit roless
        /// </summary>
        public void CommitRoles()
        {
            XmlWriter rolesWriter = XmlWriter.Create(this.RolesPath);
            rolesWriter.WriteStartElement("head");
            rolesWriter.WriteFullEndElement();
            rolesWriter.Close();
            XmlDocument docRole = new XmlDocument();
            docRole.Load(this.RolesPath);
            foreach (Role rol in this.Roles)
            {
                DataBase.SaveRoleDB(docRole, rol);
            }

            docRole.Save(this.RolesPath);
        }

        /// <summary>
        /// Load Orders
        /// </summary>
        public void LoadOrders()
        {
            int id = -1;
            int amount = -1;
            int ident = -1;
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
                    dict[ident] = amount;
                }

                if (reader.Name == "id")
                {
                    ident = reader.ReadElementContentAsInt();
                }
            }

            this.orders.Add(new Order(id, dict));
            reader.Close();
        }

        /// <summary>
        /// Load Products
        /// </summary>
        public void LoadProducts()
        {
            XmlTextReader reader = new XmlTextReader(this.ProductsPath);
            Product p = new Product();
            int id = -1;
            string name = "no_name";
            double price = -1.0;
            int amount = 0;
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
                    
                    //this.products.Add(new Product(id, name, price));                   
                    //// what the genial and magic WriteLine() ???
                    //Console.WriteLine(1);
                }

                if (reader.Name == "ProductAmount")
                {
                    amount = reader.ReadElementContentAsInt();
                    this.products.Add(new Products(id, name, price, amount));
                }
            }

            reader.Close();
        }

        /// <summary>
        /// Load Users
        /// </summary>
        public void LoadUsers()
        {
            XmlTextReader reader = new XmlTextReader(this.UsersPath);
            int id = -1;
            string login = "no_login";
            string password = "no_password";
            List<int> roles = new List<int>();
            this.users.Clear();
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
                    roles.Clear();
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

        /// <summary>
        /// Load Roles
        /// </summary>
        public void LoadRoles()
        {
            XmlTextReader reader = new XmlTextReader(this.RolesPath);

            int id = -1;
            string name = "no_name";
            while (reader.Read())
            {
                if (reader.Name == "RoleId" && reader.HasAttributes)
                {
                    id = Convert.ToInt32(reader.GetAttribute("role_id"));
                }

                if (reader.Name == "RoleName")
                {
                    name = reader.ReadElementContentAsString();
                }
                if (id != -1 && name != "no_name")
                {
                    this.roles.Add(new Role(id, name));
                    id = -1;
                    name = "no_name";
                }
            }

            

            reader.Close();
        }

        /// <summary>
        /// Save product to Data Base
        /// </summary>
        /// <param name="doc">document</param>
        /// <param name="myProduct">product which we save to Data Base</param>
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
            XmlText productName = doc.CreateTextNode(myProduct.Name);
            XmlText productPrice = doc.CreateTextNode(myProduct.Price.ToString());
            prodName.AppendChild(productName);
            prodPrice.AppendChild(productPrice);
            root.InsertAfter(prodName, root.LastChild);
            root.InsertAfter(prodPrice, root.LastChild);
        }

        /// <summary>
        /// Save user to Data Base
        /// </summary>
        /// <param name="doc">document</param>
        /// <param name="myUser">user whom we save to Data Base</param>
        private static void SaveUserDB(XmlDocument doc, User myUser)
        {
            XmlNode root = doc.DocumentElement;
            XmlElement newID = doc.CreateElement("UserId");
            XmlAttribute attrID = doc.CreateAttribute("user_id");
            attrID.Value = myUser.Id.ToString();
            newID.SetAttributeNode(attrID);
            root.InsertAfter(newID, root.LastChild);
            XmlElement userLogin = doc.CreateElement("UserLogin");
            XmlElement userPassword = doc.CreateElement("UserPassword");
            XmlElement userRole = doc.CreateElement("UserRole");
            XmlText usLog = doc.CreateTextNode(myUser.Login);
            XmlText usPass = doc.CreateTextNode(myUser.Password);
            string temp = string.Empty;
            foreach (int i in myUser.RolesId)
            {
                temp = temp + i.ToString() + "|";
            }

            XmlText usRole = doc.CreateTextNode(temp);
            userLogin.AppendChild(usLog);
            userPassword.AppendChild(usPass);
            userRole.AppendChild(usRole);
            root.InsertAfter(userLogin, root.LastChild);
            root.InsertAfter(userPassword, root.LastChild);
            root.InsertAfter(userRole, root.LastChild);
        }

        /// <summary>
        /// Save role to Data Base
        /// </summary>
        /// <param name="doc">document</param>
        /// <param name="myRole">user whom we save to Data Base</param>
        private static void SaveRoleDB(XmlDocument doc, Role myRole)
        {
            XmlNode root = doc.DocumentElement;
            XmlElement newID = doc.CreateElement("RoleId");
            XmlAttribute attrID = doc.CreateAttribute("role_id");
            attrID.Value = myRole.Id.ToString();
            newID.SetAttributeNode(attrID);
            root.InsertAfter(newID, root.LastChild);
            XmlElement roleName = doc.CreateElement("RoleName");
            XmlText rolName = doc.CreateTextNode(myRole.Name);
            roleName.AppendChild(rolName);
            root.InsertAfter(roleName, root.LastChild);
        }
    }
}

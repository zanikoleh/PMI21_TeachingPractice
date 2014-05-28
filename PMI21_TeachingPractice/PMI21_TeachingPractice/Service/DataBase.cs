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
            this.LoadChecks();
            this.LoadRoles();
        }

        /// <summary>
        /// Return order by id.
        /// </summary>
        /// <param name="id">Id of order.</param>
        /// <returns> Order if such exists, NULL otherwise.</returns>
        public Order GetOrderById(int id)
        {
            Order toReturn = null;

            foreach (Order order in this.orders)
            {
                if (order.ID == id)
                {
                    toReturn = new Order(order);
                    break;
                }
            }

            return toReturn;
        }

        /// <summary>
        /// return user by id
        /// </summary>
        /// <param name = "id">id of user</param>
        /// <returns>User if such exists, NULL otherwise</returns>
        public User GetUserById(int id)
        {
            User toReturn = null;

            foreach (User user in this.users)
            {
                if (user.Id == id)
                {
                    toReturn = new User(user);
                    break;
                }
            }

            return toReturn;
        }

        /// <summary>
        /// Gets id of user by user's login.
        /// </summary>
        /// <param name = "login" >User's login.</param>
        /// <returns>Id of user if such exists, -1 otherwise.</returns>
        public int GetUserIdByLogin(string login)
        {
            int toReturn = -1;

            foreach (User user in this.Users)
            {
                if (user.Login == login)
                {
                    toReturn = user.Id;
                    break;
                }
            }

            return toReturn;
        }

        /// <summary>
        /// Return product by id
        /// </summary>
        /// <param name="id">id of product</param>
        /// <returns>Product if such exists, NULL otherwise</returns>
        public Products GetProductById(int id)
        {
            Products toReturn = null;

            foreach (Products product in this.products)
            {
                if (product.PropProduct.Id == id)
                {
                    toReturn = new Products(product);
                    break;
                }
            }

            return toReturn;
        }

        /// <summary>
        /// return role by id
        /// </summary>
        /// <param name="id">id of role</param>
        /// <returns>Role if such exists, NULL otherwise.</returns>
        public Role GetRoleById(int id)
        {
            Role toReturn = null;

            foreach (Role role in this.roles)
            {
                if (role.Id == id)
                {
                    toReturn = new Role(role);
                    break;
                }
            }

            return toReturn;
        }

        /// <summary>
        /// return price of product by id
        /// </summary>
        /// <param name = "id"> id of product</param>
        /// <returns>Price of product if such exists, -1 otherwise.</returns>
        public double GetPriceById(int id)
        {
            double toReturn = -1;

            foreach(Products product in this.products)
            {
                if (product.PropProduct.Id == id)
                {
                    toReturn = product.PropProduct.Price;
                    break;
                }
            }

            return toReturn;
        }

        /// <summary>
        /// return name of product by id
        /// </summary>
        /// <param name="id">id of product</param>
        /// <returns>Name if such exists, NULL otherwise.</returns>
        public string GetNameById(int id)
        {
            string toReturn = null;

            foreach (Products product in this.products)
            {
                if (product.PropProduct.Id == id)
                {
                    toReturn = product.PropProduct.Name;
                    break;
                }
            }

            return toReturn;
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
                DataBase.SaveProductDB(docProduct, prd);
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
            foreach (Check check in this.Checks)
            {
                DataBase.SaveCheckDB(docCheck, check);
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
            this.orders.Clear();
            while (reader.Read())
            {
                if (reader.Name == "userId" && reader.HasAttributes)
                {
                    if (i != 0)
                    {
                        this.orders.Add(new Order(id, dict));
                        dict.Clear();
                        /// omg, facepalm 
                        //Console.WriteLine(i);
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
            this.products.Clear();
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
        /// Load checks
        /// </summary>
        public void LoadChecks()
        {
            XmlTextReader reader = new XmlTextReader(this.ChecksPath);
            int idOrder = -1;
            int idUser = -1;
            DateTime time = new DateTime();
            
            this.checks.Clear();

            while (reader.Read())
            {
                if (reader.Name == "OrderId" && reader.HasAttributes)
                {
                    idOrder = Convert.ToInt32(reader.GetAttribute("user_id"));
                }

                if (reader.Name == "UserId")
                {
                    idUser = Convert.ToInt32(reader.ReadElementContentAsString());
                }

                if (reader.Name == "Time")
                {
                    time = Convert.ToDateTime(reader.ReadElementContentAsString());

                    this.checks.Add(new Check(idOrder, idUser, time));
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
            this.roles.Clear();
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
        private static void SaveProductDB(XmlDocument doc, Products myProduct)
        {
            XmlNode root = doc.DocumentElement;
            XmlElement newID = doc.CreateElement("ProductId");
            XmlAttribute attrID = doc.CreateAttribute("product_id");
            
            attrID.Value = myProduct.PropProduct.Id.ToString();
            newID.SetAttributeNode(attrID);
            root.InsertAfter(newID, root.LastChild);
            
            XmlElement prodName = doc.CreateElement("ProductName");
            XmlElement prodPrice = doc.CreateElement("ProductPrice");
            XmlElement prodAmount = doc.CreateElement("ProductAmount");

            XmlText productName = doc.CreateTextNode(myProduct.PropProduct.Name);
            XmlText productPrice = doc.CreateTextNode(myProduct.PropProduct.Price.ToString());            
            XmlText productAmount = doc.CreateTextNode(myProduct.Amount.ToString());

            prodName.AppendChild(productName);
            prodPrice.AppendChild(productPrice);
            prodAmount.AppendChild(productAmount);

            root.InsertAfter(prodName, root.LastChild);
            root.InsertAfter(prodPrice, root.LastChild);
            root.InsertAfter(prodAmount, root.LastChild);
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
        /// Save check to Data Base.
        /// </summary>
        /// <param name="doc">Document.</param>
        /// <param name="check">Check which is saved to Data Base.</param>
        private static void SaveCheckDB(XmlDocument doc, Check check)
        {
            XmlNode root = doc.DocumentElement;
            XmlElement newID = doc.CreateElement("OrderId");
            XmlAttribute attrID = doc.CreateAttribute("order_id");
            attrID.Value = check.IdOrder.ToString();
            newID.SetAttributeNode(attrID);
            root.InsertAfter(newID, root.LastChild);
            XmlElement userID = doc.CreateElement("UserId");
            XmlElement time = doc.CreateElement("Time");
            XmlText uIDval = doc.CreateTextNode(check.IdUser.ToString());
            XmlText timeVal = doc.CreateTextNode(check.Time.ToString("o"));
            userID.AppendChild(uIDval);
            time.AppendChild(timeVal);
            root.InsertAfter(userID, root.LastChild);
            root.InsertAfter(time, root.LastChild);
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

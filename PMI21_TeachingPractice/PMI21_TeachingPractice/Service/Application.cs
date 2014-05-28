//-----------------------------------------------------------------------
// <copyright file="Application.cs" company="PMI21_TeachingPractice">
//     Copyright PMI21_TeachingPractice. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace PMI21_TeachingPractice
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Class which represents console application
    /// </summary>
    public static class Application
    {
        /// <summary>
        /// Delegate for containing 
        /// </summary>
        public delegate void UserAbbilities(User user);

        /// <summary>
        /// Main interface function
        /// </summary>
        public static void WorkFlow()
        {
            try
            {
                Console.WriteLine("Type 1 to login type 0 to exit:");
                int start = Convert.ToInt32(Console.ReadLine());
                switch (start)
                {
                    case 1:
                        {
                            User logged = Application.Login(0);
                            LoggedInterface(logged);
                            break;
                        }

                    case 0:
                        {
                            Environment.Exit(0);
                            break;
                        }
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("You chose wrong option");
                WorkFlow();
            }
        }

        /// <summary>
        /// Login interface
        /// </summary>
        /// <param name="count">Counter of tries</param>
        /// <returns>User if logged null if not</returns>
        private static User Login(int count)
        {
            try
            {
                Console.WriteLine("login:");
                string login = Console.ReadLine();
                Console.WriteLine("password:");
                ConsoleKeyInfo key;
                string password = string.Empty;
                do
                {
                    key = Console.ReadKey(true);

                    // Backspace Should Not Work
                    if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                    {
                        password += key.KeyChar;
                        Console.Write("*");
                    }
                    else
                    {
                        if (key.Key == ConsoleKey.Backspace && password.Length > 0)
                        {
                            password = password.Substring(0, (password.Length - 1));
                            Console.Write("\b \b");
                        }
                    }
                }
                while (key.Key != ConsoleKey.Enter);
                Console.WriteLine();
                if (UserControls.Identify(login, password) == null)
                {
                    if (count < 3)
                    {
                        Console.WriteLine("Wrong login or password");
                        Console.WriteLine("Press 0 to exit");
                        string message = "You have only " + (3 - count).ToString() + " more attempts";
                        Console.WriteLine(message);
                        char choice = Convert.ToChar(Console.ReadLine());
                        switch (choice)
                        {
                            case '0':
                                {
                                    Environment.Exit(0);
                                    return new User();
                                }

                            default:
                                {
                                    return Login(count + 1);
                                }
                        }
                    }
                    else
                    {
                        Environment.Exit(0);
                        return new User();
                    }
                }

                return UserControls.Identify(login, password);
            }
            catch (FormatException)
            {
                return Login(count + 1);
            }
        }

        /// <summary>
        /// Special interface for logged user
        /// </summary>
        /// <param name="user">Logged user</param>
        private static void LoggedInterface(User user)
        {
            List<UserAbbilities> abbilities = new List<UserAbbilities>();
            abbilities = BuildAbbilityList(user);
            bool working = true;
            bool find = false;
            while (working)
            {
                Console.WriteLine("Write methods for list of method exit to exit or name of method");
                find = false;
                string option = Console.ReadLine();
                if (option.Equals("methods"))
                {
                    find = true;
                    foreach (var abillity in abbilities)
                    {
                        Console.WriteLine(abillity.Method.Name);
                        option = string.Empty;
                    }
                }
                if (option.Equals("exit"))
                {
                    find = true;
                    working = false;
                    option = string.Empty;
                }
                if (!option.Equals(string.Empty))
                {
                    foreach (var abillity in abbilities)
                    {
                        if (abillity.Method.Name.Equals(option))
                        {
                            find = true;
                            abillity(user);
                        }
                    }
                    if (!find)
                    {
                        Console.WriteLine("There is no method with such name");
                    }
                }
            }
        }

        /// <summary>
        /// Method for creating ability list for user
        /// </summary>
        /// <param name="user">Logged user</param>
        /// <returns>list of UserAbilities</returns>
        private static List<UserAbbilities> BuildAbbilityList(User user)
        {
            List<UserAbbilities> abbilities = new List<UserAbbilities>();
            DataBase.Instance.SetConnections(Constants.PATH);
            DataBase.Instance.Load();
            foreach (int i in user.RolesId)
            {
                AbbilitiesAdd(abbilities, DataBase.Instance.GetRoleById(i));
            }

            return abbilities;
        }

        /// <summary>
        /// Adding abilities of role
        /// </summary>
        /// <param name="abbilities">List of UserAbilities</param>
        /// <param name="role">Needed role</param>
        private static void AbbilitiesAdd(List<UserAbbilities> abbilities, Role role)
        {
            if (role.Name.Equals("Admin"))
            {
                abbilities.Add(new UserAbbilities(AddNewUser));
                abbilities.Add(new UserAbbilities(DeleteUser));
                abbilities.Add(new UserAbbilities(ShowAllUsers));
                abbilities.Add(ShowAllRoles);
            }

            if (role.Name.Equals("Client"))
            {
                abbilities.Add(new UserAbbilities(ShowProducts));
                abbilities.Add(new UserAbbilities(PerformOrder));
            }

            if (role.Name.Equals("TradeAgent"))
            {
                abbilities.Add(AddNewProduct);
                abbilities.Add(GetHistoryOfProducts);
                abbilities.Add(Modify);
                abbilities.Add(GetHistoryOfUsersActivity);
            }
        }

        /// <summary>
        /// Adding of new user
        /// </summary>
        private static void AddNewUser(User user)
        {
            string login;
            string password;
            Console.WriteLine("Write login for new user:");
            login = Console.ReadLine();
            Console.WriteLine("Password: ");
            password = Console.ReadLine();
            UserControls.AddNewUser(login, password);
            User user1 = UserControls.Identify(login, password); bool adding = true;
            while (adding)
            {
                Console.WriteLine("Enter 0 to stop adding 1 to add new role to user any other symbol to show available roles");
                char c = Convert.ToChar(Console.ReadLine());
                switch (c)
                {
                    case '0':
                        {
                            adding = false;
                            break;
                        }

                    case '1':
                        {
                            Console.WriteLine("Enter roles id:");
                            int roleid = Convert.ToInt32(Console.ReadLine());
                            if (UserControls.AddUsersRole(user1.Id, roleid))
                            {
                                Console.WriteLine("Role added successfully");
                            }
                            else
                            {
                                Console.WriteLine("Something went wrong maybe id is incorrect");
                            }

                            break;
                        }

                    default:
                        {
                            ShowAllRoles(user);
                            break;
                        }
                }
            }
        }

        /// <summary>
        /// Show all availble roles
        /// </summary>
        /// <param name="user"></param>
        private static void ShowAllRoles(User user)
        {
            DataBase.Instance.SetConnections(Constants.PATH);
            DataBase.Instance.Load();
            foreach (var r in DataBase.Instance.Roles)
            {
                Console.WriteLine(r.ToString());
            }
        }
        /// <summary>
        /// Deleting user from base.
        /// </summary>
        private static void DeleteUser(User user)
        {
            Console.WriteLine("Input ID user to delete.");
            int idDel = new int();
            idDel = Convert.ToInt32(Console.ReadLine());
            if (UserControls.DeleteUser(idDel))
            {
                Console.WriteLine("Success!");
            }
            else
            {
                Console.WriteLine("Wrong ID!");
            }
        }

        /// <summary>
        /// Prints list of users.
        /// </summary>
        private static void ShowAllUsers(User user)
        {
            List<User> allUsers = new List<User>();
            allUsers = DataBase.Instance.Users;
            foreach (User u in allUsers)
            {
                Console.WriteLine(u.ToString());
            }
        }

        /// <summary>
        /// Prints list of products.
        /// </summary>
        private static void ShowProducts(User user)
        {
            DataBase db = DataBase.GetInstance();
            db.LoadProducts();
            List<Products> products = new List<Products>();

            products = db.Products;
            foreach (Products product in products)
            {
                product.Write();
            }
        }

        /// <summary>
        /// Adds new product to DataBase.
        /// </summary>
        private static void AddNewProduct(User user)
        {
            int id;
            string name;
            double price;
            int amount;

            Console.WriteLine("Input id of product");
            id = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Input name of product");
            name = Console.ReadLine();

            Console.WriteLine("Input price of product");
            price = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Input amount of product");
            amount = int.Parse(Console.ReadLine());

            Products product = new Products(id, name, price, amount);
            DataBase db = DataBase.GetInstance();
            db.Add(product);
        }

        /// <summary>
        /// Method to perform new order for current user
        /// </summary>
        private static void PerformOrder(User user)
        {
            Order order = new Order();
            order.ID = user.Id;
            Ordering(order);
            Console.WriteLine("Press 1 to perform order any other symbol to clear order");
            char c = Convert.ToChar(Console.ReadLine());
            if (c == '1')
            {
                DataBase.Instance.Add(order);
                Check check = new Check(order.ID, user.Id);
                DataBase.Instance.Add(check);
                DataBase.Instance.Commit();
            }
            else
            {
                PerformOrder(user);
            }
        }

        private static void Ordering(Order order)
        {
            bool ordering = true;
            try
            {
                while (ordering)
                {
                    Console.WriteLine("Enter 1 to add new product 0 to end order any other symbol to show products:");
                    char option = Convert.ToChar(Console.ReadLine());
                    switch (option)
                    {
                        case '0':
                            {
                                ordering = false;
                                break;
                            }

                        case '1':
                            {
                                DataBase.Instance.SetConnections(Constants.PATH);
                                Console.WriteLine("Enter id of product:");
                                int id = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("Enter amount of product:");
                                int amount = Convert.ToInt32(Console.ReadLine());
                                DataBase.Instance.GetProductById(id);
                                order.AddProduct(id, amount);
                                break;
                            }

                        default:
                            {
                                ShowProducts(new User());
                                break;
                            }
                    }
                }
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
                Ordering(order);
            }
            catch (FormatException e)
            {
                Console.WriteLine("Wrong id or amount");
                Ordering(order);
            }
        }

        /// <summary>
        /// Method to modify product
        /// </summary>
        private static void Modify(User user)
        {
            Console.WriteLine("Input name of product to modify");
            string name = Console.ReadLine();
            int id = Products.IdByName(name);

            if (id != 0)
            {
                Console.WriteLine("Input amount to add products (- means delete)");
                int amount = Convert.ToInt32(Console.ReadLine());
                DataBase dataBase;
                dataBase = DataBase.GetInstance();
                foreach (Products prods in dataBase.Products)
                {
                    if (prods.PropProduct.Id == id)
                    {
                        prods.Amount += amount;
                    }
                }
                dataBase.CommitProducts();
            }
        }

        /// <summary>
        /// Print list of products changing.
        /// </summary>
        private static void GetHistoryOfProducts(User user)
        {
            Console.WriteLine("Input id of poduct");
            int id = int.Parse(Console.ReadLine());
            List<Order> orders = DataBase.GetInstance().Orders;
            List<KeyValuePair<int, int>> AmountOfChangingOfProduct = new List<KeyValuePair<int, int>>();

            foreach (var order in orders)
            {
                foreach (var product in order.List)
                {
                    if (product.Key == id)
                        AmountOfChangingOfProduct.Add(product);
                }
            }

            foreach (var item in AmountOfChangingOfProduct)
            {
                Console.WriteLine("Buying id " + item.Key.ToString() + " products in " + item.Value.ToString() + " amount");
            }
            Console.WriteLine("End history of product with id " + id.ToString());
        }

        /// <summary>
        /// Gives history of user activity
        /// </summary>
        private static void GetHistoryOfUsersActivity(User user)
        {
            Console.WriteLine("Input name of user");
            string name = Console.ReadLine();
            int id = DataBase.Instance.GetUserIdByLogin(name);

            User tempUser = UserControls.GetUserById(id);
            List<Check> checks = DataBase.Instance.Checks;
            List<Check> userChecks = new List<Check>();
            foreach (var item in checks)
            {
                if (item.IdUser == tempUser.Id)
                {
                    userChecks.Add(item);
                }
            }

            foreach (var item in userChecks)
            {
                Console.WriteLine("User " + name + " create order with id " + item.IdOrder.ToString()
                    + item.Time.ToString());
            }
            Console.WriteLine("End of history of user " + tempUser.Login + " activity");
        }
    }
}

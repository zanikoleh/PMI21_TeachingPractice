using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMI21_TeachingPractice
{
    static public class Application
    {
        /// <summary>
        /// Delegate for containing 
        /// </summary>
        public delegate void UserAbbilities(User user);

        /// <summary>
        /// Main interface function
        /// </summary>
        static public void WorkFlow()
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
        static private User Login(int count)
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
                // Stops Receving Keys Once Enter is Pressed
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
        static private void LoggedInterface(User user)
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
                if (option.Equals("help"))
                {
                    foreach (var abillity in abbilities)
                    {
                        Console.WriteLine(abillity.Method.Name);
                        option = string.Empty;
                    }
                }
                if (option.Equals("exit"))
                {
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
                        if (!find)
                        {
                            Console.WriteLine("There is no method with such name");
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Method for creating abbility list for user
        /// </summary>
        /// <param name="user">Logged user</param>
        /// <returns>list of UserAbbilities</returns>
        static private List<UserAbbilities> BuildAbbilityList(User user)
        {
            List<UserAbbilities> abbilities = new List<UserAbbilities>();
            foreach (int i in user.RolesId)
            {
                AbbilitiesAdd(abbilities, UserControls.GetRoleById(i));
            }
            return abbilities;
        }

        /// <summary>
        /// Adding abillities of role
        /// </summary>
        /// <param name="abbilities">list of UserAbillities</param>
        /// <param name="role">Role</param>
        private static void AbbilitiesAdd(List<UserAbbilities> abbilities, Role role)
        {
            if (role.Name.Equals("Admin"))
            {
                abbilities.Add(new UserAbbilities(AddNewUser));
                abbilities.Add(new UserAbbilities(DeleteUser));
                abbilities.Add(new UserAbbilities(ShowAllUsers));
            }
            if (role.Name.Equals("Client"))
            {
                abbilities.Add(new UserAbbilities(ShowProducts));
                abbilities.Add(new UserAbbilities(PerformOrder));
            }
            if (role.Name.Equals("TradeAgent"))
            {

                abbilities.Add(AddNewProducts);
                //abbilities.Add(GetHistoryOfProducts);
                //abbilities.Add(GetHistoryOfUsers);
                //abbilities.Add(Modify);
                abbilities.Add(AddNewProduct);
                abbilities.Add(GetHistoryOfProducts);
                abbilities.Add(Modify);                

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
            User newUser = UserControls.Identify(login, password);
            bool adding = true;
            while (adding)
            {
                Console.WriteLine("Enter 0 to stop adding 1 to add new role to user any other symbol to show available roles");
                int c = Console.Read();
                switch (c)
                {
                    case 0:
                        {
                            adding = false;
                            break;
                        }
                    case 1:
                        {
                            Console.WriteLine("Enter roles id:");
                            int roleid = Convert.ToInt32(Console.ReadLine());
                            if (UserControls.AddUsersRole(newUser.Id, roleid))
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
                            break;
                        }
                }

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
            List<User> AllUsers = new List<User>();
            if (UserControls.LoadBaseUsers(out AllUsers))
            {
                foreach (User user1 in AllUsers)
                {
                    Console.WriteLine(user1.ToString());
                }
            }
        }

        /// <summary>
        /// Prints list of products.
        /// </summary>
        private static void ShowProducts(User user)
        {
            DataBase db = DataBase.GetInstance();
            db.LoadProducts();
            List<Product> products = new List<Product>();
            products = db.Products;
            foreach (Product product in products)
            {
                Console.WriteLine(product.ToString());
            }
        }

        /// <summary>
        /// Adds new product to DataBase.
        /// </summary>
        private static void AddNewProducts(User user)
        {
            int id;
            string name;
            double price;
            Console.WriteLine("Input id of product");
            id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Input name of product");
            name = Console.ReadLine();
            Console.WriteLine("Input price of product");
            price = Convert.ToDouble(Console.ReadLine());
            Product product = new Product(id, name, price);
            DataBase db = DataBase.GetInstance();
            db.Add(product);
        }

        private static void PerformOrder(User user)
        {
            Order order = new Order();
            Ordering(order, user);

        }

        private static void Ordering(Order order, User user)
        {
            bool ordering = true;
            try
            {
                while (ordering)
                {
                    Console.WriteLine("Enter 1 to add new product 0 to end order:");
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
                                DataBase database = DataBase.Instance;
                                database.SetConnections(Constants.PATH);
                                database.LoadProducts();
                                Console.WriteLine("Enter id of product:");
                                int id = Convert.ToInt32(Console.ReadLine());
                                database.GetProductById(id);
                                order.AddProduct(id, 1);
                                break;
                            }
                        default:
                            {
                                break;
                            }
                    }
                }

            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
                Ordering(order, user);
            }
        }

        private static void Modify(User user)
        {
            Console.WriteLine("Input name of product to modify");
            string name = Console.ReadLine();
            int id = Product.IdByName(name);
            // Needs to create list of Products in DataBase to modify amount of products.

            // Console.WriteLine("Input amount to add products (- means delete)");
            // int amount = Convert.ToInt32(Console.ReadLine());
            // DataBase dataBase;
            //dataBase = DataBase.GetInstance();
            //foreach (Products prods in dataBase.Products)
            //{
            //    if (prods.id == id)
            //    {
            //        prods.Amount += amount;
            //    }
            }

        /// <summary>
        /// Print list of products changing.
        /// </summary>
        private static void GetHistoryOfProducts(User user)
        {
            Console.WriteLine("Input name of poduct");
            string name = Console.ReadLine();
            //int id = Products().IdByName(name);
            //Order order = new Order().ReturnOrderById(id);
            //order.Write();
        }

        /// <summary>
        /// 
        /// </summary>
        private static void GetHistoryOfUsersActivity(User user)
        {
            Console.WriteLine("Input name of poduct");
            string name = Console.ReadLine();
            int id = 0; // UserControl().GetUserIdByName(name);
            User user = UserControls.GetUserById(id);
            List<Check> checks = DataBase.Instance.Checks;
            List<Check> usersChecks = new List<Check>();
            foreach (var item in checks)
            {
                if (item.IdUser == user.Id)
                    usersChecks.Add(item);
            }

            foreach (var item in usersChecks)
            {
                // 
                // Console.WriteLine(item.ToString());
            }
        }
    }
}

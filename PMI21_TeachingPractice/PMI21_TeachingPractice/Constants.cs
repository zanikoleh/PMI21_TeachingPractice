namespace UsersProj
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// This class is created in order to avoid using magic numbers in the program code
    /// </summary>
    public class Constants
    {
        public const string BaseFile = "Base.csv";
        public const string IdRegistry = "Idbase.csv";
        public const string UsersNumber = "UsersNumber.csv";
        public const int Zero = 0;
        public const int One = 1;
        public const int Two = 2;
        public const int Three = 3;

        public enum Roles 
        { 
            Admin = 1, Client, TradeAgent, NoRole 
        }
    }
}

//-----------------------------------------------------------------------
// <copyright file="Program.cs" company="PMI21_TeachingPractice">
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
    using System.Xml;
    using PMI21_TeachingPractice.Service;

    /// <summary>
    /// Main program
    /// </summary>
    public class Program
    {

        /// <summary>
        /// Main function
        /// </summary>
        public static void Main()
        {            
            DataBase.GetInstance().SetConnections(Constants.PATH);
            DataBase.GetInstance().Load();
            DataBase.GetInstance().LoadOrders();
            DataBase.GetInstance().CommitOrders();
            Application.WorkFlow();
            //System.Windows.Forms.Application.EnableVisualStyles();
            //System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
            //Console.WriteLine(UserControl.GetUserById(3));
            //System.Windows.Forms.Application.Run(new DataBaseForm());
        }
    }
}
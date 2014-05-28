//-----------------------------------------------------------------------
// <copyright file="Check.cs" company="PMI21_TeachingPractice">
//     Copyright PMI21_TeachingPractice. All rights reserved.
// </copyright>
//----------------------------------------------------------------------
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
    /// class Check save check with orders
    /// </summary>
    public class Check
    {
        /// <summary>
        /// id of order
        /// </summary>
        private int idOrder;

        /// <summary>
        /// id of user
        /// </summary>
        private int idUser;

        /// <summary>
        /// time of order
        /// </summary>
        private DateTime time;

        /// <summary>
        /// Initializes the instance of the <see cref="Check"/> class
        /// Default Constructor of class 
        /// </summary>
        public Check()
        {
            this.idOrder = 0;
            this.idUser = 0;
            this.time = new DateTime();
        }

        /// <summary>
        /// Initializes the instance of the <see cref="Check"/> class
        /// Instance constructor 
        /// </summary>
        /// <param name="idOrderVal">id of order</param>
        /// <param name="idUserVal">id of user</param>
        public Check(int idOrderVal, int idUserVal)
        {
            this.idOrder = idOrderVal;
            this.idUser = idUserVal;
            this.time = new DateTime();
        }

        /// <summary>
        /// Initializes the instance of the <see cref="Check"/> class
        /// </summary>
        /// <param name="idOrderVal">id of order</param>
        /// <param name="idUserVal">id of user</param>
        /// <param name="time">time</param>
        public Check(int idOrderVal, int idUserVal, DateTime time)
        {
            this.idOrder = idOrderVal;
            this.idUser = idUserVal;
            this.time = time;
        }

        /// <summary>
        ///  id user
        /// </summary>
        public int IdUser
        {
            get
            {
                return this.idUser;
            }
        }

        /// <summary>
        /// Id order
        /// </summary>
        public int IdOrder
        {
            get
            {
                return this.idOrder;
            }
        }

        /// <summary>
        /// Time 
        /// </summary>
        public DateTime Time
        {
            get
            {
                return this.time;
            }
        }
    }
}
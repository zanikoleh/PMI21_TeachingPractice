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

    public class Check
    {
        private int idOrder;
        private int idUser;
        private DateTime time;
        public Check()
        {
            this.idOrder = 0;
            this.idUser = 0;
            this.time = DateTime.Now;
        }
        public Check(int idOrderVal, int idUserVal)
        {
            this.idOrder = idOrderVal;
            this.idUser = idUserVal;
            this.time = DateTime.Now;
        }
        public Check(int idOrderVal, int idUserVal, DateTime time)
        {
            this.idOrder = idOrderVal;
            this.idUser = idUserVal;
            this.time = time;
        }
        public int IdUser
        {
            get
            {
                return this.idUser;
            }
        }
        public int IdOrder
        {
            get
            {
                return this.idOrder;
            }
        }
        public DateTime Time
        {
            get
            {
                return this.time;
            }
        }
    }
}
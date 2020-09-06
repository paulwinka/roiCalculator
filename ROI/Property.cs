using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROI
{
    public class Property
    {
        private int _id;
        private string _address;
        //private double _sqFt;

        public Property()
        {
        }

        public int Id { get { return _id; } set { _id = value; } }
        public string Address { get { return _address; } set { _address = value; } }
        //public double SqFt { get { return _sqFt; } set { _sqFt = value; } }
    }
}
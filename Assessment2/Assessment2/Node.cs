using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment2
{
    class Node
    {
        private Customer data;
        public Node Left, Right;

        public Node(Customer customer)
        {
            data = customer;   //constructor
            Left = null;
            Right = null;
            
        }

        public Customer Data
        {
            set { data = value; }   //property for get
            get { return data; }
        }
    }
}

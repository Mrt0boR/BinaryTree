using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assessment2
{
    class Customer : IComparable<Customer>
    {



        private string firstName;
        private string lastName;
        private int age;
        private string address;
        private float amountOwed;


        public Customer(string firstname, string lastname, int age, string address, float amountOwed)
        {
            this.firstName = firstname;
            this.lastName = lastname;
            this.age = age;
            this.address = address;
            this.amountOwed = amountOwed;
        }

        //getters and setters
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }


        public int Age
        {
            get { return age; }
            set { age = value; }

        }

        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        public float AmountOwed
        {
            get { return amountOwed; }
            set { amountOwed = value; }

        }



        /* 
         *  For my comparison I will use IComparable and the Compare to method, comparing the entered customers lastname with the last of the current node's customer.
         *  if the last name of the entered customer is lexicographically less than the last name of the current customer node then it is added to the left sub tree. If the opposite
         *  is true then the customer is added to the right subtree.
         *  
         *  the comparison is made in the compareTo method via the comparison of numerical unicode values, this allows there to be similar comparison of various integer values 
         *  similar to task 1 and 2 of the assessment where data value is an integer and that dictates subtree left or right placement.
         *
         *
         */

        

      


        //get all information

        public string GetInformation()
        {


            return "First Name: " + firstName +
                    "Last Name: " + lastName +
                   ", Age: " + age +
                   ", Address: " + address +
                   ", Amount Owed: " + amountOwed;


        }

        public int CompareTo(Customer CustomerInTree)
        {
            
            if (lastName != null)
            {
                
                Customer customerBeingEntered = (Customer)CustomerInTree; // Casting 'other' to Customer type
                return this.LastName.CompareTo(customerBeingEntered.LastName);


            }
            else
            {
                MessageBox.Show("Please Enter a customer Last Name", "Last Name Box UnFilled", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
           
        }

        public int CompareToFirstName(Customer CustomerInTree)
        {

            if (firstName != null)
            {
                Customer customerBeingEntered = (Customer)CustomerInTree;
                return this.FirstName.CompareTo(customerBeingEntered.firstName);
            }
            else
            {
                MessageBox.Show("Please Enter a customer First Name", "First Name Box UnFilled", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }





        }
    }







}


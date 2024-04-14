using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assessment2
{
    public partial class Form1 : Form
    {

        BinaryTree bintree = new BinaryTree();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }



        //CUSTOMER DETAILS ENTRY BUTTON
        private void button1_Click(object sender, EventArgs e)
        {



            if (string.IsNullOrEmpty(textBox1.Text)
                || string.IsNullOrEmpty(textBox2.Text)
                || string.IsNullOrEmpty(textBox3.Text)
                || string.IsNullOrEmpty(textBox4.Text)
                || string.IsNullOrEmpty(textBox5.Text)
                )
            {
                MessageBox.Show("Please Fill in all the Information Boxes.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            int ageParsingObject;
            try
            {
                ageParsingObject = int.Parse(textBox3.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Only Integers can be entered for a Customer Age");
                return;
            }

            //This section also follows the same function as the age intager check.
            float amountOwedParsingObject;
            try
            {
                amountOwedParsingObject = float.Parse(textBox5.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Please specify the Customer's amount owed in Pounds and Pence");
                return;
            }

            Customer newCustomer = new Customer
               (
                   textBox1.Text,
                   textBox2.Text,
                   ageParsingObject,
                   textBox4.Text,
                   amountOwedParsingObject
               );

            bintree.InsertItem(newCustomer);

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();

            label13.Text = ("Success");


            label6.Text = bintree.Count().ToString();

            inOrderUpdater();
            preOrderUpdater();
            postOrderUpdater();
        }


        private void inOrderUpdater()
        {
            string inOrderTreeData = bintree.InOrder();
            label15.Text = inOrderTreeData;

        }

        private void preOrderUpdater()
        {
            string preOrderTreeData = bintree.PreOrder();  
            label16.Text = preOrderTreeData;

        }

        private void postOrderUpdater()
        {
            string postOrderTreeData = bintree.PostOrder();
            label17.Text  = postOrderTreeData;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox6.Text))
            {
                MessageBox.Show("Search Box is Empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
          
            else
            {
                string searchedLastName = textBox6.Text;
                Customer seachedCustomer = bintree.SearchByLastName(searchedLastName);

                if (seachedCustomer == null)
                {
                    MessageBox.Show("The Customer Cannot be Found, Please Check Customer Details and Check for any Typos",
                        "Customer Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    label19.Text = seachedCustomer.GetInformation();
                }
            }
        }
    }
}

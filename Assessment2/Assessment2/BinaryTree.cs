using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assessment2
{
    class BinaryTree
    {
        
        private Node root;

        public BinaryTree()
        {
            root = null;
        }


        public BinaryTree(Node root)
        {
            this.root = root; //this is for inserting and passing a value to the root
        }




        //insert method to be recursively called
        private void insertItem (Customer customer, ref Node tree)
        {
            
            if (tree == null)
            {
                tree = new Node(customer);
            } 
            else
            {

                int comparisonvalue = customer.CompareTo(tree.Data);

                if (comparisonvalue > 0)
                {
                    // If the comparison result is greater than 0, insert the customer into the right subtree
                    insertItem(customer, ref tree.Right);
                }
                else if (comparisonvalue < 0)
                {
                    // If the comparison result is less than 0, insert the customer into the left subtree
                    insertItem(customer, ref tree.Left);
                }


                else if (comparisonvalue == 0)
                {
                    int firstnamecomparisonvalue = customer.CompareToFirstName(tree.Data);

                    if(firstnamecomparisonvalue > 0)
                    {
                        insertItem(customer, ref tree.Right);
                    }
                    else if (firstnamecomparisonvalue < 0)
                    {
                        insertItem(customer, ref tree.Left);
                    }
                }
                

                
                
            }
        }


        //recrusively call the private insertItem method

        //ASSIGN TO BUTTON ON FORM1 
        public void InsertItem(Customer item)
        {
            insertItem(item, ref root);
        }





        /*
         * 
         * old code before the comparison, in case something breaks

            else if (customer>tree.Data)
            {
                insertItem(item, ref tree.Right);
            }
            else if (customer<tree.Data)
            {
                insertItem(customer, ref tree.Left);
            }
            
        }
        */



        
        //Count the Number of items in the Tree

        public int Count()
        {
            return count(root);
        }
        private int count(Node tree)
        {
            if (tree == null)
            {
                return 0;


            }
            return count(tree.Left) + count(tree.Right) + 1;
        }







        // In order method to be recursively called
        private string inOrder(Node tree)
        {
            //if tree is not empty
            if (tree != null)
            {
                //traverse left
                string inOrderResult = string.Empty;

                inOrderResult = inOrderResult + inOrder(tree.Left);

                //display node value
                inOrderResult = inOrderResult + tree.Data.GetInformation() + "\n";

                //traverse right
                inOrderResult = inOrderResult + inOrder(tree.Right);

                return inOrderResult;

            }
            else
            {
                return string.Empty;
            }
        }

        //recursively call the private inOrder method
        public string InOrder()
        {
            //recursively call private in order method passing root value as an argument
           return inOrder(root);
        }




        //preOrder traversal method to be recursively called upon
        private string preOrder(Node tree)
        {
            if (tree != null)
            {

                string preOrderResult = string.Empty;  
                //display
                preOrderResult = preOrderResult + tree.Data.GetInformation() + "\n";

                //left sub-tree
                preOrderResult += preOrder(tree.Left);

                // right sub-tree
                preOrderResult += preOrder(tree.Right);

                //return value of the data collated into the string preOrderResult
                return preOrderResult;
            }
            else
            {
                return string.Empty;
            }
        }

        // Public method to initiate PreOrder traversal
        public string PreOrder()
        {
            // Recursively call private PreOrder method passing root value as an argument
            return preOrder(root);
        }


        private string postOrder(Node tree)
        {
            //if tree is not empty
            if (tree != null)
            {
                

                //string initialisation
                string postOrderResult = string.Empty;

                //left subtree 
                postOrderResult += postOrder(tree.Left);
                
                //right subtree
                postOrderResult += postOrder(tree.Right);

                //display
                postOrderResult += tree.Data.GetInformation() + "\n";

                //return the data now collated into the postOrderResult string.
                return postOrderResult;


            } else 
            
            { 
                
                return string.Empty; 
            }
        }

        public string PostOrder()
        {
            return postOrder(root);
        }

        //Customer Search Method
        
        public Customer SearchByLastName(string lastName)
        {
            return searchByLastName(root, lastName);

        }

        private Customer searchByLastName(Node tree, string lastName)
        {
            if (tree == null)
            {
               
                return null;
            }

            //The below line makes the tree data that is being parsed lower case, so if the user enters the name in upper lower or mixed case the name will still be found.
            // the Trim gets rid of any spaces after the entered string, so of the user enteres "smith " it becomes "smith".
            string treeLastNameData = tree.Data.LastName.ToLower().Trim();
            string treeSearchQuery = lastName.ToLower().Trim();
            
            /*
             * Comparison of the lastname entered with the last names found on each node. 
             * The varibale comparisonInt is then used to parse left or right tree branches 
             * depending on its value, as determined by the algorithm which allocates data upon insertion.
             */
            int comparisonInt = string.Compare(treeSearchQuery, treeLastNameData);

            if (comparisonInt == 0)
            {
                return tree.Data;

            }

            else if ( comparisonInt > 0)
            {

                return searchByLastName(tree.Right, lastName) ;

            }

            else 
            {
                //comparison int < 0; 

                return searchByLastName(tree.Left, lastName);
            }

        }


    }
}

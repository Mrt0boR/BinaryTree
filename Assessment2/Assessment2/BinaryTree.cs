using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

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
        private void inOrder(Node tree)
        {
            //if tree is not empty
            if (tree != null)
            {
                //traverse left
                inOrder(tree.Left);
                
                //display node value
                Console.Write(tree.Data + ",");
                
                //traverse right
                inOrder(tree.Right);


            }
        }

        //recursively call the private inOrder method
        public void InOrder()
        {
            //recursively call private in order method passing root value as an argument
            inOrder(root);
        }
    
    
    
    
        //preOrder traversal method to be recursively called upon
        private void preOrder(Node tree)
        {
            if (tree != null)
            {
                //display value in node
                Console.WriteLine(tree.Data + ",");
                
                //pre order traverse left right
                preOrder(tree.Left);
                preOrder(tree.Right);

                //endif statement closed by curly brace
            }
            
        }

        //recursively call the private inOrder method 
        public void PreOrder()
        {
            preOrder(root);
        }


        private void postOrder(Node tree)
        {
            //if tree is not empty
            if (tree != null)
            {
                //traverse left sub tree
                postOrder(tree.Left);

                //traverse right sub tree
                postOrder(tree.Right);

                //diplay value in node
                Console.WriteLine(tree.Data + ",");
            }
        }


        //Customer Search Method
            
        

    }
}

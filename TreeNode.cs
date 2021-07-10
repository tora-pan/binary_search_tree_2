using System;
using System.Collections.Generic;
using System.Text;

namespace binary_search_tree
{
    public class TreeNode
    {
        //Each Nodes Data
        private int data;
        public int Data
        {
            get { return data; }
        }

        //Right Child
        private TreeNode rightNode;
        public TreeNode RightNode
        {
            get { return rightNode; }
            set { rightNode = value; }
        }
        //Left Child
        private TreeNode leftNode;
        public TreeNode LeftNode
        {
            get { return leftNode; }
            set { leftNode = value; }
        }
        //For Implementing Soft Delete
        private bool isDeleted;
        public bool IsDeleted
        {
            get { return isDeleted; }
        }


        //Tree Node Constructor
        public TreeNode(int value)
        {
            data = value;
        }


        //To Do

        //Soft Delete
        public void Delete()
        {
            isDeleted = true;
        }
        public void Insert(int value)
        {
            if(value >= data)
            {
                if(rightNode == null)
                {
                    rightNode = new TreeNode(value);
                }
                else
                {
                    rightNode.Insert(value);
                }
            }
            else
            {
                if(leftNode == null)
                {
                    leftNode = new TreeNode(value);
                }
                else
                {
                    leftNode.Insert(value);
                }
            }
        }

        public void InOrderTraversal()
        {
            if (leftNode != null)
            {
                leftNode.InOrderTraversal();
            }
                Console.Write(data + " ");

            if (rightNode != null)
            {
                rightNode.InOrderTraversal();
            }

        }
        public void PreOrderTraversal()
        {

        }
        public void PostOrderTraversal()
        {
            if(leftNode != null)
            {
                leftNode.PostOrderTraversal();
            }
            
            if(rightNode != null)
            {
                rightNode.PostOrderTraversal();
            }

            Console.Write(data + " ");
        }
        
        public TreeNode Find(int value)
        {
            TreeNode currentNode = this;

            // loop through this node and all of the children
            while(currentNode != null)
            {
                if(value == currentNode.data)
                {
                    return currentNode;
                }
                else if(value > currentNode.data)
                {
                    currentNode = currentNode.rightNode;
                }
                else
                {
                    currentNode = currentNode.leftNode;
                }
            }
            // no match
            return null;
        }
    }
}

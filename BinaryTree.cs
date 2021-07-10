using System;
using System.Collections.Generic;
using System.Text;

namespace binary_search_tree
{
    public class BinaryTree
    {
        private TreeNode root;
        public TreeNode Root
        {
            get { return root; }
        }

        public void Insert(int data)
        {
            //Check if root is null
            if (root != null)
            {
                root.Insert(data);
            }
            else
            {
                //If null, set the root to a new Tree Node with passed in data
                root = new TreeNode(data);
            }
        }

        public void Remove(int data)
        {
            //Set the current and parent node to root, so when we remove we can remove using the parents reference
            TreeNode currentNode = root;
            TreeNode parentNode = root;
            bool isLeftChild = false;

            //empty tree
            if(currentNode == null)
            {
                return;
            }

            //Find the Node
            //loop through until node is not found or if we found the node with matching data
            while (currentNode != null && currentNode.Data != data)
            {
                //set current node to be new parent reference, then we look at its children
                parentNode = currentNode;
                //if the data we are looking for is less than the current node then we look at its left child
                if (data < currentNode.Data)
                {
                    currentNode = currentNode.LeftNode;
                    isLeftChild = true;
                }
                else
                {
                    currentNode = currentNode.RightNode;
                    isLeftChild = false;
                }
            }
            //if the node is not found nothing to delete just return
            if(currentNode == null)
            {
                return;
            }
            //We found a Leaf node aka no children
            if(currentNode.LeftNode == null && currentNode.RightNode == null)
            {
            //The root doesn't have parent to check what child it is,so just set to null
                if(currentNode == root)
                {
                    root = null;
                }
                else
                {
                    //When not the root node
                    //see which child of the parent should be deleted
                    if (isLeftChild)
                    {
                        //remove reference to left child node
                        parentNode.LeftNode = null;
                    }
                    else
                    {
                        //remove reference to right child node
                        parentNode.RightNode = null;
                    }
                }
            }
            //current only has left child, so we set the parents node child to be this nodes left child
            else if(currentNode.RightNode == null)
            {
                //If the current node is the root then we just set root to Left child node
                if(currentNode == root)
                {
                    root = currentNode.LeftNode;
                }
                else
                {
                    //see which child of the parent should be deleted
                    if (isLeftChild)
                    {
                        //current is left child so we set the left node of the parent to the current nodes left child
                        parentNode.LeftNode = currentNode.LeftNode;
                    }
                    else
                    {
                        //current is right child so we set the right node of the parent to the current nodes left child
                        parentNode.RightNode = currentNode.LeftNode;
                    }

                }
            }
            else if (currentNode.LeftNode == null) //current only has right child, so we set the parents node child to be this nodes right child
            {
                //If the current node is the root then we just set root to Right child node
                if (currentNode == root)
                {
                    root = currentNode.RightNode;
                }
                else
                {
                    //see which child of the parent should be deleted
                    if (isLeftChild)
                    {   //current is left child so we set the left node of the parent to the current nodes right child
                        parentNode.LeftNode = currentNode.RightNode;
                    }
                    else
                    {   //current is right child so we set the right node of the parent to the current nodes right child
                        parentNode.RightNode = currentNode.RightNode;
                    }
                }
            }
            else//Current Node has both a left and a right child
            {
                //When both child nodes exist we can go to the right node and then find the leaf node of the left child as this will be the least number
                //that is greater than the current node. It may have right child, so the right child would become..left child of the parent of this leaf aka successer node

                //Find the successor node aka least greater node
                TreeNode successor = GetSuccessor(currentNode);
                //if the current node is the root node then the new root is the successor node
                if (currentNode == root)
                {
                    root = successor;
                }
                else if (isLeftChild)
                {//if this is the left child set the parents left child node as the successor node
                    parentNode.LeftNode = successor;
                }
                else
                {//if this is the right child set the parents right child node as the successor node
                    parentNode.RightNode = successor;
                }
            }
        }
        private TreeNode GetSuccessor(TreeNode node)
        {
            //TODO
            return node;
        }

        public void SoftDelete(int data)
        {
            //TODO
        }

        public void InOrderTraversal()
        {
            if (root != null)
            {
                root.InOrderTraversal();
            }
        }

        public void PostOrderTraversal()
        {
            if(root != null)
            {
                root.PostOrderTraversal();
            }
        }

        public TreeNode Find(int node)
        {
            if(root != null)
            {
                return root.Find(node);
            }
            else
            {
                return null;
            }
        }

        
    }
}

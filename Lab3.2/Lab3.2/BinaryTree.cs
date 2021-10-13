using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3._2
{
    class Node<T>  where T : IComparable<T>
    {
        public Node<T> LeftNode { get; set; }
        public Node<T> RightNode { get; set; }
        public T Data { get; set; }
    }
    class BinaryTree<T> : IEnumerable, IEnumerator<T> where T : IComparable<T>
    {
        public Node<T> Root { get; set; }

        public bool Add(T value)
        {
            Node<T> before = null, after = this.Root;

            while (after != null)
            {
                before = after;
                if (value.CompareTo(after.Data) <= 0) //Is new node in left tree? 
                    after = after.LeftNode;
                else if (value.CompareTo(after.Data) >= 0) //Is new node in right tree?
                    after = after.RightNode;
                else
                {
                    //Exist same value
                    return false;
                }
            }

            Node<T> newNode = new Node<T>();
            newNode.Data = value;

            if (this.Root == null)//Tree ise empty
                this.Root = newNode;
            else
            {
                if (value.CompareTo(before.Data) >= 0)
                    before.RightNode = newNode;
                else
                    before.LeftNode = newNode;
            }

            return true;
        }

        public Node<T> Find(T value)
        {
            return this.Find(value, this.Root);
        }

        public void Remove(T value)
        {
            this.Root = Remove(this.Root, value);
        }

        private Node<T> Remove(Node<T> parent, T key)
        {
            if (parent == null) return parent;

            if (key.CompareTo(parent.Data) < 0)
            {
                parent.LeftNode = Remove(parent.LeftNode, key);
            }
            else if (key.CompareTo(parent.Data) > 0)
            {
                parent.RightNode = Remove(parent.RightNode, key);
            }

            // if value is same as parent's value, then this is the node to be deleted  
            else
            {
                // node with only one child or no child  
                if (parent.LeftNode == null)
                    return parent.RightNode;
                else if (parent.RightNode == null)
                    return parent.LeftNode;

                // node with two children: Get the inorder successor (smallest in the right subtree)  
                parent.Data = MinValue(parent.RightNode);

                // Delete the inorder successor  
                parent.RightNode = Remove(parent.RightNode, parent.Data);
            }

            return parent;
        }

        private T MinValue(Node<T> node)
        {
            T minv = node.Data;

            while (node.LeftNode != null)
            {
                minv = node.LeftNode.Data;
                node = node.LeftNode;
            }

            return minv;
        }

        private Node<T> Find(T value, Node<T> parent)
        {
            if (parent != null)
            {
                if (value.CompareTo(parent.Data) == 0)
                {
                    return parent;
                }
                if (value.CompareTo(parent.Data) < 0)
                {
                    return Find(value, parent.LeftNode);
                }
                else
                {
                    return Find(value, parent.RightNode);
                }
            }

            return null;
        }

        public int GetTreeDepth()
        {
            return this.GetTreeDepth(this.Root);
        }

        private int GetTreeDepth(Node<T> parent)
        {
            return parent == null ? 0 : Math.Max(GetTreeDepth(parent.LeftNode), GetTreeDepth(parent.RightNode)) + 1;
        }

        public void TraversePreOrder(Node<T> parent)
        {
            if (parent != null)
            {
                Console.Write(parent.Data + " ");
                TraversePreOrder(parent.LeftNode);
                TraversePreOrder(parent.RightNode);
            }
        }

        public void TraverseInOrder(Node<T> parent)
        {
            if (parent != null)
            {
                TraverseInOrder(parent.LeftNode);
                Console.Write(parent.Data + " ");
                TraverseInOrder(parent.RightNode);
            }
        }

        public void TraversePostOrder(Node<T> parent)
        {
            if (parent != null)
            {
                TraversePostOrder(parent.LeftNode);
                TraversePostOrder(parent.RightNode);
                Console.Write(parent.Data + " ");
            }
        }

        public List<T> Elements { get; set; }

        public T Current => Elements[i];

        object IEnumerator.Current => Elements[i];

        private void CreateElementList()
        {
            Elements = new List<T>();
            RecursiveInorder(Root);
        }

        private void RecursiveInorder(Node<T> root)
        {
            if (root.LeftNode != null)
            {
                RecursiveInorder(root.LeftNode);
            }
            Elements.Add(root.Data);
            if (root.RightNode != null)
            {
                RecursiveInorder(root.RightNode);
            }
        }

        int i = 0;



        public bool MoveNext()
        {

            i++;
            if (Elements.Count == i)
            {
                return false;
            }

            return true;


        }

        public void Reset()
        {
           i = 0;
        }

        public void Dispose()
        {
            i = 0;
            Elements = null;
        }

        public IEnumerator GetEnumerator()
        {
            CreateElementList();
            return this;
        }
    }
}

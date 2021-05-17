using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BST2
{
    class Program
    {
        class BST
        {
            public Node Root { get; set; }

            public class Node
            {
                public int Value { get; set; }
                public Node Left { get; set; }
                public Node Right { get; set; }

                public override string ToString()
                {
                    return Value.ToString();
                }
            }

            public void Add(int num)
            {
                if (Root == null)//If we add the very first node
                {
                    Root = new Node() { Value = num };
                    return;
                }

                //Look for the right place for a new Node
                Node Current = Root;
                while(Current.Left != null || Current.Right != null)//We reach a leaf
                {
                    if (Current.Value > num)
                    {
                        if (Current.Left == null) break;
                        Current = Current.Left;
                    }
                    else
                    {
                        if (Current.Right == null) break;
                        Current = Current.Right;
                    }
                }

                //In the leaf we need to find a leaf for a new node
                if(Current.Value > num)
                {
                    Current.Left = new Node() { Value = num };
                }
                else
                {
                    Current.Right = new Node() { Value = num };
                }

            }//End of ADD()

            public int GetMinValue() //The most left node
            {
                Node current = Root;
                while (current.Left != null)
                    current = current.Left;
                return current.Value;
            }

            public int GetMaxValue() //The most right node
            {
                Node current = Root;
                while (current.Right != null)
                    current = current.Right;
                return current.Value;
            }

            //Поиск в бинарном дереве — ключевая операция. 
            public Node Search(int element, Node root)
            {
                if (root == null) return null;//NULL means that the element is not found
                if (element == root.Value) return root;

                if (root.Value > element)
                {
                   return Search(element, root.Left);
                }
                else
                {
                    return Search(element, root.Right);
                }
            }

        }//End of class BST

        static void Main(string[] args)
        {
            var bst = new BST();
            bst.Add(10);
            bst.Add(5);
            bst.Add(15);
            bst.Add(2);
            bst.Add(3);

            Console.WriteLine(bst.GetMinValue());
            Console.WriteLine(bst.GetMaxValue());

            Console.WriteLine(bst.Search(15, bst.Root));
            Console.WriteLine(bst.Search(115, bst.Root));//null
        }
    }
}

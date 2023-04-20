using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Proj1
{
    internal class TreeNode<T> : Element<T>
    {
        public T Value { get; set; }
        //public TreeNode<T>? Left { get; set; }
        public Element<T>? Left { get; set; }
        //public TreeNode<T>? Right { get; set; }
        public Element<T>? Right { get; set; }
        //public TreeNode<T>? Parent { get; set; }
        public Element<T>? Parent { get; set; }
        //public TreeNode(T Value, TreeNode<T>? Left, TreeNode<T>? Right, TreeNode<T>? Parent)
        public TreeNode(T Value, Element<T>? Left, Element<T>? Right, Element<T>? Parent)
        {
            this.Value = Value;
            this.Left = Left;
            this.Right = Right;
            this.Parent = Parent;
        }
    }

    internal class TreeForwardIterator<T> : Iterator<T>
    {
        //public TreeNode<T>? p;
        public Element<T>? p { get; }

        //public TreeForwardIterator(TreeNode<T>? p)
        public TreeForwardIterator(Element<T>? p)
        {
            this.p = p;
        }
        public Iterator<T> Next()
        {
            //Console.WriteLine($"Next from {p.Value}           -----------------------------------------------");
            //TreeNode<T>? p1 = p, prev;
            Element<T>? p1 = p, prev;

            if (p1.Left != null) return new TreeForwardIterator<T>(p1.Left);
            else if (p1.Right != null) return new TreeForwardIterator<T>(p1.Right);

            do
            {
                //Console.WriteLine($"{p.Value}, {p1.Value}");
                prev = p1;
                p1 = p1.Parent;
                if (p1 == null)
                {         
                    return new TreeForwardIterator<T>(null);
                }
            } while (p1.Right == null || p1.Right == prev);

            return new TreeForwardIterator<T>(p1.Right);
        }

        public T Val
        {
            get
            {
                if (p == null) throw new NullReferenceException();
                return p.Value;
            }
        }

        public bool IsNotNull()
        {
            return !(p == null);
        }
    }

    internal class TreeReverseIterator<T> : Iterator<T>
    {
        //public TreeNode<T>? p;
        public Element<T>? p { get; }

        //public TreeReverseIterator(TreeNode<T>? p)
        public TreeReverseIterator(Element<T>? p)
        {
            this.p = p;
        }
        public Iterator<T> Next()
        {
            //TreeNode<T>? p1 = p;
            Element<T>? p1 = p;

            p1 = p1.Parent;

            if(p1 == null) return new TreeReverseIterator<T>(null); //jesteśmy korzeniem

            if(p1.Left == p || p1.Left == null) return new TreeReverseIterator<T>(p1); // jesteśmy lewym lub jedynym dzieckiem rodzica

            p1 = p1.Left;

            while(p1.Left != null || p1.Right != null)
            {
                if (p1.Right != null) p1 = p1.Right;
                else p1 = p1.Left;
            }

            return new TreeReverseIterator<T>(p1);

            //if (p.Left != null || p.Right == null) return new TreeReverseIterator<T>(p.Parent);

            //TreeNode<T>? prev = p;

            //p = p.Parent;

            //if (p.Left == null || p.Left == prev) return new TreeReverseIterator<T>(p);

            //p = p.Left;

            //while (p.Right == null) p = p.Right;

            //return new TreeForwardIterator<T>(p);
        }

        public T Val
        {
            get
            {
                if (p == null) throw new NullReferenceException();
                return p.Value;
            }
        }

        public bool IsNotNull()
        {
            return !(p == null);
        }
    }

    internal class MyBinaryTree<T> : Collection<T>
    {
        //public TreeNode<T>? Root { get; set; }
        public Element<T>? Root { get; set; }

        public void Add(T val)
        {
            Console.WriteLine($"Adding item: {val} to tree");

            if (Root == null)
            {
                Root = new TreeNode<T>(val, null, null, null);
                Console.WriteLine("Adding to root");
                return;
            }
            Random rnd = new Random();

            //TreeNode<T> p = Root, prev = null;
            Element<T> p = Root, prev = null;

            while(p != null)
            {
                prev = p;
                if(p.Left != null && p.Right == null)
                {
                    //p = new TreeNode<T>(val, null, null, prev);
                    p = new TreeNode<T>(val, null, null, prev);
                    prev.Right = p;
                    Console.WriteLine("Adding to right");
                    break;
                }
                else if(p.Left == null && p.Right != null)
                {
                    p = new TreeNode<T>(val, null, null, prev);
                    prev.Left = p;
                    Console.WriteLine("Adding to left");
                    break;
                }
                else if(p.Left == null && p.Right == null)
                {
                    p = new TreeNode<T>(val, null, null, prev);
                    if (rnd.Next() % 2 == 0)
                    {
                        prev.Left = p;
                        Console.WriteLine("Adding to left");
                    }
                    else
                    {
                        prev.Right = p;
                        Console.WriteLine("Adding to right");
                    }
                    break;
                }
                else
                {
                    if (rnd.Next() % 2 == 0)
                    {
                        p = p.Left;
                        Console.WriteLine("Going left");
                    }
                    else
                    {
                        p = p.Right;
                        Console.WriteLine("Going right");
                    }
                }
            }
        }

        public void Remove(Iterator<T> it)
        {
            Element<T> p = it.p, p1 = p;

            // znajdowanie liścia w poddrzewie p
            while(p1.Left != null || p1.Right != null)
            {
                if(p1.Left != null) p1 = p1.Left;
                else p1 = p1.Right;
            }

            // odłączanie liścia od rodzica
            if (p1 == p1.Parent.Left) p1.Parent.Left = null;
            else if (p1 == p1.Parent.Right) p1.Parent.Right = null;

            // podłączanie i rodzica dzieci p do p1 (byłego liścia)
            if(p1 != p.Left) p1.Left = p.Left;
            if(p1 != p.Right) p1.Right = p.Right;
            p1.Parent = p.Parent;

            // podłączanie p1 do rodzica
            if (p == p.Parent.Left) p.Parent.Left = p1;
            else if (p == p.Parent.Right) p.Parent.Right = p1;

            if(p.Left != null && p.Left != p1) p.Left.Parent = p1;
            if(p.Right != null && p.Right != p1) p.Right.Parent = p1;

            // ewentualna zmiana korzenia
            if (p == Root) Root = p1;
        }

        //public void Remove(T val)
        //{
        //    TreeForwardIterator<T> it = this.GetForwardIterator();

        //    while ( it.IsNotNull() && !it.Val.Equals(val) ) it = it.Next();

        //    if (!it.IsNotNull()) return;

        //    TreeNode<T> p = it.p;
        //}

        //public override Iterator GetForwardIterator()
        public Iterator<T> GetForwardIterator()
        {
            return new TreeForwardIterator<T>(Root);
        }

        //public override Iterator GetReverseIterator()
        public Iterator<T> GetReverseIterator()
        {
            //TreeNode<T> p = Root;
            Element<T> p = Root;

            while (p.Left != null || p.Right != null)
            {
                if (p.Right != null) p = p.Right;
                else p = p.Left;
            }
            return new TreeReverseIterator<T>(p);
        }
    }
}

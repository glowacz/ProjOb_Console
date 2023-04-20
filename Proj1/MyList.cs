//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Proj1
//{
//    internal class Node<T>
//    {
//        public T Value { get; set; }
//        public Node<T>? Prev { get; set; }
//        public Node<T>? Next { get; set; }
//        public Node(T Value, Node<T>? Prev, Node<T>? Next)
//        {
//            this.Value = Value;
//            this.Prev = Prev;
//            this.Next = Next;
//        }
//    }

//    //internal class ListIterator<T> : Iterator<T>
//    //{
//    //    Node<T>? el;

//    //    public ListIterator(Node<T>? el)
//    //    {
//    //        this.el = el;
//    //    }
//    //    public Iterator<T> Next()
//    //    {
//    //        if (el == null || el.Next == null) throw new IndexOutOfRangeException();
//    //        return new ListIterator<T>(el.Next);
//    //    }

//    //    public Iterator<T> Prev()
//    //    {
//    //        if (el == null || el.Prev == null) throw new IndexOutOfRangeException();
//    //        return new ListIterator<T>(el.Prev);
//    //    }

//    //    public T Val
//    //    {
//    //        get
//    //        {
//    //            return el.Value;
//    //        }
//    //    }
//    //}

//    internal class ListForwardIterator<T> : Iterator<T>
//    {
//        Node<T>? el;

//        public ListForwardIterator(Node<T>? el)
//        {
//            this.el = el;
//        }
//        public Iterator<T> Next()
//        {
//            //if (el == null || el.Next == null) throw new IndexOutOfRangeException();
//            return new ListForwardIterator<T>(el.Next);
//        }

//        public T Val
//        {
//            get
//            {
//                if (el == null) throw new NullReferenceException(); 
//                return el.Value;
//            }
//        }

//        public bool IsNotNull()
//        {
//            return !(el == null);
//        }
//    }

//    internal class ListReverseIterator<T> : Iterator<T>
//    {
//        Node<T>? el;

//        public ListReverseIterator(Node<T>? el)
//        {
//            this.el = el;
//        }

//        public Iterator<T> Next()
//        {
//            //if (el == null || el.Prev == null) throw new IndexOutOfRangeException();
//            return new ListReverseIterator<T>(el.Prev);
//        }

//        public T Val
//        {
//            get
//            {
//                if (el == null) throw new NullReferenceException();
//                return el.Value;
//            }
//        }

//        public bool IsNotNull()
//        {
//            return !(el == null);
//        }
//    }
//    internal class MyList<T> : Collection<T>
//    {
//        public Node<T>? Head { get; set; }
//        public Node<T>? Tail { get; set; }

//        public void Add(T val)
//        {
//            Node<T> el = new Node<T>(val, Tail, null);

//            if (Head == null || Tail == null)
//            {
//                Head = el;
//                Tail = el;
//            }
//            else
//            {
//                Tail.Next = el;
//                Tail = el;
//            }
//        }

//        public void RemoveLast()
//        {
//            if (Tail != null)
//                Tail = Tail.Prev;
//        }

//        //public override Iterator GetForwardIterator()
//        public Iterator<T> GetForwardIterator()
//        {
//            return new ListForwardIterator<T>(Head);
//        }

//        //public override Iterator GetReverseIterator()
//        public Iterator<T> GetReverseIterator()
//        {
//            return new ListReverseIterator<T>(Tail);
//        }
//    }
//}

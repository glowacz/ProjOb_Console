using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proj1
{
    interface Element<T>
    {
        Element<T> Left { get; set; }
        Element<T> Right { get; set; }
        Element<T> Parent { get; set; }
        T Value { get; set; }
    }
    interface Iterator<T>
    {
        Iterator<T> Next();
        bool IsNotNull();
        T Val { get; }
        Element<T> p { get; }
    }

    interface Collection<T>
    {
        Iterator<T> GetForwardIterator();
        Iterator<T> GetReverseIterator();

        void Add(T item);
        void Remove(Iterator<T> it);
    }

    static class Algorithms
    {
        public static T FindIf<T>(Collection<T> c, Func<T, bool> pred, bool searchDir)
        {
            Iterator<T> it = searchDir ? c.GetForwardIterator() : c.GetReverseIterator();

            while (it.IsNotNull() && !pred(it.Val)) it = it.Next();

            return it.Val;
        }

        public static void PrintIf<T>(Collection<T> c, Func<T, bool> pred, bool searchDir)
        {
            //Iterator<T> it = searchDir ? c.GetForwardIterator() : c.GetReverseIterator();

            //for (it = it; it.IsNotNull(); it = it.Next())
            for (Iterator<T> it = searchDir ? c.GetForwardIterator() : c.GetReverseIterator(); it.IsNotNull(); it = it.Next())
            {
                if (pred(it.Val))
                    Console.WriteLine(it.Val);
            }
        }

        //public static T Find<T>(Iterator<T> it, Func<T, bool> pred)
        public static Element<T> Find<T>(Iterator<T> it, Func<T, bool> pred)
        {
            while (it.IsNotNull() && !pred(it.Val)) it = it.Next();

            //if (!it.IsNotNull()) return default(T);
            if (!it.IsNotNull()) return new TreeNode<T>(default(T), null, null, null);

            return it.p;
        }

        public static void ForEach<T>(Iterator<T> it, Action<T> fun)
        {
            while (it.IsNotNull())
            {
                fun(it.Val);

                it = it.Next();
            }
        }

        public static int CountIf<T>(Iterator<T> it, Func<T, bool> pred)
        {
            int count = 0;
            while (it.IsNotNull() && !pred(it.Val))
            {
                if (pred(it.Val)) count++;
                it = it.Next();
            }
            return count;
        }
    }


}
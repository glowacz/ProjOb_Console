using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proj1
{
    interface Iterator<T>
    {
        Iterator<T> Next();
        //Iterator<T> Prev();
        bool IsNotNull();
        T Val { get; }
    }

    interface Collection<T>
    {
        Iterator<T> GetForwardIterator();
        Iterator<T> GetReverseIterator();
    }

    static class Algorithms
    {
        public static T FindIf<T>(Collection<T> c, Func<T, bool> pred, bool searchDir)
        {
            Iterator<T> it = searchDir ? c.GetForwardIterator() : c.GetReverseIterator();

            while(it.IsNotNull() && !pred(it.Val)) it = it.Next();
            
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
    }

    
}

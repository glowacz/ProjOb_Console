//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Proj1
//{
//    //internal class VectorIterator<T> : Iterator<T>
//    //{
//    //    MyVector<T> vec;
//    //    int i;

//    //    public VectorIterator(MyVector<T> vec, int i)
//    //    {
//    //        this.vec = vec;
//    //        this.i = i;
//    //    }

//    //    public Iterator<T> Next()
//    //    {
//    //        if (i + 1 >= vec.Count) throw new IndexOutOfRangeException();

//    //        return new VectorIterator<T>(vec, i + 1);
//    //    }

//    //    public Iterator<T> Prev()
//    //    {
//    //        if (i - 1 < 0) throw new IndexOutOfRangeException();

//    //        return new VectorIterator<T>(vec, i - 1);
//    //    }

//    //    public T Val
//    //    {
//    //        get
//    //        {
//    //            return vec[i];
//    //        }
//    //    }
//    //}

//    internal class VectorForwardIterator<T> : Iterator<T>
//    {
//        MyVector<T> vec;
//        int i;

//        public VectorForwardIterator(MyVector<T> vec, int i)
//        {
//            this.vec = vec;
//            this.i = i;
//        }

//        public Iterator<T> Next()
//        {
//            //if (i + 1 >= vec.Count) throw new IndexOutOfRangeException();

//            return new VectorForwardIterator<T>(vec, i + 1);
//        }

//        public T Val
//        {
//            get
//            {
//                return vec[i];
//            }
//        }

//        public bool IsNotNull()
//        {
//            return 0 <= i && i < vec.Count;
//        }
//    }

//    internal class VectorReverseIterator<T> : Iterator<T>
//    {
//        MyVector<T> vec;
//        int i;

//        public VectorReverseIterator(MyVector<T> vec, int i)
//        {
//            this.vec = vec;
//            this.i = i;
//        }

//        public Iterator<T> Next()
//        {
//            //if (i - 1 < 0) throw new IndexOutOfRangeException();

//            return new VectorReverseIterator<T>(vec, i - 1);
//        }

//        public T Val
//        {
//            get
//            {
//                return vec[i];
//            }
//        }

//        public bool IsNotNull()
//        {
//            return 0 <= i && i < vec.Count;
//        }
//    }


//    internal class MyVector<T> : Collection<T>
//    {
//        public System.Collections.Generic.List<T> arr;

//        public MyVector()
//        {
//            arr = new System.Collections.Generic.List<T>();
//        }

//        public MyVector(System.Collections.Generic.List<T> arr)
//        {
//            this.arr = arr;
//        }

//        public void Add(T val)
//        {
//            arr.Add(val);
//        }

//        public void RemoveLast()
//        {
//            arr.RemoveAt(arr.Count - 1);
//        }

//        public T this[int i]
//        {
//            get
//            {
//                if (i < 0 || i >= arr.Count)
//                    throw (new IndexOutOfRangeException());
//                return arr[i];
//            }
//            //set { }
//        }

//        public int Count
//        {
//            get
//            {
//                return arr.Count;
//            }
//        }

//        public Iterator<T> GetForwardIterator()
//        {
//            return new VectorForwardIterator<T>(this, 0);
//        }

//        public Iterator<T> GetReverseIterator()
//        {
//            return new VectorReverseIterator<T>(this, Count - 1);
//        }
//    }
//}

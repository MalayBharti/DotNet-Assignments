using System;
using System.Collections;

namespace CustomCollection
{
    public class TestCollection : ICollection
    {
        private int[] Array = { 1, 5, 9 };
        private int Counter;
        public TestCollection()
        {
            Counter = 3;
        }
        public int Count => Counter;

        public object SyncRoot => this;

        public bool IsSynchronized => false;

        public void CopyTo(Array array, int index)
        {
            foreach (int i in Array)
            {
                Array.SetValue(i, index);
                index = index + 1;
            }
        }

        public IEnumerator GetEnumerator()
        {
            return new Enumerator(Array);
        }
    }
}

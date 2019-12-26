using System;
using System.Collections;

namespace CustomCollection
{
    public class Enumerator : IEnumerator
    {
        public Enumerator(int[] array)
        {
            this.Array = array;
            Cursor = -1;

        }
        private int[] Array;
        private int Cursor;

        public object Current
        {
            get
            {
                if ((Cursor < 0) || (Cursor == Array.Length))
                    throw new InvalidOperationException();
                return Array[Cursor];
            }
        }
        public bool MoveNext()
        {
            if (Cursor < Array.Length)
                Cursor++;

            return (!(Cursor == Array.Length));
        }

        public void Reset() => Cursor = -1;

    }
}

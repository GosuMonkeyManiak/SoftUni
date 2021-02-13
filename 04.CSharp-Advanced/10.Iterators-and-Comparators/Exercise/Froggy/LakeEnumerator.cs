using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Froggy
{
    class LakeEnumerator : IEnumerator<int>
    {
        private List<int> rocks;
        private int index;

        private bool IsEven = true;

        public LakeEnumerator(IEnumerable<int> arr)
        {
            Reset();
            rocks = new List<int>(arr);
        }

        public int Current => rocks[index];

        object IEnumerator.Current => Current;

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            if ((rocks.Count - 1) % 2 == 0)
            {
                if (IsEven) //position
                {
                    index += 2;
                    bool IsOutSide = index > rocks.Count - 1;

                    if (IsOutSide)
                    {
                        index = rocks.Count - 2;
                        IsEven = false;
                    }
                }
                else //odd possition
                {
                    index -= 2;
                }
            }
            else //odd elements
            {
                if (IsEven) //position
                {
                    index += 2;
                    bool IsOusSide = index > rocks.Count - 1;

                    if (IsOusSide)
                    {
                        IsEven = false;
                        index = rocks.Count - 1;
                    }
                }
                else //position
                {
                    index -= 2;
                }
            }

            return index >= 0 && index <rocks.Count;
        }

        public void Reset()
        {
            index = -2;
        }
    }
}

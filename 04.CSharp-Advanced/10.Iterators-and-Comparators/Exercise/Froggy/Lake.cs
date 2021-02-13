using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Froggy
{
    public class Lake : IEnumerable<int>
    {
        private List<int> rocks;
        private bool IsEven = true;

        public Lake(params int[] arr)
        {
            rocks = new List<int>(arr);
        }

        public IEnumerator<int> GetEnumerator()
        {
            return new LakeEnumerator(rocks);
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}

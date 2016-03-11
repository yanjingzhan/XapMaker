namespace PhoneDirect3DXamlAppInterop
{
    using System;
    using System.Runtime.CompilerServices;

    public static class Extensions
    {
        public static T[] Slice<T>(this T[] source, int start, int end)
        {
            if (end < 0)
            {
                end = source.Length + end;
            }
            int num = end - start;
            T[] localArray = new T[num];
            for (int i = 0; i < num; i++)
            {
                localArray[i] = source[i + start];
            }
            return localArray;
        }
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algsstructures.arrays
{
    internal class sort
    {
        // Реализация пузырьковой сортировки
        public static void BubbleSort<T>(T[] a) where T : IComparable<T>
        {
            for (int i = 0; i < a.Length; i++)
            {
                for (int j = 0; j < a.Length - i - 1; j++)
                {
                    if (a[j].CompareTo(a[j + 1]) > 0)
                    {
                        Swap(j, j + 1, a);
                    }
                }
            }
        }

        // Реализация сортировки вставками
        public static void InsertionSort<T>(T[] a) where T : IComparable<T>
        {
            for (int outIndex = 1; outIndex < a.Length; outIndex++)
            {
                T temp = a[outIndex];
                int inIndex = outIndex;
                while (inIndex > 0 && a[inIndex - 1].CompareTo(temp) >= 0)
                {
                    a[inIndex] = a[inIndex - 1];
                    inIndex--;
                }
                a[inIndex] = temp;
            }
        }

        // Рекурсивная реализация сортировки слиянием
        public static void RecMergeSort<T>(T[] theArray, T[] workSpace, int lowerBound, int upperBound) where T : IComparable<T>
        {
            if (lowerBound == upperBound)
                return;

            int mid = (lowerBound + upperBound) / 2;
            RecMergeSort(theArray, workSpace, lowerBound, mid);
            RecMergeSort(theArray, workSpace, mid + 1, upperBound);
            Merge(theArray, workSpace, lowerBound, mid + 1, upperBound);
        }

        public static void Merge<T>(T[] theArray, T[] workSpace, int lowPtr, int highPtr, int upperBound) where T : IComparable<T>
        {
            int j = 0;
            int lowerBound = lowPtr;
            int mid = highPtr - 1;
            int n = upperBound - lowerBound + 1;

            while (lowPtr <= mid && highPtr <= upperBound)
            {
                if (theArray[lowPtr].CompareTo(theArray[highPtr]) < 0)
                    workSpace[j++] = theArray[lowPtr++];
                else
                    workSpace[j++] = theArray[highPtr++];
            }

            while (lowPtr <= mid)
                workSpace[j++] = theArray[lowPtr++];

            while (highPtr <= upperBound)
                workSpace[j++] = theArray[highPtr++];

            for (j = 0; j < n; j++)
                theArray[lowerBound + j] = workSpace[j];
        }

        // Сортировка слиянием двух массивов
        public static void MergeArrays<T>(T[] arrayA, int sizeA, T[] arrayB, int sizeB, T[] arrayC) where T : IComparable<T>
        {
            int aDex = 0, bDex = 0, cDex = 0;
            while (aDex < sizeA && bDex < sizeB)
            {
                if (arrayA[aDex].CompareTo(arrayB[bDex]) < 0)
                    arrayC[cDex++] = arrayA[aDex++];
                else
                    arrayC[cDex++] = arrayB[bDex++];
            }

            while (aDex < sizeA)
                arrayC[cDex++] = arrayA[aDex++];

            while (bDex < sizeB)
                arrayC[cDex++] = arrayB[bDex++];
        }

        // Вывод содержимого массива
        public static void Display<T>(T[] theArray)
        {
            foreach (var item in theArray)
                Console.Write(item + " ");
            Console.WriteLine();
        }

        // Реализация сортировки выбором
        public static void SelectionSort<T>(T[] a) where T : IComparable<T>
        {
            for (int outIndex = 0; outIndex < a.Length - 1; outIndex++)
            {
                int min = outIndex;
                for (int inIndex = outIndex + 1; inIndex < a.Length; inIndex++)
                {
                    if (a[inIndex].CompareTo(a[min]) < 0)
                        min = inIndex;
                }
                Swap(outIndex, min, a);
            }
        }

        public static void Swap<T>(int one, int two, T[] a)
        {
            T temp = a[one];
            a[one] = a[two];
            a[two] = temp;
        }
        // Реализация сортировки Шелла
        public static void ShellSort<T>(T[] theArray, int nElems) where T : IComparable<T>
        {
            int inner, outer;
            T temp;
            int h = 1;

            while (h <= nElems / 3)
                h = h * 3 + 1;

            while (h > 0)
            {
                for (outer = h; outer < nElems; outer++)
                {
                    temp = theArray[outer];
                    inner = outer;

                    while (inner > h - 1 && theArray[inner - h].CompareTo(temp) >= 0)
                    {
                        theArray[inner] = theArray[inner - h];
                        inner -= h;
                    }
                    theArray[inner] = temp;
                }
                h = (h - 1) / 3;
            }
        }

        // Рекурсивная реализация быстрой сортировки
        public static void RecQuickSort<T>(T[] theArray, int left, int right) where T : IComparable<T>
        {
            if (right - left <= 0)
                return;

            T pivot = theArray[right];
            int partition = PartitionIt(theArray, left, right, pivot);
            RecQuickSort(theArray, left, partition - 1);
            RecQuickSort(theArray, partition + 1, right);
        }

        public static int PartitionIt<T>(T[] theArray, int left, int right, T pivot) where T : IComparable<T>
        {
            int leftPtr = left - 1;
            int rightPtr = right;

            while (true)
            {
                while (leftPtr < right && theArray[++leftPtr].CompareTo(pivot) < 0) { }

                while (rightPtr > left && theArray[--rightPtr].CompareTo(pivot) > 0) { }

                if (leftPtr >= rightPtr)
                    break;
                else
                    Swap(leftPtr, rightPtr, theArray);
            }
            Swap(leftPtr, right, theArray);
            return leftPtr;
        }
    }
}

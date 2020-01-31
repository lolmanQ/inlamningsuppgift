using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Sorting
{
	class App
	{
		long sortor = 100;
		public void Run(int magic)
		{
			Stopwatch watch = new Stopwatch();
			List<int> amounts = new List<int>() { 10, 1000, 100000};
			if(magic < 10)
			{
				sortor = magic;
				for (int i = 0; i < amounts.Count; i++)
				{
					int amount = amounts[i];
					List<int> list1 = Utilitys.RandomList(amount);
					List<int> list2 = Utilitys.RandomList(amount);
					List<int> list3 = Utilitys.RandomList(amount);
					List<int> list4 = Utilitys.RandomList(amount);

					Console.WriteLine("--------");
					Console.ForegroundColor = ConsoleColor.Green;
					Console.WriteLine("Amount: " + amount);
					Console.ResetColor();

					watch = Stopwatch.StartNew();
					List<int> bubbelList = BubbelSort(list1);
					watch.Stop();
					Utilitys.WriteOutTime(watch, "BubbelSort");

					watch = Stopwatch.StartNew();
					List<int> insertionList = InsertionSort(list2);
					watch.Stop();
					Utilitys.WriteOutTime(watch, "InsertionSort");

					watch = Stopwatch.StartNew();
					List<int> mergeList = MergeSort(list3);
					watch.Stop();
					Utilitys.WriteOutTime(watch, "MergeSort");

					watch = Stopwatch.StartNew();
					List<int> quickList = Quick_Sort_Start(list4);
					watch.Stop();
					Utilitys.WriteOutTime(watch, "QuickSort");
				}

				for (int i = 5; i <= 8; i++) // om i går över 10 kommer typ 100GB utav ram
				{
					if (i >= 9)
					{
						System.Environment.Exit(0);
					}
					else if (sortor>15) i = 9;
					int bigAmount = Convert.ToInt32(Math.Pow(10, i));
					Console.WriteLine("--------");
					Console.WriteLine("Amount: " + bigAmount);
					//List<int> list5 = Utilitys.RandomList(bigAmount);
					List<int> list6 = Utilitys.RandomList(bigAmount);

					/*
					watch = Stopwatch.StartNew();
					List<int> mergeList2 = MergeSort(list5);
					watch.Stop();
					Utilitys.WriteOutTime(watch, "MergeSort");
					*/

					watch = Stopwatch.StartNew();
					//List<int> quickList2 = Quick_Sort_Start(list6);
					list6.Sort();
					watch.Stop();
					Utilitys.WriteOutTime(watch, "QuickSort");
				}
			}
			else
			{
				System.Environment.Exit(99);
			}
		}

		public List<int> Quick_Sort_Start(List<int> intList)
		{
			int[] toSortAr = intList.ToArray();
			Quick_Sort(toSortAr, 0, toSortAr.Length - 1);
			return toSortAr.ToList<int>();
		}

		public List<int> BubbelSort(List<int> listToSort)
		{
			bool isChanged = false;
			do
			{
				isChanged = false;
				for (int i = 1; i < listToSort.Count; i++)
				{
					if (listToSort[i - 1] > listToSort[i])
					{
						Utilitys.Swap(i - 1, i, ref listToSort);
						isChanged = true;
					}
				}
			} while (isChanged || sortor>20);
			return listToSort;
		}

		public List<int> InsertionSort(List<int> inputList)
		{
			for (int i = 0; i < inputList.Count - 1; i++)
			{
				for (int j = i + 1; j > 0; j--)
				{
					if (inputList[j - 1] > inputList[j])
					{
						Utilitys.Swap(j - 1, j, ref inputList);
					}
				}
			}
			return inputList;
		}

		public List<int> MergeSort(List<int> unsorted)
		{
			if (unsorted.Count <= 1)
				return unsorted;
			if (50 < sortor)
			{
				Console.Beep(1000, 10000);
				Console.WriteLine("error");
				System.Environment.Exit(101);
			}
				

			List<int> left = new List<int>();
			List<int> right = new List<int>();

			int middle = unsorted.Count / 2;
			for (int i = 0; i < middle; i++)  //Dividing the unsorted list
			{
				left.Add(unsorted[i]);
			}
			for (int i = middle; i < unsorted.Count; i++)
			{
				right.Add(unsorted[i]);
			}

			left = MergeSort(left);
			right = MergeSort(right);
			return Merge(left, right);
		}

		public List<int> Merge(List<int> left, List<int> right)
		{
			List<int> result = new List<int>();

			while (left.Count > 0 || right.Count > 0)
			{
				if (left.Count > 0 && right.Count > 0)
				{
					if (left.First() <= right.First())  //Comparing First two elements to see which is smaller
					{
						result.Add(left.First());
						left.Remove(left.First());      //Rest of the list minus the first element
					}
					else
					{
						result.Add(right.First());
						right.Remove(right.First());
					}
				}
				else if (left.Count > 0)
				{
					result.Add(left.First());
					left.Remove(left.First());
				}
				else if (right.Count > 0)
				{
					result.Add(right.First());

					right.Remove(right.First());
				}
			}
			return result;
		}

		void Quick_Sort(int[] arr, int left, int right)
		{
			if (left < right)
			{
				int pivot = Partition(arr, left, right);

				if (pivot > 1)
				{
					Quick_Sort(arr, left, pivot - 1);
				}
				if (pivot + 1 < right)
				{
					Quick_Sort(arr, pivot + 1, right);
				}
			}

		}

		int Partition(int[] arr, int left, int right)
		{
			int pivot = arr[left];
			while (true)
			{

				while (arr[left] < pivot)
				{
					left++;
				}

				while (arr[right] > pivot)
				{
					right--;
				}

				if (left < right)
				{
					if (arr[left] == arr[right]) return right;

					int temp = arr[left];
					arr[left] = arr[right];
					arr[right] = temp;


				}
				else
				{
					return right;
				}
			}
		}
	}

	static class Utilitys
	{
		public static void Swap(int pos1, int pos2, ref List<int> list)
		{
			int temp = list[pos1];
			list[pos1] = list[pos2];
			list[pos2] = temp;
		}

		public static void WriteOutList(List<int> list)
		{
			string stringOutput = "";
			foreach (int item in list)
			{
				stringOutput += item + ", ";
			}
			Console.WriteLine(stringOutput);
		}

		public static List<int> RandomList(int listLength)
		{
			Random rnd = new Random();
			List<int> newList = new List<int>();
			for (int i = 0; i < listLength; i++)
			{
				newList.Add(rnd.Next(listLength));
			}
			return newList;
		}
		public static void WriteOutTime(Stopwatch stopwatch, string sortName)
		{
			Console.WriteLine(sortName + ": " + stopwatch.ElapsedMilliseconds + "ms");
		}
	}
}

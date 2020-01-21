using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sorting
{
	class App
	{
		public void Run()
		{
			int amount = 1000;
			List<int> list1 = Utilitys.RandomList(amount);
			List<int> list2 = Utilitys.RandomList(amount);
			List<int> list3 = Utilitys.RandomList(amount);

			List<int> bubbelList = BubbelSort(list1);
			List<int> insertionList = InsertionSort(list2);
			List<int> mergeList = MergeSort(list3);

			Utilitys.WriteOutList(bubbelList);
			Utilitys.WriteOutList(insertionList);
			Utilitys.WriteOutList(mergeList); //need to remake
			
		}

		public List<int> BubbelSort(List<int> listToSort)
		{
			bool isChanged = false;
			do
			{
				isChanged = false;
				for (int i = 1; i < listToSort.Count; i++)
				{
					if(listToSort[i-1] > listToSort[i])
					{
						Utilitys.Swap(i - 1, i ,ref listToSort);
						isChanged = true;
					}
				}
			} while (isChanged);
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
				newList.Add(rnd.Next(1000));
			}
			return newList;
		}
	}
}

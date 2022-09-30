using UnityEngine;

namespace TeasingGame.Extension
{
    public static class Extensions
    {
		/// <summary>
		/// Method called to shuffle an int array
		/// </summary>
		/// <param name="arrayToShuffle">Array to shuffle</param>
		public static void ShuffleArray(int[] arrayToShuffle)
		{
			int tempInt;

			for (int i = 0; i < arrayToShuffle.Length; i++)
			{
				int rnd = Random.Range(0, arrayToShuffle.Length);
				tempInt = arrayToShuffle[rnd];
				arrayToShuffle[rnd] = arrayToShuffle[i];
				arrayToShuffle[i] = tempInt;
			}
		}
	}
}

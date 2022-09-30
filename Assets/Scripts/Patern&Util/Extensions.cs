using UnityEngine;

namespace TeasingGame.Extension
{
    internal static class Extensions
    {
		/// <summary>
		/// Method called to shuffle an int array
		/// </summary>
		/// <param name="arrayToShuffle">Array to shuffle</param>
		internal static void ShuffleArray(int[] arrayToShuffle)
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

		/// <summary>
		/// Transforms a point from screen space into world space, where world space 
		/// is defined as the coordinate system at the very top of your game's hierarchy.
		/// </summary>
		internal static Vector3 ScreenToWorld(Camera camera, Vector3 position)
		{
			position.z = camera.nearClipPlane;
			return camera.ScreenToWorldPoint(position);
		}

		/// <summary>
		/// Returns a ray going from camera through a screen point
		/// </summary>
		internal static Ray ScreenToRay(Camera camera, Vector3 position)
		{
			position.z = camera.nearClipPlane;
			return camera.ScreenPointToRay(position);
		}
	}
}

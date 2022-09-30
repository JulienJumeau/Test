using UnityEngine;

namespace TeasingGame
{
	internal abstract class GenericSingleton<T> : MonoBehaviour where T : Component
	{
		#region Fields & Properties

		internal static T Instance { get; private set; } = null;

		#endregion

		#region Unity Methods + Event Sub

		protected virtual void Awake()
		{
			if (Instance == null)
			{
				Instance = this as T;
			}

			else
			{
				Destroy(gameObject);
			}
		}

		#endregion
	}
}
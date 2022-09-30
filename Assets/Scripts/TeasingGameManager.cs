using UnityEngine;
using TeasingGame.Extension;

namespace TeasingGame
{
	internal sealed class TeasingGameManager : GenericSingleton<TeasingGameManager>
	{
		#region Fields & Properties

		private GameManager _gameManagerInstance;
		[SerializeField] private GameObject[] _cellsArray;
		[SerializeField] private Cells[] _cellsImageArray;

		#endregion

		#region Unity Methods + Event Sub

		// This function is called when the object becomes enabled and active.
		private void OnEnable()
		{
			EventSubscription(true);
		}

		// Start is called before the first frame update
		private void Start()
		{
			_gameManagerInstance = GameManager.Instance;
			EventSubscription(true);
		}

		// This function is called when the behaviour becomes disabled and when the object is destroyed
		private void OnDisable()
		{
			EventSubscription(false);
		}

		/// <summary>
		/// Method called to (un)subcribe to events
		/// </summary>
		/// <param name="mustSubscribe">If true subscribe, false to unsubcribe</param>
		private void EventSubscription(bool mustSubscribe)
		{
			if (_gameManagerInstance != null)
			{
				if (mustSubscribe)
				{
					_gameManagerInstance.OnStartButtonPressed += GameManagerInstance_OnStartButtonPressed;
				}

				else
				{
					_gameManagerInstance.OnStartButtonPressed -= GameManagerInstance_OnStartButtonPressed;
				}
			}
		}

		#endregion

		#region Custom Methods

		/// <summary>
		/// Method called when the player press the start button (Event from GameManager)
		/// </summary>
		/// <param name="sender">Object who sended the event</param>
		/// <param name="e">Event args (Empty)</param>
		private void GameManagerInstance_OnStartButtonPressed(object sender, System.EventArgs e)
		{
			int[] array = GetSolvableArray();

			for (int i = 0; i < array.Length; i++)
			{
				_cellsImageArray[array[i]].transform.position = _cellsArray[i].transform.position;
				_cellsImageArray[array[i]].transform.SetParent(_cellsArray[i].transform);
			}
		}

		/// <summary>
		/// Method called to have a solvable shuffled int array 
		/// </summary>
		/// <returns></returns>
		private int[] GetSolvableArray()
		{
			int[] array = new int[9] { 0, 1, 2, 3, 4, 5, 6, 7, 8 };

			do
			{
				Extensions.ShuffleArray(array);
			}
			while (!IsSolvableCheck(array));

			return array;
		}

		/// <summary>
		/// Method called to check if the shuffled int array is solvable into the teasing game.
		/// If a number is greater than a number that follows it in the array, it is call an inversion.
		/// It is not possible to solve an instance of 8 puzzle if number of inversions is odd in the input state
		/// Source : https://www.geeksforgeeks.org/check-instance-8-puzzle-solvable/?ref=gcse
		/// </summary>
		/// <param name="arr"></param>
		/// <returns></returns>
		private bool IsSolvableCheck(int[] arr)
		{
			int inv_count = 0;
			for (int i = 0; i < 9; i++)
				for (int j = i + 1; j < 9; j++)

					// Value 0 is used for empty space
					if (arr[i] > 0 && arr[j] > 0 && arr[i] > arr[j])
						inv_count++;
			return (inv_count % 2 == 0);
		}

		#endregion

		#region Events

		#endregion
	}
}
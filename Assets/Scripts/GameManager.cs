using System;
using UnityEngine;

namespace TeasingGame
{
	internal sealed class GameManager : GenericSingleton<GameManager>
	{
		#region Fields & Properties

		private TeasingGameManager _teasingGameManager;

		#endregion

		#region Unity Methods + Event Sub

		// Start is called before the first frame update
		private void Start()
		{
			_teasingGameManager = TeasingGameManager.Instance;
		}

		#endregion

		#region Custom Methods

		/// <summary>
		/// Method called when the game start buton si pressed
		/// </summary>
		public void StartTeasingGame()
		{
			StartButtonPressed();
		}

		public void Win()
		{
			Debug.Log("Win");
		}

		#endregion

		#region Events

		// Event to trigger when the game start buton si pressed ( Args : empty )

		internal event EventHandler OnStartButtonPressed;

		private void StartButtonPressed() => OnStartButtonPressed?.Invoke(this, EventArgs.Empty);

		#endregion
	}
}

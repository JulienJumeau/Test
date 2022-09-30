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

		// Update is called once per frame
		private void Update()
		{

		}

		#endregion

		#region Custom Methods

		public void StartTeasingGame()
		{
			StartButtonPressed();
		}

		#endregion

		#region Events

		// Event to trigger when the shoot button state change ( Args : empty )

		public event EventHandler OnStartButtonPressed;

		private void StartButtonPressed() => OnStartButtonPressed?.Invoke(this, EventArgs.Empty);

		#endregion
	}
}

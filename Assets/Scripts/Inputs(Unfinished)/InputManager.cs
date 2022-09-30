using UnityEngine;
using UnityEngine.InputSystem;
using TeasingGame.Extension;

namespace TeasingGame
{
	[DefaultExecutionOrder(-1)]
	internal sealed class InputManager : GenericSingleton<InputManager>
	{
		#region Fields & Properties

		private SwipeInputAction _swipeInputActions;
		private Camera _mainCamera;

		#endregion

		#region Unity Methods + Event Sub

		protected override void Awake()
		{
			base.Awake();
			_swipeInputActions = new SwipeInputAction();
			_mainCamera = Camera.main;
		}

		private void OnEnable()
		{
			_swipeInputActions.Enable();
		}

		private void OnDisable()
		{
			_swipeInputActions.Disable();
		}

		// Start is called before the first frame update
		private void Start()
		{
			_swipeInputActions.Touch.PrimaryContact.started += ctx => StartTouchPrimary(ctx);
			_swipeInputActions.Touch.PrimaryContact.canceled += ctx => EndTouchPrimary(ctx);
		}

		#endregion

		#region Custom Methods

		private void StartTouchPrimary(InputAction.CallbackContext ctx)
		{
			OnStartTouch?.Invoke(
				Extensions.ScreenToWorld(_mainCamera, _swipeInputActions.Touch.PrimaryPosition.ReadValue<Vector2>()),
				(float)ctx.startTime);
		}

		private void EndTouchPrimary(InputAction.CallbackContext ctx)
		{
			OnEndTouch?.Invoke(
				Extensions.ScreenToWorld(_mainCamera, _swipeInputActions.Touch.PrimaryPosition.ReadValue<Vector2>()),
				(float)ctx.startTime);
		}

		#endregion

		#region Events

		public delegate void StartTouch(Vector2 position, float time);
		public event StartTouch OnStartTouch;

		public delegate void EndTouch(Vector2 position, float time);
		public event EndTouch OnEndTouch;

		#endregion
	}
}

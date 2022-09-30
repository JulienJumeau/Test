using UnityEngine;

namespace TeasingGame
{
    internal sealed class SwipeDetection : GenericSingleton<SwipeDetection>
    {

		#region Fields & Properties

		private InputManager _inputManager;
		private Vector2 _startPosition;
		private float _startTime;
		private Vector2 _endPosition;
		private float _endTime;

		[SerializeField] private float _minimumDistance = 0.2f;
		[SerializeField] private float maximumTime = 1f;

		[SerializeField][Range(0,1)] private float _directionThreshold = 0.9f;

		#endregion

		#region Unity Methods + Event Sub

		protected override void Awake()
		{
			base.Awake();
			_inputManager = InputManager.Instance;
		}

		private void OnEnable()
		{
			EventSubscription(true);
		}

		private void OnDisable()
		{
			EventSubscription(false);
		}

		// Start is called before the first frame update
		private void Start()
		{

		}

		// Update is called once per frame
		private void Update()
		{

		}

		private void EventSubscription(bool mustSubscribe)
		{
			if (_inputManager != null)
			{
				if (mustSubscribe)
				{
					_inputManager.OnStartTouch += SwipeStart;
					_inputManager.OnEndTouch += SwipeEnd;
				}

				else
				{
					_inputManager.OnStartTouch -= SwipeStart;
					_inputManager.OnEndTouch -= SwipeEnd;
				}
			}
		}

		#endregion

		#region Custom Methods

		private void SwipeStart(Vector2 position, float time)
		{
			_startPosition = position;
			_startTime = time;
		}

		private void SwipeEnd(Vector2 position, float time)
		{
			_endPosition = position;
			_endTime = time;
			DetectSwipe();
		}

		private void DetectSwipe()
		{
			//Debug.Log(_startPosition);
			//Debug.Log(_startTime + " - " + _endTime);
			if (Vector3.Distance(_startPosition, _endPosition) >= _minimumDistance && (_endTime - _startTime) <= maximumTime)
			{
				Debug.DrawLine(_startPosition, _endPosition, Color.red, 5f);
				Vector3 direction = _endPosition - _startPosition;
				Vector3 direction2D = new Vector2(direction.x, direction.y).normalized;
				SwipeDirection(direction2D);
			}
		}

		private void SwipeDirection(Vector2 direction)
		{
			if (Vector2.Dot(Vector2.up, direction) > _directionThreshold)
			{
				//Debug.Log("Swipe Up");
			}

			else if (Vector2.Dot(Vector2.down, direction) > _directionThreshold)
			{
				//Debug.Log("Swipe down");
			}

			else if (Vector2.Dot(Vector2.left, direction) > _directionThreshold)
			{
				//Debug.Log("Swipe Left");
			}

			else if (Vector2.Dot(Vector2.right, direction) > _directionThreshold)
			{
				//Debug.Log("Swipe right");
			}
		}

		#endregion

		#region Events

		#endregion
	}
}

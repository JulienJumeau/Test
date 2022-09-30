using UnityEngine;
using UnityEngine.EventSystems;

namespace TeasingGame
{
	internal sealed class CellsTile : MonoBehaviour, IDragHandler, IBeginDragHandler, IDropHandler
	{
		#region Fields & Properties

		[SerializeField] private int _tileId = 0;
		private TeasingGameManager _teasingGameManager;

		public int TileId => _tileId;

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
		/// Not used but IDragHandler is mandatory for the Drag&Drop system work
		/// </summary>
		public void OnDrag(PointerEventData eventData)
		{
			//Debug.Log("IsDragging " + TileId);
		}

		/// <summary>
		/// Called when Pointer Event Begin drag is triggered ( IBeginDragHandler Interface )
		/// Used to detected the first clicked/taped tile and if it's dragged
		/// </summary>
		public void OnBeginDrag(PointerEventData eventData)
		{
			_teasingGameManager.TileDragAndDroppedOn(true, this);
		}

		/// <summary>
		/// Called when Pointer Event Begin drop is triggered ( IDropHandler Interface )
		/// Used to detected the current tile where the drag is over (On dropped) 
		/// </summary>
		public void OnDrop(PointerEventData eventData)
		{
			_teasingGameManager.TileDragAndDroppedOn(false, this);
		}

		#endregion
	}
}

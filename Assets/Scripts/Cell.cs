using UnityEngine;

namespace TeasingGame
{
    internal sealed class Cell : MonoBehaviour
    {
		#region Fields & Properties

		[SerializeField] private int _cellId = 0;

        public int CellId => _cellId;

		#endregion
    }
}

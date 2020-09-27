using System;
using System.Collections.ObjectModel;

namespace ImpedanceApp
{
	/// <summary>
	/// Collection for add method in <see cref="ValueChanged"/> event
	/// </summary>
	/// <typeparam name="T"> is <see cref="ISegment"/></typeparam>
	public sealed class SegmentObservableCollection : ObservableCollection<ISegment>
	{
		/// <summary>
		/// Collection event
		/// </summary>
		public event EventHandler SegmentObservableCollectionChanged;

		/// <summary>
		/// Event for collection
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnSegmentChanged(object sender, EventArgs e)
		{
			SegmentObservableCollectionChanged?.Invoke(sender, e);
		}

		/// <summary>
		/// Override method by <see cref="ObservableCollection{T}"/>
		/// Taken base method and added event subscription
		/// </summary>
		/// <param name="index"> the index where the element 
		/// will be inserted</param>
		/// <param name="item">element to insert</param>
		protected override void InsertItem(int index, ISegment item)
		{
			base.InsertItem(index, item);
			item.SegmentChanged += OnSegmentChanged;
		}

		/// <summary>
		/// Override method by <see cref="ObservableCollection{T}"/>
		/// Taken base method and added event unsubscribe
		/// </summary>
		/// <param name="index">the index where the element 
		/// will be deleted</param>
		protected override void RemoveItem(int index)
		{
			var item = this[index];
			base.RemoveItem(index);
			item.SegmentChanged -= OnSegmentChanged;
		}

		/// <summary>
		/// Override method by <see cref="ObservableCollection{T}"/>
		/// Taken base method and added event over-subscription
		/// </summary>
		/// <param name="index">the index where the element 
		/// will be set</param>
		/// <param name="item">element to set</param>
		protected override void SetItem(int index, ISegment item)
		{
			var oldItem = this[index];
			base.SetItem(index, item);
			oldItem.SegmentChanged -= OnSegmentChanged;
			item.SegmentChanged += OnSegmentChanged;
		}

		/// <summary>
		/// Override method by <see cref="ObservableCollection{T}"/>
		/// Taken base method and added event unsubscribe for all elements
		/// </summary>
		protected override void ClearItems()
		{
			foreach (var item in Items)
			{
				item.SegmentChanged -= OnSegmentChanged;
			}

			base.ClearItems();
		}
	}
}

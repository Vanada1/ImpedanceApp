using System;
using System.Collections.ObjectModel;

namespace ImpedanceApp
{
	/// <summary>
	/// Collection for add metod in <see cref="ValueChanged"/> event
	/// </summary>
	/// <typeparam name="T"> is <see cref="ISegment"/></typeparam>
	public sealed class SegmentObservableCollection<T> : Collection<T>
	where T : ISegment
	{
		/// <summary>
		/// Collection event
		/// </summary>
		public event EventHandler ElementObservableCollectionChanged;

		/// <summary>
		/// Override metod
		/// </summary>
		/// <param name="index"> the index where the element 
		/// will be inserted</param>
		/// <param name="item">element to insert</param>
		protected override void InsertItem(int index, T item)
		{
            base.InsertItem(index, item);
            if (item is IElement element)
            {
				element.SegmentChanged += ItemPropertyChanged;
            }
		}

		/// <summary>
		/// Override metod
		/// </summary>
		/// <param name="index">the index where the element 
		/// will be deleted</param>
		protected override void RemoveItem(int index)
		{
			var item = this[index] as IElement;
			base.RemoveItem(index);
			item.SegmentChanged -= ItemPropertyChanged;
		}

		/// <summary>
		/// Override metod
		/// </summary>
		/// <param name="index">the index where the element 
		/// will be set</param>
		/// <param name="item">element to set</param>
		protected override void SetItem(int index, T item)
		{
			IElement oldItem = this[index] as IElement;
			base.SetItem(index, item);
			oldItem.SegmentChanged -= ItemPropertyChanged;
            if (item is IElement element)
            {
                element.SegmentChanged += ItemPropertyChanged;
            }
        }

		/// <summary>
		/// Override metod
		/// </summary>
		protected override void ClearItems()
		{
			foreach (var item in Items)
			{
				if (item is IElement element)
				{
					element.SegmentChanged -= ItemPropertyChanged;
				}
			}
			base.ClearItems();
		}

		/// <summary>
		/// Event for collection
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ItemPropertyChanged(object sender, EventArgs e)
		{
			ElementObservableCollectionChanged?.Invoke(sender, e);
		}
	
	}
}

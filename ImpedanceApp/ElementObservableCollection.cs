using System;
using System.Collections.ObjectModel;

namespace ImpedanceApp
{
	/// <summary>
	/// Collection for add metod in <see cref="ValueChanged"/> event
	/// </summary>
	/// <typeparam name="T"> is <see cref="IElement"/></typeparam>
	public sealed class ElementObservableCollection<T> : Collection<T>
	where T : IElement
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
			item.ValueChanged += item_PropertyChanged;
		}

		/// <summary>
		/// Override metod
		/// </summary>
		/// <param name="index">the index where the element 
		/// will be deleted</param>
		protected override void RemoveItem(int index)
		{
			var item = this[index];
			base.RemoveItem(index);
			item.ValueChanged -= item_PropertyChanged;
		}

		/// <summary>
		/// Override metod
		/// </summary>
		/// <param name="index">the index where the element 
		/// will be set</param>
		/// <param name="item">element to set</param>
		protected override void SetItem(int index, T item)
		{
			var oldItem = this[index];
			base.SetItem(index, item);
			oldItem.ValueChanged -= item_PropertyChanged;
			item.ValueChanged += item_PropertyChanged;
		}

		/// <summary>
		/// Override metod
		/// </summary>
		protected override void ClearItems()
		{
			foreach (var item in Items)
			{
				item.ValueChanged -= item_PropertyChanged;
			}
			base.ClearItems();
		}

		/// <summary>
		/// Event for collection
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void item_PropertyChanged(object sender, EventArgs e)
		{
			ElementObservableCollectionChanged?.Invoke(sender, e);
		}
	
	}
}

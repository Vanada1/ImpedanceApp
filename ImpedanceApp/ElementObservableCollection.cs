using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Text;

namespace ImpedanceApp
{
	public delegate void Changed(object sender, object e);
	public sealed class ElementObservableCollection<T> : Collection<T>
	where T : IElement
	{
		public event Changed CircuitChanged;

		protected override void InsertItem(int index, T item)
		{
			base.InsertItem(index, item);
			item.ValueChanged += item_PropertyChanged;
			if(CircuitChanged != null)
			{
				CircuitChanged(item, "Added element");
			}
		}

		protected override void RemoveItem(int index)
		{
			var item = this[index];
			base.RemoveItem(index);
			item.ValueChanged -= item_PropertyChanged;
		}

		protected override void SetItem(int index, T item)
		{
			var oldItem = this[index];
			base.SetItem(index, item);
			oldItem.ValueChanged -= item_PropertyChanged;
			item.ValueChanged += item_PropertyChanged;
		}

		protected override void ClearItems()
		{
			foreach (var item in Items)
			{
				item.ValueChanged -= item_PropertyChanged;
			}
			base.ClearItems();
		}

		private void item_PropertyChanged(object sender, object e)
		{
			CircuitChanged?.Invoke(sender, e);
		}
	
	}
}

using System;
using System.Collections.ObjectModel;

namespace ImpedanceApp
{
	/// <summary>
	///     Collection for add method in <see cref="ValueChanged" /> event
	/// </summary>
	/// <typeparam name="T"> is <see cref="ISegment" /></typeparam>
	public sealed class SegmentObservableCollection : ObservableCollection<ISegment>, ICloneable,
		IEquatable<SegmentObservableCollection>
	{
		public object Clone()
		{
			var newCollection = new SegmentObservableCollection();
			foreach (var segment in this) newCollection.Add(segment.Clone() as ISegment);

			return newCollection;
		}

		public bool Equals(SegmentObservableCollection other)
		{
			if (other == null) return false;
			if (Count != other.Count) return false;

			for (var i = 0; i < Count; i++)
				if (!this[i].Equals(other[i]))
					return false;

			return true;
		}

		/// <summary>
		///     Collection event
		/// </summary>
		public event EventHandler SegmentObservableCollectionChanged;

		/// <summary>
		///     Event for collection
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnSegmentChanged(object sender, EventArgs e)
		{
			SegmentObservableCollectionChanged?.Invoke(sender, e);
		}

		/// <summary>
		///     Override method by <see cref="ObservableCollection{T}" />
		///     Taken base method and added event subscription
		/// </summary>
		/// <param name="index">
		///     the index where the element
		///     will be inserted
		/// </param>
		/// <param name="item">element to insert</param>
		protected override void InsertItem(int index, ISegment item)
		{
			base.InsertItem(index, item);
			item.SegmentChanged += OnSegmentChanged;
		}

		/// <summary>
		///     Override method by <see cref="ObservableCollection{T}" />
		///     Taken base method and added event unsubscribe
		/// </summary>
		/// <param name="index">
		///     the index where the element
		///     will be deleted
		/// </param>
		protected override void RemoveItem(int index)
		{
			var item = this[index];
			base.RemoveItem(index);
			item.SegmentChanged -= OnSegmentChanged;
		}

		/// <summary>
		///     Override method by <see cref="ObservableCollection{T}" />
		///     Taken base method and added event over-subscription
		/// </summary>
		/// <param name="index">
		///     the index where the element
		///     will be set
		/// </param>
		/// <param name="item">element to set</param>
		protected override void SetItem(int index, ISegment item)
		{
			var oldItem = this[index];
			base.SetItem(index, item);
			oldItem.SegmentChanged -= OnSegmentChanged;
			item.SegmentChanged += OnSegmentChanged;
		}

		/// <summary>
		///     Override method by <see cref="ObservableCollection{T}" />
		///     Taken base method and added event unsubscribe for all elements
		/// </summary>
		protected override void ClearItems()
		{
			foreach (var item in Items) item.SegmentChanged -= OnSegmentChanged;

			base.ClearItems();
		}

		public override bool Equals(object obj)
		{
			return ReferenceEquals(this, obj) || obj is SegmentObservableCollection other &&
				Equals(other);
		}

		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		/// <summary>
		///     Overriding the == comparison operator. Comparing
		///     two <see cref="SegmentObservableCollection" />
		/// </summary>
		/// <param name="element1">
		///     First <see cref="SegmentObservableCollection" />
		///     for comparison
		/// </param>
		/// <param name="element2">
		///     Second <see cref="SegmentObservableCollection" />
		///     for comparison
		/// </param>
		/// <returns>
		///     Comparison result.True - equal.
		///     False - not equal
		/// </returns>
		public static bool operator ==(SegmentObservableCollection element1,
			SegmentObservableCollection element2)
		{
			if ((object) element1 == null || (object) element2 == null) return Equals(element1, element2);

			return element1.Equals(element2);
		}

		/// <summary>
		///     Overriding the == comparison operator. Comparing two
		///     <see cref="SegmentObservableCollection" />
		/// </summary>
		/// <param name="element1">
		///     First <see cref="SegmentObservableCollection" /> for
		///     comparison
		/// </param>
		/// <param name="element2">
		///     Second <see cref="SegmentObservableCollection" /> for
		///     comparison
		/// </param>
		/// <returns>
		///     Comparison result.True - not equal.
		///     False - equal
		/// </returns>
		public static bool operator !=(SegmentObservableCollection element1,
			SegmentObservableCollection element2)
		{
			if ((object) element1 == null || (object) element2 == null) return !Equals(element1, element2);

			return !element1.Equals(element2);
		}
	}
}
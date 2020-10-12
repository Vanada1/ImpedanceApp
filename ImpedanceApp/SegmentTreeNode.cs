using Impedance;
using System.Windows.Forms;

namespace ImpedanceApp
{
	/// <summary>
	/// Own TreeNode class for contain <see cref="ISegment"/> element
	/// </summary>
	public class SegmentTreeNode : TreeNode
	{
		/// <summary>
		/// Set and return <see cref="ISegment"/> element of TreeNode
		/// </summary>
		public ISegment Segment { get; set; }
	}
}

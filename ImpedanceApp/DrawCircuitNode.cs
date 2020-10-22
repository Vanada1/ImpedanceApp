using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using Impedance;

namespace ImpedanceApp
{
	/// <summary>
	/// Node class for drawing elements
	/// </summary>
	public class DrawCircuitNode
	{
		/// <summary>
		/// Element width
		/// </summary>
		private const int _widthElement = 50;

		/// <summary>
		/// Element height
		/// </summary>
		private const int _heightElement = 25;

		/// <summary>
		/// Adding distance for correct display X coordinate
		/// </summary>
		private const int _addX = 5;

		/// <summary>
		/// Adding distance for correct display Y coordinate
		/// </summary>
		private const int _addY = 5;

		/// <summary>
		/// check start
		/// </summary>
		private bool _isStart = true;

		/// <summary>
		/// Segment point
		/// </summary>
		private Point _segmentPoint;

		/// <summary>
		/// Connect point to left
		/// </summary>
		private Point _connectToLeft;

		/// <summary>
		/// Connect point to right
		/// </summary>
		private Point _connectToRight;

		/// <summary>
		/// Set and return <see cref="SegmentPoint"/>
		/// </summary>
		public Point SegmentPoint
		{
			get=> _segmentPoint;
			set
			{
				_segmentPoint = value;
				_connectToLeft = new Point(value.X,
					value.Y + Size.Height / 2);
				_connectToRight = new Point(value.X + Size.Width,
					value.Y + Size.Height / 2);
			}
		}

		/// <summary>
		/// Set and return element size
		/// </summary>
		public Size Size { get; set; }

		/// <summary>
		/// Set and return connect position to the element of left side
		/// </summary>
		public Point ConnectToLeft
		{
			get=> _connectToLeft;
			set
			{
				_connectToLeft = value;
				_connectToRight = new Point(value.X + Size.Width, value.Y);
				_segmentPoint = new Point(value.X, value.Y - Size.Height / 2);
			}
		}

		/// <summary>
		/// Set and return connect position to the element of right side
		/// </summary>
		public Point ConnectToRight
		{
			get=>_connectToRight;
			set
			{
				_connectToRight = value;
				_connectToLeft = new Point(value.X - Size.Width, value.Y);
				_segmentPoint = new Point(value.X - Size.Width, value.Y - Size.Height / 2);
			}
		}

		/// <summary>
		/// Set and return element parent 
		/// </summary>
		public DrawCircuitNode Parent { get; set; }

		/// <summary>
		/// Set and return element <see cref="SubNodes"/>
		/// </summary>
		public List<DrawCircuitNode> SubNodes { get; set; } =  new List<DrawCircuitNode>();

		/// <summary>
		/// Set and return element <see cref="ISegment"/>
		/// </summary>
		public ISegment Segment { get; set; }

		/// <summary>
		/// DrawCircuitNode constructor 
		/// </summary>
		/// <param name="parent">Node <see cref="Parent"/></param>
		/// <param name="segment">Segment of this node</param>
		public DrawCircuitNode(DrawCircuitNode parent, ISegment segment)
		{
			Parent = parent;
			Segment = segment;

			if (segment is Element)
			{
				Size = new Size(_widthElement,_heightElement);
			}
		}

		/// <summary>
		/// Calculate position for this Node
		/// </summary>
		/// <param name="prevPoint">
		/// Optional parameter.
		/// If you send a point, then he began to draw from a certain point.
		/// If nothing is sent, it will start from the default point.
		/// </param>
		public void CalculatePosition()
		{
			if(SubNodes.Count == 0) return;

			for (var i = 0; i < Segment.SubSegments.Count; i++)
			{
				SubNodes[i].SegmentPoint = SubNodes[i].Parent.SegmentPoint;

				if (i != 0)
				{
					if (Segment is ParallelCircuit)
					{
						SubNodes[i].SegmentPoint = new Point(SubNodes[i].SegmentPoint.X,
							SubNodes[i - 1].SegmentPoint.Y + SubNodes[i - 1].Size.Height + _addY);
					}
					else
					{
						SubNodes[i].ConnectToLeft = new Point(SubNodes[i - 1].ConnectToRight.X + _addX,
							SubNodes[i - 1].ConnectToRight.Y);
					}
				}

				SubNodes[i].CalculatePosition();
			}

			Size = GetSizeSegment();

			if (_isStart)
			{
				_isStart = false;
				CalculatePosition();
			}
		}

		/// <summary>
		/// Calculates segment size
		/// </summary>
		/// <param name="node">Segment for calculation</param>
		/// <returns>Segment size</returns>
		private Size GetSizeSegment()
		{
			Size segmentSize;

			switch (Segment)
			{
				case Element _:
				{
					segmentSize = Size;
					break;
				}
				case ParallelCircuit _:
				{
					var startSegment = SubNodes[0].SegmentPoint.Y;
					var endSegment = SubNodes[SubNodes.Count - 1].SegmentPoint.Y + SubNodes[SubNodes.Count - 1].Size.Height;
					var height = Math.Abs(endSegment - startSegment);
					segmentSize = new Size(FindMaxWidth(this), height);
					break;
				}
				default:
				{
					var startSegment = SubNodes[0].SegmentPoint.X;
					var endSegment = SubNodes[SubNodes.Count - 1].SegmentPoint.X + SubNodes[SubNodes.Count - 1].Size.Width;
					var width = Math.Abs(endSegment - startSegment);
					segmentSize = new Size(width, FindMaxHeight(this));
					break;
				}
			}

			return segmentSize;
		}

		/// <summary>
		/// Finds the maximum Width of an segment
		/// </summary>
		/// <param name="node">The element in which the search occurs</param>
		/// <returns>Maximum Width</returns>
		private static int FindMaxWidth(DrawCircuitNode node)
		{
			var maxWidth = node.SubNodes[0].Size.Width;

			foreach (var subNode in node.SubNodes)
			{
				if (maxWidth < subNode.Size.Width)
				{
					maxWidth = subNode.Size.Width;
				}
			}
			
			return maxWidth;
		}

		/// <summary>
		/// Finds the maximum Height of an segment
		/// </summary>
		/// <param name="node">The element in which the search occurs</param>
		/// <returns>Maximum Height</returns>
		private static int FindMaxHeight(DrawCircuitNode node)
		{
			var maxHeight = node.SubNodes[0].Size.Height;

			foreach (var subNode in node.SubNodes)
			{
				if (maxHeight < subNode.Size.Height)
				{
					maxHeight = subNode.Size.Height;
				}
			}

			return maxHeight;
		}
	}
}

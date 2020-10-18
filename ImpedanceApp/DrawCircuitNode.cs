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
	class DrawCircuitNode
	{
		/// <summary>
		/// Element width
		/// </summary>
		private readonly int _width = 50;

		/// <summary>
		/// Element height
		/// </summary>
		private readonly int _height = 25;

		/// <summary>
		/// Adding distance for correct display X coordinate
		/// </summary>
		private readonly int _addX = 5;

		/// <summary>
		/// Adding distance for correct display Y coordinate
		/// </summary>
		private readonly int _addY = 5;

		/// <summary>
		/// check start
		/// </summary>
		private bool _isStart = true;

		/// <summary>
		/// Set and return <see cref="SegmentPoint"/>
		/// </summary>
		public Point SegmentPoint { get; set; }

		/// <summary>
		/// Set and return element size
		/// </summary>
		public Size Size { get; set; }

		/// <summary>
		/// Set and return connect position to the element of left side
		/// </summary>
		public Point ConnectToLeft { get; set; }

		/// <summary>
		/// Set and return connect position to the element of right side
		/// </summary>
		public Point ConnectToRight { get; set; }

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
				Size = new Size(_width,_height);
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
		public void CalculatePosition(Point prevPoint = new Point())
		{
			var startPoint = SegmentPoint;

			if (Parent != null)
			{
				startPoint = Parent.SegmentPoint;
				if (Parent.Segment is ParallelCircuit)
				{
					startPoint.Y += prevPoint.Y;
				}
				else
				{
					startPoint.X += prevPoint.X;
				}

				SegmentPoint = startPoint;
			}

			if (Segment is Element) return;
			if(Segment.SubSegments.Count == 0) return;

			SubNodes[0].CalculatePosition();
			SubNodes[0].SegmentPoint = startPoint;
			for (var i = 1; i < Segment.SubSegments.Count; i++)
			{
				ConnectToLeft = new Point(SegmentPoint.X, SegmentPoint.Y + Size.Height / 2);
				ConnectToRight = new Point(SegmentPoint.X + Size.Width,
					SegmentPoint.Y + Size.Height / 2);

				var newSegmentSize =
					new Point((SubNodes[i - 1].Size.Width + _addX) * i,
					(SubNodes[i - 1].Size.Height + _addY) * i);

				SubNodes[i].CalculatePosition(newSegmentSize);
			}

			Size = GetSizeSegment(this);

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
		private Size GetSizeSegment(DrawCircuitNode node)
		{
			Size segmentSize;

			switch (node.Segment)
			{
				case Element _:
				{
					segmentSize = node.Size;
					break;
				}
				case ParallelCircuit _:
				{
					var startSegment = node.SubNodes[0].SegmentPoint.Y;
					var endSegment = node.SubNodes[SubNodes.Count - 1].SegmentPoint.Y;
					var height = Math.Abs(endSegment - startSegment) + _height;
					segmentSize = new Size(FindMaxWidth(node), height);
					break;
				}
				default:
				{
					var startSegment = node.SubNodes[0].SegmentPoint.X;
					var endSegment = node.SubNodes[SubNodes.Count - 1].SegmentPoint.X;
					var width = Math.Abs(endSegment - startSegment) + _width;
					segmentSize = new Size(width, FindMaxHeight(node));
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

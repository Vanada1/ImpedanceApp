using System;
using System.Collections.Generic;
using System.Reflection;
using Impedance;
using SegmentsDrawing.Elements;
using SegmentsDrawing.Segments;

namespace SegmentsDrawing
{
    /// <summary>
    /// Draw Tree View Manager class
    /// </summary>
    public class DrawingTreeViewManager
	{
		/// <summary>
		/// Stores the segment type in the key, and the type of the element to be drawn in the value
		/// </summary>
		private readonly Dictionary<Type, Type> _segmentDictionary;

		/// <summary>
		/// Drawn <see cref="Circuit"/>
		/// </summary>
		public CircuitDrawer CircuitDrawer { get; set; }
		
		/// <summary>
		/// <see cref="DrawingTreeViewManager"/> Constructor
		/// </summary>
		/// <param name="circuit"></param>
	    public DrawingTreeViewManager(Circuit circuit)
	    {
		    CircuitDrawer = new CircuitDrawer();
		    _segmentDictionary = CreateSegmentDictionary(typeof(DrawableSegmentBase));
		    FillDrawTreeView(circuit);
	    }

	    /// <summary>
	    /// Create segments tree
	    /// </summary>
	    private void FillDrawTreeView(Circuit circuit)
	    {
		    try
		    {
			    CircuitDrawer = new CircuitDrawer();
			    FillTreeNode(CircuitDrawer, circuit);
			    ClearEmptySegments(CircuitDrawer);

		    }
		    catch (ArgumentException e)
		    {
			    MessageBox.Show(e.Message, @"Error",
				    MessageBoxButtons.OK, MessageBoxIcon.Error);
		    }
	    }

	    /// <summary>
	    /// Add sub-segments in the tree
	    /// </summary>
	    /// <param name="treeNode">node where will add</param>
	    /// <param name="segment">segment where will add</param>
	    private void FillTreeNode(DrawableSegmentBase treeNode, ISegment segment)
	    {
		    try
		    {
			    foreach (var subSegment in segment.SubSegments)
			    {
				    var segmentTreeNode = GetDrawSegment(subSegment);
				    segmentTreeNode.Name = subSegment.Name;
				    treeNode.Nodes.Add(segmentTreeNode);
				    if (!(subSegment is Element))
				    {
					    FillTreeNode(segmentTreeNode, subSegment);
				    }
			    }
		    }
		    catch (ArgumentException e)
		    {
			    MessageBox.Show(e.Message, @"Error",
				    MessageBoxButtons.OK, MessageBoxIcon.Error);
		    }
	    }

		/// <summary>
		/// Returns the segment to draw based on the segment being sent
		/// </summary>
		/// <param name="segment">segment for check</param>
		/// <returns>Draw Segment</returns>
		private DrawableSegmentBase GetDrawSegment(ISegment segment)
	    {
		    var drawingType = _segmentDictionary[segment.GetType()];
			Type[] types = new Type[] { drawingType };
		    var constructors = drawingType.GetConstructors();
		    foreach (var constructor in constructors)
		    {
				return constructor.Invoke(new object[0]) as DrawableSegmentBase;
			}
		    return null;
	    }

		/// <summary>
		/// Creates a dictionary of segment types
		/// </summary>
		/// <param name="baseType"></param>
		/// <returns>Types Dictionary</returns>
		private static Dictionary<Type, Type> CreateSegmentDictionary(Type baseType)
	    {
		    var segmentDictionary = new Dictionary<Type, Type>();
		    var typeList = GetTypeList(baseType);

		    foreach (var drawingType in typeList)
		    {
			    var attributes = drawingType.GetCustomAttributes();
			    foreach (var attribute in attributes)
			    {
				    if (!(attribute is SegmentTypeValidationAttribute validationAttribute))
				    {
						continue;
				    }

				    var type = validationAttribute.SegmentType;
				    segmentDictionary.Add(type, drawingType);
			    }
			}

			return segmentDictionary;
	    }

		/// <summary>
		/// Lets get a list of all child types of the base class
		/// </summary>
		/// <param name="baseType">Base class type for search</param>
		/// <returns>List of all child class types</returns>
		private static List<Type> GetTypeList(Type baseType)
	    {
		    var currentDomain = AppDomain.CurrentDomain;
			var assemblies = currentDomain.GetAssemblies();
			var types = new List<Type>();
			foreach (var assembly in assemblies)
			{
				foreach (var type in assembly.GetTypes())
				{
					if (type.IsSubclassOf(baseType))
					{
						types.Add(type);
					}
				}
			}

			return types;
	    }

		/// <summary>
		/// Clears empty segments
		/// </summary>
		/// <param name="root">Starting root</param>
		private static void ClearEmptySegments(DrawableSegmentBase root)
	    {
		    if (root.Nodes.Count == 0)
		    {
			    return;
		    }
		    DrawableSegmentBase node = root.Nodes[0] as DrawableSegmentBase;
		    while (node != null)
		    {
			    DrawableSegmentBase nextSegment = node.NextNode as DrawableSegmentBase;
			    if (!(node is DrawingElementBase))
			    {
				    if (node.Nodes.Count != 0)
				    {
					    ClearEmptySegments(node);
				    }
				    if (node.Nodes.Count == 0)
				    {
					    node.Remove();
				    }
			    }
			    node = nextSegment;
		    }
	    }
	}
}
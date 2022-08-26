using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using DrawItems.Segments;
using Impedance.Elements;
using Impedance.Interface;
using Impedance.Segments;

namespace DrawItems
{
    /// <summary>
    /// Draw Tree View Manager class
    /// </summary>
    public class DrawingTreeViewManager
	{
		/// <summary>
		/// Stores the segment type in the key, and the type of the element to be drawn in the value
		/// </summary>
		private static readonly Dictionary<Type, Type> SegmentDictionary;

		/// <summary>
		/// Drawn <see cref="Circuit"/>
		/// </summary>
		protected CircuitVM CircuitDrawer { get; set; }

		static DrawingTreeViewManager()
		{
			SegmentDictionary = CreateSegmentDictionary(typeof(ISegmentDrawable));
		}

		public static CircuitVM CreateDrawableCircuit(Circuit circuit)
		{
			return new DrawingTreeViewManager(circuit).CircuitDrawer;
		}

		/// <summary>
		/// <see cref="DrawingTreeViewManager"/> Constructor
		/// </summary>
		/// <param name="circuit"></param>
		protected DrawingTreeViewManager(Circuit circuit)
	    {
		    CircuitDrawer = new CircuitVM(circuit);
		    FillDrawTreeView(circuit);
	    }

		/// <summary>
		/// Create segments tree
		/// </summary>
		private void FillDrawTreeView(Circuit circuit)
		{
			FillTreeNode(CircuitDrawer, circuit);
			ClearEmptySegments(CircuitDrawer);
		}

		/// <summary>
		/// Add sub-segments in the tree
		/// </summary>
		/// <param name="treeNode">node where will add</param>
		/// <param name="segment">segment where will add</param>
		private void FillTreeNode(ISegmentDrawable treeNode, ISegment segment)
		{
			foreach (var subSegment in segment.SubSegments)
			{
				var segmentTreeNode = GetDrawSegment(subSegment);
				segmentTreeNode.Name = subSegment.Name;
				treeNode.SubSegments.Add(segmentTreeNode);
				if (!(subSegment is Element))
				{
					FillTreeNode(segmentTreeNode, subSegment);
				}
			}
		}

		/// <summary>
		/// Returns the segment to draw based on the segment being sent
		/// </summary>
		/// <param name="segment">segment for check</param>
		/// <returns>Draw Segment</returns>
		private ISegmentDrawable GetDrawSegment(ISegment segment)
	    {
		    var drawingType = SegmentDictionary[segment.GetType()];
		    var constructors = drawingType.GetConstructors();
		    foreach (var constructor in constructors)
		    {
				return constructor.Invoke(new object[] { segment }) as ISegmentDrawable;
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
		    if (baseType.IsInterface)
		    {
			    return GetTypeListAsInterface(baseType);
		    }

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
		/// Get all realization of interface.
		/// </summary>
		/// <param name="baseType">Interface type.</param>
		/// <returns></returns>
		private static List<Type> GetTypeListAsInterface(Type baseType)
		{
			return AppDomain.CurrentDomain.GetAssemblies()
				.SelectMany(s => s.GetTypes())
				.Where(baseType.IsAssignableFrom).ToList();
		}

		/// <summary>
		/// Clears empty segments
		/// </summary>
		/// <param name="root">Starting root</param>
		private static void ClearEmptySegments(ISegmentDrawable root)
	    {
			// TODO: may be unnecessary
			//if (root.SubSegments.Count == 0)
			//{
			// return;
			//}

			//var node = root.SubSegments[0] as ISegmentDrawable;
			//while (node != null)
			//{
			// var nextSegment = node.NextNode as DrawableSegmentBase;
			// if (!(node is DrawingElementBase))
			// {
			//  if (node.Nodes.Count != 0)
			//  {
			//   ClearEmptySegments(node);
			//  }
			//  if (node.Nodes.Count == 0)
			//  {
			//   node.Remove();
			//  }
			// }
			// node = nextSegment;
			//}
		}
	}
}
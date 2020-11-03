﻿using System;
using Impedance;
using ImpedanceApp.Draw.Elements;
using ImpedanceApp.Draw.Segments;

namespace ImpedanceApp.Draw
{
    //TODO: нет, не так. Имелось ввиду, что атрибут в качестве своего свойства ХРАНИТ тип элемента, с которым он связан ...
	// ... а из кода он задается типа [SegmentTypeValidation(Type = typeof(Resistor))] ...
	// ... Менеджер отрисовки хранит словарь <Type, Type>, где ключом является тип сегмента, а значением - тип отрисовщика...
	// ... Словарь инициализируется в конструкторе менеджера через рефлексию - находятся все отрисовщики в этой библиотеке, из их атрибутов забирается информация об сегменте, который они рисуют, и сохраняется в словаре (то есть ты не вручную прописываешь соответствие всех отрисовщиков, а шарповый код сам это делает автоматически при каждом новом запуске программы).
    // ... А во время отрисовки менеджер, обходя сегменты дерева, берет их тип, из созданного словаря находит для этого сегмента свой отрисовщик, и там создает для него экземпляр.
	// ... В итоге у тебя в коде нигде нет свитча, напрямую фиксирующего эелменты и отрисовщики (это плохое решение с точки зрения расширяемости), а соответствие делается автоматически.
	// ...
	// ... Сейчас же свитч просто перенесся внутрь атрибута, но принципиально ничего не изменилось - стало только запутаннее.
	/// <summary>
	/// Attribute for converting <see cref="ISegment"/> in <see cref="DrawableSegmentBase"/>
	/// </summary>
	public class SegmentTypeValidationAttribute : Attribute
    {
		/// <summary>
		/// Get a type of <see cref="ISegment"/>
		/// </summary>
		/// <param name="segment"></param>
		/// <returns>Drawing segment</returns>
		public DrawableSegmentBase GetDrawingSegmentType(ISegment segment)
		{
			switch (segment)
			{
				case Resistor _:
				{
					return new DrawingResistor();
				}

				case Inductor _:
				{
					return new DrawingInductor();
				}

				case Capacitor _:
				{
					return new DrawingCapacitor();
				}

				case ParallelCircuit _:
				{
					return new DrawingParallelCircuit();
				}

				case SerialCircuit _:
				{
					return new DrawingSerialCircuit();
				}

				case Circuit _:
				{
					return new CircuitDrawer();
				}

				default:
				{
					throw new ArgumentException("Unknown Segment");
				}
			}
		}
	}
}
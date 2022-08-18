namespace Services
{
    /// <summary>
    /// Interface for drawing circuit.
    /// </summary>
    public interface IDrawable
    {
        /// <summary>
        /// Draw circuit.
        /// </summary>
        void Draw();

        /// <summary>
        /// Redraw circuit.
        /// </summary>
        void Redraw();
    }
}
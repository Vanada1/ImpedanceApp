using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    /// <summary>
    /// Service for open window.
    /// </summary>
    public interface IWindowService
    {
        /// <summary>
        /// Open window and get result.
        /// </summary>
        /// <returns>Window result.</returns>
	    DialogResult OpenWindow(object dataContext);
    }
}

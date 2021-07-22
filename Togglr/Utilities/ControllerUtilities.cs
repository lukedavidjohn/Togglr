using System.Collections.Generic;

namespace Togglr.Utilities
{
    class ControllerUtilities<T>
    {
        public static List<T> GetAll()
        {
            return new List<T>{};
        }
    }
}

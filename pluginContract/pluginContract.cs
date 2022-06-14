using System;
using System.Collections.Generic;

namespace pluginContract
{
    /// <summary>
    /// List here all the functions from the pluginCore namespace.
    /// This is to expose those functions through the "contract" to the GH side.
    /// </summary>
    public interface IPlugin 
    {
        int IntegerAdd(int A, int B);
        string ShowText();
    }
}

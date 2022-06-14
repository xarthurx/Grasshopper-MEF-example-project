using System;
using System.ComponentModel.Composition;
using pluginContract;

namespace pluginComputation
{
    /// <summary>
    /// The actual implementation of computation functions.
    /// </summary>
    [Export(typeof(IPlugin))]
    public class pluginComputation : IPlugin
    {
        public int IntegerAdd(int A, int B)
        {
            return A + B;
        }

        public string ShowText()
        {
            return "Compute A+B using the MEF approach.";
        }
    }
}

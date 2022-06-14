using Grasshopper;
using Grasshopper.Kernel;
using System;
using System.Drawing;

namespace pluginLoader
{
    public class pluginLoaderInfo : GH_AssemblyInfo
    {
        public override string Name => "pluginLoader";

        //Return a 24x24 pixel bitmap to represent this GHA library.
        public override Bitmap Icon => null;

        //Return a short string describing the purpose of this GHA library.
        public override string Description => "";

        public override Guid Id => new Guid("741D888F-274D-40B6-B1F8-C6C268455916");

        //Return a string identifying you or your company.
        public override string AuthorName => "Dr. Zhao Ma";

        //Return a string representing your preferred contact details.
        public override string AuthorContact => "xliotx@gmail.com";
    }
}
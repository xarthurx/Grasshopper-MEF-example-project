using Grasshopper;
using Grasshopper.Kernel;
using Rhino.Geometry;
using pluginContract;
using System;
using System.Reflection;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;

namespace pluginLoader
{
    public class pluginLoader : GH_Component
    {
        /// <summary>
        /// Import MEF contract for calling the functions in dll from this GH components.
        /// </summary>
        [Import(typeof(IPlugin))]
        public IPlugin mFunc;

        /// <summary>
        /// Each implementation of GH_Component must provide a public 
        /// constructor without any arguments.
        /// Category represents the Tab in which the component will appear, 
        /// Subcategory the panel. If you use non-existing tab or panel names, 
        /// new tabs/panels will automatically be created.
        /// </summary>
        public pluginLoader()
          : base("pluginLoader", "pLoader",
            "loader of MEF-based GH plugin.",
            "demoMEF", "loader")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddIntegerParameter("A", "A", "first integer number.", GH_ParamAccess.item);
            pManager.AddIntegerParameter("B", "B", "second integer number.", GH_ParamAccess.item);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddIntegerParameter("Result", "R", "result.", GH_ParamAccess.item);
            pManager.AddTextParameter("Text", "T", "text demo.", GH_ParamAccess.item);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object can be used to retrieve data from input parameters and 
        /// to store data in output parameters.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            int intA = 0;
            int intB = 0;
            if (!DA.GetData(0, ref intA)) { return; }
            if (!DA.GetData(1, ref intB)) { return; }

            var info = Instances.ComponentServer.FindAssemblyByObject(ComponentGuid);
            string dllFile = info.Location.Replace("pluginLoader.gha", "pluginComputation.dll"); // hard coded

            if (!System.IO.File.Exists(dllFile))
            {
                AddRuntimeMessage(GH_RuntimeMessageLevel.Error, String.Format("The core computation lib {0} does not exist.", dllFile));
            }

            // MEF
            try
            {
                // An aggregate catalog that combines multiple catalogs.
                var catalog = new AggregateCatalog();
                catalog.Catalogs.Add(new AssemblyCatalog(Assembly.Load(System.IO.File.ReadAllBytes(dllFile))));
                //catalog.Catalogs.Add(new AssemblyCatalog(typeof(IPlugin).Assembly));

                // Create the CompositionContainer with the parts in the catalog.
                _container = new CompositionContainer(catalog);
                _container.ComposeParts(this);

            }
            catch (CompositionException compositionException)
            {
                AddRuntimeMessage(GH_RuntimeMessageLevel.Error, compositionException.ToString());
                return;
            }

            // call the actural function
            DA.SetData(0, mFunc.IntegerAdd(intA, intB));
            DA.SetData(1, mFunc.ShowText());

        }
        // define the MEF container
        private CompositionContainer _container;

        /// <summary>
        /// Provides an Icon for every component that will be visible in the User Interface.
        /// Icons need to be 24x24 pixels.
        /// You can add image files to your project resources and access them like this:
        /// return Resources.IconForThisComponent;
        /// </summary>
        protected override System.Drawing.Bitmap Icon => null;

        /// <summary>
        /// Each component must have a unique Guid to identify it. 
        /// It is vital this Guid doesn't change otherwise old ghx files 
        /// that use the old ID will partially fail during loading.
        /// </summary>
        public override Guid ComponentGuid => new Guid("2AF68DC7-D112-4582-B640-C46158D162E0");
    }
}
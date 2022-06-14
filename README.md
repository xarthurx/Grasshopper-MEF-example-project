<h1 align="center">Grasshopper-MEF-Example-Project</h1>
An example project for developing Grasshopper plugin with the MEF approach.

## Why 
- [Compiling .dll without restarting Rhino](https://discourse.mcneel.com/t/compiling-dll-without-restarting-rhino/93825)
- [How To Debug/Recompile Without Restarting Rhino](https://discourse.mcneel.com/t/how-to-debug-recompile-without-restarting-rhino/94141)
- [Plugin dev and external .dll reload](https://discourse.mcneel.com/t/plugin-dev-and-external-dll-reload/114020)

## Related (Rhino Plugin)
- [A Solution for Rhino Plugin](https://discourse.mcneel.com/t/new-way-to-load-a-c-net-plugin/31284)


## Goal 
After digging for a few days, I cannot really find a solution for **How to developing GH plugin without restarting Rhino/GH everytime I change the code**. So that's what this repo does -- An starter-kit for those who are familar with Grasshopper plugin development, but are annoyed with the tedious Rhino/GH restarting process.


### What is "MEF"?
#### Official Page
- [Managed Extensibility Framework (MEF)](https://docs.microsoft.com/en-us/dotnet/framework/mef/)

#### Short summary
- A framework that can link external `.dll`(s) to the main application online easily.
- For Grasshopper development, it allows us to link an external `dll`  to the loaded Grasshopper plugin in a way that: 
  - **the external `dll` can be _independently_ compiled and re-compiled without affecting the loaded Grasshopper plugin.**

![Demo Video](https://github.com/xarthurx/Grasshopper-MEF-demo/blob/main/demoMEF.gif)
*This approach will greatly increase the developing speed and eliminate the tedious waiting time with ease.*


## Project Structure
The project has following 3 sub-projects:
- `pluginComputation` (backend): The core library contains the actural functions that do the work.
- `pluginLoader` (frontend): The GH plugin that will be loaded in Grasshopper. It calls the function from the backend through the linker ("contract").
- `pluginContract`: The definition (required by MEF) that works as the link between the **backend** (`pluginComputation`) and the **frontend** (`pluginLoader`).

### When a RESTART is needed:
Once the `pluginLoader` is loaded in a Grasshopper session, changes made to the function body of any functions defined in `pluginContract`/`pluginComputation` do not require a restart. However, adding new functions (or change function names, return types, etc.) will require a hard **RESTART** of Rhino/Grasshopper.

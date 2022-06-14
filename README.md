<h1 align="center">Grasshopper-MEF-Demo</h1>
A demo project for developing Grasshopper plugin with the MEF approach.

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
  - **the external `dll` can be -independently- compiled and re-compiled without affecting the loaded Grasshopper plugin.**

#### demo
![Demo Video](https://github.com/xarthurx/Grasshopper-MEF-demo/blob/main/demoMEF.gif)

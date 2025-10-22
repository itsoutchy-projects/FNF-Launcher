# FNF Launcher
This launcher creates an easy to use way to download engines and create instances of Friday Night Funkin'

Easily manage and find your instances and download the latest version of each engine with a few clicks.

TODO:  
- [x] Add more engines (leather engine, JS Engine, etc)  
- [x] First release
	- [x] Confirm most bugs are fixed

It's also on Gamebanana!  
[![](https://gamebanana.com/tools/embeddables/19676?type=large)](https://gamebanana.com/tools/19676)

## Custom Engine Documentation
So, you wanna add your own engine? Well take a look at the documentation for this new feature.  

First off, go ahead and find the folder where you have the launcher at (Go to settings and click "Open App Folder"). In there, you'll find an "engines" folder. This is where you'll define your engines.  

Next, make a new file. Name it something like the name of the engine.  

Now, in here you'll want to put something like this:  
```
name=OSEngine
repo=https://github.com/notweuz/FNF-OSEngine
platformNum=0
executable=OS Engine.exe
```
I'll go over each property next.

### Name
Simple enough, it's the name of the engine, as you'd like it to show up in the app. If you don't include this the app will just use the file name instead.

### Repo
This is where you'll put the Github repository that the engine is located in (it MUST have a release on there, or else you wont be able to use it).

### PlatformNum
This is the 0-based index of the release asset that the engine should download. For example, let's use the official VSlice latest release: https://github.com/FunkinCrew/Funkin/releases/latest  
Scroll down to where it says "Assets". Here you'll find different binaries that you'll need to download for your platform. It looks like that's number 3.  
In programing though, you'll use 0-based indexing, so that's actually number 2. (first one is 0, second is 1, etc.)

### Executable
This is where the engine's executable is located relative to the instance's folder. For example, with OS Engine, that's just `OS Engine.exe`, since they put it directly in the root folder of the archive.  
For Psych Engine though, that's `PsychEngine/PsychEngine.exe`.  
If you find the launcher can't run the engine, double check that this is set correctly.
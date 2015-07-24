#autoFrost

#GUI

Compile autoFrost and use the GUI to build GrayFrost.

Select the C# executable you want to package and the .sln file for GrayFrost and it will build the GrayFrost{32,64}.dll files for injection.

#Python

Streamlined CLI version of autoFrost 

Usage: 

	autoFrost.py <C# Payload .exe> <GrayFrost .sln file>

Example usage: 

	autoFrost.py graystorm\bin\Debug\GrayStorm.exe grayfrost\GrayFrost.sln
   

###Ensure that "MSBUILD.exe" is in your PATH variable for either method of building GrayFrost. 

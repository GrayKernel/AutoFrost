# autoFrost

## GUI

Compile autoFrost and use the GUI to build GrayFrost.

Select the C# executable you want to package and the .sln file for GrayFrost and it will build the GrayFrost{32,64}.dll files for injection.

## Python

Streamlined CLI version of autoFrost 

Usage: 

```bash
autoFrost.py <C# Payload .exe> <GrayFrost .sln file>
```

Example usage: 

```bash
autoFrost.py graystorm\bin\Debug\GrayStorm.exe grayfrost\GrayFrost.sln
```

---

## Output

The output of GrayFrost will appear in the GrayFrost\output directory. 

---

**Ensure that "MSBUILD.exe" is in your $PATH variable for either method of building GrayFrost.**

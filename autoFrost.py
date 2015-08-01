'''
Python script to automate the build of GrayFrost. 

Usage: 
   autoFrost.py <C# Payload .exe> <GrayFrost .sln file>

Example usage: 
   autoFrost.py graystorm\bin\Debug\GrayStorm.exe grayfrost\GrayFrost.sln
'''
import sys
import os
import subprocess

def autoBuild(buildPath, msbuild, args=''):
   arguments = args  + buildPath
   fp = open(os.devnull, 'w')
   retCode = subprocess.Popen([msbuild, args, buildPath], stdout=fp).wait()
   if retCode:
      print "[-] An error has occured in the build process"
      print "[-] View below msbuild.exe stderr for information"
      subprocess.Popen([msbuild, args, buildPath]).wait()
      exit()
	  
def buildCppArray(grayFrostCSharp):
   generator = bytes_from_file(grayFrostCSharp)
   embedArray =  "#define SIZE " + str(len(generator)) + " \n"
   embedArray += "unsigned char data[" + str(len(generator)) + "] = {"
   embedArray += generator
   embedArray += "\n};"
   return embedArray

def buildPayloadArray(payload):
   generator = bytes_from_file(payload)
   embedArray =  "namespace GrayFrostCSharp { class payload { \n public static byte[] g_bInjectCode = new byte[] \n\t{\n\t"
   embedArray += generator
   embedArray += "\n\t}; } }"
   return embedArray

def bytes_from_file(filename):
   builder = ''
   firstPass = True
   formatCounter = 0
   with open(filename, "rb") as f:
      while True:
         byte = f.read(1)
         formatCounter+=1
         if (formatCounter == 100):
            builder += "\n\t"
            formatCounter = 0
         if not byte:
            break
         if (firstPass):
            firstPass = False
            builder += ""+hex(ord(byte))
            continue
         builder += ","+hex(ord(byte))
   return builder

def writeFile(embedArray, path):
   file = open(path, 'wb')
   file.seek(0)
   file.write(embedArray)
   file.close()
   
def findMSBuild():
   msbuild = "msbuild.exe"
   for path in os.environ["PATH"].split(os.pathsep):
      path = path.strip('"')
      exe = os.path.join(path, msbuild)
      if os.path.isfile(exe) and os.access(exe, os.X_OK):
         return exe
   return None
   
def usage():
   print "Usage: autoFrost.py <C# Payload.exe> <GrayFrost.sln file>"
   exit()
   
def main(argv):
   payload = argv[0]
   GrayFrostSln = argv[1]
   if not os.path.exists(payload): 
      usage()
   if not os.path.exists(GrayFrostSln): 
      usage()
   msBuild = findMSBuild()
   if msBuild is None:
      print("Ensure msbuild.exe is in $PATH")
      exit()
   GrayFrostSln = GrayFrostSln.replace("\\GrayFrost.sln", "")
   print "[+] Building Payload into embeddable array"
   embedded = buildPayloadArray(payload)
   print "[+] Writing GrayFrostCSharp\\payload.cs"
   writeFile(embedded, GrayFrostSln + "\\GrayFrostCSharp\\payload.cs")
   print "[+] Building GrayFrostCSharp"
   autoBuild(GrayFrostSln + "\\GrayFrostCSharp\\GrayFrostCSharp.csproj", msBuild)
   print "[+] Writing Slate.h"
   grayFrostHeader = buildCppArray(GrayFrostSln + "\\GrayFrostCSharp\\bin\\Debug\\GrayFrostCSharp.exe")
   writeFile(grayFrostHeader, GrayFrostSln + "\\GrayFrost\\slate.h")
   print "[+] Building GrayFrost{32,64}.dll"
   autoBuild(GrayFrostSln + "\\GrayFrost\\GrayFrost32.vcxproj", msBuild, "/property:Configuration=Release;Platform=x86")
   autoBuild(GrayFrostSln + "\\GrayFrost\\GrayFrost64.vcxproj", msBuild, "/property:Configuration=Release;Platform=x64")
   print "[+] GrayFrost finished building"

if __name__ == '__main__':
   if len(sys.argv) == 3:
	   main(sys.argv[1:])
   else:
      usage()
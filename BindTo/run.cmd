del TestBindToNoInterface.exe
del TestBind.exe
del TestBindMultipleInterfaces.exe

..\Binaries\Debug\csc.exe /target:library Registry.cs
..\Binaries\Debug\csc.exe Singleton.cs /r:Registry.dll

pause
..\Binaries\Debug\csc.exe TestBindMultipleInterfaces.cs /r:Registry.dll
TestBindMultipleInterfaces.exe
pause

..\Binaries\Debug\csc.exe TestBindToInt.cs /r:Bind.dll

del TestBindToNoInterface.exe
..\Binaries\Debug\csc.exe TestBindToNoInterface.cs /r:Bind.dll
TestBindToNoInterface.exe
..\Binaries\Debug\csc.exe TestBind.cs /r:Bind.dll
TestBind.exe

pause
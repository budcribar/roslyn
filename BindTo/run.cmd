del TestBindToNoInterface.exe
del TestBind.exe
del TestBindMultipleInterfaces.exe
..\Binaries\Debug\csc.exe TestBindMultipleInterfaces.cs /r:Bind.dll
TestBindMultipleInterfaces.exe
pause

..\Binaries\Debug\csc.exe TestBindToInt.cs /r:Bind.dll

del TestBindToNoInterface.exe
..\Binaries\Debug\csc.exe TestBindToNoInterface.cs /r:Bind.dll
TestBindToNoInterface.exe
..\Binaries\Debug\csc.exe TestBind.cs /r:Bind.dll
TestBind.exe

pause
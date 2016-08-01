del TestBindToNoInterface.exe
del TestBind.exe

..\Binaries\Debug\csc.exe TestBindToInt.cs /r:Bind.dll

del TestBindToNoInterface.exe
..\Binaries\Debug\csc.exe TestBindToNoInterface.cs /r:Bind.dll
TestBindToNoInterface.exe
..\Binaries\Debug\csc.exe TestBind.cs /r:Bind.dll
TestBind.exe
pause
Echo off
IF EXIST MageTastic\bin\Debug\Assets ( ContentCompiler.exe .\Assets .\MageTastic\bin\Debug\Assets )
IF EXIST MageTastic\bin\Debug\Assets ( ContentCompiler.exe .\Assets .\MageTastic\bin\Release\Assets )
Pause
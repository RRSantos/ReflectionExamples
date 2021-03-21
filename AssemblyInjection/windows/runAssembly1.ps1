 .\build.ps1
$assemblyName = "Assembly1"
$programFolder = "..\LoadAssembly\bin\Debug\net5.0"
$loadAssemblyFolder = "$programFolder\Assembly\"

Write-Host "Creating directory '$loadAssemblyFolder'"
New-Item -ItemType Directory -Force -Path "$loadAssemblyFolder" | Out-Null

Write-Host "Removing *.dll from directory '$loadAssemblyFolder'"
Remove-Item "$loadAssemblyFolder\*.dll"

Write-Host "Copying $assemblyName to directory '$loadAssemblyFolder'"
Copy-Item "..\$assemblyName\bin\Debug\net5.0\$assemblyName.dll" -Destination "$loadAssemblyFolder"
Push-Location "$programFolder"
.\LoadAssembly.exe

Pop-Location

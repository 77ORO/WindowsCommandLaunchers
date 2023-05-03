# Windows Command Launchers

Tools that run commands under Windows

## DLLs

### Run Command From File

DLL that runs any cmd command that is placed inside file

## EXEs

### PowerShell Runner

Runs PowerShell using System.Management.Automation DLL

- bypasses constrained language mode
- bypasses execution policies
- bypasses PowerShell app blocking

### FileRunner Service

Creates a service that runs any commands located inside the following file: 

	C:\ProgramData\input-file.txt

After execution the file will be emptied. New commands are run after a 5-minute interval.
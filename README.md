# MongoDB-LocalhostInstance-Creation-Tool
Simple cli tool that creates a new MongoDB instance that runs in the background with the specified database path and localhost port for Windows 10/11

## Usage

Build in Visual Studio & add the `bin` folder to your path

Example:
```powershell
PS C:\> create-mongodb-instance Desktop\MongoDB-Local\data-1 27017

MongoDB instance created successfully...
  connection string = mongodb://localhost:27017
  dbPath = C:\MongoDB-Local\data-1
  port = 27017
  pid = 19132

Run the following command in Command Prompt or Powershell to kill this instance:
  cmd: taskkill /F /PID 19132
```

Run the same command with a different `port` & `database path` to create a second local MongoDB database
```powershell
PS C:\> create-mongodb-instance Desktop\MongoDB-Local\data-2 27018

MongoDB instance created successfully...
  connection string = mongodb://localhost:27018
  dbPath = C:\MongoDB-Local\data-1
  port = 27018
  pid = 16172

Run the following command in Command Prompt or Powershell to kill this instance:
  cmd: taskkill /F /PID 16172
```

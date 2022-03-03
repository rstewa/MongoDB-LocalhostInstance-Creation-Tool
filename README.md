# MongoDB-LocalhostInstance-Creation-Tool
Simple cli tool that creates a new MongoDB instance that runs in the background with the specified database path and localhost port for Windows 10/11

## Build

Build with Visual Studio & add the `bin\Release\net5.0` folder to your path or run `create-mongodb-instance.exe` directly

## Usage
```powershell
create-mongodb-instance [file-path-to-db] [local-port-to-use] [copy-taskkill-cmd-to-clipboard: y | n]
```

## Example:

```powershell
PS C:\> create-mongodb-instance Desktop\MongoDB-Local\data-1 27017 y

MongoDB instance created successfully:
  connection string = mongodb://localhost:27017
  dbPath = C:\Users\rstewar2\Desktop\MongoDB-Local\data-1
  port = 27017
  pid = 11312

To kill this instance run:
  'taskkill /F /PID 11312' (copied to clipboard = True)
```

Run the same command with a different `port` & `database-path` to create a second local MongoDB instance
```powershell
PS C:\> create-mongodb-instance Desktop\MongoDB-Local\data-2 27018 y

MongoDB instance created successfully:
  connection string = mongodb://localhost:27018
  dbPath = C:\Users\rstewar2\Desktop\MongoDB-Local\data-2
  port = 27018
  pid = 15604

To kill this instance run:
  'taskkill /F /PID 15604' (copied to clipboard = True)
```

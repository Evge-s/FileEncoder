# FileEncoder

`FileEncoder` is a tool designed for securely encrypting and decrypting files using a user-specified key coupled with an auto-generated random number.

## 📋 Requirements

- [.NET SDK](https://dotnet.microsoft.com/download) (Version 6.0 or newer)

## 🛠 Compilation Steps

1. **Clone the Repository**
First, clone the repository to your local machine:
```
git clone [Repository URL]
cd FileEncoder
```
3. **Install Dependencies**

Inside the project directory, run the following command:
```
dotnet restore
```
4. **Compile the Application**

For Windows x64:
```
dotnet publish -c Release --self-contained true --runtime win-x64
```
For Linux x64:
```
dotnet publish -c Release --self-contained true --runtime linux-x64 -p:PublishSingleFile=true
```
For MacOS x64:
```
dotnet publish -c Release --self-contained true --runtime osx-x64 -p:PublishSingleFile=true
```
4. **Launch the Application**

Navigate to the publish directory and launch the FileEncoder.exe file (for Windows)

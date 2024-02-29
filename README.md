English | [简体中文](./README.CN.md) 

# PSDeObfuscator

PSDeObfuscator is a PowerShell deobfuscation tool that utilizes C# function hooking techniques. It is designed to identify and restore the original content and intentions of obfuscated PowerShell scripts by intercepting and analyzing the calls to key functions. This tool is particularly useful for security researchers in uncovering the true nature of obfuscated PowerShell code.


## 1. Working Principle
By customizing the PowerShell profile file, we have introduced DLL injection technology, which is capable of imposing hooks on critical functions at the core level. The purpose of these hooks is to identify and deconstruct any obfuscated code streams, effectively managing the deobfuscation process. Once the process is complete, the results are transformed into JSON format and are automatically output to a predefined log file, facilitating subsequent data analysis and code review tasks.

## 2. List of Functions Currently Hooked
```
System.Convert.FromBase64String
System.Net.WebClient.DownloadString
System.Net.WebClient.DownloadFile
System.Text.UTF8Encoding.GetBytes
System.IO.MemoryStream.MemoryStream
System.IO.Compression.GZipStream.GZipStream
System.IO.Compression.DeflateStream.DeflateStream
System.IO.StreamReader.ReadToEnd
Microsoft.PowerShell.Commands.InvokeExpressionCommand.ProcessRecord
System.Management.Automation.ScriptBlock.Create
```


## 3. Usage
### Installation

```
Run .\Bin\install_psdeobfuscator.bat with administrator rights to install the profile file.
```
### Example Execution

```
Execute the sample scripts located in the .\Examples folder, such as by using the PowerShell command powershell .\Examples\IEX.ps1.
After the script has finished executing, enter the C:\psdecode_dir directory to view the deobfuscated output result of the script, which is in the format {pid}.json.
```
### Uninstallation

```
Run .\Bin\uninstall_psdeobfuscator.bat with administrator rights to uninstall the profile file.
```

## 4. Cautions

To perform the deobfuscation of PowerShell scripts, our method requires the execution of sample code. Due to the risk associated with this operation, we strongly advise performing it within a completely isolated virtual machine environment, to prevent potential security threats or damage that the execution of malicious code might cause to the host system. Running the sample in a virtual environment not only protects your hardware but also ensures that malware does not impact external networks.

## 5. Open Source LICENSE

[GPL 3.0](LICENSE.GPL)
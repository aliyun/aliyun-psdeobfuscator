[English](./README.md) | 简体中文 

# PSDeObfuscator

PSDeObfuscator 是一款基于 C# 函数钩子（hook）技术的 PowerShell 解混淆工具。它专门设计用于识别并还原常见的 PowerShell 混淆技巧，通过拦截和分析关键函数的调用，有效地帮助安全研究人员揭示被混淆的 PowerShell 脚本原本的内容和意图。


## 1. 工作原理
通过定制PowerShell的profile文件，我们引入了DLL注入技术，该技术能够在核心层面对关键函数施加钩子。这些钩子的作用是识别和解构任何混淆的代码流，有效地进行去混淆处理。处理完成后，我们会将结果转换成JSON格式，并自动输出到一个预定义的日志文件中，方便后续的数据分析和代码审计工作。

## 2. 目前hook的函数列表
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


## 3. 使用方法
### 安装

```
以管理员权限执行 .\Bin\install_psdeobfuscator.bat 来安装 profile 文件
```
### 执行例子

```
运行位于 .\Examples 文件夹内的示例脚本，例如通过 PowerShell 命令 powershell .\Examples\IEX.ps1。
在执行完成后，进入C:\psdecode_dir目录，能看到该脚本执行后解混淆的输出结果，其文件格式为 {pid}.json。
```
### 卸载

```
以管理员权限执行.\Bin\uninstall_psdeobfuscator.bat 来卸载profile文件
```

## 4. 注意事项

为了进行PowerShell脚本的解混淆工作，我们的方法需要执行样本代码。鉴于此操作的风险性，我们强烈建议在完全隔离的虚拟机环境内进行，以避免恶意代码的执行可能对主机系统造成的安全威胁或损害。在虚拟环境中运行样本不仅可以保护设备安全，还能确保恶意软件不会对外部网络造成影响。

## 5. 开源 LICENSE

[GPL 3.0](LICENSE.GPL)
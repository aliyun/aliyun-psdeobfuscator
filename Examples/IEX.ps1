$base64Command = 'V3JpdGUtSG9zdCBIZWxsb1dvcmxk'

$decodedBytes = [System.Convert]::FromBase64String($base64Command)

$decodedCommand = [System.Text.Encoding]::UTF8.GetString($decodedBytes)

iex $decodedCommand

$base64String = "SGVsbG8gV29ybGQh"

$bytes = [System.Convert]::FromBase64String($base64String)

$decodedString = [System.Text.Encoding]::UTF8.GetString($bytes)


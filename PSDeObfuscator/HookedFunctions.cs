using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Diagnostics;
using System.Reflection;
using System.IO.Compression;
using Microsoft.PowerShell.Commands;
using System.Management.Automation;

namespace PSDeObfuscator
{
    class HookedFunctions
    {
        public static object[][] GetHookInfo()
        {
           return  new object[][]
            {
                new object[]
                {
                    typeof(System.Convert),
                    "FromBase64String",
                    new Type[] { typeof(string) },
                    typeof(HookedFunctions),
                    "FromBase64String",
                    new Type[] { typeof(string) }
                },
                new object[]
                {
                    typeof(System.Net.WebClient),
                    "DownloadString",
                    new Type[] { typeof(Uri) },
                    typeof(Hooked_WebClient),
                    "DownloadString",
                    new Type[] { typeof(Uri) }
                },
                new object[]
                {
                    typeof(System.Net.WebClient),
                    "DownloadFile",
                    new Type[] { typeof(Uri), typeof(string) },
                    typeof(Hooked_WebClient),
                    "DownloadFile",
                    new Type[] { typeof(Uri), typeof(string) }
                },
                new object[]
                {
                    typeof(System.Text.UTF8Encoding),
                    "GetBytes",
                    new Type[] { typeof(string) },
                    typeof(Hooked_UTF8Encoding),
                    "GetBytes",
                    new Type[] { typeof(string) }
                },
                new object[]
                {
                    typeof(System.IO.MemoryStream),
                    "MemoryStream",
                    new Type[] { typeof(byte[]) },
                    typeof(Hooked_MemoryStream),
                    "MemoryStream",
                    new Type[] { typeof(byte[]) }
                },
                new object[]
                {
                    typeof(System.IO.Compression.GZipStream),
                    "GZipStream",
                    new Type[] {  typeof(Stream), typeof(CompressionMode), typeof(bool) },
                    typeof(Hooked_GZipStream),
                    "GZipStream",
                    new Type[] {  typeof(Stream), typeof(CompressionMode), typeof(bool) }
                },
                new object[]
                {
                    typeof(System.IO.Compression.GZipStream),
                    "GZipStream",
                    new Type[] {  typeof(Stream), typeof(CompressionLevel), typeof(bool) },
                    typeof(Hooked_GZipStream),
                    "GZipStream",
                    new Type[] {  typeof(Stream), typeof(CompressionLevel), typeof(bool) }
                },
                new object[]
                {
                    typeof(System.IO.Compression.DeflateStream),
                    "DeflateStream",
                    new Type[] {  typeof(Stream), typeof(CompressionMode), typeof(bool) },
                    typeof(Hooked_DeflateStream),
                    "DeflateStream",
                    new Type[] {  typeof(Stream), typeof(CompressionMode), typeof(bool) }
                },
                new object[]
                {
                    typeof(System.IO.Compression.DeflateStream),
                    "DeflateStream",
                    new Type[] {  typeof(Stream), typeof(CompressionLevel), typeof(bool) },
                    typeof(Hooked_DeflateStream),
                    "DeflateStream",
                    new Type[] {  typeof(Stream), typeof(CompressionLevel), typeof(bool) }
                },
                new object[]
                {
                    typeof(System.IO.StreamReader),
                    "ReadToEnd",
                    new Type[] {},
                    typeof(Hooked_StreamReader),
                    "ReadToEnd",
                    new Type[] {}
                },
                new object[]
                {
                    typeof(Microsoft.PowerShell.Commands.InvokeExpressionCommand),
                    "ProcessRecord",
                    new Type[] {},
                    typeof(Hooked_InvokeExpressionCommand),
                    "ProcessRecord",
                    new Type[] {}
                },
                new object[]
                {
                    typeof(System.Management.Automation.ScriptBlock),
                    "Create",
                    new Type[] { typeof(string) },
                    typeof(HookedFunctions),
                    "Create",
                    new Type[] { typeof(string) }
                }


              };
        }


        public class Hooked_WebClient
        {

            public string DownloadString(Uri address)
            {
                string ret = null;
                string exception = null;

                try
                {
                    WebClient _this = (object)this as WebClient;
                    ret = _this.DownloadString(address);
                }
                catch (Exception ex)
                {
                    exception = ex.Message;
                }
                finally
                {

                    Logger.WriteJsonObject(new
                    {
                        ApiName = typeof(WebClient).FullName + "." + MethodBase.GetCurrentMethod().Name,
                        address = address.ToString(),
                        ret = ret,
                        exception = exception
                    });
                }

                return ret;

            }


            public void DownloadFile(Uri address, string fileName)
            {
                string ret = null;
                string exception = null;

                try
                {
                    WebClient _this = (object)this as WebClient;
                    _this.DownloadFile(address, fileName);
                }
                catch (Exception ex)
                {
                    exception = ex.Message;
                }
                finally
                {

                    Logger.WriteJsonObject(new
                    {
                        ApiName = typeof(WebClient).FullName + "." + MethodBase.GetCurrentMethod().Name,
                        address = address.ToString(),
                        fileName = fileName,
                        ret = ret,
                        exception = exception
                    });
                }

                return;
            }

        }



        public static byte[] FromBase64String(string s)
        {
            byte[] ret = null;
            string exception = null;

            try
            {
                ret = Convert.FromBase64String(s);
            }
            catch (Exception ex)
            {
                exception = ex.Message;
            }
            finally
            {

                Logger.WriteJsonObject(new
                {
                    ApiName = typeof(Convert).FullName + "." + MethodBase.GetCurrentMethod().Name,
                    s = s,
                    ret = (ret == null ? "" : System.Text.Encoding.UTF8.GetString(ret)),
                    exception = exception
                });
            }

            return ret;

        }

        public static ScriptBlock Create(string script)
        {
            ScriptBlock ret = null;
            string exception = null;

            try
            {
                ret = ScriptBlock.Create(script);
            }
            catch (Exception ex)
            {
                exception = ex.Message;
            }
            finally
            {

                Logger.WriteJsonObject(new
                {
                    ApiName = typeof(ScriptBlock).FullName + "." + MethodBase.GetCurrentMethod().Name,
                    script = script,
                    ret = ret,
                    exception = exception
                });
            }

            return ret;

        }
        public class Hooked_UTF8Encoding
        {
            
            public byte[] GetBytes(string s)
            {
                byte[] ret = null;
                string exception = null;

                try
                {
                    UTF8Encoding _this = (object)this as UTF8Encoding;
                    ret =  _this.GetBytes(s);
                }
                catch (Exception ex)
                {
                    exception = ex.Message;
                }
                finally
                {

                    Logger.WriteJsonObject(new
                    {
                        ApiName = typeof(UTF8Encoding).FullName + "." + MethodBase.GetCurrentMethod().Name,
                        chars = s,
                        ret = ret,
                        exception = exception
                    });
                }

                return ret;
            }

        }

        public class Hooked_MemoryStream
        {
            public void MemoryStream(byte[] buffer)
            {
                string ret = null;
                string exception = null;

                try
                {
                    System.IO.MemoryStream _this = (object)this as System.IO.MemoryStream;
                    ConstructorInfo constructorInfo = typeof(System.IO.MemoryStream).GetConstructor(new Type[] { typeof(byte[]) });
                    constructorInfo.Invoke(_this, new object[] { buffer });
                }
                catch (Exception ex)
                {
                    exception = ex.Message;
                }
                finally
                {

                    Logger.WriteJsonObject(new
                    {
                        ApiName = typeof(System.IO.MemoryStream).FullName + "." + MethodBase.GetCurrentMethod().Name,
                        buffer = buffer,
                        ret = ret,
                        exception = exception
                    });
                }

                return;
            }
        }

        public class Hooked_GZipStream
        {
            public void GZipStream(Stream stream, CompressionMode mode, bool leaveOpen)
            {
                string ret = null;
                string exception = null;

                var oldPosition = stream.Position;
                var stream_buffer = new StreamReader(stream).ReadToEnd();
                stream.Position = oldPosition;

                try
                {
                    System.IO.Compression.GZipStream _this = (object)this as System.IO.Compression.GZipStream;
                    ConstructorInfo constructorInfo = typeof(System.IO.Compression.GZipStream).GetConstructor(new Type[] { typeof(Stream), typeof(CompressionMode), typeof(bool) });
                    constructorInfo.Invoke(_this, new object[] { stream, mode , leaveOpen });
                }
                catch (Exception ex)
                {
                    exception = ex.Message;
                }
                finally
                {

                    Logger.WriteJsonObject(new
                    {
                        ApiName = typeof(System.IO.Compression.GZipStream).FullName + "." + MethodBase.GetCurrentMethod().Name + "_1",
                        stream = stream_buffer,
                        mode = mode.ToString(),
                        leaveOpen = leaveOpen,
                        ret = ret,
                        exception = exception
                    });
                }

                return;
            }

            public void GZipStream(Stream stream, CompressionLevel compressionLevel, bool leaveOpen)
            {
                string ret = null;
                string exception = null;

                var oldPosition = stream.Position;
                var stream_buffer = new StreamReader(stream).ReadToEnd();
                stream.Position = oldPosition;

                try
                {
                    System.IO.Compression.GZipStream _this = (object)this as System.IO.Compression.GZipStream;
                    ConstructorInfo constructorInfo = typeof(System.IO.Compression.GZipStream).GetConstructor(new Type[] { typeof(Stream), typeof(CompressionLevel), typeof(bool) });
                    constructorInfo.Invoke(_this, new object[] { stream, compressionLevel, leaveOpen });
                }
                catch (Exception ex)
                {
                    exception = ex.Message;
                }
                finally
                {

                    Logger.WriteJsonObject(new
                    {
                        ApiName = typeof(System.IO.Compression.GZipStream).FullName + "." + MethodBase.GetCurrentMethod().Name + "_2",
                        stream = stream_buffer,
                        compressionLevel = compressionLevel.ToString(),
                        leaveOpen = leaveOpen,
                        ret = ret,
                        exception = exception
                    });
                }

                return;
            }
        }

        public class Hooked_DeflateStream
        {
            public void DeflateStream(Stream stream, CompressionMode mode, bool leaveOpen)
            {
                string ret = null;
                string exception = null;

                var oldPosition = stream.Position;
                var stream_buffer = new StreamReader(stream).ReadToEnd();
                stream.Position = oldPosition;

                try
                {
                    System.IO.Compression.DeflateStream _this = (object)this as System.IO.Compression.DeflateStream;
                    ConstructorInfo constructorInfo = typeof(System.IO.Compression.DeflateStream).GetConstructor(new Type[] { typeof(Stream), typeof(CompressionMode), typeof(bool) });
                    constructorInfo.Invoke(_this, new object[] { stream, mode, leaveOpen });
                }
                catch (Exception ex)
                {
                    exception = ex.Message;
                }
                finally
                {

                    Logger.WriteJsonObject(new
                    {
                        ApiName = typeof(System.IO.Compression.DeflateStream).FullName + "." + MethodBase.GetCurrentMethod().Name + "_1",
                        stream = stream_buffer,
                        mode = mode.ToString(),
                        leaveOpen = leaveOpen,
                        ret = ret,
                        exception = exception
                    });
                }

                return;
            }

            public void DeflateStream(Stream stream, CompressionLevel compressionLevel, bool leaveOpen)
            {
                string ret = null;
                string exception = null;

                var oldPosition = stream.Position;
                var stream_buffer = new StreamReader(stream).ReadToEnd();
                stream.Position = oldPosition;

                try
                {
                    System.IO.Compression.DeflateStream _this = (object)this as System.IO.Compression.DeflateStream;
                    ConstructorInfo constructorInfo = typeof(System.IO.Compression.DeflateStream).GetConstructor(new Type[] { typeof(Stream), typeof(CompressionLevel), typeof(bool) });
                    constructorInfo.Invoke(_this, new object[] { stream, compressionLevel, leaveOpen });
                }
                catch (Exception ex)
                {
                    exception = ex.Message;
                }
                finally
                {

                    Logger.WriteJsonObject(new
                    {
                        ApiName = typeof(System.IO.Compression.DeflateStream).FullName + "." + MethodBase.GetCurrentMethod().Name + "_2",
                        stream = stream_buffer,
                        compressionLevel = compressionLevel.ToString(),
                        leaveOpen = leaveOpen,
                        ret = ret,
                        exception = exception
                    });
                }

                return;
            }
        }


        public class Hooked_StreamReader
        {
            public string ReadToEnd()
            {
                string ret = null;
                string exception = null;

                try
                {
                    StreamReader _this = (object)this as StreamReader;
                    ret = _this.ReadToEnd();
                }
                catch (Exception ex)
                {
                    exception = ex.Message;
                }
                finally
                {

                    Logger.WriteJsonObject(new
                    {
                        ApiName = typeof(StreamReader).FullName + "." + MethodBase.GetCurrentMethod().Name,
                        ret = ret,
                        exception = exception
                    });
                }

                return ret;
            }
        }


        public class Hooked_InvokeExpressionCommand
        {
            public void ProcessRecord()
            {
                string exception = null;

                try
                {
                    InvokeExpressionCommand _this = (object)this as InvokeExpressionCommand;

                    Logger.WriteJsonObject(new
                    {
                        ApiName = typeof(InvokeExpressionCommand).FullName + "." + MethodBase.GetCurrentMethod().Name,
                        Command = _this.Command,
                        ret = "",
                        exception = exception
                    });

                    MethodInfo method = typeof(InvokeExpressionCommand).GetMethod("ProcessRecord", BindingFlags.Instance | BindingFlags.NonPublic);

                    if (method != null)
                    {
                       method.Invoke(this, null);
                    }
                }
                catch (Exception ex)
                {
                    exception = ex.Message;
                }
                finally
                {

                }

                return;
            }
        }

    }
}


using System;
using System.Runtime.InteropServices;
using System.Reflection;
using Newtonsoft.Json;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;

namespace PSDeObfuscator
{
    public class PowershellApiHookHelper
    {
        static DeviareLiteInterop.HookLib cHook;
        public static List<object> hookedobjects = new List<object>();

        public PowershellApiHookHelper()
        {
  
        }


        public static void EnableAllhook()
        {
        
            cHook = new DeviareLiteInterop.HookLib();
            
            object[][] hookInfo = PSDeObfuscator.HookedFunctions.GetHookInfo();

            for (int i = 0; i < hookInfo.Length; i++)
            {
                try
                {
                    Type targetType = (Type)hookInfo[i][0];
                    string targetMethod = (string)hookInfo[i][1];
                    Type[] targetMethodParams = (Type[])hookInfo[i][2];
                    Type replacementType = (Type)hookInfo[i][3];
                    string replacementMethod = (string)hookInfo[i][4];
                    Type[] replacementMethodParams = (Type[])hookInfo[i][5];

                    object hookedObject = cHook.Hook(targetType, targetMethod, targetMethodParams,
                                        replacementType, replacementMethod, replacementMethodParams);

                    if (hookedObject != null)
                    {
                        hookedobjects.Add(hookedObject); // Add the hooked object to the list
                        Logger.WriteLog($"Success hook {((Type)hookInfo[i][0]).FullName}.{hookInfo[i][1]} ");
                    }
                    else
                    {
                        Logger.WriteLog($"Hook initialization failed for {((Type)hookInfo[i][0]).FullName}.{hookInfo[i][1]}");
                    }
                }
                catch (Exception e)
                {
                    // Handle exception
                    Logger.WriteLog($"Error hook {((Type)hookInfo[i][0]).FullName}.{hookInfo[i][1]}: {e.Message}");
                }
            }
        }

        public static void DisableAllhook()
        {
            if (hookedobjects != null)
            {
                foreach (object hookedobject in hookedobjects)
                {
                    cHook.Unhook(hookedobject);
                }
                hookedobjects.Clear(); // Clear the list after unhooking
            }
        }

    }
}

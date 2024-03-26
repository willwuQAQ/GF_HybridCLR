#if UNITY_EDITOR
using System;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;
using UnityEngine;

public class MsvcStdextWorkaround : IPreprocessBuildWithReport
{
    const string kWorkaroundFlag = "/D_SILENCE_STDEXT_HASH_DEPRECATION_WARNINGS";
 
    public int callbackOrder => 0;
 
    public void OnPreprocessBuild(BuildReport report)
    {
        Debug.Log("enter OnPreprocessBuild");
        var clEnv = Environment.GetEnvironmentVariable("_CL_");
 
        if (string.IsNullOrEmpty(clEnv))
        {
            Environment.SetEnvironmentVariable("_CL_", kWorkaroundFlag);
        }
        else if (!clEnv.Contains(kWorkaroundFlag))
        {
            clEnv += " " + kWorkaroundFlag;
            Environment.SetEnvironmentVariable("_CL_", clEnv);
        }
    }
}
 
#endif // UNITY_EDITOR
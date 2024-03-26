using UnityEditor;
using System.Collections.Generic;

public static class BuildScript
{
    static void BuildAndroid()
    {
        string path = "Builds/Android/mygame.apk";
        BuildPipeline.BuildPlayer(GetEnabledScenes(), path, BuildTarget.Android, BuildOptions.None);
    }

    static void BuildWindows()
    {
        string path = "Builds/Windows/mygame.exe";
        BuildPipeline.BuildPlayer(GetEnabledScenes(), path, BuildTarget.StandaloneWindows64, BuildOptions.None);
    }

    static void BuildMac()
    {
        string path = "Builds/Mac/mygame.app";
        BuildPipeline.BuildPlayer(GetEnabledScenes(), path, BuildTarget.StandaloneOSX, BuildOptions.None);
    }

    static string[] GetEnabledScenes()
    {
        List<string> enabledScenes = new List<string>();
        EditorBuildSettingsScene[] scenes = EditorBuildSettings.scenes;

        foreach (EditorBuildSettingsScene scene in scenes)
        {
            if (scene.enabled)
            {
                enabledScenes.Add(scene.path);
            }
        }

        return enabledScenes.ToArray();
    }

    [MenuItem("Build/Build Android")]
    static void PerformBuildAndroid()
    {
        BuildAndroid();
    }

    [MenuItem("Build/Build Windows")]
    static void PerformBuildWindows()
    {
        BuildWindows();
    }

    [MenuItem("Build/Build Mac")]
    static void PerformBuildMac()
    {
        BuildMac();
    }
}
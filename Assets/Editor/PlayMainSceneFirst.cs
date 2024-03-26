using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

public class PlayMainSceneFirst : MonoBehaviour
{
    [MenuItem("BuildTools/PlayModeUseFirstScene", true)]
    static bool ValidatePlayModeUseFirstScene()
    {
        Menu.SetChecked("BuildTools/PlayModeUseFirstScene", EditorSceneManager.playModeStartScene != null);
        return !EditorApplication.isPlaying;
    }

    [MenuItem("BuildTools/PlayModeUseFirstScene")]
    static void UpdatePlayModeUseFirstScene()
    {
        if (Menu.GetChecked("BuildTools/PlayModeUseFirstScene"))
        {
            EditorSceneManager.playModeStartScene = null;
        }
        else
        {
            SceneAsset scene = AssetDatabase.LoadAssetAtPath<SceneAsset>(EditorBuildSettings.scenes[0].path);
            EditorSceneManager.playModeStartScene = scene;
        }
    }
}

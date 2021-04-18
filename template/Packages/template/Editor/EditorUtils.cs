using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

[InitializeOnLoad]
public class EditorUtils
{
    static string keyRestoreScenePath;
    static string keyNeedRestore;

    static EditorUtils() 
    {
        EditorApplication.update += Update;

        keyRestoreScenePath = Application.dataPath + "restoreScenePath";
        keyNeedRestore = Application.dataPath + "needRestore";
    }

    static void Update() 
    {
        if (!EditorApplication.isPlaying &&
            !EditorApplication.isPlayingOrWillChangePlaymode &&
            PlayerPrefs.GetInt(keyNeedRestore) == 1)
        {
            PlayerPrefs.SetInt(keyNeedRestore, 0);
            EditorSceneManager.OpenScene(PlayerPrefs.GetString(keyRestoreScenePath));
        }
    }

    [MenuItem("CubePlatformer/Run Game")]
    public static void RunGame() 
    {
        if (!EditorApplication.isPlaying)
        {
            PlayerPrefs.SetString(keyRestoreScenePath, EditorSceneManager.GetActiveScene().path);
            EditorSceneManager.SaveOpenScenes();
            EditorSceneManager.OpenScene(EditorBuildSettings.scenes[0].path);
            PlayerPrefs.SetInt(keyNeedRestore, 1);
            EditorApplication.isPlaying = true;              
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class ResetSaveFile : EditorWindow
{
    [MenuItem("Save/SaveEditor")]

    public static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(ResetSaveFile));
    }

    void OnGUI()
    {
        // The actual window code goes here
        if (GUILayout.Button("삭제"))
        {
            PlayerPrefs.DeleteAll();
        }
    }

}

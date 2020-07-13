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

        GUILayout.Label("세이브 초기화", EditorStyles.boldLabel);
        if (GUILayout.Button("삭제"))
        {
            PlayerPrefs.DeleteAll();
        }
        GUILayout.Label("세이브 조작", EditorStyles.boldLabel);
        int loadScenceCount=EditorGUILayout.IntField("로드 씬", PlayerPrefs.GetInt("Stage"));
        PlayerPrefs.SetInt("Stage", loadScenceCount);
        PlayerPrefs.Save();

        if (GUILayout.Button("All Clear"))
        {
            for (int i = 0; i <= loadScenceCount; i++)
            {
                string sName = "S" + i;
                PlayerPrefs.SetInt(sName, 3);
            }
        }
    }

}

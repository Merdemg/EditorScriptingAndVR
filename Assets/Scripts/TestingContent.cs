using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class TestingContent : EditorWindow
{
    ContentToTest contentToTest = null;
    Texture2D greenIcon = null;
    Texture2D redIcon = null;

    enum CheckedStatus
    {
        Unchecked,
        Found,
        NotFound
    }

    List<CheckedStatus> checkedStatus = new List<CheckedStatus>();

    [MenuItem("Window/TestingContent")]
    public static void ShowWindow(){
        GetWindow<TestingContent>("Testing Content");
    }

    void OnEnable(){
        contentToTest = Resources.Load<ContentToTest>("ContentToTest");
        greenIcon = Resources.Load<Texture2D>("greenIcon");
        redIcon = Resources.Load<Texture2D>("redIcon");

        checkedStatus = new List<CheckedStatus>();

        foreach (string item in contentToTest.content)
        {
            checkedStatus.Add(CheckedStatus.Unchecked);
        }
    }

    void OnGUI(){
        if (contentToTest != null)
        {
            for (int i = 0; i < contentToTest.content.Count; i++)
            {              
                GUILayout.BeginHorizontal();

                GUILayout.Label(contentToTest.content[i]); // Write the name of the game object


                switch (checkedStatus[i])
                {   // Draw the icon
                    case CheckedStatus.Found:
                    GUILayout.Label(greenIcon, GUILayout.MaxHeight(10));
                    break;
                    case CheckedStatus.NotFound:
                    GUILayout.Label(redIcon, GUILayout.MaxHeight(10));
                    break;
                    case CheckedStatus.Unchecked:
                    //Maybe draw a question mark icon?
                    break;
                }
                
                GUILayout.FlexibleSpace();

                if (GUILayout.Button("VALIDATE", EditorStyles.miniButtonRight))
                {
                    GameObject[] AllObjects = FindObjectsOfType<GameObject>();

                    bool IsFound = false;
                    foreach (GameObject obj in AllObjects)
                    {
                        if (obj.name == contentToTest.content[i])
                        {
                            IsFound = true;
                            break;
                        }
                    }

                    if (IsFound)
                    {
                        checkedStatus[i] = CheckedStatus.Found;
                    }else
                    {
                        if (EditorUtility.DisplayDialog(contentToTest.content[i] + " not found.",contentToTest.content[i] + " not found. Create it?", "Yes", "No"))
                        {
                            new GameObject(contentToTest.content[i]);
                            checkedStatus[i] = CheckedStatus.Found;
                        }else
                        {
                            checkedStatus[i] = CheckedStatus.NotFound;
                        }                       
                    }
                }
                GUILayout.EndHorizontal();
            }
        }else
        {
            Debug.LogWarning("No content to test");
        }
    }
}

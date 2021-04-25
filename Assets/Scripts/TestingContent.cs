using UnityEngine;
using UnityEditor;

public class TestingContent : EditorWindow
{
    ContentToTest contentToTest = null;

    [MenuItem("Window/TestingContent")]
    public static void ShowWindow(){
        GetWindow<TestingContent>("Testing Content");
    }

    void OnEnable(){
        contentToTest = Resources.Load<ContentToTest>("ContentToTest");
    }

    void OnGUI(){
        if (contentToTest != null)
        {
            foreach (string item in contentToTest.content)
            {

                GUILayout.BeginHorizontal();

                GUILayout.Label(item);
                GUILayout.FlexibleSpace();

                if (GUILayout.Button("VALIDATE", EditorStyles.miniButtonRight))
                {
                    GameObject[] AllObjects = FindObjectsOfType<GameObject>();
                    bool IsFound = false;

                    foreach (GameObject obj in AllObjects)
                    {
                        if (obj.name == item)
                        {
                            IsFound = true;
                            break;
                        }
                    }

                    if (IsFound)
                    {
                        Debug.Log(item + "is found");
                    }else
                    {
                        Debug.Log(item + "not found");
                        if (EditorUtility.DisplayDialog(item + "not found.",item + "not found. Create it?", "Yes", "No"))
                        {
                            new GameObject(item);
                        }
                        
                    }
                }
                GUILayout.EndHorizontal();
            }
        }else
        {
            Debug.Log("No content to test");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ContentToTest", menuName = "ScriptableObjects/ContentToTest", order = 1)]
public class ContentToTest : ScriptableObject
{
    public List<string> content = new List<string>();
}

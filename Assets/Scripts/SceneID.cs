using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneID : ScriptableObject
{
    [SerializeField] private string sceneName;
    public string SceneName => sceneName;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneChangeName : MonoBehaviour
{
    [SerializeField] string sceneName;
    [SerializeField] int sceneNumber;
    public string GetSceneName() => sceneName;
    public int GetSceneNumber() => sceneNumber;
}

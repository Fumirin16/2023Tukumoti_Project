using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugBotton : MonoBehaviour
{
    [SerializeField] string sceneName;
    SceneManagerScript smsc;
    private void Start()
    {
        smsc = new SceneManagerScript();
    }
    public void SceneChange()
    {
        smsc.Load(sceneName);
    }
    public void ReloadScene()
    {
        smsc.Reload();
    }
    public void AnimaScene(Animator anima,string name)
    {
        anima.Play(name);
    }
    public void ObjSetActive(GameObject obj,bool b)=>obj.SetActive(b);
    public void Quit()
    {
        Quit();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class konsekiText : MonoBehaviour
{
    GameObject[] objs;

    [SerializeField] string sceneName;

    SceneManagerScript smsc;

    // Start is called before the first frame update
    void Start()
    {
        //konsekiUI.enabled = false;
        smsc = new SceneManagerScript();
    }

    // Update is called once per frame
    void Update()
    {
        objs = GameObject.FindGameObjectsWithTag("Cube");

        //if (objs.Length == 0)
        //{
        //    Invoke(nameof(change), 2.0f);
        //}
    }

    //void scan()
    //{
    //    if (objs.length == 0)
    //    {
    //        invoke(nameof(change), 2.0f);
    //    }
    //}

    public void OnClickScene()
    {
        Invoke(nameof(change), 2.0f);
        AudioManagerScript.instance.PlayAudio(AudioData.Sound.back, Camera.main.gameObject, AudioManagerScript.Type.SE);
    }

    public void change()
    {
        smsc.Load(sceneName);
    }
}

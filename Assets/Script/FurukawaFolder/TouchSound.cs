using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchSound : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        AudioManagerScript.instance.PlayAudio(AudioData.Sound.buttonClick, Camera.main.gameObject, AudioManagerScript.Type.SE);
    }
}

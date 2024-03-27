using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARHelpButtonScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCickHelp()
    {
        AudioManagerScript.instance.PlayAudio(AudioData.Sound.buttonClick, Camera.main.gameObject, AudioManagerScript.Type.SE);
    }
    public void OnCickback()
    {
        AudioManagerScript.instance.PlayAudio(AudioData.Sound.back, Camera.main.gameObject, AudioManagerScript.Type.SE);
    }
}

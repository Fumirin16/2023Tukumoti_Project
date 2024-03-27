using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nakigoeScript : MonoBehaviour
{
    float time;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if(time % 5 < 4)
        AudioManagerScript.instance.PlayAudio(AudioData.Sound.Nakigoe, Camera.main.gameObject, AudioManagerScript.Type.SE);
        //AudioManagerScript.instance.PlayAudio(AudioData.Sound.ikaku, Camera.main.gameObject, AudioManagerScript.Type.SE);
    }
}

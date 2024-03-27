using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerScript : MonoBehaviour
{
    public enum Type
    {
        BGM,SE
    }
    public static AudioManagerScript instance=new AudioManagerScript();
    private float[] Vols=new float[System.Enum.GetValues(typeof(AudioManagerScript.Type)).Length];
    publicÅ@AudioData SoundData;
    // Start is called before the first frame update

    private void Start()
    {
        instance.SoundData = SoundData;
        instance.SetVol(0.5f, AudioManagerScript.Type.BGM);
        instance.SetVol(0.5f, AudioManagerScript.Type.SE);
    }
    public void PlayAudio(AudioData.Sound se,GameObject obj,Type type)
    {
        int num=-1;
        for (int i = 0; i < SoundData.sounds.Length; i++)
        {
            if (SoundData.sounds[i].soundName == se)
            {
                num = i;
            }
        }
        if(num==-1){
            Debug.Log("ó^Ç¶ÇÁÇÍÇΩSoundÇ©DataÇ…âπåπÇ™Ç†ÇËÇ‹ÇπÇÒ");
        }
        AudioClip clip = SoundData.sounds[num].clip;
        AudioSource source = null;
        if (!obj.GetComponent<AudioSource>())
        {
            source = obj.AddComponent<AudioSource>();

        }
        else
        {
            source = obj.GetComponent<AudioSource>();
        }

        source.volume = GetVol(type);
        source.PlayOneShot(clip);
    }

    public void SetVol(float x,Type type) => Vols[(int)type]=x;
    public float GetVol(Type type) => Vols[(int)type];
}

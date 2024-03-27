using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public struct Sounds
{
    [Tooltip("音源")] public AudioClip clip;
    [Tooltip("音源の名前")] public AudioData.Sound soundName;
}
[CreateAssetMenu]
public class AudioData : ScriptableObject
{
    public enum Sound
    {

        Give, Help, KonsekiFind, KonsekiGet, Love, Love2, TokotokoRader, Kurusii, Uresii,back, buttonClick,Escape,Natuita,Nakigoe,mainBGM,ikaku
    }
    [Header("新しい音源を追加する場合はAudioData.cs内のenumに追記してください")]
    [Tooltip("音データ")]public Sounds[] sounds;
}

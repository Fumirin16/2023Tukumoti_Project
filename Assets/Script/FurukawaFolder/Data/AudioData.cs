using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public struct Sounds
{
    [Tooltip("����")] public AudioClip clip;
    [Tooltip("�����̖��O")] public AudioData.Sound soundName;
}
[CreateAssetMenu]
public class AudioData : ScriptableObject
{
    public enum Sound
    {

        Give, Help, KonsekiFind, KonsekiGet, Love, Love2, TokotokoRader, Kurusii, Uresii,back, buttonClick,Escape,Natuita,Nakigoe,mainBGM,ikaku
    }
    [Header("�V����������ǉ�����ꍇ��AudioData.cs����enum�ɒǋL���Ă�������")]
    [Tooltip("���f�[�^")]public Sounds[] sounds;
}

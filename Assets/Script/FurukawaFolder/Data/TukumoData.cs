using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
[System.Serializable]
public struct Konsekis
{
    [Tooltip("���Ղ̎�ނ����")] public KonsekiData KonsekiData;
    [Tooltip("���Ղ�^�����ۂ̍D���x�����")] public int like;
}
[CreateAssetMenu]

public class TukumoData : ScriptableObject
{
    [Tooltip("���������̖��O�����")] public new string name;
    [Tooltip("���������̖��O�����")][Multiline(5)] public string detail;
    [Tooltip("�D���x�̍ő�l�����")]public int max;
    [Tooltip("����������prefab�����Ă�������")] public GameObject model;
    [Tooltip("�t���������̉摜")] public Sprite img;
    [Tooltip("���Ղ̏������")] public Konsekis[] konsekis;
}

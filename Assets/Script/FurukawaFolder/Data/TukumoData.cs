using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
[System.Serializable]
public struct Konsekis
{
    [Tooltip("痕跡の種類を入力")] public KonsekiData KonsekiData;
    [Tooltip("痕跡を与えた際の好感度を入力")] public int like;
}
[CreateAssetMenu]

public class TukumoData : ScriptableObject
{
    [Tooltip("つくもっちの名前を入力")] public new string name;
    [Tooltip("つくもっちの名前を入力")][Multiline(5)] public string detail;
    [Tooltip("好感度の最大値を入力")]public int max;
    [Tooltip("つくもっちのprefabを入れてください")] public GameObject model;
    [Tooltip("付くもっちの画像")] public Sprite img;
    [Tooltip("痕跡の情報を入力")] public Konsekis[] konsekis;
}

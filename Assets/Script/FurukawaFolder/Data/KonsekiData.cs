using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
    [CreateAssetMenu]
    public class KonsekiData : ScriptableObject
    {
        [Tooltip("���Ղ̖��O�����")] public new string name;
        [Tooltip("���Ղ̏ڍׂ����")][Multiline(5)] public  string detail;
        [Tooltip("���Ղ̉摜��}��")] public Sprite img;
}

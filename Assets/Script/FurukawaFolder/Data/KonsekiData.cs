using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
    [CreateAssetMenu]
    public class KonsekiData : ScriptableObject
    {
        [Tooltip("­Õ‚Ì–¼‘O‚ğ“ü—Í")] public new string name;
        [Tooltip("­Õ‚ÌÚ×‚ğ“ü—Í")][Multiline(5)] public  string detail;
        [Tooltip("­Õ‚Ì‰æ‘œ‚ğ‘}“ü")] public Sprite img;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// 平面検知して痕跡配置する

public class TapSound : MonoBehaviour
{
    [SerializeField] GameObject[] _spawnObject;
    [SerializeField] TextMeshProUGUI _textOK;
    [SerializeField] GameObject button;
    [SerializeField] int spownNum;
    [SerializeField] GameObject scansystem;
    [SerializeField] GameObject attentionPanel;

    GameObject[] objs;

    bool flag = true;

    public static int SceneNum;

    public static GameObject spawn;

    void Start()
    {
    }

    void Update()
    {
        objs = GameObject.FindGameObjectsWithTag("floor");

        spawn = _spawnObject[SceneNum];

        if (flag)
        {
            Instantiate(_spawnObject[SceneNum], objs[spownNum].transform.position, Quaternion.identity);
            _textOK.text = "OK！";
            //button.SetActive(true);
            attentionPanel.SetActive(false);
            scansystem.SetActive(true);
            flag = false;
        }
    }
}
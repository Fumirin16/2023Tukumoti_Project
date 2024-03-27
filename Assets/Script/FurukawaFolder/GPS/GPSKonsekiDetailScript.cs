using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GPSKonsekiDetailScript : MonoBehaviour
{
    GPSKonsekiUIScript uiManager;
    [SerializeField] TextMeshProUGUI name;
    [SerializeField] TextMeshProUGUI explanation;
    [SerializeField] Image img;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetUI(KonsekiData data)
    {
        name.text = data.name;
        explanation.text = data.detail;
        img.sprite = data.img;
    }
    public void SetUIManager(GPSKonsekiUIScript x)=>uiManager = x;
    public void SetActiveObj(bool x)=>gameObject.SetActive(x);
}

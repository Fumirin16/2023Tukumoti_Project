using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GPSUIManager : MonoBehaviour
{
    [SerializeField] GameObject konsekiObj;
    [SerializeField] GameObject contentObj;
    [SerializeField] GameObject KonsekiDetailObj;
    GameObject obj;
    // Start is called before the first frame update
    void Awake()
    {
        for (int i = 0; i < Getkonseki._konsekiList.Count; i++)
        {
            obj = Instantiate(konsekiObj, transform.position, Quaternion.identity, contentObj.transform);

            obj.GetComponent<Image>().sprite = Getkonseki._konsekiList[i].img;
            obj.GetComponent<GPSKonsekiUIScript>().SetUIManager(this);
            obj.GetComponent<GPSKonsekiUIScript>().SetKonsekiData(Getkonseki._konsekiList[i]);

        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void ActiveDetail(KonsekiData data)
    {
        KonsekiDetailObj.SetActive(true);
        KonsekiDetailObj.GetComponent<GPSKonsekiDetailScript>().SetUIManager(this.GetComponent<GPSKonsekiUIScript>());
        KonsekiDetailObj.GetComponent<GPSKonsekiDetailScript>().SetUI(data);
    }
}

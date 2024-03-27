using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class NatukaseUIManager : MonoBehaviour 
{
    // Start is called before the first frame update
    [SerializeField] GameObject contentObj;
    [SerializeField] GameObject konsekiObj;
    [SerializeField] GameObject dragObjPrefab;
    [SerializeField] Sprite[] konsekiImages;
    [SerializeField] Transform dragParent;
    [SerializeField] GameObject tukumochi;
    [SerializeField] GameObject GetTukumoUI;
    [SerializeField] GameObject EscTukumoUI;
    [SerializeField] TextMeshProUGUI name;
    [SerializeField] TextMeshProUGUI detail;
    [SerializeField] Image img;
    private GameObject dragObj;
    private RectTransform canvasRect;
   private Canvas canvas;
    private KonsekiData data;
    Camera cam;
    private Vector2 pos;
    void Start()
    {
        canvas = gameObject.GetComponent<Canvas>();
        canvasRect = canvas.GetComponent<RectTransform>();
        cam = canvas.worldCamera;
        GetTukumoUI.SetActive(false);
        EscTukumoUI.SetActive(false);
        for (int i = 0; i < Getkonseki._konsekiList.Count; i++)
        {
            GameObject obj = Instantiate(konsekiObj, transform.position, Quaternion.identity, contentObj.transform);

            obj.GetComponent<Image>().sprite = Getkonseki._konsekiList[i].img;
            obj.GetComponent<KonsekiImageScript>().SetUIManager(this);
            obj.GetComponent<KonsekiImageScript>().SetName(Getkonseki._konsekiList[i]);
        }
        if (Getkonseki._konsekiList.Count < 3)
        {
            for(int i = 0; i < 3 - Getkonseki._konsekiList.Count; i++)
            {
                GameObject obj = Instantiate(konsekiObj, transform.position, Quaternion.identity, contentObj.transform);

                obj.GetComponent<Image>().color=Color.black;
                obj.GetComponent<KonsekiImageScript>().SetUIManager(this);
                obj.GetComponent<KonsekiImageScript>().IsSet(true);
            }
        }
        Getkonseki._konsekiList.Clear();
        if (canvas.renderMode == RenderMode.ScreenSpaceOverlay)
        {
            cam = null;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SetPos(Vector2 vector)
    {
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRect, Input.mousePosition, canvas.worldCamera, out pos);

        if (dragObj!=null)dragObj.GetComponent<RectTransform>().anchoredPosition = pos;
    }
    public void drop() {
        tukumochi.GetComponent<NatukaseObjScript>().GiveKonseki(data);
        int a=0;
        foreach (Transform child in contentObj.transform)
        {
            if (!child.GetComponent<KonsekiImageScript>().GetSet()) a++;
            // 子オブジェクトに対する処理をここに書く
        }
        if (a == 1)
        {
            //全部使用時の処理記入
            tukumochi.GetComponent<NatukaseObjScript>().GetCharenge(false);
        }
    }
    public void Create(Vector3 pos,Sprite sprite,KonsekiData datas) {
        dragObj = Instantiate(dragObjPrefab, dragParent.position, Quaternion.identity, canvas.transform);
        dragObj.GetComponent<Image>().sprite = sprite;
        data = datas;
    } 
    public void dragObjDestroy()=>Destroy(dragObj);

    public void GetTukumoUISet(bool x) => GetTukumoUI.SetActive(x);
    public void EscTukumoUISet(bool x) => EscTukumoUI.SetActive(x);
    public void SetGetUIData(TukumoData data)
    {
        img.sprite = data.img;
        name.text = data.name;
        detail.text = data.detail;
    }
}

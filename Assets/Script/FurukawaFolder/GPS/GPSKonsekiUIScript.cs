using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.EventSystems;
public class GPSKonsekiUIScript : MonoBehaviour
{
    GPSUIManager uiManager;
    KonsekiData data;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public bool IsOnUI()
    {
        if (Input.GetMouseButtonUp(0))
        {
            PointerEventData pointData = new(EventSystem.current);

            pointData.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

            List<RaycastResult> rayResults = new();

            EventSystem.current.RaycastAll(pointData, rayResults);

            for (int j = 0; j < rayResults.Count; j++)
            {

                if (rayResults[j].gameObject == gameObject)
                {
                    uiManager.ActiveDetail(data);
                    return true;
                }
            }
        }
        return false;
    }
    // Update is called once per frame
    void Update()
    {
        if (IsOnUI()) ;
    }
    public void SetUIManager(GPSUIManager x) => uiManager = x;
    public void SetKonsekiData(KonsekiData _data) => data = _data;

}

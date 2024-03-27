using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class KonsekiImageScript : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    private RectTransform parentRectTransform;
    private NatukaseUIManager uiManager;
    private KonsekiData data;
    private bool isSet=false;
    private void Awake()
    {
    }


    // ドラッグ開始時の処理
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (isSet) return;
        // ドラッグ前の位置を記憶しておく
        // RectTransformの場合はpositionではなくanchoredPositionを使う
        uiManager.Create(eventData.pressPosition, this.gameObject.GetComponent<Image>().sprite,data);
        //transform.parent = canvas;
        //prevPos = rectTransform.anchoredPosition;
    }

    // ドラッグ中の処理
    public void OnDrag(PointerEventData eventData)
    {
        if (isSet) return;

        uiManager.SetPos(eventData.position);
        // eventData.positionから、親に従うlocalPositionへの変換を行う
        // オブジェクトの位置をlocalPositionに変更する

        //Vector2 localPosition = GetLocalPosition(eventData.position);
        //rectTransform.anchoredPosition = localPosition;
    }

    // ドラッグ終了時の処理
    public void OnEndDrag(PointerEventData eventData)
    {
        if (isSet) return;
        // オブジェクトをドラッグ前の位置に戻す
        //rectTransform.anchoredPosition = prevPos;
        //transform.parent = parent;

        var raycastResults = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, raycastResults);

        foreach (var hit in raycastResults)
        {
            if (hit.gameObject.CompareTag("TukumoPoint"))
            {

                uiManager.drop();
                Destroy(gameObject);
            }
        }

        uiManager.dragObjDestroy();
    }

    // ScreenPositionからlocalPositionへの変換関数
    private Vector2 GetLocalPosition(Vector2 screenPosition)
    {
        Vector2 result = Vector2.zero;

        // screenPositionを親の座標系(parentRectTransform)に対応するよう変換する.
        RectTransformUtility.ScreenPointToLocalPointInRectangle(parentRectTransform, screenPosition, Camera.main, out result);

        return result;
    }
    public void SetUIManager(NatukaseUIManager x) => uiManager = x;
    public void SetName(KonsekiData x)=>data = x;

    public void IsSet(bool x)=>isSet = x;
    public bool GetSet()=>isSet;

}

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


    // �h���b�O�J�n���̏���
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (isSet) return;
        // �h���b�O�O�̈ʒu���L�����Ă���
        // RectTransform�̏ꍇ��position�ł͂Ȃ�anchoredPosition���g��
        uiManager.Create(eventData.pressPosition, this.gameObject.GetComponent<Image>().sprite,data);
        //transform.parent = canvas;
        //prevPos = rectTransform.anchoredPosition;
    }

    // �h���b�O���̏���
    public void OnDrag(PointerEventData eventData)
    {
        if (isSet) return;

        uiManager.SetPos(eventData.position);
        // eventData.position����A�e�ɏ]��localPosition�ւ̕ϊ����s��
        // �I�u�W�F�N�g�̈ʒu��localPosition�ɕύX����

        //Vector2 localPosition = GetLocalPosition(eventData.position);
        //rectTransform.anchoredPosition = localPosition;
    }

    // �h���b�O�I�����̏���
    public void OnEndDrag(PointerEventData eventData)
    {
        if (isSet) return;
        // �I�u�W�F�N�g���h���b�O�O�̈ʒu�ɖ߂�
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

    // ScreenPosition����localPosition�ւ̕ϊ��֐�
    private Vector2 GetLocalPosition(Vector2 screenPosition)
    {
        Vector2 result = Vector2.zero;

        // screenPosition��e�̍��W�n(parentRectTransform)�ɑΉ�����悤�ϊ�����.
        RectTransformUtility.ScreenPointToLocalPointInRectangle(parentRectTransform, screenPosition, Camera.main, out result);

        return result;
    }
    public void SetUIManager(NatukaseUIManager x) => uiManager = x;
    public void SetName(KonsekiData x)=>data = x;

    public void IsSet(bool x)=>isSet = x;
    public bool GetSet()=>isSet;

}

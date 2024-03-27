using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrackingUI : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Image arrow;

    public Camera mainCamera;
    //RectTransform rectTransform;

    //Vector3 targetpos;

    private Rect rect = new Rect(0, 0, 1, 1);

    private Rect canvasRect;

    // Start is called before the first frame update
    void Start()
    {
        // UIがはみ出さないようにする
        canvasRect = ((RectTransform)arrow.canvas.transform).rect;
        canvasRect.Set(
            canvasRect.x + arrow.rectTransform.rect.width * 0.5f,
            canvasRect.y + arrow.rectTransform.rect.height * 0.5f,
            canvasRect.width - arrow.rectTransform.rect.width,
            canvasRect.height - arrow.rectTransform.rect.height
        );
    }

    // Update is called once per frame
    void Update()
    {

        var viewport = mainCamera.WorldToViewportPoint(target.position);
        //Debug.Log(viewport);

        Vector2 toDirection = viewport - arrow.rectTransform.position;

        // 画面外と画面内の判定（Contains、文字列内に指定の文字、文字列が含まれるか）
        if (rect.Contains(viewport))
        {
            arrow.enabled = false;
        }
        else
        {
            arrow.enabled = true;

            viewport.x = Mathf.Clamp01(viewport.x);
            viewport.y = Mathf.Clamp01(viewport.y);
            
            //arrow.rectTransform.eulerAngles = new Vector3(0f, 0f,Mathf.Atan2(viewport.y, viewport.x) * Mathf.Rad2Deg);
            //arrow.transform.rotation = Quaternion.FromToRotation(Vector3.up, toDirection);

            arrow.rectTransform.anchoredPosition = Rect.NormalizedToPoint(canvasRect, viewport);
        }
    }
}

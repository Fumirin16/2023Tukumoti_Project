using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HelpScript : MonoBehaviour
{
    GameObject[] target;
    [SerializeField] Image[] arrow;
    [SerializeField] Camera mainCamera;
    [SerializeField] float cycle;
    [SerializeField] int count;

    double _time;

    float repeatValue;

    Rect rect = new Rect(0, 0, 1, 1);

    Rect canvasRect;

    bool active;

    float elapsedTime;

    void Start()
    {
    }

    void Update()
    {
        target = GameObject.FindGameObjectsWithTag("Cube");

        // UI���͂ݏo���Ȃ��悤�ɂ���
        for (int i = 0; i < target.Length; i++)
        {
            canvasRect = ((RectTransform)arrow[i].canvas.transform).rect;
            canvasRect.Set(
                canvasRect.x + arrow[i].rectTransform.rect.width * 0.5f,
                canvasRect.y + arrow[i].rectTransform.rect.height * 0.5f,
                canvasRect.width - arrow[i].rectTransform.rect.width,
                canvasRect.height - arrow[i].rectTransform.rect.height
            );
        }

        _time += Time.deltaTime;

        repeatValue = Mathf.Repeat((float)_time, cycle);
        //Debug.Log(repeatValue);
        //Debug.Log(elapsedTime);
        for (int i = 0; i < target.Length; i++)
        {
            var viewport = mainCamera.WorldToViewportPoint(target[i].transform.position);

            // ��ʊO�Ɖ�ʓ��̔���iContains�A��������Ɏw��̕����A�����񂪊܂܂�邩�j
            if (rect.Contains(viewport) || elapsedTime > count)
            {
                arrow[i].enabled = false;
                elapsedTime = 0;
            }
            else if (active)
            {
                elapsedTime += Time.deltaTime;

                // ��������time�ɂ����閾�ŏ�Ԃ𔽉f
                arrow[i].enabled = repeatValue >= cycle * 0.5f;

                viewport.x = Mathf.Clamp01(viewport.x);
                viewport.y = Mathf.Clamp01(viewport.y);

                arrow[i].rectTransform.anchoredPosition = Rect.NormalizedToPoint(canvasRect, viewport);

                if(elapsedTime > count)
                {
                    active = false;
                }
            }
        }
    }

    public void Help()
    {
        active = true;
        AudioManagerScript.instance.PlayAudio(AudioData.Sound.Help, Camera.main.gameObject, AudioManagerScript.Type.SE);
    }
}
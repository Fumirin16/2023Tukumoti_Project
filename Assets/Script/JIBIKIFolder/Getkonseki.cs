using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

// 痕跡取得、痕跡データを保持する

public class Getkonseki : MonoBehaviour
{
    Ray rayOrigin;
    RaycastHit hitInfo;
    Animator hitobj;
    public static List<KonsekiData> _konsekiList = new List<KonsekiData>();
    [SerializeField] Animator GetAnimator;
    [SerializeField] TextMeshProUGUI konsekiname;
    [SerializeField] TextMeshProUGUI konsekidetail;
    [SerializeField] Image image;
    [SerializeField] GameObject GetObj;

    int layerMask  = 1<<7;

    private void Start()
    {
        //image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // スクリーン位置から3Dオブジェクトに対してRay（光線）を発射
            rayOrigin = Camera.main.ScreenPointToRay(Input.mousePosition);

            // Rayがオブジェクトにヒットした場合
            if (Physics.Raycast(rayOrigin, out hitInfo, Mathf.Infinity, layerMask))
            {
                // タグがPlayerの場合
                if (hitInfo.collider.CompareTag("Cube"))
                {
                    AudioManagerScript.instance.PlayAudio(AudioData.Sound.KonsekiGet, Camera.main.gameObject, AudioManagerScript.Type.SE);

                    // 痕跡リストにオブジェクト追加
                    _konsekiList.Add(hitInfo.collider.gameObject.GetComponent<KonsekiScript>().GetData());
                    StaticObjPotiosion.GetKonsekiNumber.Add(TapSound.SceneNum);
                    GetObj.SetActive(true);
                    GetAnimator.Play("GetIn");

                    //GetAnimator.Play("GetIn");

                    hitobj = hitInfo.collider.gameObject.GetComponent<Animator>();
                    hitobj.Play("Small");

                    konsekiname.text = hitInfo.collider.gameObject.GetComponent<KonsekiScript>().GetData().name;
                    konsekidetail.text = hitInfo.collider.gameObject.GetComponent<KonsekiScript>().GetData().detail;
                    image.sprite = hitInfo.collider.gameObject.GetComponent<KonsekiScript>().GetData().img;

                    hitInfo.collider.gameObject.SetActive(false);
                }
            }
        }
    }
}
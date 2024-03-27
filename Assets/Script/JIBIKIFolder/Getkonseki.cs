using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

// ���Վ擾�A���Ճf�[�^��ێ�����

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
            // �X�N���[���ʒu����3D�I�u�W�F�N�g�ɑ΂���Ray�i�����j�𔭎�
            rayOrigin = Camera.main.ScreenPointToRay(Input.mousePosition);

            // Ray���I�u�W�F�N�g�Ƀq�b�g�����ꍇ
            if (Physics.Raycast(rayOrigin, out hitInfo, Mathf.Infinity, layerMask))
            {
                // �^�O��Player�̏ꍇ
                if (hitInfo.collider.CompareTag("Cube"))
                {
                    AudioManagerScript.instance.PlayAudio(AudioData.Sound.KonsekiGet, Camera.main.gameObject, AudioManagerScript.Type.SE);

                    // ���Ճ��X�g�ɃI�u�W�F�N�g�ǉ�
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
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerScript : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    RaycastHit _hit;
    [SerializeField] Animator MenuAnima;
    // Start is called before the first frame update
    void Start()
    {
        AudioManagerScript.instance.PlayAudio(AudioData.Sound.mainBGM, Camera.main.gameObject, AudioManagerScript.Type.BGM);
    }
    public void OnPointerDown(PointerEventData eventData)//�I�u�W�F�N�g���N���b�N�A�w�Ń^�b�v�����Ƃ��ɌĂ΂��
    {
    }

    public void OnPointerUp(PointerEventData eventData) //�I�u�W�F�N�g�𗣂����Ƃ��ɌĂ΂��
    {
       
    }
    void Update()
    {
        ReloadcCunter.Instance.PlusTime(Time.deltaTime);

        if (Input.touchCount > 0)
        {
            Touch touch = Input.touches[0];
            if (touch.phase == TouchPhase.Began)
            {
                var _ray = Camera.main.ScreenPointToRay(touch.position);
                if (Physics.Raycast(_ray, out _hit))
                {
                    // �I�����ꂽ�I�u�W�F�N�g�ւ̏���
                    if (_hit.collider.gameObject.CompareTag("Player"))
                    {
                        MenuAnima.Play("MenuUp");
                    }
                }
            }
        }
    }
}

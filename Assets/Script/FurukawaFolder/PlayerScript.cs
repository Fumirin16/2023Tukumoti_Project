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
    public void OnPointerDown(PointerEventData eventData)//オブジェクトをクリック、指でタップしたときに呼ばれる
    {
    }

    public void OnPointerUp(PointerEventData eventData) //オブジェクトを離したときに呼ばれる
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
                    // 選択されたオブジェクトへの処理
                    if (_hit.collider.gameObject.CompareTag("Player"))
                    {
                        MenuAnima.Play("MenuUp");
                    }
                }
            }
        }
    }
}

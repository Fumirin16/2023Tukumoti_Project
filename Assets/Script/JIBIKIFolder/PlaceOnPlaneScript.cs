//�쐬�n����
//���ʌ��o�����Ƃ���Ƀ^�b�`������object�o��
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARRaycastManager))]
public class PlaceOnPlaneScript : MonoBehaviour
{
    [SerializeField]
    private GameObject _spawnObject; //�o��������I�u�W�F�N�g
    
    ARRaycastManager raycastManager;

    // Raycast�̏Փˏ��͋����ɂ���ă\�[�g����邽�߁A0�Ԗڂ��ł��߂��ꏊ�Ńq�b�g�������ƂȂ�܂�
    public List<ARRaycastHit> hitResults = new List<ARRaycastHit>();

    // Start is called before the first frame update
    void Start()
    {
        raycastManager = GetComponent<ARRaycastManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (raycastManager.Raycast(Input.GetTouch(0).position, hitResults))
            {
                Instantiate(_spawnObject, hitResults[0].pose.position, Quaternion.identity);
            }
        }
    }
}

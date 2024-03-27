using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;

public class Location : MonoBehaviour
{
    public static Location Instance { set; get; }

    public float latitude;
    public float longitude;
    public float altitude;
    public int gps_count = 0;
    public string message;
    public float vecx;
    public float vecy;
    public bool GetPos=false;
    public float speed;
    [SerializeField]float waitTime=3;
    [SerializeField]int timeOutMax=20;

    private void Start()
    {
        Instance = this;
        speed = 780;
        DontDestroyOnLoad(this.gameObject);
        Request();
    }

    void Request()
    {
        // �ʒu��񂪋�����Ă��邩�̊m�F
        if (Permission.HasUserAuthorizedPermission(Permission.CoarseLocation))
        {
            //message = "�������ȁI�I";
            StartCoroutine(StartLocationService());
        }
        else
        {
            //message = "�����I������I�I�I";
            Permission.RequestUserPermission(Permission.FineLocation);//�ʒu���̏����\��
            Request();
        }
    }
    private IEnumerator StartLocationService()//���t���[�����Ȃ�R���[�`������Ȃ��Ă�������
    {
        // �ʒu��񂪋�����Ă��邩�̊m�F�B������Ȃ��Ƃ��������[�v
        if (!Input.location.isEnabledByUser)
        {
            //message = "�ʒu��񂪋�����Ă��܂���";
            yield break;
        }

        // �ʒu���������B���Ԃ�������ۂ�����^�C���A�E�g�̏���
        Input.location.Start();

        int maxWait = timeOutMax;
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return new WaitForSeconds(1);
            maxWait--;
        }
        if (maxWait <= 0)
        {
            //message = "�^�C���A�E�g�B��蒼���܂�";
            yield break;
        }

        // Connection has failed
        if (Input.location.status == LocationServiceStatus.Failed)
        {
            //message = "���P�[�V�����̃X�e�[�^�X��Failed�Ȃ��߂�";
            yield break;
        }

        // �S���N���A������ݒ肳�ꂽ�b�����Ɉʒu�����������܂�
        while (true)
        {
            GetPos = true;
            latitude = Input.location.lastData.latitude;
            longitude = Input.location.lastData.longitude;
            altitude = Input.location.lastData.altitude;
            vecx = ReloadcCunter.Instance.GetMovePos().x;
            vecy = ReloadcCunter.Instance.GetMovePos().y;
            //gps_count++;
            yield return new WaitForSeconds(5f);//�}�b�v�X�V���b�ł��邩
        }
    }
}
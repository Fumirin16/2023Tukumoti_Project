using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class StaticMapController : MonoBehaviour
{

    //Google Maps Static API URL
    private const string STATIC_MAP_URL = "https://maps.googleapis.com/maps/api/staticmap?&zoom=15&size=1242x2688&key=AIzaSyBix5u2Rp765lQ8WaReLkUItsiijF53hOk&style=feature:all%7Ccolor:0x88fa5f&style=feature:road%7Ccolor:0xe7ffde&maptype=roadmap&style=element:labels|visibility:off";//���̍��W��35.59802,139.7084

    private float defaultZoom=15;
    [SerializeField] GameObject mainCamera;
    [SerializeField] float Time=5;
    [SerializeField] TokotokoRadarScript tokotoko;

    float baseDistance;
    float currentDistance;
    float pinchDistance;
    float x = 0;
    float FingerPosX0; //�^�b�v���A�w����ʂɐG�ꂽ�u�Ԃ̎w��x���W
    float FingerPosX1; //�^�b�v���A�w����ʂ��痣�ꂽ�u�Ԃ�x���W
    float FingerPosNow; //���݂̎w��x���W
    float PosDiff = 5f; //x���W�̍��̂����l�B
    Vector2 oldPos;
    Vector2 nowPos;
    // Start is called before the first frame update
    void Start()
    {

        if(GetComponent<Renderer>()==null)
            gameObject.AddComponent<Renderer>();

        // �񓯊�����
        StartCoroutine(Set());

    }
    // Update is called once per frame
    void Update()
    {
        ReloadcCunter.Instance.SetCunter(1);
        // 5�b�Ɉ�x�̎��s
        if (ReloadcCunter.Instance.IsCunter())
        {
            StartCoroutine(getStaticMap());
            ReloadcCunter.Instance.ResetTime();

        }
        GetTouchPos();

        if (Input.GetMouseButtonUp(0))
        {
            if (Mathf.Abs(FingerPosX0 - FingerPosX1) < PosDiff)
            {
            }
            if (FingerPosX0 - FingerPosNow > PosDiff)
            {

                tokotoko.TokotokoStart();
                tokotoko.gameObject.SetActive(true);
            }
            else if (FingerPosNow - FingerPosX0 > -PosDiff)
            {
                if (FingerPosNow - FingerPosX0 != 0)
                {

                }
            }
        }

        if (Input.touchCount == 2) { 
 //{
 //           pinchDistance = 0;
 //           baseDistance = 0;
 //           currentDistance = 0;
 //           // �Y�[������
 //           if (Input.touches[0].phase == TouchPhase.Moved || Input.touches[1].phase == TouchPhase.Moved)
 //           {
 //               baseDistance = Vector2.Distance(Input.touches[0].position, Input.touches[1].position);
 //           }
 //           currentDistance = Vector2.Distance(Input.touches[0].position, Input.touches[1].position);
               
 //               pinchDistance = (baseDistance - currentDistance);

 //           mainCamera.transform.Translate(new Vector3(0, 0, -pinchDistance), Space.World);
        }
    }
    private void GetTouchPos()
    {
        if (Input.GetMouseButtonDown(0))
        {
            FingerPosX0 = Input.mousePosition.y;
        }

        if (Input.GetMouseButtonUp(0))
        {
            FingerPosX1 = Input.mousePosition.y;
        }

        if (Input.GetMouseButton(0))
        {
            FingerPosNow = Input.mousePosition.y;
        }
    }
    IEnumerator Set()
    {
        if(!Location.Instance.GetPos)
            yield break;

        // �񓯊�����
        StartCoroutine(getStaticMap());
    }
    IEnumerator getStaticMap()
    {
        //x += 0.00001f;
        var query = "";
        nowPos = new Vector2(Location.Instance.longitude, Location.Instance.latitude);
        // center�Ŏ擾����~�j�}�b�v�̒������W��ݒ�
        query += "&center=" + Location.Instance.latitude+","+(Location.Instance.longitude); 

        // markers�œn�������W(=���݈ʒu)�Ƀ}�[�J�[�𗧂Ă�
        //query += "&markers=" + Location.Instance.latitude+"," +Location.Instance.longitude;
        //query += "&zoom="+defaultZoom++.ToString();
        // ���N�G�X�g�̒�`
        var req = UnityWebRequestTexture.GetTexture(STATIC_MAP_URL+query);
        // ���N�G�X�g���s
        yield return req.SendWebRequest();
        ReloadcCunter.Instance.SetMove(true);
        if (req.error == null)
        {
            // ���łɕ\�����Ă���}�b�v���X�V
            Destroy(GetComponent<Renderer>().material.mainTexture);
            GetComponent<Renderer>().material.mainTexture = ((DownloadHandlerTexture)req.downloadHandler).texture;

        }
        if (oldPos != Vector2.zero)
        {
            Vector2 x = nowPos - oldPos;
            ReloadcCunter.Instance.SetMovePos(x);
        }
        Location.Instance.gps_count++;
        oldPos = nowPos;
    }
}
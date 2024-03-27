using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class StaticMapController : MonoBehaviour
{

    //Google Maps Static API URL
    private const string STATIC_MAP_URL = "https://maps.googleapis.com/maps/api/staticmap?&zoom=15&size=1242x2688&key=AIzaSyBix5u2Rp765lQ8WaReLkUItsiijF53hOk&style=feature:all%7Ccolor:0x88fa5f&style=feature:road%7Ccolor:0xe7ffde&maptype=roadmap&style=element:labels|visibility:off";//仮の座標＝35.59802,139.7084

    private float defaultZoom=15;
    [SerializeField] GameObject mainCamera;
    [SerializeField] float Time=5;
    [SerializeField] TokotokoRadarScript tokotoko;

    float baseDistance;
    float currentDistance;
    float pinchDistance;
    float x = 0;
    float FingerPosX0; //タップし、指が画面に触れた瞬間の指のx座標
    float FingerPosX1; //タップし、指が画面から離れた瞬間のx座標
    float FingerPosNow; //現在の指のx座標
    float PosDiff = 5f; //x座標の差のいき値。
    Vector2 oldPos;
    Vector2 nowPos;
    // Start is called before the first frame update
    void Start()
    {

        if(GetComponent<Renderer>()==null)
            gameObject.AddComponent<Renderer>();

        // 非同期処理
        StartCoroutine(Set());

    }
    // Update is called once per frame
    void Update()
    {
        ReloadcCunter.Instance.SetCunter(1);
        // 5秒に一度の実行
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
 //           // ズーム処理
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

        // 非同期処理
        StartCoroutine(getStaticMap());
    }
    IEnumerator getStaticMap()
    {
        //x += 0.00001f;
        var query = "";
        nowPos = new Vector2(Location.Instance.longitude, Location.Instance.latitude);
        // centerで取得するミニマップの中央座標を設定
        query += "&center=" + Location.Instance.latitude+","+(Location.Instance.longitude); 

        // markersで渡した座標(=現在位置)にマーカーを立てる
        //query += "&markers=" + Location.Instance.latitude+"," +Location.Instance.longitude;
        //query += "&zoom="+defaultZoom++.ToString();
        // リクエストの定義
        var req = UnityWebRequestTexture.GetTexture(STATIC_MAP_URL+query);
        // リクエスト実行
        yield return req.SendWebRequest();
        ReloadcCunter.Instance.SetMove(true);
        if (req.error == null)
        {
            // すでに表示しているマップを更新
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
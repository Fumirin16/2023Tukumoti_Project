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
        // 位置情報が許可されているかの確認
        if (Permission.HasUserAuthorizedPermission(Permission.CoarseLocation))
        {
            //message = "許可したな！！";
            StartCoroutine(StartLocationService());
        }
        else
        {
            //message = "おい！許可しろ！！！";
            Permission.RequestUserPermission(Permission.FineLocation);//位置情報の所得申請
            Request();
        }
    }
    private IEnumerator StartLocationService()//毎フレーム取るならコルーチンじゃなくていいかも
    {
        // 位置情報が許可されているかの確認。許可されないとここをループ
        if (!Input.location.isEnabledByUser)
        {
            //message = "位置情報が許可されていません";
            yield break;
        }

        // 位置情報を所得。時間かかるっぽいからタイムアウトの処理
        Input.location.Start();

        int maxWait = timeOutMax;
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return new WaitForSeconds(1);
            maxWait--;
        }
        if (maxWait <= 0)
        {
            //message = "タイムアウト。やり直します";
            yield break;
        }

        // Connection has failed
        if (Input.location.status == LocationServiceStatus.Failed)
        {
            //message = "ロケーションのステータスがFailedならやめる";
            yield break;
        }

        // 全部クリアしたら設定された秒数毎に位置情報を所得します
        while (true)
        {
            GetPos = true;
            latitude = Input.location.lastData.latitude;
            longitude = Input.location.lastData.longitude;
            altitude = Input.location.lastData.altitude;
            vecx = ReloadcCunter.Instance.GetMovePos().x;
            vecy = ReloadcCunter.Instance.GetMovePos().y;
            //gps_count++;
            yield return new WaitForSeconds(5f);//マップ更新何秒でするか
        }
    }
}
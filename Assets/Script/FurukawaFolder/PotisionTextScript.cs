using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PotisionTextScript : MonoBehaviour
{
    public TextMeshProUGUI location;
    

    private void Update()
    {
        location.text = StaticObjPotiosion.mes;
        //$"緯度: {Location.Instance.latitude}\n経度: {Location.Instance.longitude}\n高度: {Location.Instance.altitude}\n\nCount: {Location.Instance.gps_count}\nMessage:\n{Location.Instance.message}\n" +
        //    $"移動量前：{Location.Instance.vecx},{Location.Instance.vecy}\n時間：{ReloadcCunter.Instance.IsCunter()}\nリミット：{ReloadcCunter.Instance.GetCunter()}\n";
    }
}

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
        //$"�ܓx: {Location.Instance.latitude}\n�o�x: {Location.Instance.longitude}\n���x: {Location.Instance.altitude}\n\nCount: {Location.Instance.gps_count}\nMessage:\n{Location.Instance.message}\n" +
        //    $"�ړ��ʑO�F{Location.Instance.vecx},{Location.Instance.vecy}\n���ԁF{ReloadcCunter.Instance.IsCunter()}\n���~�b�g�F{ReloadcCunter.Instance.GetCunter()}\n";
    }
}

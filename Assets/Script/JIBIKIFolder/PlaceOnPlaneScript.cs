//作成地引翼
//平面検出したところにタッチしたらobject出現
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARRaycastManager))]
public class PlaceOnPlaneScript : MonoBehaviour
{
    [SerializeField]
    private GameObject _spawnObject; //出現させるオブジェクト
    
    ARRaycastManager raycastManager;

    // Raycastの衝突情報は距離によってソートされるため、0番目が最も近い場所でヒットした情報となります
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

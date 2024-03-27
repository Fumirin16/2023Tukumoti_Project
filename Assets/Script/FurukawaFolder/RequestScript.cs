using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;
public class RequestScript : MonoBehaviour
{
    // Start is called before the first frame update
    string[] requestDatas = new string[2];
    void Start()
    {
        requestDatas[0] = Permission.Camera;
        requestDatas[1] = Permission.FineLocation;
        Request();
    }

    void Request()
    {
        // request
        for (int i = 0; i < requestDatas.Length; i++)
        {
            if (!Permission.HasUserAuthorizedPermission(requestDatas[i]))
            {
                Permission.RequestUserPermission(requestDatas[i]);
            }
        }
        check();

    }
    void check()
    {
        for (int i = 0; i < requestDatas.Length; i++)
        {
            if (!Permission.HasUserAuthorizedPermission(requestDatas[i]))
            {
                Request();
                break;
            }
        }
    }
}

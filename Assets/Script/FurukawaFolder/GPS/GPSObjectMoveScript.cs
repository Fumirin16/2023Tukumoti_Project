using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GPSObjectMoveScript : MonoBehaviour
{
    int c;
    [SerializeField]float speed;
    private GPSTukumoPointScript pointScript;
    private void Awake()
    {
    }
    private void Start()
    {
        pointScript = this.gameObject.GetComponent<GPSTukumoPointScript>();
    }
    private void Update()
    {

        if (ReloadcCunter.Instance.IsMove())
        {
            Move(ReloadcCunter.Instance.GetMovePos());
        }
    }
    public void Move(Vector2 movePos)
    {
        if (movePos.x > 10 || movePos.y > 10 || movePos.x < -10 || movePos.y < -10)
        {
            //StaticObjPotiosion.mes = movePos.ToString();
        }
        else { 
            transform.position += new Vector3(-(movePos.x * Location.Instance.speed), -(movePos.y * Location.Instance.speed), 0);
        }
        ReloadcCunter.Instance.SetMove(false);
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            pointScript.GetData(col.gameObject);
        }
    }
    private void OnTriggerStay(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            pointScript.GetData(col.gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GPS_CameraScript : MonoBehaviour
{
    [SerializeField] GameObject target;
    [SerializeField] Vector3 axis;
    [SerializeField] float speed;
    private Transform targetTransform;
    private float startCompass;
    private float oldMoveCommpas;
    private Vector3 move;
    float baseDistance;
    float currentDistance;
    float pinchDistance;
    float x = 0;
    void Start()
    {
        oldMoveCommpas = 0;
        targetTransform = target.transform;
        Input.compass.enabled = true;
        Input.location.Start();
        startCompass = Input.compass.trueHeading;
        target.transform.localEulerAngles=new Vector3(-oldMoveCommpas, -90, 90);

        pinchDistance = 0;
        baseDistance = 0;
        currentDistance = 0;
        move = target.transform.position - transform.position;
        Vector3.Normalize(move);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount == 2)
        {
            // ƒY[ƒ€ˆ—
            if (Input.touches[0].phase == TouchPhase.Moved || Input.touches[1].phase == TouchPhase.Moved)
            {
                baseDistance = Vector2.Distance(Input.touches[0].position, Input.touches[1].position);
            }
            currentDistance = Vector2.Distance(Input.touches[0].position, Input.touches[1].position);

            pinchDistance = (baseDistance - currentDistance);
            float x=0;
            if (pinchDistance != 0)
                x = Mathf.Sign(pinchDistance);

            if (Vector3.Distance(target.transform.position, transform.position) > 5 && x == 1)
            {

                transform.position = Vector3.MoveTowards(transform.position, target.transform.position, (x * 30 * Time.deltaTime));
            }

            if (Vector3.Distance(target.transform.position, transform.position) < 10 && x == -1)
            {

                transform.position = Vector3.MoveTowards(transform.position, target.transform.position, (x * 30 * Time.deltaTime));
            }
        }

        float compass = Input.compass.trueHeading;
        //compass += startCompass;

        //if (compass > 360)
        //    compass -= 360;

        compass -= 90;
        if (compass >= 360) compass -= 360;
        if (compass <= 0) compass += 360;
        string mes = "Šp“x:" + (compass)+"old"+oldMoveCommpas.ToString();
        //Location.Instance.message = mes;


            Vector3 localAngle = target.transform.localEulerAngles;
        if (oldMoveCommpas + 2.5f < compass || oldMoveCommpas-2.5f > compass)
        {
            oldMoveCommpas = compass;
        }
            localAngle.x = 360 - compass;
            localAngle.y = -90f;
            localAngle.z = 90;
        target.transform.localEulerAngles = localAngle;
        target.transform.rotation = Quaternion.Euler(localAngle);
        //transform.RotateAround(targetTransform.position, axis, move * speed * Time.deltaTime);
    }
}

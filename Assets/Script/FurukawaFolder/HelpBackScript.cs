using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpBackScript : MonoBehaviour
{
    RaycastHit _hit;
    [SerializeField] Animator anima;
    [SerializeField] string animaName;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.touches[0];
            if (touch.phase == TouchPhase.Began)
            {
                var _ray = Camera.main.ScreenPointToRay(touch.position);
                if (!Physics.Raycast(_ray, out _hit))
                {
                    anima.Play(animaName);
                }
            }
        }
    }
}

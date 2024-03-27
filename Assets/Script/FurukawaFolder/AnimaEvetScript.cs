using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimaEvetScript : MonoBehaviour
{
    [SerializeField] GPSTukumoPointScript pointsc;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void KonsekiAllGet() {
        pointsc.SetIsget(true);
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class KonsekiInfoBG : MonoBehaviour
{
    [SerializeField] public RawImage rawImage;
    [SerializeField] public Vector2 move = new Vector2(0, 1);



    // Start is called before the first frame update
    void OnEnable()
    {
        rawImage = GetComponent<RawImage>();
    }

    // Update is called once per frame
    void Update()
    {
        newPosition();
    }

    public void newPosition()
    {
        rawImage.uvRect = new Rect(rawImage.uvRect.position+move*Time.deltaTime, rawImage.uvRect.size);
    }
    
}

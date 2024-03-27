using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tukumotiFloating : MonoBehaviour
{
    [SerializeField] float floating = 0.1f;

    [SerializeField] float speed;

    float time;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Transform myTransform = this.transform;

        Vector3 pos = myTransform.position;

        //enemyÇècÇ…ïÇóVÇ≥ÇπÇÈ
        time += Time.deltaTime;
        pos.y = 5.0f * (Mathf.PerlinNoise(time / speed , floating) - 0.5f);
        pos.x = 5.0f * (Mathf.PerlinNoise(time / speed, time) - 0.5f);

        myTransform.position = pos;
    }
}

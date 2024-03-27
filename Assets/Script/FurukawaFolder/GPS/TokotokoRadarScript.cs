using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TokotokoRadarScript : MonoBehaviour
{
    [SerializeField] float maxSize;
    [SerializeField] float minSize;
    private float speed = 1;
    int a=0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.localScale *= speed;
        if(gameObject.transform.localScale.x >=maxSize)
        {
            TokotokoEnd();
        }
    }

    private void OnTriggerEnter(Collider col)
    {

        if (col.CompareTag("trace"))
        {
            //Ç±Ç±Ç…ìñÇΩÇ¡ÇΩéûÇÃèàóù
            col.GetComponent<Animator>().Play("TukumoPointAnima");
            AudioManagerScript.instance.PlayAudio(AudioData.Sound.KonsekiFind, Camera.main.gameObject, AudioManagerScript.Type.SE);
        }
    }
    public void TokotokoStart()
    {
            a++;
        StaticObjPotiosion.mes = a.ToString();
        speed = 1.1f;
        AudioManagerScript.instance.PlayAudio(AudioData.Sound.TokotokoRader, Camera.main.gameObject, AudioManagerScript.Type.SE);
    }
    public void TokotokoEnd()
    {
        speed = 1;
        gameObject.transform.localScale = new Vector3(minSize, minSize, minSize);
        gameObject.SetActive(false);
    }
}

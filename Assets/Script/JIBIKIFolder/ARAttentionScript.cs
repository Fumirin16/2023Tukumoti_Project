using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARAttentionScript : MonoBehaviour
{
    [SerializeField] GameObject attentionPanel;

    BoxCollider col;

    // Start is called before the first frame update
    void Start()
    {
        col = TapSound.spawn.GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickButton()
    {
        attentionPanel.SetActive(false);
        gameObject.SetActive(false);

        col.enabled = true;
    }
}

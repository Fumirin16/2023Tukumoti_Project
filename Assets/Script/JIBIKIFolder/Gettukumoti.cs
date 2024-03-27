using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Gettukumoti : MonoBehaviour
{
    [SerializeField] Renderer _Renderer;
    [SerializeField] Slider meter;
    [SerializeField] TextMeshProUGUI textUI;
    [SerializeField] string Name;
    [SerializeField] float maxTime;
    float elapsedTime = 0; // Œ»ÝŽžŠÔ

    SceneManagerScript sceneManagerScript;

    void Start()
    {
        elapsedTime = 0;
        sceneManagerScript = new SceneManagerScript();
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime = Mathf.Clamp(elapsedTime, 0, maxTime);

        meter.maxValue = maxTime;

        if (OnBecameInvisible())
        {
            elapsedTime += Time.deltaTime;
        }
        else
        {
            elapsedTime -= Time.deltaTime;
        }

        meter.value = elapsedTime;
        textUI.text = elapsedTime.ToString();
        if (elapsedTime > maxTime)
        {
            Time.timeScale = 0;
            sceneManagerScript.Load(Name);
        }
    }

    public bool OnBecameInvisible()
    {
        return _Renderer.isVisible;
    }
}

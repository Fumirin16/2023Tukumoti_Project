using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class NatukaseObjScript : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] float sliderSpeed;
    [SerializeField] TextMeshProUGUI text;
    [SerializeField]KonsekiData konsekiData;
    [SerializeField]KonsekiData konsekiData1;
    [SerializeField]KonsekiData konsekiData2;
    [SerializeField] GameObject loveEffect;
    [SerializeField] GameObject angryEffect;
    [SerializeField] NatukaseUIManager uIManager;
    private float likeMeter;
    public TukumoData data;
    bool isSliderMove;
    bool isCharenge;
    Animator anima;
    private void Awake()
    {
        //Getkonseki._konsekiList.Add(konsekiData);
        //Getkonseki._konsekiList.Add(konsekiData1);
        //Getkonseki._konsekiList.Add(konsekiData2);
    }
    private void Start()
    {
        Time.timeScale = 1;
        slider.maxValue = data.max;
        anima = GetComponent<Animator>();
    }
    private void Update()
    {
        SliderChange();
        Debug.Log(likeMeter.ToString());
    }
    void SliderChange()
    {
        if (likeMeter + 1f > slider.value && likeMeter - 1f < slider.value)
        {
            slider.value = likeMeter;
            isSliderMove = true;
        }
        else
        {
            isSliderMove = false;
            if (likeMeter > slider.value)
            {
                slider.value += sliderSpeed * Time.deltaTime;

            }
            else if (likeMeter < slider.value)
            {
                slider.value -= sliderSpeed * Time.deltaTime;
            }
        }
        if (slider.value <= 0 && 0 > likeMeter)
            isSliderMove = true;

        text.text=likeMeter.ToString();
        if (!isSliderMove && likeMeter >= data.max)
        {
            GetCharenge(true);
        }

        if (!isSliderMove && isCharenge)
        {
            isCharenge = false;
            StartCoroutine("End");
        }
    }
    public void GiveKonseki(KonsekiData data)//痕跡が与えられる
    {

        for (int i = 0; i < this.data.konsekis.Length; i++)
        {
            if (data.name == this.data.konsekis[i].KonsekiData.name)
            {
                likeMeter += this.data.konsekis[i].like;

                if (this.data.konsekis[i].like > 0)
                {
                    Instantiate(loveEffect, transform.position + Vector3.up, Quaternion.identity);
                    anima.Play("TakeNiko");
                    AudioManagerScript.instance.PlayAudio(AudioData.Sound.Uresii, Camera.main.gameObject, AudioManagerScript.Type.SE);
                }
                else
                {
                    Instantiate(angryEffect, transform.position + Vector3.up, Quaternion.identity);
                    anima.Play("TakeOko");
                    AudioManagerScript.instance.PlayAudio(AudioData.Sound.Kurusii, Camera.main.gameObject, AudioManagerScript.Type.SE);

                }

                Debug.Log (data.name + "を与えたよ！" + this.data.konsekis[i].like +"点！");
                return;
            }

        }
    }
    public void GetCharenge(bool x)
    {
        if (x)
        {
            //ここに成功したときのアニメーションやエフェクト
            Debug.Log("成功");
            text.text = "つくもっちが\n懐いたよ";
            GetList.getlist.Add(data);
            AudioManagerScript.instance.PlayAudio(AudioData.Sound.Natuita, Camera.main.gameObject, AudioManagerScript.Type.SE);
            uIManager.SetGetUIData(data);
            uIManager.GetTukumoUISet(true);
        }
        else
        {
            AudioManagerScript.instance.PlayAudio(AudioData.Sound.Escape, Camera.main.gameObject, AudioManagerScript.Type.SE);
            anima.Play("EscapeTukumo");
            //失敗時のアニメーションやエフェクト
            Debug.Log("失敗");
        }
            StaticObjPotiosion.transforms.Clear();
            StaticObjPotiosion.objs.Clear();
        isCharenge = true;
        StaticObjPotiosion.GetKonsekiNumber.Clear();
    }
    IEnumerator End()
    {
        yield return new WaitForSeconds(3f);
        //SceneChange();
    }

    public void animaEnd()
    {
        uIManager.EscTukumoUISet(true);
    }
    void SceneChange()
    {
        SceneManagerScript.instance.Load(SceneManagerScript.SceneName.GPSScene.ToString());

    }
}

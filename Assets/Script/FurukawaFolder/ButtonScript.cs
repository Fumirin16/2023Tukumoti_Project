using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    enum Type
    {
        ChangeScene,SetActive
    }
    enum SceneName
    {
        ARScene, GetScene, GPSScene, natukaseScene, SampleScene, TitleScene,OptionScene,CollectionScene
    }
    [SerializeField] Type type;
    [SerializeField] SceneName sceneName;
    [SerializeField]Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (type)//É{É^ÉìÇ≤Ç∆UpdataÇ≈èàóùÇ™Ç†ÇÈÇ»ÇÁãLì¸
        {
            case Type.ChangeScene:
                break;
                case Type.SetActive:
                break;
            default:
                break;
        }

    }

    public void PlayAnima(string name)
    {
        if (animator != null)
        {
            animator.Play(name);
        }
    }
    public void ChangeScene()
    {
        SceneManagerScript.instance.Load(sceneName.ToString());
    }

    public void BottonSE()
    {
        AudioManagerScript.instance.PlayAudio(AudioData.Sound.back, Camera.main.gameObject, AudioManagerScript.Type.SE);
    }
    public void Tokotoko(GameObject obj)
    {
        obj.SetActive(true);
    }
    public void Quit()
    {
        Application.Quit();
    }
}

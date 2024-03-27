using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GPSTukumoPointScript : MonoBehaviour
{

    [SerializeField] List<Transform> poss;
    [SerializeField] GameObject engage;
    [SerializeField] Slider slider;
    [SerializeField] GameObject allGetObj;
    [SerializeField] string sceneName;
    [SerializeField] GameObject tokotoko;
    private bool IsTouch;
    private GameObject target;
    public static AndroidJavaObject vibrator;
    private string scene;
    private SceneChangeName nums;
    private float des= 0.2f;
    bool isGet;
    // Start is called before the first frame update
    void Start()
    {
        engage.SetActive(false);
        allGetObj.SetActive(false);
        GetKonsekiDestroy();
        slider.maxValue = 7f;
        slider.value = des;
        isGet = false;
    }

    // Update is called once per frame
    void Update()
    {
        //StaticObjPotiosion.mes = slider.value.ToString();
        if (isGet)
            if (Input.touchCount > 0)
            {
                SceneManager.LoadScene(sceneName);
            }

        if (Input.touches.Length == 3)
            des += 0.0001f*Time.deltaTime;

        if (Input.GetMouseButtonDown(0)) tokotoko.SetActive(false);
        des =slider.value;
        if (IsTouch)
        {
            if (poss.Count == 0)
            {
                tokotoko.SetActive(false);
                allGetObj.SetActive(true);
            }
            for(int i = 0; i < poss.Count; i++)
            {
                float x = Vector3.Distance(target.transform.position, poss[i].position);
                if (x <= des)
                {
                    Vibration.Vibrate(500);
                    if (!engage.activeSelf) engage.SetActive(true);
                    scene = poss[i].GetComponent<SceneChangeName>().GetSceneName();
                    TapSound.SceneNum = poss[i].GetComponent<SceneChangeName>().GetSceneNumber();
                    nums = poss[i].GetComponent<SceneChangeName>();
                    break;
                    //SceneManager.LoadScene("ARScene");
                    //ç≠ê’çÃéÊâÊñ Ç÷ÇÃëJà⁄

                    StaticObjPotiosion.mes = x.ToString() + "dis" + des.ToString();
                }
                else if (engage.activeSelf) {
                    if(engage.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime<1)
                    engage.SetActive(false);

                }

            }

        }
    }
    public void KonsekiDestroy()
    {
                Destroy(nums.gameObject);
        poss.Remove(nums.gameObject.transform);

    }
    public void GetData(GameObject obj)
    {
       target = obj;
        IsTouch = true;
    }

    public void GetKonsekiDestroy()
    {
        for (int i = 0; i < poss.Count; i++)
        {
            for (int y=0; StaticObjPotiosion.GetKonsekiNumber.Count>y; y++) {

                if (StaticObjPotiosion.GetKonsekiNumber[y] == poss[i].gameObject.GetComponent<SceneChangeName>().GetSceneNumber())
                {
                    Destroy(poss[i].gameObject);
                    poss.Remove(poss[i]);
                }
            }
        }

    }
    public void ChangeScene() => SceneManagerScript.instance.Load(scene);

    public void SetIsget(bool x)=>isGet = x;
}

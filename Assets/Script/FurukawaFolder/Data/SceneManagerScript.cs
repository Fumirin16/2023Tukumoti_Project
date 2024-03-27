using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneManagerScript 
{
    public static SceneManagerScript instance =new SceneManagerScript();
    public enum SceneName
    {
        ARScene, AttentionScene, GetScene, GPSScene, natukaseScene, OptionScene, SampleScene,TitleScene
    }
    public void Load(string name)
    {
       SceneManager.LoadScene(name);
    }

    public void Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

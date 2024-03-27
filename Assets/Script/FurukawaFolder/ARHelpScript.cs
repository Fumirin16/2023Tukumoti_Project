using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARHelpScript : MonoBehaviour
{
    [SerializeField] Animator anima;
    [SerializeField] string AnimaName;

    public void InHelp()
    {
        anima.Play(AnimaName);
    }
}
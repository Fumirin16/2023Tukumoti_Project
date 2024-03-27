using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayUIAnimation : MonoBehaviour
{
    [SerializeField] string animationName;
    [SerializeField] Animator anima;
    [SerializeField] bool onPointerUse;
    private GameObject animaUI;
    private bool onPointer;
    void Start()
    {
        animaUI = anima.gameObject;
        animaUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (onPointerUse && Input.GetMouseButtonDown(0) && onPointer)
        {
            //IsTouch();
            UISetActive(false);
        }

    }

    public void IsTouch()
    {
        anima.Play(animationName);
    }
    public void UISetActive(bool x)
    {
        animaUI.SetActive(x);
    }
    public void OnPointer(bool x)
    {
        onPointer = x;
    }
    public void PointerAnima(bool x)
    {
        if (x == onPointer)
        {
            anima.Play(animationName);
        }
    }
    public void PointerSetObj(bool x)
    {
        if (x == onPointer)
        {
            animaUI.SetActive(true);
        }
    }
    public void setOBJ() => this.gameObject.SetActive(false);
}

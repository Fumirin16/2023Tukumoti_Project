using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadcCunter
{
    public static ReloadcCunter Instance =new ReloadcCunter();
    float time;
    float Cunter;
    bool move;
    Vector2 movePos=new Vector2(0,0);
    public void SetCunter(float x) =>Cunter = x;
    public float GetCunter() =>Cunter;
    public void ResetTime() => time = 0;
    public void PlusTime(float x) => time += x;
    public bool IsCunter() => time > Cunter;
    public bool IsMove() => move;
    public void SetMove(bool a) => move = a;
    public Vector2 GetMovePos() => movePos;
    public void SetMovePos(Vector3 x) => movePos = x;
    public float GetTime() => time;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TukumoPointManager : MonoBehaviour
{

    void Start()
    {
        int a = 0;

        if (StaticObjPotiosion.objs.Count < transform.childCount)
        {
            foreach (Transform child in transform)
            {
                StaticObjPotiosion.objs.Add(child.gameObject);
                StaticObjPotiosion.transforms.Add(child.transform.localPosition);
                a++;

            }

        }
        else
        {
            StaticObjPotiosion.objs.Clear();
            foreach (Transform child in transform)
            {
                StaticObjPotiosion.objs.Add(child.gameObject);
            }
            for (int i = 0; i < StaticObjPotiosion.objs.Count; i++)
            {
                StaticObjPotiosion.objs[i].transform.localPosition = StaticObjPotiosion.transforms[i];

            }
        }
        //StaticObjPotiosion.mes = StaticObjPotiosion.objs[0].transform.position.ToString() + "local\n" + StaticObjPotiosion.objs[0].transform.localPosition.ToString();

    }
    private void Update()
    {

        for (int i = 0; i < StaticObjPotiosion.objs.Count; i++)
        {
            StaticObjPotiosion.transforms[i] = StaticObjPotiosion.objs[i].transform.localPosition;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CharacterGenerator : MonoBehaviour
{
    static Datas[] data;
    
    public static void GenerateCharacter(Object player, bool canAnimate, bool wantCamera)
    {
        data = Resources.FindObjectsOfTypeAll<Datas>();
        Datas tempData=data[0];
        if (player)
        {
            GameObject temp = Instantiate((GameObject)player);
            temp.transform.position = Vector3.zero;
            temp.AddComponent<PlayerMovement>();
            if (canAnimate)
            {
                if (!temp.GetComponent<Animator>())
                {
                    temp.AddComponent<Animator>();
                    temp.GetComponent<Animator>().runtimeAnimatorController = tempData.anim;
                }
                else
                {
                    temp.GetComponent<Animator>().runtimeAnimatorController = tempData.anim;
                }
            }
            if (wantCamera)
            {
                Camera cam = Instantiate(tempData.chasingCamera);
            }
        }


    }
}

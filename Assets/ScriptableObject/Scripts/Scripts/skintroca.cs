using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skintroca : MonoBehaviour
{
    public AnimatorOverrideController Move1;
    public AnimatorOverrideController Move2;
    public AnimatorOverrideController Move3;
    public AnimatorOverrideController Move4;
    public AnimatorOverrideController Move5;

    [SerializeField]
    private escolhaskin skinstatus;



    private enum escolhaskin
    {
        Primskin,
        Segskin,
        Tercskin,
        Quarskin,
        Quinskin

    }

    private void Start()
    {
        if (skinstatus == escolhaskin.Primskin)
            GetComponent<Animator>().runtimeAnimatorController = Move1 as RuntimeAnimatorController;
        if (skinstatus == escolhaskin.Segskin)
            GetComponent<Animator>().runtimeAnimatorController = Move2 as RuntimeAnimatorController;
        if (skinstatus == escolhaskin.Tercskin)
            GetComponent<Animator>().runtimeAnimatorController = Move3 as RuntimeAnimatorController;
        if (skinstatus == escolhaskin.Quarskin)
            GetComponent<Animator>().runtimeAnimatorController = Move4 as RuntimeAnimatorController;
        if (skinstatus == escolhaskin.Quinskin)
            GetComponent<Animator>().runtimeAnimatorController = Move5 as RuntimeAnimatorController;


    }

    

    

    

}

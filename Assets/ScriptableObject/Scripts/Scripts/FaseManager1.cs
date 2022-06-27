using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaseManager1 : MonoBehaviour
{
    [SerializeField]
    NPCorredorController[] NPCList;
    
    

    private void Start()
    {

        NPCList[0].OnomoFase1();

        NPCList[1].OnomoFase1();

        NPCList[2].OnomoFase1();

        NPCList[3].OnomoFase1();

        NPCList[4].OnomoFase1();
        
    }
}

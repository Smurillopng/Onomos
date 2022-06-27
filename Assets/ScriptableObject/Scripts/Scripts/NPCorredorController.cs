using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCorredorController : MonoBehaviour
{
    public GameObject objeto;
    public GameObject final;

    public GameObject[] NPCList;
    private int characternum;

    //Se leu é gay
    public void OnomoFase1()
    {

        characternum = PlayerPrefs.GetInt("CharacterSelected");

        //botao1 = new Button[botoes.transform.childCount];
        NPCList = new GameObject[transform.childCount];

        //coloca os modelo na lista
        for (int i = 0; i < transform.childCount; i++)
        {
            NPCList[i] = transform.GetChild(i).gameObject;
        }




        //Desliga o GameObject
        foreach (GameObject go in NPCList)
        {
            go.SetActive(false);
        }

        characternum = Random.Range(0, NPCList.Length);
        //liga o GameObject
        NPCList[characternum].SetActive(true);




    }
    public void OnDrawGizmos()
    {
        Gizmos.DrawLine(objeto.transform.position, final.transform.position);

    }


}

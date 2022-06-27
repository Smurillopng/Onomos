using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Corrida/Fase/OnomosFase", fileName = "OnomosFase")]
public class PistaProperties : ScriptableObject
{
    public List<GameObject> onomos;
    GameObject onomosReserva;
    

    public void GetPlayer(GameObject Comprado,int qual)
    {
        onomos[qual] = Comprado;
    }

    public GameObject GetOnomos(int replay)
    {

        
        int ramdom = Random.Range(0, onomos.Count - replay);
        GameObject onomo = onomos[ramdom];



            

        onomosReserva = onomos[ramdom];
        onomos[ramdom] = onomos[onomos.Count - replay];
        onomos[onomos.Count - replay] = onomosReserva;

        return onomo;

        
        
    }

    public GameObject GetCorredores(int replay)
    {
        GameObject onomo = onomos[replay];



            

        

        return onomo;

        
        
    }
    public void VamosCorrer(GameObject corredor,int qual)
    {
        onomos[qual] = corredor;
    }

    public bool Repetido(GameObject Comprado, int qual)
    {
        if(onomos[qual] == Comprado)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void GetEscolha(GameObject player, int qual)
    {
        player.GetComponent<SpriteRenderer>().sprite = onomos[qual].GetComponent<SpriteRenderer>().sprite;
        player.GetComponent<carroeng1>().velomax = onomos[qual].GetComponent<carroeng1>().velomax;
        player.GetComponent<carroeng1>().velomin = onomos[qual].GetComponent<carroeng1>().velomin;
        player.GetComponent<BoxCollider2D>().offset = onomos[qual].GetComponent<BoxCollider2D>().offset;
        player.GetComponent<BoxCollider2D>().size = onomos[qual].GetComponent<BoxCollider2D>().size;
        player.GetComponent<Animator>().runtimeAnimatorController = onomos[qual].GetComponent<Animator>().runtimeAnimatorController;
        player.GetComponent<OnomoStatus>().ID = onomos[qual].GetComponent<OnomoStatus>().ID;
        //player.GetComponent<OnomoStatus>().popularidade = onomos[qual].GetComponent<OnomoStatus>().popularidade;
        

    }

     public void zeratudo()
    {
        for(int i=0; i<onomos.Count; i++)
        {
            onomos[i] = null;

        }
        
    }

    

    
}

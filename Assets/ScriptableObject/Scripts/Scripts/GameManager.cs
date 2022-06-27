using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Cinemachine;

public class GameManager : MonoBehaviour
{
    public int totalMoney = 100;
    public Text text;
    public List<PistaProperties> onomosFase;

    public int FASE;
    public PolygonCollider2D PeraFase1;

    public PolygonCollider2D PeraFase2;

    public PolygonCollider2D PeraFase3;


    public CinemachineConfiner Area;

    CinemachineVirtualCamera CameraLimite; 

    

    public GameObject faicha;

    public PistaProperties playerOnomos;

    public GameObject[] fases;

    public Sprite premio1;

    public Sprite premio2;

    public Sprite premio3;

    public Image lugar1;

    public Image lugar2;

    public Image lugar3;










     private void Start()
     {
        Area.m_BoundingShape2D = PeraFase1;
        FASE = 1;
        playerOnomos.zeratudo();
        faicha.GetComponent<BoxCollider2D>().offset = new Vector2(16.7f, -0.07242775f);
        

     }
    private void Update()
    {
        
        text.text = totalMoney.ToString() + "ml";

        

        if (totalMoney <= 0)
        {
            
            FASE=0;

        }

       

        


       
        
           
       

       

       

        
    }

    public void faseDev(int fase)
    {
        FASE = fase;
    }
    

    public PistaProperties GetOnomos()
    {
        return onomosFase[FASE - 1];
    }
    
    public void ChecaFase()
    {
        if(totalMoney >= 6000 && FASE != 3)
        {
            
            FASE = 2;
            Debug.Log("GameManager "+ FASE);
            Area.m_BoundingShape2D = PeraFase2;
            faicha.GetComponent<BoxCollider2D>().offset = new Vector2(35.9f, -0.07242775f);

            fases[0].SetActive(false);
            fases[1].SetActive(true);
            fases[2].SetActive(false);

            lugar1.sprite = premio1;

        }

        if(totalMoney >= 20000)
        {

            FASE = 3;
            Area.m_BoundingShape2D = PeraFase3;
            faicha.GetComponent<BoxCollider2D>().offset = new Vector2(45.5f, -0.07242775f);
            fases[0].SetActive(false);
            fases[1].SetActive(false);
            fases[2].SetActive(true);

            lugar2.sprite = premio2;

        }

        if(totalMoney >= 100000)
        {

            lugar3.sprite = premio3;

        }

    }
    public void CoemcarJogo()
    {
        SceneManager.LoadScene(1);

    }

    public void tuturial()
    {
        SceneManager.LoadScene(3);

    }

    public void telainicial()
    {
        SceneManager.LoadScene(0);

    }

    //Button

}
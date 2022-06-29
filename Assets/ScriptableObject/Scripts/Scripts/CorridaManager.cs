using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class CorridaManager : MonoBehaviour
{
    // Start is called before the first frame update
    

   
    public GameManager gm;
    public PreCorridaManager PreCorrida;

    public StageProperties Corredores;

    public ApostaManager Aposta;


    public int lugar = 0;

    public int faseAtual = 0;
    public int replay;

    float VeloMax;
    float VeloMin;

    public int DezdeDez;
    public Pista[] pistas;

    public Text text;
    public Text negação;

    public bool iniciarCooldown;

    

    public GameObject player;
    public GameObject playerpista;
    public GameObject Spawnpointplayer;

    
    public int Randy;
    
    public int betMoney;

    public int FaseAtual;
    public float cooldown = 5;

    public Image[] imagemvenc;

    public Button[] AtivarPowerUp;

    

    StageProperties listOnomos;
    private Vector2 vPlayer;
    private Vector2 pista1;
    private Vector2 pista2;
    private Vector2 pista3;
    private Vector2 pista4;
    private Vector2 pista5;
    private Vector2 pista6;

    public Animator MenoZero;
    public Animator Barani;

    public Animator Habilina;

   public float time; 

   public GameObject Bar;

   public GameObject livro;

   public bool confirmadorAnima = true;

   public Habilidades HABI;

   

   public GameObject Canvascorrida;

   public int PistaArray;

   public GameObject apostadomostra;

   public GameObject[] corredor;

   public GameObject[] SpawnpointNPC;


   public float[] VeloMxRE;
   public float[] VeloMnRE;




    void Start()
    {
        player.SetActive(false);
       
        corredor[0].SetActive(false);
        corredor[1].SetActive(false);
        corredor[2].SetActive(false);
        corredor[3].SetActive(false);
        corredor[4].SetActive(false);

        Canvascorrida.SetActive(false);
        vPlayer = player.transform.position;
        listOnomos = gm.GetOnomos();
        player.GetComponentInChildren<SpriteRenderer>().sortingOrder = 150;
        player.GetComponentInChildren<OnomoStatus>().pista = 6;
        player.tag = "pista6"; 


        
        
        
        

           
        
    }
    
    

    // Update is called once per frame
    void FixedUpdate()
    {
       betMoney = Aposta.betMoney;
          
       pista1 = corredor[0].transform.position;
      
       //Debug.Log(pista1.x);
       pista2 =  corredor[1].transform.position;
       //Debug.Log(pista2.x);
       pista3 = corredor[2].transform.position;
       //Debug.Log(pista3.x);
       pista4 = pistas[3].onomo.transform.position;
       //Debug.Log(pista4.x);
       pista5 = corredor[4].transform.position;
       //Debug.Log(pista5.x);
       pista6 = playerpista.transform.position;
       //Debug.Log(pista6.x);
       //Debug.Log(pista1.x, pista2.x, pista3.x, pista4.x,pista5.x, pista6.x);



       


        

        /*if(iniciarCooldown == true){
            Habilina.SetTrigger("timerhabi");

            if(cooldown > 0){
            cooldown -= Time.deltaTime;
            AtivarPowerUp[0].interactable = false;
        }
        else{
            AtivarPowerUp[0].interactable = true;
            cooldown = 5;
            iniciarCooldown = false;
            
        }
        }*/
       
        

       

       }

       public void Executarint(int array)
       {

         PistaArray = array;

       }


        public void  finalizarCoolDown()
        {
            
            Habilina.SetTrigger("voltaencher");
            AtivarPowerUp[0].interactable = true;
            
        }
       
       

      public void BotãoColocar()
      {
        /*listOnomos = gm.GetOnomos(faseAtual);
        player.GetComponentInChildren<SpriteRenderer>().sortingOrder = 50;
        player.GetComponent<OnomoStatus>().pista = 6;
        player.tag = "pista6";*/
        
        replay = 0;

        HabilidadesNulas();
        
        

        


       
        
        
       


             
        if(betMoney != 0 && PreCorrida.Apostadonumero >= 1 && PreCorrida.Apostadonumero <= 6 && Aposta.chooseBet != 3)
        {
            Aposta.confirm = false;


        player.SetActive(true); // <---------------------------------
        corredor[0].SetActive(true);
        corredor[1].SetActive(true);
        corredor[2].SetActive(true);
        corredor[3].SetActive(true);
        corredor[4].SetActive(true);
        

        Canvascorrida.SetActive(true);

        AtivarPowerUp[0].interactable = false;
        Invoke(nameof(finalizarCoolDown), 5.0f);
            
        
        Habilina.SetTrigger("timerhabi");

        VeloMax = player.GetComponentInChildren<carroeng1>().veloMax;
        VeloMin = player.GetComponentInChildren<carroeng1>().veloMin;

        //player.GetComponentInChildren<carroeng1>().velomax = 0;
        //player.GetComponentInChildren<carroeng1>().velomin = 0;

        VeloMxRE[0] = corredor[0].GetComponent<carroeng1>().veloMax;
        VeloMnRE[0] = corredor[0].GetComponent<carroeng1>().veloMin;

        corredor[0].GetComponent<carroeng1>().veloMax = 0;
        corredor[0].GetComponent<carroeng1>().veloMin = 0;
        
        VeloMxRE[1] = corredor[1].GetComponent<carroeng1>().veloMax;
        VeloMnRE[1] = corredor[1].GetComponent<carroeng1>().veloMin;

        corredor[1].GetComponent<carroeng1>().veloMax = 0;
        corredor[1].GetComponent<carroeng1>().veloMin = 0;
        
        VeloMxRE[2] = corredor[2].GetComponent<carroeng1>().veloMax;
        VeloMnRE[2] = corredor[2].GetComponent<carroeng1>().veloMin;

        corredor[2].GetComponent<carroeng1>().veloMax = 0;
        corredor[2].GetComponent<carroeng1>().veloMin = 0;
        
        VeloMxRE[3] = corredor[3].GetComponent<carroeng1>().veloMax;
        VeloMnRE[3] = corredor[3].GetComponent<carroeng1>().veloMin;

        corredor[3].GetComponent<carroeng1>().veloMax = 0;
        corredor[3].GetComponent<carroeng1>().veloMin = 0;

        VeloMxRE[4] = corredor[4].GetComponent<carroeng1>().veloMax;
        VeloMnRE[4] = corredor[4].GetComponent<carroeng1>().veloMin;

        corredor[4].GetComponent<carroeng1>().veloMax = 0;
        corredor[4].GetComponent<carroeng1>().veloMin = 0;

      
        
        MenoZero.SetTrigger("IrPraCorrida");
        Bar.SetActive(false);
        livro.SetActive(false);
        

       

        StartCoroutine(Timer());
        //player.GetComponentInChildren<carroeng1>(true);

       



        
        

        
        
        Randy = PreCorrida.randy;
          
          foreach (Pista p in pistas)
           {
               
            
            GameObject onomo = PreCorrida.pistas[replay].onomo;
            
            //GameObject instanceOnomo = Instantiate(onomo, p.NPCSpawnPoint.transform.position, Quaternion.identity, p.NPCSpawnPoint.transform);

            //p.onomo = instanceOnomo;

            corredor[replay].GetComponent<SpriteRenderer>().sprite =  p.onomo.GetComponent<SpriteRenderer>().sprite;
            corredor[replay].GetComponent<carroeng1>().veloMax = p.onomo.GetComponent<carroeng1>().veloMax;
            corredor[replay].GetComponent<carroeng1>().veloMin =  p.onomo.GetComponent<carroeng1>().veloMin;
            corredor[replay].GetComponent<BoxCollider2D>().offset  =  p.onomo.GetComponent<BoxCollider2D>().offset;
            corredor[replay].GetComponent<BoxCollider2D>().size =  p.onomo.GetComponent<BoxCollider2D>().size;
            corredor[replay].GetComponent<Animator>().runtimeAnimatorController =  p.onomo.GetComponent<Animator>().runtimeAnimatorController;
            corredor[replay].GetComponent<OnomoStatus>().ID =  p.onomo.GetComponent<OnomoStatus>().ID;


            




            
            
            /*if(replay == 1)
            {
            
            corredor[0].GetComponent<carroeng1>().botãoashabiinvo[0] = AtivarPowerUp[0];
             
            }
            if(replay == 2)
            {
            
             corredor[1].GetComponent<carroeng1>().botãoashabiinvo[0] = AtivarPowerUp[0];
             
            }
            if(replay == 3)
            {
            
            corredor[2].GetComponent<carroeng1>().botãoashabiinvo[0] = AtivarPowerUp[0];
             
            }   
            if(replay == 4)
            {
            
            pistas[3].onomo.GetComponent<carroeng1>().botãoashabiinvo[0] = AtivarPowerUp[0];
             
            }
            if(replay == 5)
            {
        
            corredor[4].GetComponent<carroeng1>().botãoashabiinvo[0] = AtivarPowerUp[0];
             
            }*/

            
            
            replay++;
            //DezdeDez=DezdeDez+10;
           }


           

          
           
        
           

         /*if (Randy != 5)
        {
            player.GetComponentInChildren<SpriteRenderer>().sortingOrder = pistas[Randy].GetComponentInChildren<SpriteRenderer>().sortingOrder;
            pistas[Randy].GetComponentInChildren<SpriteRenderer>().sortingOrder = 50;

            player.transform.position = pistas[Randy].transform.position;
            pistas[Randy].transform.position = vPlayer;

            player.tag = pistas[Randy].onomo.tag;
            pistas[Randy].onomo.tag = "pista6";

            pistas[Randy].onomo.GetComponent<OnomoStatus>().pista = player.GetComponent<OnomoStatus>().pista;
            pistas[Randy].onomo.GetComponent<OnomoStatus>().pista = 6;

            
            

        }
        if (Randy == 5)
        {
            player.transform.position = vPlayer;
            
        }*/
        
       // for(int i = 0; i<1; i++)
       //{
           

        TimerPlayer();
        //player.GetComponentInChildren<carroeng1>(true);



        if(gm.level == 2)
            {
             corredor[0].GetComponent<carroeng1>().veloMax =  4;
             corredor[0].GetComponent<carroeng1>().veloMin =  0.61f;


             corredor[1].GetComponent<carroeng1>().veloMax =  4;
             corredor[1].GetComponent<carroeng1>().veloMin =  0.61f;



             corredor[2].GetComponent<carroeng1>().veloMax =  4;
             corredor[2].GetComponent<carroeng1>().veloMin =  0.61f;



             corredor[3].GetComponent<carroeng1>().veloMax =  4;
             corredor[3].GetComponent<carroeng1>().veloMin =  0.61f;



             corredor[4].GetComponent<carroeng1>().veloMax =  4;
             corredor[4].GetComponent<carroeng1>().veloMin =  0.61f;

            }

            if(gm.level == 3)
            {
             
             corredor[0].GetComponent<carroeng1>().veloMax =  5;
             corredor[0].GetComponent<carroeng1>().veloMin =  0.61f;


             corredor[1].GetComponent<carroeng1>().veloMax =  5;
             corredor[1].GetComponent<carroeng1>().veloMin =  0.61f;



             corredor[2].GetComponent<carroeng1>().veloMax =  5;
             corredor[2].GetComponent<carroeng1>().veloMin =  0.61f;



             corredor[3].GetComponent<carroeng1>().veloMax =  5;
             corredor[3].GetComponent<carroeng1>().veloMin =  0.61f;



             corredor[4].GetComponent<carroeng1>().veloMax =  5;
             corredor[4].GetComponent<carroeng1>().veloMin =  0.61f;

            }


        

       //}

        
        }
        else if (betMoney == 0)
        {
            MenoZero.SetTrigger("NãoPode");
            negação.text = "Para apostar tem que ser acima de 0";
            Debug.Log("Tem que colocar algo acima de 0");
        } 
        else if (PreCorrida.Apostadonumero < 1 || PreCorrida.Apostadonumero > 6)
        {
            MenoZero.SetTrigger("NãoPode");
            negação.text = "Para apostar tem que escolher um corredor";
            Debug.Log("Tem que colocar algo acima de 0");
        }
        else if (Aposta.chooseBet == 3)
        {
            MenoZero.SetTrigger("NãoPode");
            negação.text = "Voce tem que escolher um tipo de aposta primeiro";
            Debug.Log("Tem que colocar algo acima de 0");
        }




        

         
          

      }

      IEnumerator Timer()
        {
        print(Time.time);

    
        
           //yield return new WaitForSecondsRealtime(1);
            text.text = "3";
            MenoZero.SetTrigger("321...vai");
           
            

            yield return new WaitForSecondsRealtime(1);
            text.text = "2";

            MenoZero.SetTrigger("321...vai");

            
            text.text = "1";

            MenoZero.SetTrigger("321...vai");
            
            
            yield return new WaitForSecondsRealtime(1);
            text.text = "Vai!!!";

            MenoZero.SetTrigger("corrida");
            Time.timeScale = 1f;

           
            
    
        }

        public void TimerPlayer()
        {
         //yield return new WaitForSecondsRealtime(5);
        Time.timeScale = 0.01f;
         player.GetComponentInChildren<carroeng1>().veloMax = VeloMax;
         player.GetComponentInChildren<carroeng1>().veloMin = VeloMin;
         corredor[0].GetComponentInChildren<carroeng1>().veloMax = VeloMxRE[0];
         corredor[0].GetComponentInChildren<carroeng1>().veloMin = VeloMnRE[0];
         corredor[1].GetComponent<carroeng1>().veloMax = VeloMxRE[1];
         corredor[1].GetComponent<carroeng1>().veloMin = VeloMnRE[1];
         corredor[2].GetComponent<carroeng1>().veloMax = VeloMxRE[2];
         corredor[2].GetComponent<carroeng1>().veloMin = VeloMnRE[2];
         corredor[3].GetComponent<carroeng1>().veloMax = VeloMxRE[3];
         corredor[3].GetComponent<carroeng1>().veloMin = VeloMnRE[3];
         corredor[4].GetComponent<carroeng1>().veloMax = VeloMxRE[4];
         corredor[4].GetComponent<carroeng1>().veloMin = VeloMnRE[4];





           
            
    
        }

        public void HabilidadesNulas()
        {
            Debug.Log("Oi");
            //Colorida so pode 
            if(player.GetComponentInChildren<OnomoStatus>().ID == "C010r1d0")
            {
                Debug.Log("Oii");
                for(int i = 0; i < 5; i++)
                {Debug.Log("I9");
                   if(pistas[i].onomo.GetComponentInChildren<OnomoStatus>().ID != "4zu1" && pistas[i].onomo.GetComponentInChildren<OnomoStatus>().ID != "r0x0" && pistas[i].onomo.GetComponentInChildren<OnomoStatus>().ID != "v3rd3" && pistas[i].onomo.GetComponentInChildren<OnomoStatus>().ID != "v3rm3lh0" && pistas[i].onomo.GetComponentInChildren<OnomoStatus>().ID != "C010r1d0")
                   {
                       Debug.Log("I");
                    corredor[i].GetComponentInChildren<OnomoStatus>().BPista.interactable = false;
                   // corredor[3].GetComponent<OnomoStatus>().BPista.interactable = false;

                   }
                }

            }

            //Balanço de cores

            //Azul
            if(player.GetComponentInChildren<OnomoStatus>().ID == "4zu1")
            {
                for(int i = 0; i < 5; i++)
                {
                   if(pistas[i].onomo.GetComponentInChildren<OnomoStatus>().ID != "v3rm3lh0")
                   {

                    corredor[i].GetComponentInChildren<OnomoStatus>().BPista.interactable = false;

                   }
                }

            }

            //vermelho
            if(player.GetComponentInChildren<OnomoStatus>().ID == "v3rm3lh0")
            {
                for(int i = 0; i < 5; i++)
                {
                   if(pistas[i].onomo.GetComponentInChildren<OnomoStatus>().ID != "v3rd3")
                   {

                    corredor[i].GetComponentInChildren<OnomoStatus>().BPista.interactable = false;

                   }
                }

            }

            //Verde
            if(player.GetComponentInChildren<OnomoStatus>().ID == "v3rd3")
            {
                for(int i = 0; i < 5; i++)
                {
                   if(pistas[i].onomo.GetComponentInChildren<OnomoStatus>().ID != "r0x0")
                   {

                    corredor[i].GetComponentInChildren<OnomoStatus>().BPista.interactable = false;

                   }
                }

            }

            //Roxo
            if(player.GetComponentInChildren<OnomoStatus>().ID == "r0x0")
            {
                for(int i = 0; i < 5; i++)
                {
                   if(pistas[i].onomo.GetComponentInChildren<OnomoStatus>().ID != "4zu1")
                   {

                    corredor[i].GetComponentInChildren<OnomoStatus>().BPista.interactable = false;

                   }
                }

            }








            //Anula caveira vermelha
            if(player.GetComponentInChildren<OnomoStatus>().ID == "cav31r4")
            {
                player.GetComponentInChildren<OnomoStatus>().BPista.interactable = false;
                for(int i = 0; i < 5; i++)
                {
                   if(pistas[i].onomo.GetComponentInChildren<OnomoStatus>().ID == "cav31r4" || pistas[i].onomo.GetComponentInChildren<OnomoStatus>().ID == "p1ch3" || pistas[i].onomo.GetComponentInChildren<OnomoStatus>().ID == "t3rr0r")
                   {

                    corredor[i].GetComponentInChildren<OnomoStatus>().BPista.interactable = false;

                   }
                }

            }

            //Anula caveirinha
            if(player.GetComponentInChildren<OnomoStatus>().ID == "c4v31r1nha")
            {
                player.GetComponentInChildren<OnomoStatus>().BPista.interactable = false;
                for(int i = 0; i < 5; i++)
                {
                   if(pistas[i].onomo.GetComponentInChildren<OnomoStatus>().ID == "cav31r4" || pistas[i].onomo.GetComponentInChildren<OnomoStatus>().ID == "p1ch3" || pistas[i].onomo.GetComponentInChildren<OnomoStatus>().ID == "t3rr0r")
                   {

                    corredor[i].GetComponentInChildren<OnomoStatus>().BPista.interactable = false;

                   }
                }

            }

            //Anula fogo
            if(player.GetComponentInChildren<OnomoStatus>().ID == "f0g0")
            {
                player.GetComponentInChildren<OnomoStatus>().BPista.interactable = false;
                for(int i = 0; i < 5; i++)
                {
                   if(pistas[i].onomo.GetComponentInChildren<OnomoStatus>().ID == "f0g0" || pistas[i].onomo.GetComponentInChildren<OnomoStatus>().ID == "greg0" || pistas[i].onomo.GetComponentInChildren<OnomoStatus>().ID == "l4v4" || pistas[i].onomo.GetComponentInChildren<OnomoStatus>().ID == "gel0")
                   {

                    corredor[i].GetComponentInChildren<OnomoStatus>().BPista.interactable = false;

                   }
                }

            }

            //Anula fogo grego
            if(player.GetComponentInChildren<OnomoStatus>().ID == "greg0")
            {
                player.GetComponentInChildren<OnomoStatus>().BPista.interactable = false;
                for(int i = 0; i < 5; i++)
                {
                   if(pistas[i].onomo.GetComponentInChildren<OnomoStatus>().ID == "f0g0" || pistas[i].onomo.GetComponentInChildren<OnomoStatus>().ID == "greg0" || pistas[i].onomo.GetComponentInChildren<OnomoStatus>().ID == "l4v4" || pistas[i].onomo.GetComponentInChildren<OnomoStatus>().ID == "gel0")
                   {

                    corredor[i].GetComponentInChildren<OnomoStatus>().BPista.interactable = false;

                   }
                }

            }

            //Anula eletrico
            if(player.GetComponentInChildren<OnomoStatus>().ID == "l3tric0")
            {
                player.GetComponentInChildren<OnomoStatus>().BPista.interactable = false;
                for(int i = 0; i < 5; i++)
                {
                   if(pistas[i].onomo.GetComponentInChildren<OnomoStatus>().ID == "l3tric0" || pistas[i].onomo.GetComponentInChildren<OnomoStatus>().ID == "gel0" || pistas[i].onomo.GetComponentInChildren<OnomoStatus>().ID == "pedr4")
                   {

                    corredor[i].GetComponentInChildren<OnomoStatus>().BPista.interactable = false;

                   }
                }

            }

            //Anula lula
            if(player.GetComponentInChildren<OnomoStatus>().ID == "lul0")
            {
                player.GetComponentInChildren<OnomoStatus>().BPista.interactable = false;
                for(int i = 0; i < 5; i++)
                {
                   if(pistas[i].onomo.GetComponentInChildren<OnomoStatus>().ID == "l3tric0" || pistas[i].onomo.GetComponentInChildren<OnomoStatus>().ID == "gel0" || pistas[i].onomo.GetComponentInChildren<OnomoStatus>().ID == "pedr4")
                   {

                    corredor[i].GetComponentInChildren<OnomoStatus>().BPista.interactable = false;

                   }
                }

            }
            
            //Anula melo
            if(player.GetComponentInChildren<OnomoStatus>().ID == "melo")
            {
                player.GetComponentInChildren<OnomoStatus>().BPista.interactable = false;
                for(int i = 0; i < 5; i++)
                {
                   if(pistas[i].onomo.GetComponentInChildren<OnomoStatus>().ID == "melo" || pistas[i].onomo.GetComponentInChildren<OnomoStatus>().ID == "melor0m" || pistas[i].onomo.GetComponentInChildren<OnomoStatus>().ID == "f0g0" || pistas[i].onomo.GetComponentInChildren<OnomoStatus>().ID == "l4v4" || pistas[i].onomo.GetComponentInChildren<OnomoStatus>().ID == "greg0")
                   {

                    corredor[i].GetComponentInChildren<OnomoStatus>().BPista.interactable = false;

                   }
                }

            }

            //Anula melor0m
            if(player.GetComponentInChildren<OnomoStatus>().ID == "melor0m")
            {
                player.GetComponentInChildren<OnomoStatus>().BPista.interactable = false;
                for(int i = 0; i < 5; i++)
                {
                   if(pistas[i].onomo.GetComponentInChildren<OnomoStatus>().ID == "melo" || pistas[i].onomo.GetComponentInChildren<OnomoStatus>().ID == "melor0m" || pistas[i].onomo.GetComponentInChildren<OnomoStatus>().ID == "f0g0" || pistas[i].onomo.GetComponentInChildren<OnomoStatus>().ID == "l4v4" || pistas[i].onomo.GetComponentInChildren<OnomoStatus>().ID == "greg0")
                   {

                    corredor[i].GetComponentInChildren<OnomoStatus>().BPista.interactable = false;

                   }
                }

            }

            //Anula pedra
            if(player.GetComponentInChildren<OnomoStatus>().ID == "pedr4")
            {
                player.GetComponentInChildren<OnomoStatus>().BPista.interactable = false;
                for(int i = 0; i < 5; i++)
                {
                   if(pistas[i].onomo.GetComponentInChildren<OnomoStatus>().ID == "l3tric0" || pistas[i].onomo.GetComponentInChildren<OnomoStatus>().ID == "gel0" || pistas[i].onomo.GetComponentInChildren<OnomoStatus>().ID == "pedr4")
                   {

                    corredor[i].GetComponentInChildren<OnomoStatus>().BPista.interactable = false;

                   }
                }

            }

            //Anula gelo
            if(player.GetComponentInChildren<OnomoStatus>().ID == "gel0")
            {
                player.GetComponentInChildren<OnomoStatus>().BPista.interactable = false;
                for(int i = 0; i < 5; i++)
                {
                   if(pistas[i].onomo.GetComponentInChildren<OnomoStatus>().ID == "l3tric0" || pistas[i].onomo.GetComponentInChildren<OnomoStatus>().ID == "gel0" || pistas[i].onomo.GetComponentInChildren<OnomoStatus>().ID == "pedr4")
                   {

                    corredor[i].GetComponentInChildren<OnomoStatus>().BPista.interactable = false;

                   }
                }

            }

            //Anula Bola
            if(player.GetComponentInChildren<OnomoStatus>().ID == "3014")
            {
                player.GetComponentInChildren<OnomoStatus>().BPista.interactable = false;
                for(int i = 0; i < 5; i++)
                {
                   if(pistas[i].onomo.GetComponentInChildren<OnomoStatus>().ID == "3014" || pistas[i].onomo.GetComponentInChildren<OnomoStatus>().ID == "f00tball" || pistas[i].onomo.GetComponentInChildren<OnomoStatus>().ID == "pr4ia")
                   {

                    corredor[i].GetComponentInChildren<OnomoStatus>().BPista.interactable = false;

                   }
                }

            }

            //Anula Footbola
            if(player.GetComponentInChildren<OnomoStatus>().ID == "f00tball")
            {
                player.GetComponentInChildren<OnomoStatus>().BPista.interactable = false;
                for(int i = 0; i < 5; i++)
                {
                   if(pistas[i].onomo.GetComponentInChildren<OnomoStatus>().ID == "3014" || pistas[i].onomo.GetComponentInChildren<OnomoStatus>().ID == "f00tball" || pistas[i].onomo.GetComponentInChildren<OnomoStatus>().ID == "pr4ia")
                   {

                    corredor[i].GetComponentInChildren<OnomoStatus>().BPista.interactable = false;

                   }
                }

            }

            //Anula praiabola
            if(player.GetComponentInChildren<OnomoStatus>().ID == "pr4ia")
            {
                player.GetComponentInChildren<OnomoStatus>().BPista.interactable = false;
                for(int i = 0; i < 5; i++)
                {
                   if(pistas[i].onomo.GetComponentInChildren<OnomoStatus>().ID == "3014" || pistas[i].onomo.GetComponentInChildren<OnomoStatus>().ID == "f00tball" || corredor[i].GetComponentInChildren<OnomoStatus>().ID == "pr4ia")
                   {

                    corredor[i].GetComponentInChildren<OnomoStatus>().BPista.interactable = false;

                   }
                }

            }

            //Anula mariomelo
            if(player.GetComponentInChildren<OnomoStatus>().ID == "m4ri0")
            {
                player.GetComponentInChildren<OnomoStatus>().BPista.interactable = false;
                for(int i = 0; i < 5; i++)
                {
                   if(pistas[i].onomo.GetComponentInChildren<OnomoStatus>().ID == "n1tro" || pistas[i].onomo.GetComponentInChildren<OnomoStatus>().ID == "s01" || pistas[i].onomo.GetComponentInChildren<OnomoStatus>().ID == "v1d4")
                   {

                    corredor[i].GetComponentInChildren<OnomoStatus>().BPista.interactable = false;

                   }
                }

            }

            //Anula planta
            if(player.GetComponentInChildren<OnomoStatus>().ID == "gr4m4")
            {
                for(int i = 0; i < 5; i++)
                {
                   if(pistas[i].onomo.GetComponentInChildren<OnomoStatus>().ID == "n1tro" || pistas[i].onomo.GetComponentInChildren<OnomoStatus>().ID == "s01" ||pistas[i].onomo.GetComponentInChildren<OnomoStatus>().ID == "ndourada")
                   {

                    corredor[i].GetComponentInChildren<OnomoStatus>().BPista.interactable = false;

                   }
                }

            }

        }

        public void destruidorCanvas()
        {
            
            Canvascorrida.SetActive(false);

            if(gm.level == 0)
            {
               SceneManager.LoadScene(2);
            }

            
        }

        public void destruidor()
        {
            for(int i = 0; i <5;i++)
            {
                corredor[i].transform.position = SpawnpointNPC[i].transform.position;
                corredor[i].SetActive(false);

            } 
            /*if (Randy != 5)
            {
                
                pistas[Randy].transform.position = player.transform.position;
            }*/
            
           
            




            playerpista.transform.position = Spawnpointplayer.transform.position;
            player.transform.position = vPlayer;
           
            player.SetActive(false);
        }

        

        public void recolocabotão()
        {

            corredor[0].GetComponent<SpriteRenderer>().sortingOrder = 0;
            corredor[1].GetComponent<SpriteRenderer>().sortingOrder = 0;
            corredor[2].GetComponent<SpriteRenderer>().sortingOrder = 0;
            corredor[3].GetComponent<SpriteRenderer>().sortingOrder = 0;
            corredor[4].GetComponent<SpriteRenderer>().sortingOrder = 0;
            
            corredor[0].GetComponent<OnomoStatus>().BPista.interactable = true;
            corredor[1].GetComponent<OnomoStatus>().BPista.interactable = true;
            corredor[2].GetComponent<OnomoStatus>().BPista.interactable = true;
            corredor[3].GetComponent<OnomoStatus>().BPista.interactable = true;
            corredor[4].GetComponent<OnomoStatus>().BPista.interactable = true;
            player.GetComponentInChildren<OnomoStatus>().BPista.interactable = true;

            corredor[0].GetComponent<OnomoStatus>().Chegada = true;
            corredor[1].GetComponent<OnomoStatus>().Chegada = true;
            corredor[2].GetComponent<OnomoStatus>().Chegada = true;
            corredor[3].GetComponent<OnomoStatus>().Chegada= true;
            corredor[4].GetComponent<OnomoStatus>().Chegada= true;
            player.GetComponentInChildren<OnomoStatus>().Chegada = true;
            
        }

    
     void OnCollisionEnter2D(Collision2D collision)
    {  
       // if (collision.gameObject.tag == "Onomo")
        //{
            
            
          //  collision.gameObject.SendMessage("ApplyDamage", 10);
        //}  
        
        lugar++;              
        
        if(collision.gameObject.tag == "pista1"){
            /*if(Randy == 0)
            {
                player.GetComponent<OnomoStatus>().podio = lugar;
            }
            else*/
            //{
            corredor[0].GetComponent<OnomoStatus>().podio = lugar;
            corredor[0].GetComponent<OnomoStatus>().BPista.interactable = false;
            corredor[0].GetComponent<OnomoStatus>().Chegada = false;
            //HABI.BPistas[0].interactable = false;
            //}


            if (corredor[0].GetComponent<OnomoStatus>().podio == 1)
            {
                imagemvenc[0].sprite =  corredor[0].GetComponent<SpriteRenderer>().sprite;
                corredor[0].GetComponent<OnomoStatus>().popularidade = 90;

            }
            if (corredor[0].GetComponent<OnomoStatus>().podio == 2)
            {
                imagemvenc[1].sprite =  corredor[0].GetComponent<SpriteRenderer>().sprite;

                if (Random.Range(0,1) == 1)
                {
                    corredor[0].GetComponent<OnomoStatus>().popularidade = 80;
                }
                else 
                {
                    corredor[0].GetComponent<OnomoStatus>().popularidade = 70;
                }


            }
            if (corredor[0].GetComponent<OnomoStatus>().podio == 3)
            {
                imagemvenc[2].sprite =  corredor[0].GetComponent<SpriteRenderer>().sprite;

                if (Random.Range(0,1) == 1)
                {
                    corredor[0].GetComponent<OnomoStatus>().popularidade = 60;
                }
                else 
                {
                    corredor[0].GetComponent<OnomoStatus>().popularidade = 50;
                }

            }
            if (corredor[0].GetComponent<OnomoStatus>().podio == 4)
            {
                imagemvenc[3].sprite =  corredor[0].GetComponent<SpriteRenderer>().sprite;

                if (Random.Range(0,1) == 1)
                {
                    corredor[0].GetComponent<OnomoStatus>().popularidade = 40;
                }
                else 
                {
                    corredor[0].GetComponent<OnomoStatus>().popularidade = 30;
                }

            }
            if (corredor[0].GetComponent<OnomoStatus>().podio == 5)
            {
                imagemvenc[4].sprite =  corredor[0].GetComponent<SpriteRenderer>().sprite;

                corredor[0].GetComponent<OnomoStatus>().popularidade = 20;

            }
            if (corredor[0].GetComponent<OnomoStatus>().podio == 6)
            {
                imagemvenc[5].sprite =  corredor[0].GetComponent<SpriteRenderer>().sprite;
                corredor[0].GetComponent<OnomoStatus>().popularidade = 10;

            }
            
        }
        if(collision.gameObject.tag == "pista2")
        {
            /*if(Randy == 1)
            {
                player.GetComponent<OnomoStatus>().podio = lugar;
            }
            else*/
            //{
                corredor[1].GetComponent<OnomoStatus>().podio = lugar;
                corredor[1].GetComponent<OnomoStatus>().BPista.interactable = false;
                corredor[1].GetComponent<OnomoStatus>().Chegada = false;
                //HABI.BPistas[1].interactable = false;
           //}



           if ( corredor[1].GetComponent<OnomoStatus>().podio == 1)
            {
                imagemvenc[0].sprite =   corredor[1].GetComponent<SpriteRenderer>().sprite;
                 corredor[1].GetComponent<OnomoStatus>().popularidade = 90;

            }
            if ( corredor[1].GetComponent<OnomoStatus>().podio == 2)
            {
                imagemvenc[1].sprite =   corredor[1].GetComponent<SpriteRenderer>().sprite;

                if (Random.Range(0,1) == 1)
                {
                     corredor[1].GetComponent<OnomoStatus>().popularidade = 80;
                }
                else 
                {
                     corredor[1].GetComponent<OnomoStatus>().popularidade = 70;
                }

            }
            if ( corredor[1].GetComponent<OnomoStatus>().podio == 3)
            {
                imagemvenc[2].sprite =   corredor[1].GetComponent<SpriteRenderer>().sprite;

                if (Random.Range(0,1) == 1)
                {
                     corredor[1].GetComponent<OnomoStatus>().popularidade = 60;
                }
                else 
                {
                     corredor[1].GetComponent<OnomoStatus>().popularidade = 50;
                }

            }
            if ( corredor[1].GetComponent<OnomoStatus>().podio == 4)
            {
                imagemvenc[3].sprite =   corredor[1].GetComponent<SpriteRenderer>().sprite;

                if (Random.Range(0,1) == 1)
                {
                     corredor[1].GetComponent<OnomoStatus>().popularidade = 40;
                }
                else 
                {
                     corredor[1].GetComponent<OnomoStatus>().popularidade = 30;
                }

            }
            if ( corredor[1].GetComponent<OnomoStatus>().podio == 5)
            {
                imagemvenc[4].sprite =   corredor[1].GetComponent<SpriteRenderer>().sprite;
                 corredor[1].GetComponent<OnomoStatus>().popularidade = 20;

            }
            if ( corredor[1].GetComponent<OnomoStatus>().podio == 6)
            {
                imagemvenc[5].sprite =   corredor[1].GetComponent<SpriteRenderer>().sprite;
                 corredor[1].GetComponent<OnomoStatus>().popularidade = 10;

            }
            
        }
        if(collision.gameObject.tag == "pista3"){
            /*if(Randy == 2)
            {
                player.GetComponent<OnomoStatus>().podio = lugar;
            }
            else*/
            //{
                corredor[2].GetComponent<OnomoStatus>().podio = lugar;
                corredor[2].GetComponent<OnomoStatus>().BPista.interactable = false;
                corredor[2].GetComponent<OnomoStatus>().Chegada = false;
                //HABI.BPistas[2].interactable = false;
           // }


           if (corredor[2].GetComponent<OnomoStatus>().podio == 1)
            {
                imagemvenc[0].sprite =  corredor[2].GetComponent<SpriteRenderer>().sprite;
                corredor[2].GetComponent<OnomoStatus>().popularidade = 90;

            }
            if (corredor[2].GetComponent<OnomoStatus>().podio == 2)
            {
                imagemvenc[1].sprite =  corredor[2].GetComponent<SpriteRenderer>().sprite;

                if (Random.Range(0,1) == 1)
                {
                    corredor[2].GetComponent<OnomoStatus>().popularidade = 80;
                }
                else 
                {
                    corredor[2].GetComponent<OnomoStatus>().popularidade = 70;
                }

            }
            if (corredor[2].GetComponent<OnomoStatus>().podio == 3)
            {
                imagemvenc[2].sprite =  corredor[2].GetComponent<SpriteRenderer>().sprite;

                if (Random.Range(0,1) == 1)
                {
                    corredor[2].GetComponent<OnomoStatus>().popularidade = 60;
                }
                else 
                {
                    corredor[2].GetComponent<OnomoStatus>().popularidade = 50;
                }

            }
            if (corredor[2].GetComponent<OnomoStatus>().podio == 4)
            {
                imagemvenc[3].sprite =  corredor[2].GetComponent<SpriteRenderer>().sprite;

                if (Random.Range(0,1) == 1)
                {
                    corredor[2].GetComponent<OnomoStatus>().popularidade = 40;
                }
                else 
                {
                    corredor[2].GetComponent<OnomoStatus>().popularidade = 30;
                }

            }
            if (corredor[2].GetComponent<OnomoStatus>().podio == 5)
            {
                imagemvenc[4].sprite =  corredor[2].GetComponent<SpriteRenderer>().sprite;

                corredor[2].GetComponent<OnomoStatus>().popularidade = 20;

                

            }
            if (corredor[2].GetComponent<OnomoStatus>().podio == 6)
            {
                imagemvenc[5].sprite =  corredor[2].GetComponent<SpriteRenderer>().sprite;
                corredor[2].GetComponent<OnomoStatus>().popularidade = 10;

            }
            
        }
        if(collision.gameObject.tag == "pista4"){
            /*if(Randy == 3)
            {
                player.GetComponent<OnomoStatus>().podio = lugar;
            }
            else*/
            //{
                corredor[3].GetComponent<OnomoStatus>().podio = lugar;
                corredor[3].GetComponent<OnomoStatus>().BPista.interactable = false;
                corredor[3].GetComponent<OnomoStatus>().Chegada = false;
                //HABI.BPistas[3].interactable = false;
            //}


            if (corredor[3].GetComponent<OnomoStatus>().podio == 1)
            {
                imagemvenc[0].sprite = corredor[3].GetComponent<SpriteRenderer>().sprite;
                corredor[3].GetComponent<OnomoStatus>().popularidade = 90;

            }
            if (corredor[3].GetComponent<OnomoStatus>().podio == 2)
            {
                imagemvenc[1].sprite =  corredor[3].GetComponent<SpriteRenderer>().sprite;

                if (Random.Range(0,1) == 1)
                {
                    corredor[3].GetComponent<OnomoStatus>().popularidade = 80;
                }
                else 
                {
                   corredor[3].GetComponent<OnomoStatus>().popularidade = 70;
                }


            }
            if (corredor[3].GetComponent<OnomoStatus>().podio == 3)
            {
                imagemvenc[2].sprite =  corredor[3].GetComponent<SpriteRenderer>().sprite;

                if (Random.Range(0,1) == 1)
                {
                    corredor[3].GetComponent<OnomoStatus>().popularidade = 60;
                }
                else 
                {
                    corredor[3].GetComponent<OnomoStatus>().popularidade = 50;
                }

            }
            if (corredor[3].GetComponent<OnomoStatus>().podio == 4)
            {
                imagemvenc[3].sprite =  corredor[3].GetComponent<SpriteRenderer>().sprite;

                if (Random.Range(0,1) == 1)
                {
                    corredor[3].GetComponent<OnomoStatus>().popularidade = 40;
                }
                else 
                {
                    corredor[3].GetComponent<OnomoStatus>().popularidade = 30;
                }



            }
            if (corredor[3].GetComponent<OnomoStatus>().podio == 5)
            {
                imagemvenc[4].sprite = corredor[3].GetComponent<SpriteRenderer>().sprite;
                corredor[3].GetComponent<OnomoStatus>().popularidade = 20;

            }
            if (corredor[3].GetComponent<OnomoStatus>().podio == 6)
            {
                imagemvenc[5].sprite =  corredor[3].GetComponent<SpriteRenderer>().sprite;
                corredor[3].GetComponent<OnomoStatus>().popularidade = 10;

            }
            
        }
        if(collision.gameObject.tag == "pista5"){
            /*if(Randy == 4)
            {
                player.GetComponent<OnomoStatus>().podio = lugar;
            }
            else*/
            //{
                corredor[4].GetComponent<OnomoStatus>().podio = lugar;
                corredor[4].GetComponent<OnomoStatus>().BPista.interactable = false;
                corredor[4].GetComponent<OnomoStatus>().Chegada = false;
                //HABI.Bcorredor[4].interactable = false;
            //}
            

            if (corredor[4].GetComponent<OnomoStatus>().podio == 1)
            {
                imagemvenc[0].sprite =  corredor[4].GetComponent<SpriteRenderer>().sprite;
                corredor[4].GetComponent<OnomoStatus>().popularidade = 90;
                

            }
            if (corredor[4].GetComponent<OnomoStatus>().podio == 2)
            {
                imagemvenc[1].sprite =  corredor[4].GetComponent<SpriteRenderer>().sprite;
                if (Random.Range(0,1) == 1)
                {
                    corredor[4].GetComponent<OnomoStatus>().popularidade = 80;
                }
                else 
                {
                    corredor[4].GetComponent<OnomoStatus>().popularidade = 70;
                }

            }
            if (corredor[4].GetComponent<OnomoStatus>().podio == 3)
            {
                imagemvenc[2].sprite  =  corredor[4].GetComponent<SpriteRenderer>().sprite;
                if (Random.Range(0,1) == 1)
                {
                    corredor[4].GetComponent<OnomoStatus>().popularidade = 60;
                }
                else 
                {
                    corredor[4].GetComponent<OnomoStatus>().popularidade = 50;
                }

            }
            if (corredor[4].GetComponent<OnomoStatus>().podio == 4)
            {
                imagemvenc[3].sprite  =  corredor[4].GetComponent<SpriteRenderer>().sprite;
                if (Random.Range(0,1) == 1)
                {
                   corredor[4].GetComponent<OnomoStatus>().popularidade = 40;
                }
                else 
                {
                   corredor[4].GetComponent<OnomoStatus>().popularidade = 30;
                }
            }
            if (corredor[4].GetComponent<OnomoStatus>().podio == 5)
            {
                imagemvenc[4].sprite =  corredor[4].GetComponent<SpriteRenderer>().sprite;
                corredor[4].GetComponent<OnomoStatus>().popularidade = 20;

            }
            if (corredor[4].GetComponent<OnomoStatus>().podio == 6)
            {
                imagemvenc[5].sprite =  corredor[4].GetComponent<SpriteRenderer>().sprite;
                corredor[4].GetComponent<OnomoStatus>().popularidade = 10;
                

            }
        }
        if(collision.gameObject.tag == "pista6"){
            
            player.GetComponentInChildren<OnomoStatus>().BPista.interactable = false;
            player.GetComponentInChildren<OnomoStatus>().podio = lugar;
            player.GetComponentInChildren<OnomoStatus>().Chegada = false;
           /* if(Randy == 0)
            {
                corredor[0].GetComponent<OnomoStatus>().podio = lugar;
            }
            if(Randy == 1)
            {
                 corredor[1].GetComponent<OnomoStatus>().podio = lugar;
            }
            if(Randy == 2)
            {
                corredor[2].GetComponent<OnomoStatus>().podio = lugar;
            }
            if(Randy == 3)
            {
                pistas[3].onomo.GetComponent<OnomoStatus>().podio = lugar;
            }
            if(Randy == 4)
            {
                corredor[4].GetComponent<OnomoStatus>().podio = lugar;
            }*/
            //if(Randy == 5)
            //{
                
            //}

            if (player.GetComponentInChildren<OnomoStatus>().podio == 1)
            {
                imagemvenc[0].sprite =  player.GetComponentInChildren<SpriteRenderer>().sprite;
                player.GetComponentInChildren<OnomoStatus>().popularidade = 90;
                

            }
            if (player.GetComponentInChildren<OnomoStatus>().podio == 2)
            {
                imagemvenc[1].sprite =  player.GetComponentInChildren<SpriteRenderer>().sprite;
                if (Random.Range(0,1) == 1)
                {
                    player.GetComponentInChildren<OnomoStatus>().popularidade = 80;
                }
                else 
                {
                    player.GetComponentInChildren<OnomoStatus>().popularidade = 80;
                }

            }
            if (player.GetComponentInChildren<OnomoStatus>().podio == 3)
            {
                imagemvenc[2].sprite =  player.GetComponentInChildren<SpriteRenderer>().sprite;

                if (Random.Range(0,1) == 1)
                {
                    player.GetComponentInChildren<OnomoStatus>().popularidade = 60;
                }
                else 
                {
                    player.GetComponentInChildren<OnomoStatus>().popularidade = 50;
                }

            }
            if (player.GetComponentInChildren<OnomoStatus>().podio == 4)
            {
                imagemvenc[3].sprite =  player.GetComponentInChildren<SpriteRenderer>().sprite;

                if (Random.Range(0,1) == 1)
                {
                    player.GetComponentInChildren<OnomoStatus>().popularidade = 30;
                }
                else 
                {
                    player.GetComponentInChildren<OnomoStatus>().popularidade = 30;
                }

            }
            if (player.GetComponentInChildren<OnomoStatus>().podio == 5)
            {
                imagemvenc[4].sprite =  player.GetComponentInChildren<SpriteRenderer>().sprite;
                player.GetComponentInChildren<OnomoStatus>().popularidade = 20;


            }
            if (player.GetComponentInChildren<OnomoStatus>().podio == 6)
            {
                imagemvenc[5].sprite =  player.GetComponentInChildren<SpriteRenderer>().sprite;
                player.GetComponentInChildren<OnomoStatus>().popularidade = 0;
                

            }
            
            
        }

        


        
        //pistas[].onomo.GetComponent<OnomoStatus>().podio = lugar;
        //corredor[0].Get
        //OnomosStatus.podio=lugar;
        

        if (lugar == 6)
        {
            if(Aposta.apostado.GetComponentInChildren<OnomoStatus>().podio == 1)
            {
                apostadomostra.GetComponent<RectTransform>().localPosition = new Vector2(41.2f, 130.1f);

            }

            if(Aposta.apostado.GetComponentInChildren<OnomoStatus>().podio == 2)
            {
                apostadomostra.GetComponent<RectTransform>().localPosition = new Vector2(41.2f, 90.3f);

            }

            if(Aposta.apostado.GetComponentInChildren<OnomoStatus>().podio == 3)
            {
                apostadomostra.GetComponent<RectTransform>().localPosition = new Vector2(41.2f, 47.4f);

            }

            if(Aposta.apostado.GetComponentInChildren<OnomoStatus>().podio == 4)
            {
                apostadomostra.GetComponent<RectTransform>().localPosition = new Vector2(41.2f, 3.6f);

            }

            if(Aposta.apostado.GetComponentInChildren<OnomoStatus>().podio == 5)
            {
                apostadomostra.GetComponent<RectTransform>().localPosition = new Vector2(41.2f, -36.5f);

            }

            if(Aposta.apostado.GetComponentInChildren<OnomoStatus>().podio == 6)
            {
                apostadomostra.GetComponent<RectTransform>().localPosition = new Vector2(41.2f, -78.09f);

            }
            



            Habilina.SetTrigger("Descehabi");
            player.GetComponentInChildren<carroeng1>().PowerUp = null;
            player.GetComponentInChildren<carroeng1>().veloMax = VeloMax;
            player.GetComponentInChildren<carroeng1>().veloMin = VeloMin;

            for(int i=0; i > 6; i++)
            {
            

            pistas[i].onomo.GetComponent<OnomoStatus>().popularidade = pistas[i].onomo.GetComponent<OnomoStatus>().SetPop(pistas[i].onomo.GetComponent<OnomoStatus>().popularidade);
            

            
            }
            MenoZero.SetTrigger("Vitoria");
            
            Debug.Log("CM1"+Aposta.apostado+Aposta.apostado.GetComponent<OnomoStatus>().podio);

            livro.SetActive(true);
            Bar.SetActive(true);
            
            Aposta.BetCalculator();
            gm.ChecaFase();

            Aposta.confirm = true;
            Debug.Log("CM2"+Aposta.apostado+Aposta.apostado.GetComponent<OnomoStatus>().podio);
            Debug.Log("CM3"+Aposta.apostado);


            

            
            recolocabotão();
            destruidor();

            PreCorrida.novojogo();
            
            

            lugar = 0;
            
            //vai comparar os onomos da lista da fase com os corredores para igualar o nivel de popularidade
            

            

        }
    }

    

}

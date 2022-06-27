
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class carroeng1 : MonoBehaviour
{


    public GameObject final;
    
    public GameObject carro;
    public GameObject Player;
    public CorridaManager CorridaManager;

    private bool correr = false;


    public Rigidbody2D RGDB;


    private float distancia;

    public bool tempo = false;

    public OnomoStatus Velonomo;

    public delegate void DelegatePowerUp();
    public DelegatePowerUp delegatePowerUp;

    //public float speed = 5;
    [Range(0, 100), SerializeField]
    public float velo;

    [Range(0, 100), SerializeField]
    public float velomax = 1;
    [Range(0, 100), SerializeField]
    public float velomin = 1;

    public float time;

    public float reservaMaxima;
    public float reservaMinima;

    

    public Button button;
    

   
    //////////////////////////////////

    public Button[] BHabilidades;

    public Button[] botãoashabiinvo;

    public Animator AHabilidade;

    public int numeroPista;

    public float ColliderX;

    public float x;

    public int randomico;


    
    


    

    void Start()
    {
        carro = GetComponent<GameObject>();
        RGDB = GetComponent<Rigidbody2D>();
        distancia = 0;
        time = 0;
        Velonomo = GetComponent<OnomoStatus>();
        botãoashabiinvo = GetComponentInParent<CorridaManager>().AtivarPowerUp;
        Player = GetComponentInParent<CorridaManager>().playerpista;
        
        
        
        
 

    }

    void Update()
    {
        randomico = Random.Range(1, 10);
        numeroPista = GetComponentInParent<CorridaManager>().PistaArray;
        ColliderX = GetComponentInParent<BoxCollider2D>().offset.x - 0.1f;

        
        //velomax = Velonomo.veloMax;
        //velomin = Velonomo.veloMin;
        if (tempo == false)
        {
        StartCoroutine(ContrTempo());
        }
        if (tempo == true)
        {
        if( delegatePowerUp != null ){
            delegatePowerUp();
            Debug.Log("habilidade em outro onomo1");
            botãoashabiinvo[0].interactable = false;
            Debug.Log("habilidade em outro onomo2");
            //time.Time = time;
                if(time > 0){
                    time -= Time.deltaTime;
                }
                else{
                    delegatePowerUp = null;
                   // ativarHabilidade = false;
                   //botãoashabiinvo[0].interactable = false;
                    Invoke(nameof(InicializaCoolDown), 5.0f);
                    velomax = reservaMaxima;
                    velomin = reservaMinima;
                    velo = Random.Range(velomin, velomax);
                    time = 0;
                    //CorridaManager.iniciarCooldown = true;
                    
                    GetComponentInParent<CorridaManager>().Habilina.SetTrigger("timerhabi");

                    
                    
                    
                    
                }
        }
        else{
            Mover(); 
        }
        
       }
        
    }

    public void StarCorrer()
    {

        correr = true;

    }
    
    

    private Vector2 pixelvaificarlegal(Vector2 vetorfoda)
    {
        Vector2 vetornopixel = new Vector2(
            Mathf.RoundToInt(vetorfoda.x * 64),
            Mathf.RoundToInt(vetorfoda.y * 64));
            
        return vetornopixel / 64;

    }
    private void Mover()
    {
        //if (Chegada == Vector3.zero)
        //Chegada = transform.position;

        //velo = Random.Range(0.5f, 1f);

        
        velo = Random.Range(velomin, velomax);
        


        //rgdb.velocity = new Vector2(velocity, rgdb.velocity.y);

        RGDB.velocity = new Vector2(velo, RGDB.velocity.y);

        //RGDB.DOMove(mover, velo).SetEase(moveEase);

        //RGDB.DOMove(final2.transform.position, velo2).SetEase(moveEase);
        //transform.DOMove(Chegada, velo).SetEase(moveEase);

    }

    public void InicializaCoolDown(){
        GetComponentInParent<CorridaManager>().Habilina.SetTrigger("voltaencher");
        botãoashabiinvo[0].interactable = true;
    }
    IEnumerator ContrTempo()
        {
            velo = 0;
            yield return new WaitForSecondsRealtime(5);
            tempo = true;
            
        }
    public void Desacelerar()//onomos azul/roxo/vermelho/verde
    {
        if(time == 0){
           time = 2;
           reservaMaxima = velomax;
           reservaMinima = velomin;
        }
        velomin= 0.5f;
        velomax= 1f;
        //corredor[i].GetComponent<carroeng1>().velomax =- 1;
        //corredor[i].GetComponent<OnomoStatus>().velomax =- 1;
        //veloMax = veloMax - 0.5;
       // veloMin = veloMin - 0.5;
        velo = Random.Range(velomin, velomax);
        RGDB.velocity = new Vector2(velo, RGDB.velocity.y);
        Debug.Log("habilidade 1 executada");

    }

    public void DashMolhado()//onomo pao
    {
         if(time == 0){
           time = 1f;
           reservaMaxima = velomax;
           reservaMinima = velomin;
        }
        
        if(time > 0.5){
            velomax = 4f;
            velomin = 4f;
        }
        else{
            velomax = 0;
            velomin = 0;
            }
        velo = Random.Range(velomin, velomax);
        RGDB.velocity = new Vector2(velo, RGDB.velocity.y);
         
        Debug.Log("habilidade 2 executada");
    }

    public void DesacelerarOutros()// onomo colorido
    {
        if(time == 0){
           time = 2f;
           reservaMaxima = velomax;
           reservaMinima = velomin;
        }
        else{
            velomax = 1f;
            velomin = 0.5f;

            velo = Random.Range(velomin, velomax);
            //rgdb.velocity = new Vector2(velocity, rgdb.velocity.y);
            RGDB.velocity = new Vector2(velo, RGDB.velocity.y);

            Debug.Log("habilidade 3 executada");
        }
        
    }

     public void Invisivel()//onomo polvo
    {
        Debug.Log("habilidade 4 executada");
        
        if(time == 0){
           time = 0.1f;
           reservaMaxima = velomax;
           reservaMinima = velomin;
        }
        else
        {
            velo = Player.transform.position.x + 0.1f;
            Player.transform.position = new Vector2(velo, Player.transform.position.y);

        }

        //velo = Random.Range(velomin, velomax);
        //rgdb.velocity = new Vector2(velocity, rgdb.velocity.y);
        //RGDB.velocity = new Vector2(velo, RGDB.velocity.y);    
    }

    
     public void DashEscorregar()//onomo agua
    {
        Debug.Log("habilidade 5 executada");
        
        if(time == 0)
        {
           time = 3.6f;
           reservaMaxima = velomax;
           reservaMinima = velomin;
        }
        if(time>=3)
        {
            velomin = 4;
            velomax = 4;
            velo = Random.Range(velomin, velomax);
            RGDB.velocity = new Vector2(velo, RGDB.velocity.y);
        }
        if(time<3)
        {
            velomin = reservaMinima;
            velomax = reservaMaxima;
            velo = Random.Range(velomin, velomax);
            RGDB.velocity = new Vector2(velo, RGDB.velocity.y);
        }
        
        //velo = Random.Range(velomin, velomax);
        //rgdb.velocity = new Vector2(velocity, rgdb.velocity.y);
        //RGDB.velocity = new Vector2(velo, RGDB.velocity.y);    
    }
    public void Marcacao()//onomo bola/futebola/praia
    {
        Debug.Log("habilidade 6 executada");
        //int veloreserva;
        if(time == 0){
           time = 1;
           reservaMaxima = velomax;
           reservaMinima = velomin;
        }
        //Player.GetComponent<carroeng1>().velomin;
        //Player.GetComponent<carroeng1>().velomax;
        if(Player.transform.position.x<=RGDB.transform.position.x)
        {
           velomin = -0.8f;
            velomax = -0.6f;
            velo = Random.Range(velomin, velomax);
            //RGDB.velocity = new Vector2(velo, RGDB.velocity.y);
            Player.GetComponent<carroeng1>().RGDB.velocity = new Vector2(velo, RGDB.velocity.y);
            
            
        }
        if(Player.transform.position.x>RGDB.transform.position.x)
        {
            velomin = 4;
            velomax = 4.5f;
            velo = Random.Range(velomin, velomax);
            //RGDB.velocity = new Vector2(velo, RGDB.velocity.y);
            Player.GetComponent<carroeng1>().RGDB.velocity = new Vector2(velo, RGDB.velocity.y);
            
        }
        
        
        

        //velo = Random.Range(velomin, velomax);
        //rgdb.velocity = new Vector2(velocity, rgdb.velocity.y);
        //RGDB.velocity = new Vector2(velo, RGDB.velocity.y);    
    }
    public void MarcacaoLenta()//onomo bola/futebola/praia
    {
        Debug.Log("habilidade 6.1 executada");
        //int veloreserva;
        if(time == 0){
           time = 1;
           reservaMaxima = velomax;
           reservaMinima = velomin;
        }
        velomax = 1.6f;
        velomin = 1.4f;

        velo = Random.Range(velomin, velomax);
            //rgdb.velocity = new Vector2(velocity, rgdb.velocity.y);
        
        RGDB.velocity = new Vector2(velo, RGDB.velocity.y);

        if(Player.transform.position.x<=RGDB.transform.position.x)
        {
           velomin = -0.8f;
            velomax = -0.6f;
            velo = Random.Range(velomin, velomax);
            Player.GetComponent<carroeng1>().RGDB.velocity = new Vector2(velo, RGDB.velocity.y);
            
        }
        if(Player.transform.position.x>RGDB.transform.position.x)
        {
            velomin = 3f;
            velomax = 3.5f;
            velo = Random.Range(velomin, velomax);
            Player.GetComponent<carroeng1>().RGDB.velocity = new Vector2(velo, RGDB.velocity.y);

        }
        //Player.GetComponent<carroeng1>().velomin;
        //Player.GetComponent<carroeng1>().velomax;
        
        
        

        //velo = Random.Range(velomin, velomax);
        //rgdb.velocity = new Vector2(velocity, rgdb.velocity.y);
        //RGDB.velocity = new Vector2(velo, RGDB.velocity.y);    
    }
    public void FootMarcacao()//onomo bola/futebola/praia
    {
         Debug.Log("habilidade 6.2S executada");
        //int veloreserva;
        if(time == 0){
           time = 1;
           reservaMaxima = velomax;
           reservaMinima = velomin;
        }
        velomax = 4f;
        velomin = 4f;

        velo = Random.Range(velomin, velomax);
            //rgdb.velocity = new Vector2(velocity, rgdb.velocity.y);
        
        RGDB.velocity = new Vector2(velo, RGDB.velocity.y);

        if(Player.transform.position.x>=transform.position.x)
        {
           velomin = -0.6f;
            velomax = -0.2f;
            velo = Random.Range(velomin, velomax);
            Player.GetComponent<carroeng1>().RGDB.velocity = new Vector2(velo, RGDB.velocity.y);
            
        }
        if(Player.transform.position.x<transform.position.x)
        {
            velomin = 4f;
            velomax = 4.5f;
            velo = Random.Range(velomin, velomax);
            Player.GetComponent<carroeng1>().RGDB.velocity = new Vector2(velo, RGDB.velocity.y);

        }
        /*
        Debug.Log("habilidade 6 executada");
        //int veloreserva;
        if(time == 0){
           time = 1;
           reservaMaxima = velomax;
           reservaMinima = velomin;
        }
        //Player.GetComponent<carroeng1>().velomin;
        //Player.GetComponent<carroeng1>().velomax;
        RGDB.transform.position = new Vector2(Player.transform.position.x-0.1f, RGDB.transform.position.y);
        
        */

        //velo = Random.Range(velomin, velomax);
        //rgdb.velocity = new Vector2(velocity, rgdb.velocity.y);
        //RGDB.velocity = new Vector2(velo, RGDB.velocity.y);    
    }
    
    public void Assustar1()// Onomo caveirinha
    {
        Debug.Log("habilidade 7 executada");
        
        if(time == 0){
           time = 0.5f;
           reservaMaxima = velomax;
           reservaMinima = velomin;
        }
        
        if(Player.transform.position.x<=RGDB.transform.position.x)
        {
            velomin = 3f;
            velomax = 3.5f;
            velo = Random.Range(velomin, velomax);
            RGDB.velocity = new Vector2(velo, RGDB.velocity.y);
            
        }
        if(Player.transform.position.x>RGDB.transform.position.x)
        {
            velomin = -0.6f;
            velomax = -0.2f;
            velo = Random.Range(velomin, velomax);
            RGDB.velocity = new Vector2(velo, RGDB.velocity.y);

        }
        

        //velo = Random.Range(velomin, velomax);
        //rgdb.velocity = new Vector2(velocity, rgdb.velocity.y);
        //RGDB.velocity = new Vector2(velo, RGDB.velocity.y);    
    }
    public void Assustar2()// Onomo caveira piche e verde
    {
        Debug.Log("habilidade 7 executada");
        
        if(time == 0){
           time = 1f;
           reservaMaxima = velomax;
           reservaMinima = velomin;
        }
        
        if(Player.transform.position.x<=RGDB.transform.position.x)
        {
            velomin = 3f;
            velomax = 3.5f;
            velo = Random.Range(velomin, velomax);
            RGDB.velocity = new Vector2(velo, RGDB.velocity.y);
            
        }
        if(Player.transform.position.x>RGDB.transform.position.x)
        {
            velomin = -0.6f;
            velomax = -0.2f;
            velo = Random.Range(velomin, velomax);
            RGDB.velocity = new Vector2(velo, RGDB.velocity.y);

        }
        

        //velo = Random.Range(velomin, velomax);
        //rgdb.velocity = new Vector2(velocity, rgdb.velocity.y);
        //RGDB.velocity = new Vector2(velo, RGDB.velocity.y);    
    }
    public void Assustar3()// Onomo terror
    {
        Debug.Log("habilidade 7 executada");
        
        if(time == 0){
           time = 1;
           reservaMaxima = velomax;
           reservaMinima = velomin;
        }
        
        if(Player.transform.position.x<=RGDB.transform.position.x)
        {
            velomin = 4f;
            velomax = 4.5f;
            velo = Random.Range(velomin, velomax);
            RGDB.velocity = new Vector2(velo, RGDB.velocity.y);
            
        }
        if(Player.transform.position.x>RGDB.transform.position.x)
        {
            velomin = -0.8f;
            velomax = -0.4f;
            velo = Random.Range(velomin, velomax);
            RGDB.velocity = new Vector2(velo, RGDB.velocity.y);

        }
        

        //velo = Random.Range(velomin, velomax);
        //rgdb.velocity = new Vector2(velocity, rgdb.velocity.y);
        //RGDB.velocity = new Vector2(velo, RGDB.velocity.y);    
    }

      public void Quentinho()//fogo
    {
        Debug.Log("habilidade 8 executada");
        
        if(time == 0){
           time = 1;
           reservaMaxima = velomax;
           reservaMinima = velomin;
        }
          if(Player.transform.position.x<=RGDB.transform.position.x)
        {
           velomin = -0.6f;
            velomax = -0.2f;
            velo = Random.Range(velomin, velomax);
            RGDB.velocity = new Vector2(velo, RGDB.velocity.y);
            
        }
        if(Player.transform.position.x>RGDB.transform.position.x)
        {
            velomin = 2.5f;
            velomax = 3f;
            velo = Random.Range(velomin, velomax);
            RGDB.velocity = new Vector2(velo, RGDB.velocity.y);

        }
        

        //velo = Random.Range(velomin, velomax);
        //rgdb.velocity = new Vector2(velocity, rgdb.velocity.y);
        //RGDB.velocity = new Vector2(velo, RGDB.velocity.y);    
    }
    public void Paralisia()//gelo/pedra/elétrico/planta
    {
        Debug.Log("habilidade 9 executada");
        
        if(time == 0){
           time = 0.5f;
           reservaMaxima = velomax;
           reservaMinima = velomin;
        }
        velomin= 0;
        velomax= 0;
        velo = Random.Range(velomin, velomax);
        RGDB.velocity = new Vector2(velo, RGDB.velocity.y);

        //velo = Random.Range(velomin, velomax);
        //rgdb.velocity = new Vector2(velocity, rgdb.velocity.y);
        //RGDB.velocity = new Vector2(velo, RGDB.velocity.y);    
    }
    public void Paralisia2()//gelo
    {
        Debug.Log("habilidade 9 executada");
        
        if(time == 0){
           time = 1.5f;
           reservaMaxima = velomax;
           reservaMinima = velomin;
        }
        velomin = 0;
        velomax = 0;
        velo = Random.Range(velomin, velomax);
        RGDB.velocity = new Vector2(velo, RGDB.velocity.y);

        //velo = Random.Range(velomin, velomax);
        //rgdb.velocity = new Vector2(velocity, rgdb.velocity.y);
        //RGDB.velocity = new Vector2(velo, RGDB.velocity.y);    
    }
    public void Paralisia3()//pedra
    {
        Debug.Log("habilidade 9 executada");
        
        if(time == 0){
           time = 1.5f;
           reservaMaxima = velomax;
           reservaMinima = velomin;
        }
        velomin= 0;
        velomax= 0;
        velo = Random.Range(velomin, velomax);
        RGDB.velocity = new Vector2(velo, RGDB.velocity.y);

        //velo = Random.Range(velomin, velomax);
        //rgdb.velocity = new Vector2(velocity, rgdb.velocity.y);
        //RGDB.velocity = new Vector2(velo, RGDB.velocity.y);    
    }
    public void Paralisia4()//planta
    {
        Debug.Log("habilidade 9 executada");
        
        if(time == 0){
           time = 1f;
           reservaMaxima = velomax;
           reservaMinima = velomin;
        }
        velomin= 0;
        velomax= 0;
        velo = Random.Range(velomin, velomax);
        RGDB.velocity = new Vector2(velo, RGDB.velocity.y);

        //velo = Random.Range(velomin, velomax);
        //rgdb.velocity = new Vector2(velocity, rgdb.velocity.y);
        //RGDB.velocity = new Vector2(velo, RGDB.velocity.y);    
    }
    public void Paralisia5()//lula
    {
        Debug.Log("habilidade 9 executada");
        float r=3;
        if(time == 0){
           time = 0.5f;
           reservaMaxima = velomax;
           reservaMinima = velomin;
           r = Random.Range(1,10);
        }
        if(r>5&&r!=3){
            velomin= 0.71f;
            velomax= 2f;
            velo = Random.Range(velomin, velomax);
            RGDB.velocity = new Vector2(velo, RGDB.velocity.y);
        }
        if(r<=5&&r!=3){
            velomin= 0;
            velomax= 0;
            velo = Random.Range(velomin, velomax);
            RGDB.velocity = new Vector2(velo, RGDB.velocity.y);
        }
        

        //velo = Random.Range(velomin, velomax);
        //rgdb.velocity = new Vector2(velocity, rgdb.velocity.y);
        //RGDB.velocity = new Vector2(velo, RGDB.velocity.y);    
    }

    public void DesacelerarBuffado(){//Não usada
        Debug.Log("habilidade 10 executada");
        
        if(time == 0){
           time = 1;
           reservaMaxima = velomax;
           reservaMinima = velomin;
        }
        velomin=- 1.5f;
        velomax=- 2;
        velo = Random.Range(velomin, velomax);
        RGDB.velocity = new Vector2(velo, RGDB.velocity.y);

        //velo = Random.Range(velomin, velomax);
        //rgdb.velocity = new Vector2(velocity, rgdb.velocity.y);
        //RGDB.velocity = new Vector2(velo, RGDB.velocity.y);    
    }
    public void Confusao(){//melo/ melonemo/mario
        Debug.Log("habilidade 11 executada");
        randomico = Random.Range(1, 10);
        
        if(time == 0){
           time = 1f;
           reservaMaxima = velomax;
           reservaMinima = velomin;
        }

        
        if(randomico <= 5)
        {
            velomin= Random.Range(-4,-5);
            velomax= Random.Range(-3,-4);

        }
        else
        {
            velomin= Random.Range(3,3);
            velomax= Random.Range(3.5f, 4);

        }

        
        velo = Random.Range(velomin, velomax);
        RGDB.velocity = new Vector2(velo, RGDB.velocity.y);
        

        //velo = Random.Range(velomin, velomax);
        //rgdb.velocity = new Vector2(velocity, rgdb.velocity.y);
        //RGDB.velocity = new Vector2(velo, RGDB.velocity.y);    
    }

     public void Tornado(){//nuvem/nuvem dourada
        Debug.Log("habilidade 13 executada");
        
        if(time == 0){
           time = 0.1f;
           reservaMaxima = velomax;
           reservaMinima = velomin;
        }

        x = 0;
        if(randomico <= 5)
        {
           x = RGDB.transform.position.x - 0.3f;
        }
        else
        {
            x = RGDB.transform.position.x + 0.3f; 
        }
        
        /*
        if(ColliderX < x)
        {
            x = ColliderX - 0.01f;
        }*/

        RGDB.transform.position = new Vector2(x, RGDB.transform.position.y);

        //velo = Random.Range(velomin, velomax);
        //rgdb.velocity = new Vector2(velocity, rgdb.velocity.y);
        //RGDB.velocity = new Vector2(velo, RGDB.velocity.y);    
    }
     public void Magnetismo(){//metal
        Debug.Log("habilidade 14 executada");
        
        if(time == 0){
           time = 1f;
           reservaMaxima = velomax;
           reservaMinima = velomin;
        }
        
       // for(int i = 0; i<6; i++)
        //{
            
            if(Player.transform.position.x<=RGDB.transform.position.x)
           {

            velomin = -0.4f;
            velomax = -0.2f;
            velo = Random.Range(velomin, velomax);
            RGDB.velocity = new Vector2(velo, RGDB.velocity.y);
            
           }
           if(Player.transform.position.x>RGDB.transform.position.x)
           {

            velomin = 3.5f;
            velomax = 4f;
            velo = Random.Range(velomin, velomax);
            RGDB.velocity = new Vector2(velo, RGDB.velocity.y);

           }
       // }
        //velo = velo + Random.Range(4,-3);
        //RGDB.velocity = new Vector2(velo, RGDB.velocity.y);

        //velo = Random.Range(velomin, velomax);
        //rgdb.velocity = new Vector2(velocity, rgdb.velocity.y);
        //RGDB.velocity = new Vector2(velo, RGDB.velocity.y);    
    }
     public void QuentinhoRapido(){//nitro
        Debug.Log("habilidade 15 executada");
        
        if(time == 0){
           time = 0.5f;
           reservaMaxima = velomax;
           reservaMinima = velomin;
        }
        
         if(Player.transform.position.x<=RGDB.transform.position.x)
        {
           velomin = -0.7f;
            velomax = -0.2f;
            velo = Random.Range(velomin, velomax);
            RGDB.velocity = new Vector2(velo, RGDB.velocity.y);
            
        }
        if(Player.transform.position.x>RGDB.transform.position.x)
        {
            velomin = 4f;
            velomax = 3.4f;
            velo = Random.Range(velomin, velomax);
            RGDB.velocity = new Vector2(velo, RGDB.velocity.y);

        }
       // velomin =+ 2.1f;
        //velomax =+ 3.1f;
        //velo = Random.Range(velomin, velomax);
        //Player.GetComponent<Rigidbody2D>().velocity = new Vector2(velo, Player.GetComponent<Rigidbody2D>().velocity.y);

        //velo = Random.Range(velomin, velomax);
        //rgdb.velocity = new Vector2(velocity, rgdb.velocity.y);
        //RGDB.velocity = new Vector2(velo, RGDB.velocity.y);    
    }
     public void Acelerar(){//
        Debug.Log("habilidade 16 executada");
        
        if(time == 0){
           time = 2f;
           reservaMaxima = velomax;
           reservaMinima = velomin;
           velomin = velomin  + 1.1f;
           velomax = velomax;
        }
        
        velo = Random.Range(velomin, velomax);
        RGDB.velocity = new Vector2(velo, RGDB.velocity.y);

        //velo = Random.Range(velomin, velomax);
        //rgdb.velocity = new Vector2(velocity, rgdb.velocity.y);
        //RGDB.velocity = new Vector2(velo, RGDB.velocity.y);    
    }
     public void ConfusaoArea(){
        Debug.Log("habilidade 17 executada");
        
        if(time == 0){
           time = 0.2f;
           reservaMaxima = velomax;
           reservaMinima = velomin;
        }
        velomin =+ 1.1f;
        velomax =+ 2.1f;
        
        RGDB.velocity = new Vector2(velo, RGDB.velocity.y);

        //velo = Random.Range(velomin, velomax);
        //rgdb.velocity = new Vector2(velocity, rgdb.velocity.y);
        //RGDB.velocity = new Vector2(velo, RGDB.velocity.y);    
    }
    public void DarPassagem(){//vidamelo
        Debug.Log("habilidade 17 executada");
        
        if(time == 0){
           time = 0.2f;
           reservaMaxima = velomax;
           reservaMinima = velomin;
        }
        velomin = 3.6f;
        velomax = 5f;
        RGDB.velocity = new Vector2(velo, RGDB.velocity.y);

        //velo = Random.Range(velomin, velomax);
        //rgdb.velocity = new Vector2(velocity, rgdb.velocity.y);
        //RGDB.velocity = new Vector2(velo, RGDB.velocity.y);    
    }
    public void TornadoArea(){
        Debug.Log("habilidade 17 executada");
        
        if(time == 0){
           time = 0.2f;
           reservaMaxima = velomax;
           reservaMinima = velomin;
        }
        velomin =+ 1.1f;
        velomax =+ 2.1f;
        RGDB.velocity = new Vector2(velo, RGDB.velocity.y);

        //velo = Random.Range(velomin, velomax);
        //rgdb.velocity = new Vector2(velocity, rgdb.velocity.y);
        //RGDB.velocity = new Vector2(velo, RGDB.velocity.y);    
    }

     public void Cegar(){
        Debug.Log("habilidade do Sol executada");
        
        if(time == 0){
           time = 0.5f;
           reservaMaxima = velomax;
           reservaMinima = velomin;
        }
        if(Player.transform.position.x>RGDB.transform.position.x){
            velomin = 0f;
            velomax = 0f;
        }
        
        RGDB.velocity = new Vector2(velo, RGDB.velocity.y);

        //velo = Random.Range(velomin, velomax);
        //rgdb.velocity = new Vector2(velocity, rgdb.velocity.y);
        //RGDB.velocity = new Vector2(velo, RGDB.velocity.y);    
    }
    public void Nitro()//onomo nitro
    {
        Debug.Log("habilidade 5 executada");
        
        if(time == 0)
        {
           time = 3.6f;
           reservaMaxima = velomax;
           reservaMinima = velomin;
        }
        if(time>=3)
        {
            velomin = 5;
            velomax = 5;
            velo = Random.Range(velomin, velomax);
            RGDB.velocity = new Vector2(velo, RGDB.velocity.y);
        }
        if(time<3)
        {
            velomin = reservaMinima;
            velomax = reservaMaxima;
            velo = Random.Range(velomin, velomax);
            RGDB.velocity = new Vector2(velo, RGDB.velocity.y);
        }
        
        //velo = Random.Range(velomin, velomax);
        //rgdb.velocity = new Vector2(velocity, rgdb.velocity.y);
        //RGDB.velocity = new Vector2(velo, RGDB.velocity.y);    
    }


    


    /* public void ExecutarPowerUp(GameObject Pista)
    {
        AHabilidade.SetTrigger("fimHabi");
        //delegatePowerUp = Desacelerar;
        //pista[i].onomo.GetComponent<carroeng1>().delegatePowerUp();
        Pista.GetComponent<carroeng1>().delegatePowerUp = DesacelerarBuffado;
        
        Pista.GetComponent<carroeng1>().ativarHabilidade = true;

        
        //pista[i].onomo.GetComponent<carroeng1>.ativarHabilidade = true;
    }*/

    

/*
    public void PowerUpOnomo()
    {
        reservaMaxima = velomax;
        reservaMinima = velomin;
        iD=GetComponent<OnomoStatus>().ID;
        if(iD ==  "4zu1" || iD == "r0x0" || iD == "v3rm3lh0" || iD == "v3rd3"){
            //delegatePowerUp = Desacelerar;
            //texto do botão com o nome da habilidade;
            //delegatePowerUp = Desacelerar;
            //ativarHabilidade = true;
             //delegatePowerUp = DesacelerarBuffado;
             AHabilidade.SetTrigger("Habilidade");
             Debug.Log("Ta funfando");
        }

        if(iD == "p04"){
            //delegatePowerUp = DashMolhado;
            delegatePowerUp = DashMolhado;
            ativarHabilidade = true;
        }

        if(iD == "C010r1d0"){
            //delegatePowerUp = PowerUp3;
             delegatePowerUp = DesacelerarBuffado;
             //AHabilidade
             //ativar animação dos botões
             
        }

        if(iD == "4gua"){
            //delegatePowerUp = PowerUp4;
        }

        if(iD == "3014"){
           // delegatePowerUp = Desacelerar;
            
        }

        if(iD == "cav31r4"){
            delegatePowerUp = DashMolhado;
            
        }

        if(iD == "c4v31r1nha"){
            //delegatePowerUp = PowerUp3;
        }

        if(iD == "f0g0"){
            //delegatePowerUp = PowerUp4;
        }

         if(iD == "f00tball"){
            delegatePowerUp = Desacelerar;
            
        }

        if(iD == "gel0"){
            delegatePowerUp = DashMolhado;
            
        }

        if(iD == "greg0"){
            //delegatePowerUp = PowerUp3;
        }

        if(iD == "l4v4"){
            //delegatePowerUp = PowerUp4;
        }

        if(iD == "l3tric0"){
            delegatePowerUp = Desacelerar;
            
        }

        if(iD == "lul0"){
            delegatePowerUp = DashMolhado;
            
        }

        if(iD == "m4ri0"){
            //delegatePowerUp = PowerUp3;
        }

        if(iD == "melo"){
            //delegatePowerUp = PowerUp4;
        }

        if(iD == "melor0m"){
            delegatePowerUp = Desacelerar;
            
        }

        if(iD == "m3741"){
            delegatePowerUp = DashMolhado;
            
        }

        if(iD == "n1tro"){
            //delegatePowerUp = PowerUp3;
        }

        if(iD == "ndourada"){
            //delegatePowerUp = PowerUp4;
        }
        
        if(iD == "nuvem"){
            delegatePowerUp = Desacelerar;
            
        }

        if(iD == "pedr4"){
            delegatePowerUp = DashMolhado;
            
        }

        if(iD == "p1ch3"){
            //delegatePowerUp = PowerUp3;
        }

        if(iD == "gr4m4"){
            //delegatePowerUp = PowerUp4;
        }

         if(iD == "p0lv0"){
            delegatePowerUp = Desacelerar;
            
        }

        if(iD == "s01"){
            delegatePowerUp = DashMolhado;
            
        }

        if(iD == "s0m"){
            //delegatePowerUp = PowerUp4;
        }

        if(iD == "v1d4"){
            delegatePowerUp = Desacelerar;
            
        }

        if(iD == "pr4ia"){
            delegatePowerUp = DashMolhado;
            
        }

       
    }*/

}

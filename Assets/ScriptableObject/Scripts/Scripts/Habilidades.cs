using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Habilidades : MonoBehaviour
{
    // Start is called before the first frame update
    //public delegate void DelegatePowerUp();
    //public DelegatePowerUp delegatePowerUp;
    
    public GameObject Player;

    public CorridaManager cm;

    //desacelerar
    public bool desacelerar = false;
  
    public bool desacelerarBuffado = false;

    public bool desacelerarOutros = false;

    //dashes
    public bool dashMolhado = false;
    public bool dashagua = false;
    public bool dashlava = false;


    //marcação
    public bool bolamarcacao = false;

    public bool footmarcacao = false;

    public bool marcacaoLenta = false;

   //assustar

    public bool assustarcaverinha = false;

    public bool assustarcaveira = false;

    public bool assustarpiche = false;

    public bool assustarterror = false;


    //quentinhos
    public bool quentinhofogo = false;

    public bool quentinhogrego = false;

    public bool quentinhoRapido = false;


    // paralizia
    public bool paraliziaGelo = false;
    public bool paraliziaPedra = false;
    public bool paraliziaLetrico = false;
    public bool paraliziaPlanta = false;
    public bool paraliziaSol = false;

    
    //confuso
    public bool confusaoarea = false;

    public bool confusaomelo = false;

    public bool confusaorom = false;

    
    //magnetismo

    public bool magnetismo = false;

    
    //tornado
    public bool tornado = false;

    public bool tornadoarea = false;


    //invisivel
    public bool invisivel = false;


    // acelerar outros
    public bool acelerar = false;


    // dar passagem
    public bool darpassagem = false;



    string iD;
   

    

    public Animator AHabilidade;

    public Button[] BPistas;
    public Button BHabilidade;
    

    


    
    public void ExecutarPowerUp(GameObject Pista)
    {
        
        AHabilidade.SetTrigger("Descehabi");
        //cm.iniciarCooldown = true;
        //cm.Habilina.SetTrigger("timerhabi");
        //Invoke(nameof(InicializaCoolDown), 5.0f);
        //delegatePowerUp = Desacelerar;
        //pista[i].onomo.GetComponent<carroeng1>().delegatePowerUp();

        if(desacelerar == true){

            Debug.Log("Ta funcionando");
            Pista.GetComponentInChildren<carroeng1>().PowerUp = Pista.GetComponentInChildren<carroeng1>().Desacelerar;

            desacelerar = false;
            //Pista.GetComponent<carroeng1>().ativarHabilidade = true;
        
        }

         if(desacelerarOutros == true){
            Pista.GetComponentInChildren<carroeng1>().PowerUp = Pista.GetComponentInChildren<carroeng1>().DesacelerarOutros;
            desacelerarOutros = false;
            //Pista.GetComponent<carroeng1>().ativarHabilidade = true;
        
        }


        
        //if(dashMolhado == true){
          //  Pista.GetComponentInChildren<carroeng1>().delegatePowerUp = Pista.GetComponentInChildren<carroeng1>().DashMolhado;
           // dashMolhado  = false;
            //Pista.GetComponent<carroeng1>().ativarHabilidade = true;
        
       // }


        //if(dashagua == true){
          //  Pista.GetComponentInChildren<carroeng1>().delegatePowerUp = Pista.GetComponentInChildren<carroeng1>().DashEscorregar;
            //dashagua  = false;
            //Pista.GetComponent<carroeng1>().ativarHabilidade = true;
        
        //}



        if(assustarcaveira == true){
            Pista.GetComponentInChildren<carroeng1>().PowerUp = Pista.GetComponentInChildren<carroeng1>().Assustar2;
            assustarcaveira  = false;
            //Pista.GetComponent<carroeng1>().ativarHabilidade = true;
        
        }

        if(assustarcaverinha == true){
            Pista.GetComponentInChildren<carroeng1>().PowerUp = Pista.GetComponentInChildren<carroeng1>().Assustar1;
            assustarcaverinha  = false;
            //Pista.GetComponent<carroeng1>().ativarHabilidade = true;
        
        }

        if(quentinhofogo == true){
            Pista.GetComponentInChildren<carroeng1>().PowerUp = Pista.GetComponentInChildren<carroeng1>().Quentinho;
            quentinhofogo  = false;
            //Pista.GetComponent<carroeng1>().ativarHabilidade = true;
        
        }

        if(bolamarcacao == true){
            Pista.GetComponentInChildren<carroeng1>().PowerUp = Pista.GetComponentInChildren<carroeng1>().Marcacao;
            bolamarcacao  = false;
            //Pista.GetComponent<carroeng1>().ativarHabilidade = true;
        
        }
         

        if(quentinhogrego == true){
            Pista.GetComponentInChildren<carroeng1>().PowerUp = Pista.GetComponentInChildren<carroeng1>().Quentinho;
            quentinhogrego  = false;
            //Pista.GetComponent<carroeng1>().ativarHabilidade = true;
        
        }

        if(footmarcacao == true){
            Pista.GetComponentInChildren<carroeng1>().PowerUp = Pista.GetComponentInChildren<carroeng1>().FootMarcacao;
            footmarcacao  = false;
            //Pista.GetComponent<carroeng1>().ativarHabilidade = true;
        
        }

        /*if(dashlava == true){
            Pista.GetComponentInChildren<carroeng1>().delegatePowerUp = Pista.GetComponentInChildren<carroeng1>().DashEscorregar;
            dashlava  = false;
            //Pista.GetComponent<carroeng1>().ativarHabilidade = true;
        
        }*/

        if(paraliziaGelo == true){
            Pista.GetComponentInChildren<carroeng1>().PowerUp = Pista.GetComponentInChildren<carroeng1>().Paralisia;
            paraliziaGelo  = false;
            //Pista.GetComponent<carroeng1>().ativarHabilidade = true;
        
        }

        if(desacelerarBuffado == true){
            Pista.GetComponentInChildren<carroeng1>().PowerUp = Pista.GetComponentInChildren<carroeng1>().Paralisia5;
            desacelerarBuffado  = false;
            //Pista.GetComponent<carroeng1>().ativarHabilidade = true;
        
        }

        if(confusaoarea == true){
            Pista.GetComponentInChildren<carroeng1>().PowerUp = Pista.GetComponentInChildren<carroeng1>().Confusao;//ConfusaoArea;
            confusaoarea  = false;
            //Pista.GetComponent<carroeng1>().ativarHabilidade = true;
        
        }

        if(confusaorom == true){
            Pista.GetComponentInChildren<carroeng1>().PowerUp = Pista.GetComponentInChildren<carroeng1>().Confusao;
            confusaorom = false;
            //Pista.GetComponent<carroeng1>().ativarHabilidade = true;
        
        }

        if(confusaomelo == true){
            Pista.GetComponentInChildren<carroeng1>().PowerUp = Pista.GetComponentInChildren<carroeng1>().Confusao;
            confusaomelo = false;
            //Pista.GetComponent<carroeng1>().ativarHabilidade = true;
        
        }

        if(magnetismo == true){
            //Pista.GetComponentInChildren<carroeng1>().delegatePowerUp = Pista.GetComponentInChildren<carroeng1>().Magnetismo;
           
                for(int i = 0; i<5; i++)
                {
                    cm.corredor[i].GetComponentInChildren<carroeng1>().PowerUp = cm.corredor[i].GetComponentInChildren<carroeng1>().Magnetismo;
                    
                }
            magnetismo  = false;
            //Pista.GetComponent<carroeng1>().ativarHabilidade = true;
        
        }

        if(quentinhoRapido == true){
            Pista.GetComponentInChildren<carroeng1>().PowerUp = Pista.GetComponentInChildren<carroeng1>().QuentinhoRapido;
            quentinhoRapido  = false;
            //Pista.GetComponent<carroeng1>().ativarHabilidade = true;
        
        }

        if(tornadoarea == true){
            Pista.GetComponentInChildren<carroeng1>().PowerUp = Pista.GetComponentInChildren<carroeng1>().Tornado;//TornadoArea;
            tornadoarea  = false;
            //Pista.GetComponent<carroeng1>().ativarHabilidade = true;
        
        }

        if(tornado == true){
            Pista.GetComponentInChildren<carroeng1>().PowerUp = Pista.GetComponentInChildren<carroeng1>().Tornado;
            tornado  = false;
            //Pista.GetComponent<carroeng1>().ativarHabilidade = true;
        
        }

        if(paraliziaPedra == true){
            Pista.GetComponentInChildren<carroeng1>().PowerUp = Pista.GetComponentInChildren<carroeng1>().Paralisia;
            paraliziaPedra  = false;
            //Pista.GetComponent<carroeng1>().ativarHabilidade = true;
        
        }

        if(assustarpiche == true){
            Pista.GetComponentInChildren<carroeng1>().PowerUp = Pista.GetComponentInChildren<carroeng1>().Assustar2;
            assustarpiche  = false;
            //Pista.GetComponent<carroeng1>().ativarHabilidade = true;
        
        }

        if(paraliziaLetrico == true){
            Pista.GetComponentInChildren<carroeng1>().PowerUp = Pista.GetComponentInChildren<carroeng1>().Paralisia;
            paraliziaLetrico  = false;
            //Pista.GetComponent<carroeng1>().ativarHabilidade = true;
        
        }

        /*if(invisivel == true)
        {
            Pista.GetComponentInChildren<carroeng1>().delegatePowerUp = Pista.GetComponentInChildren<carroeng1>().Invisivel;
            invisivel = false;
            //Pista.GetComponent<carroeng1>().ativarHabilidade = true;
        
        }*/

        if(paraliziaPlanta == true)
        {
            for(int i = 0; i<5; i++)
                {
                    cm.corredor[i].GetComponentInChildren<carroeng1>().PowerUp = cm.corredor[i].GetComponentInChildren<carroeng1>().Paralisia;
                    
                }
            paraliziaPlanta = false;
            //Pista.GetComponent<carroeng1>().ativarHabilidade = true;
        
        }

        if(acelerar == true){
            Pista.GetComponentInChildren<carroeng1>().PowerUp = Pista.GetComponentInChildren<carroeng1>().Acelerar;
            acelerar  = false;
            //Pista.GetComponent<carroeng1>().ativarHabilidade = true;
        
        }

        if(darpassagem == true){
            for(int i = 0; i<5; i++)
                {
                    cm.corredor[i].GetComponentInChildren<carroeng1>().PowerUp = cm.corredor[i].GetComponentInChildren<carroeng1>().DarPassagem;
                    
                }
           
            darpassagem = false;
            //Pista.GetComponent<carroeng1>().ativarHabilidade = true;
        
        }

        if(marcacaoLenta == true){
            Pista.GetComponentInChildren<carroeng1>().PowerUp = Pista.GetComponentInChildren<carroeng1>().MarcacaoLenta;
            marcacaoLenta  = false;
            //Pista.GetComponent<carroeng1>().ativarHabilidade = true;
        
        }

        if(assustarterror == true){
            Pista.GetComponentInChildren<carroeng1>().PowerUp = Pista.GetComponentInChildren<carroeng1>().Assustar3;
            assustarterror  = false;
            //Pista.GetComponent<carroeng1>().ativarHabilidade = true;
        
        }

        if(paraliziaSol == true){
            Pista.GetComponentInChildren<carroeng1>().PowerUp = Pista.GetComponentInChildren<carroeng1>().Cegar;
            paraliziaSol  = false;
            //Pista.GetComponent<carroeng1>().ativarHabilidade = true;
        
        }
       

        
        //pista[i].onomo.GetComponent<carroeng1>.ativarHabilidade = true;
    }


    // aparecem, sim melhor aki mesmo
    //ok. De agr em diante bora sempre falar por aqui mas nunca apagar os comentários.
    //ok. ae se vai colocar certo aqules qeu não prescisam ser chamados como o botão pista? (ele falou de nois S2)
    //Athos vai querer colcar em call
    
    public void PowerUpOnomo()
    {
        
        iD=Player.GetComponent<OnomoStatus>().ID;
        if(iD ==  "4zu1" || iD == "r0x0" || iD == "v3rm3lh0" || iD == "v3rd3"){
            //texto do botão com o nome da habilidade;
            //delegatePowerUp = Desacelerar;
            //delegatePowerUp = DesacelerarBuffado;
            desacelerar = true;
             AHabilidade.SetTrigger("SobeHabi");
            //Player.GetComponentInChildren<carroeng1>().delegatePowerUp = Player.GetComponentInChildren<carroeng1>().Desacelerar;
            Debug.Log("Ta funfando");

            

        }
        if(iD == "C010r1d0"){
            //delegatePowerUp = PowerUp3;
             //delegatePowerUp = DesacelerarBuffado;
             desacelerarOutros = true;
             AHabilidade.SetTrigger("SobeHabi");
             Debug.Log("Ta funfando 2");
             //AHabilidade
             //ativar animação dos botões
             
        }

        if(iD == "p04"){
            //delegatePowerUp = DashMolhado;
            Player.GetComponentInChildren<carroeng1>().PowerUp = Player.GetComponentInChildren<carroeng1>().DashMolhado;
            //AHabilidade.SetTrigger("SobeHabi");
           //dashMolhado = true;
            Debug.Log("Ta funfando 3");
        }

        if(iD == "4gua"){
            //delegatePowerUp = PowerUp4;
            Player.GetComponentInChildren<carroeng1>().PowerUp = Player.GetComponentInChildren<carroeng1>().DashEscorregar;
            //dashagua = true;
            Debug.Log("Ta funfando 4");
        }

        if(iD == "3014"){
           // delegatePowerUp = Desacelerar;
            AHabilidade.SetTrigger("SobeHabi");
            bolamarcacao = true;
            Debug.Log("Ta funfando 5");
            
        }
        if(iD == "cav31r4"){
            AHabilidade.SetTrigger("SobeHabi");
            assustarcaveira = true;
            Debug.Log("Ta funfando 6");
        }
        if(iD == "c4v31r1nha"){
            //delegatePowerUp = PowerUp3;
            AHabilidade.SetTrigger("SobeHabi");
            assustarcaverinha = true;
            Debug.Log("Ta funfando 7");
        }
        if(iD == "f0g0"){
            //delegatePowerUp = PowerUp4;
            AHabilidade.SetTrigger("SobeHabi");
            quentinhofogo = true;
            Debug.Log("Ta funfando 8");
        }

        if(iD == "f00tball"){
            //delegatePowerUp = Desacelerar;
            AHabilidade.SetTrigger("SobeHabi");
            footmarcacao = true;
            Debug.Log("Ta funfando 9");
            
        }

        if(iD == "gel0"){
            //delegatePowerUp = DashMolhado;
            
            AHabilidade.SetTrigger("SobeHabi");
            paraliziaGelo = true;
            Debug.Log("Ta funfando 10");
            
        }

        if(iD == "greg0"){
            //delegatePowerUp = PowerUp3;

            AHabilidade.SetTrigger("SobeHabi");
            quentinhogrego = true;
            Debug.Log("Ta funfando 11");
        }

        if(iD == "l4v4"){
            //delegatePowerUp = PowerUp4;
            //AHabilidade.SetTrigger("SobeHabi");
            //dashlava = true;
            Player.GetComponentInChildren<carroeng1>().PowerUp = Player.GetComponentInChildren<carroeng1>().DashEscorregar;
            Debug.Log("Ta funfando 12");
        }

        if(iD == "l3tric0"){
            //delegatePowerUp = Desacelerar;

            AHabilidade.SetTrigger("SobeHabi");
            paraliziaLetrico = true;
            Debug.Log("Ta funfando 13");
            
        }

        if(iD == "lul0"){
            //delegatePowerUp = DashMolhado;
            AHabilidade.SetTrigger("SobeHabi");
            desacelerarBuffado = true;
            Debug.Log("Ta funfando 14");
            
        }

        if(iD == "m4ri0"){
            //delegatePowerUp = PowerUp3;
            //AHabilidade.SetTrigger("SobeHabi");
            for(int i = 0; i<5; i++)
                {
                    if(cm.corredor[i].GetComponentInChildren<OnomoStatus>().Chegada != false && cm.corredor[i].GetComponentInChildren<OnomoStatus>().ID != "melo" && cm.corredor[i].GetComponentInChildren<OnomoStatus>().ID != "melor0m" && cm.corredor[i].GetComponentInChildren<OnomoStatus>().ID != "n1tro" && cm.corredor[i].GetComponentInChildren<OnomoStatus>().ID != "s01" && cm.corredor[i].GetComponentInChildren<OnomoStatus>().ID != "v1d4")//v1d4
                    {
                     cm.corredor[i].GetComponentInChildren<carroeng1>().PowerUp = cm.corredor[i].GetComponentInChildren<carroeng1>().Confusao;
                    }
                    
                    if(Player.GetComponentInChildren<OnomoStatus>().Chegada != false)
                    {
                        Player.GetComponentInChildren<carroeng1>().PowerUp = Player.GetComponentInChildren<carroeng1>().Confusao;
                    }
                    
                    
                }
                //Player.GetComponentInChildren<carroeng1>().delegatePowerUp = Player.GetComponentInChildren<carroeng1>().Confusao;
            //confusaoarea = true;
            Debug.Log("Ta funfando 15");
        }
        if(iD == "melo"){
            //delegatePowerUp = PowerUp4;
            AHabilidade.SetTrigger("SobeHabi");
            confusaomelo  = true;
            Debug.Log("Ta funfando 16");
        }
        if(iD == "melor0m"){
            //delegatePowerUp = Desacelerar;
            AHabilidade.SetTrigger("SobeHabi");
            confusaorom = true;
            Debug.Log("Ta funfando 17");
            
        }
        if(iD == "m3741"){
            //delegatePowerUp = DashMolhado;
             for(int i = 0; i<5; i++)
                {
                    if(cm.corredor[i].GetComponentInChildren<OnomoStatus>().Chegada != false )//v1d4
                    {
                      cm.corredor[i].GetComponentInChildren<carroeng1>().PowerUp = cm.corredor[i].GetComponentInChildren<carroeng1>().Magnetismo;
                    }
                   
                    
                }
            // AHabilidade.SetTrigger("SobeHabi");
            //magnetismo = true;
            Debug.Log("Ta funfando 18");
            
        }
        if(iD == "n1tro"){
            //delegatePowerUp = PowerUp3;
            //AHabilidade.SetTrigger("SobeHabi");
            for(int i = 0; i<5; i++)
                {
                    if(cm.corredor[i].GetComponentInChildren<OnomoStatus>().Chegada != false && cm.corredor[i].GetComponentInChildren<OnomoStatus>().ID != "s01" )//v1d4
                    {
                     cm.corredor[i].GetComponentInChildren<carroeng1>().PowerUp = cm.corredor[i].GetComponentInChildren<carroeng1>().QuentinhoRapido;
                    }
                    
                    
                }
             Player.GetComponentInChildren<carroeng1>().PowerUp = Player.GetComponentInChildren<carroeng1>().Nitro;
            
            //quentinhoRapido = true;
            Debug.Log("Ta funfando 19");
            
        }
        if(iD == "ndourada"){
            //delegatePowerUp = PowerUp4;
            //AHabilidade.SetTrigger("SobeHabi");
            for(int i = 0; i<5; i++)
                {
                    if(cm.corredor[i].GetComponentInChildren<OnomoStatus>().Chegada != false )//v1d4
                    {
                     cm.corredor[i].GetComponentInChildren<carroeng1>().PowerUp = cm.corredor[i].GetComponentInChildren<carroeng1>().Tornado;
                    }
                     
                    
                }
            //tornadoarea = true;
            Debug.Log("Ta funfando 20");
        }
        if(iD == "nuvem"){
            //delegatePowerUp = Desacelerar;

           AHabilidade.SetTrigger("SobeHabi");
           tornado = true;
           Debug.Log("Ta funfando 21");
            
        }
        if(iD == "pedr4"){
            //delegatePowerUp = DashMolhado;

            AHabilidade.SetTrigger("SobeHabi");
            paraliziaPedra = true;
            Debug.Log("Ta funfando 22");
            
        }
        if(iD == "p1ch3"){
            //delegatePowerUp = PowerUp3;
            AHabilidade.SetTrigger("SobeHabi");
            assustarpiche = true;
            Debug.Log("Ta funfando 23");
        }
        if(iD == "gr4m4"){
            //delegatePowerUp = PowerUp4;
            for(int i = 0; i<5; i++)
                {
                    if(cm.corredor[i].GetComponentInChildren<OnomoStatus>().Chegada != false && cm.corredor[i].GetComponentInChildren<OnomoStatus>().ID != "ndourada" && cm.corredor[i].GetComponentInChildren<OnomoStatus>().ID != "nuvem" && cm.corredor[i].GetComponentInChildren<OnomoStatus>().ID != "n1tro" && cm.corredor[i].GetComponentInChildren<OnomoStatus>().ID != "s01")
                    {
                    cm.corredor[i].GetComponentInChildren<carroeng1>().PowerUp = cm.corredor[i].GetComponentInChildren<carroeng1>().Paralisia;
                    }
                }
             
            //paraliziaPlanta = true;
            Debug.Log("Ta funfando 24");
        }
        if(iD == "p0lv0"){
            //delegatePowerUp = Desacelerar;
            //AHabilidade.SetTrigger("SobeHabi");
            //invisivel = true;
            Player.GetComponentInChildren<carroeng1>().PowerUp = Player.GetComponentInChildren<carroeng1>().Invisivel;
            Debug.Log("Ta funfando 25");
            
        }
        if(iD == "s01"){
            //delegatePowerUp = DashMolhado;
            //AHabilidade.SetTrigger("SobeHabi");
            for(int i = 0; i<5; i++)
                {
                     if(cm.corredor[i].GetComponentInChildren<OnomoStatus>().Chegada != false )//v1d4
                    {
                     cm.corredor[i].GetComponentInChildren<carroeng1>().PowerUp = cm.corredor[i].GetComponentInChildren<carroeng1>().Cegar;
                    }
                    
                    
                }
            //paraliziaSol = true;
            Debug.Log("Ta funfando 26");
            
        }
        if(iD == "s0m"){
            //delegatePowerUp = PowerUp4;
            AHabilidade.SetTrigger("SobeHabi");
            acelerar = true;
            Debug.Log("Ta funfando 27");
        }
        if(iD == "v1d4"){
            //delegatePowerUp = Desacelerar;
           //AHabilidade.SetTrigger("SobeHabi");
           for(int i = 0; i<5; i++)
                {
                     if(cm.corredor[i].GetComponentInChildren<OnomoStatus>().Chegada != false )//v1d4
                    {
                     cm.corredor[i].GetComponentInChildren<carroeng1>().PowerUp = cm.corredor[i].GetComponentInChildren<carroeng1>().DarPassagem;
                    }
                    
                    
                }
            //Player.GetComponentInChildren<carroeng1>().delegatePowerUp = Player.GetComponentInChildren<carroeng1>().Desacelerar;
            //darpassagem = true;
            Debug.Log("Ta funfando 28");
            
        }
        if(iD == "pr4ia"){
            //delegatePowerUp = DashMolhado;
            AHabilidade.SetTrigger("SobeHabi");
            marcacaoLenta = true;
            Debug.Log("Ta funfando 29");
            
        }
        if(iD == "t3rr0r"){
            //delegatePowerUp = DashMolhado;
           // AHabilidade.SetTrigger("SobeHabi");
           for(int i = 0; i<5; i++)
                {
                    if(cm.corredor[i].GetComponentInChildren<OnomoStatus>().Chegada != false )
                    {
                      cm.corredor[i].GetComponentInChildren<carroeng1>().PowerUp = cm.corredor[i].GetComponentInChildren<carroeng1>().Assustar3;
                    }
                    
                    if(Player.GetComponentInChildren<OnomoStatus>().Chegada != false)
                    {
                       Player.GetComponentInChildren<carroeng1>().PowerUp = Player.GetComponentInChildren<carroeng1>().Assustar3;
                    }
                   
                    
                }
                
            //assustarterror = true;
            Debug.Log("Ta funfando 30");
            
        }
/*
        

        t3rr0r

        

        

        

         

        

        

        

        if(iD == "l3tric0"){
            delegatePowerUp = Desacelerar;
            
        }

        

        if(iD == "m4ri0"){
            //delegatePowerUp = PowerUp3;
        }

        

        

        

        

        
        
        if(iD == "nuvem"){
            delegatePowerUp = Desacelerar;
            
        }

        

        

        

         

        if(iD == "s01"){
            delegatePowerUp = DashMolhado;
            
        }

        

        

        
        */
       
    }
    
}

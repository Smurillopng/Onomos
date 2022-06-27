using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ApostaManager : MonoBehaviour
{

    public int chooseBet = 3;
    public int chooseSlime;
    public int priceMoney;
    //public int chancePerc = 30;
    public int firstPlace;
    public int secondPlace;
    public int betMoney;

    public Text text;
    public Text PriceMoney;
    public Text Apostexto;

    public Text Loko;

    public bool Confirm = true; 
    
    public PreCorridaManager PreCorrida;

    public CorridaManager Corrida;

    public GameObject Apostado;

    public GameManager Gm;

    public Button[] BottõesApostas;

    public int chancePerc;





    // Start is called before the first frame update
    void Start()
    {
        chooseBet=3;
        text.text = "0ml";
        
        //chooseBet = PlayerPrefs.GetInt("ChooseBet");
        if(PreCorrida == null)
        {
            PreCorrida = GetComponent<PreCorridaManager>();

        }

        if(Corrida == null)
        {
            Corrida = GetComponent<CorridaManager>();

        }
        

        
    }

    // Update is called once per frame
    void Update()
    {
        if(PreCorrida.apostado!=null)
        {

            Apostado = PreCorrida.apostado;
            if(Confirm == true)
            {
            chancePerc = Apostado.GetComponent<OnomoStatus>().popularidade;//Colocar nos botões de escolha de apopsta
            //Coloca o onomo apostado se a referencia dele for nula
            }
        }

        
        
        if(0 < betMoney){
            
            Loko.text = "To Não";
        }
        else
        {
            Loko.text = "To Loko";
        }
        
        
        
            
        //Vai comparar o onomo a pista no OnomoStatus dos Onomos ate achar o mesmo e depois atualizar ele para assim conseguir o Podio dele ou posição
        

    }

    


    public void MakeFinalBet(int Escolha)
    {
        chooseBet = Escolha;

        if(Escolha == 1)
        {
            BottõesApostas[0].interactable = false;
            BottõesApostas[1].interactable = true;
            BottõesApostas[2].interactable = true;
            Apostexto.text = "Esse é o tipo convencional de aposta onde voce coloca uma certa quantidade na aposta e caso o corredor que voce escolheu fique em primeiro voce ira resceber sua recopensa.";
           

        }
        if(Escolha == 0)
        {
            BottõesApostas[0].interactable = true;
            BottõesApostas[1].interactable = false;
            BottõesApostas[2].interactable = true;
            Apostexto.text =  "Esse é a aposta mais segura que pode ser feita onde no terceiro, segundo e primeiro lugar voce podera ganhar ainda assim ate que quanto menor a posição menor o ganho ate chegar no quarto lugar onde nele voce tera perca minima ate o sexto lugar onde vai ter perda maxima.";
            
        }
        if(Escolha == -1)
        {
            BottõesApostas[0].interactable = true;
            BottõesApostas[1].interactable = true;
            BottõesApostas[2].interactable = false;
            Apostexto.text =  "Essa é a aposta mais complicada onde voce tem que escolher o corredor que ira cair em terceira ou quarta posição, mas saiba que nessa aposta o ganha é muito maior so que a quantidade que voce apostar sera aumentada e a perda sera maior.";
            
        }

        
        //totalMoney = totalMoney - betMoney;
        //buttonAnimaçãoEscolhidoAtivar;
    }
    
    //Button

    //botão que aumenta para diretia com 10 +
    public void BetMoneyright10()
    {
        
        betMoney = betMoney + 10;
        if(Gm.totalMoney < betMoney){
            betMoney = betMoney-10;
        }
        text.text = betMoney.ToString()+"ml";
    }

    public void BetMoneyleft10()
    {
        betMoney = betMoney - 10;
        if(betMoney < 0)
        {
         betMoney = 0;   
        }
        text.text = betMoney.ToString()+"ml";
    }
    //Somar 100 e completar o valor total, ou não completar caso passe de 100
    //Ex: 150 aumenta para 200, ou não aumenta pq estouraria o limite 
    public void BetMoneyRight100()
    {
        betMoney = betMoney + 100;
        if(Gm.totalMoney < betMoney){
            betMoney = betMoney-100;
        }
        text.text = betMoney.ToString()+"ml";
    }
    public void BetMoneyLeft100()
    {
        betMoney = betMoney - 100;
        if(betMoney < 0)
        {
         betMoney = 0;   
        }
        text.text = betMoney.ToString()+"ml";

    }
    public void toLoko()
    {
        
        
        if(0 < betMoney)
        {
            betMoney = 0;
            Loko.text = "To loko";




        }
        else
        {
            betMoney = Gm.totalMoney;
            Loko.text = "To Não";
            
        }
        text.text = betMoney.ToString()+"ml";
    }
    //BetManager
    public void Betcalculator()
    {
         if (chooseBet == 1)
         {
             Debug.Log("teste1"+Apostado+Apostado.GetComponent<OnomoStatus>().podio);
            FirsBet(Gm.totalMoney, betMoney, chancePerc);

         }


        if (chooseBet == 0)
        {
            FirstSecondBet(Gm.totalMoney, betMoney, chancePerc);

        }
        if (chooseBet == -1)
        {
            Exac(Gm.totalMoney, betMoney, chancePerc);
        }

        text.text = "00Ml";
        betMoney = 0;
        BottõesApostas[0].interactable = true;
        BottõesApostas[1].interactable = true;
        BottõesApostas[2].interactable = true;
        chooseBet = 3;
                 
    }

    // Executa os calculos da primeira aposta e confere se foi bem sucedida
    public void FirsBet(int totalMoney, int betMoney, int chancePerc)
    {
        Debug.Log("teste2"+Apostado+Apostado.GetComponent<OnomoStatus>().podio);
        if (Apostado.GetComponent<OnomoStatus>().podio == 1)
        {
            if(chancePerc>70){
                priceMoney = (betMoney * (100 - chancePerc) * 2)/100;
                Debug.Log("venceu1");
            }
            else{
                 priceMoney = (betMoney * (100 - chancePerc) * 2)/10;
                 Debug.Log("venceu2");
            }
            //Gm.totalMoney = Gm.totalMoney + 4000;//priceMoney;
            print("Ganhou");
            Gm.totalMoney = Gm.totalMoney+priceMoney;
            PriceMoney.text  = "Você ganhou "+ priceMoney.ToString()+"ml";
            Debug.Log("venceu3"+Apostado+Apostado.GetComponent<OnomoStatus>().podio);
        }
        else
        {
            priceMoney = betMoney;
            Gm.totalMoney = Gm.totalMoney - priceMoney;
            print("Perdeu");
           // Gm.totalMoney = Gm.totalMoney - 10;
            PriceMoney.text  = "Você perdeu "+ priceMoney.ToString()+"ml";
            Debug.Log("perdeu1"+Apostado+Apostado.GetComponent<OnomoStatus>().podio);
        }
       //PriceMoney.text  = "O resultado da aposta foi "+ priceMoney.ToString()+"ml";
        
        
    }

    // Executa os calculos da segunda aposta e confere se foi bem sucedida
    public void FirstSecondBet(int totalMoney, int betMoney, int chancePerc)
    {
        if (Apostado.GetComponent<OnomoStatus>().podio == 1 || Apostado.GetComponent<OnomoStatus>().podio == 2 || Apostado.GetComponent<OnomoStatus>().podio == 3)
        {
            if(chancePerc>70){
                if (Apostado.GetComponent<OnomoStatus>().podio == 1){
                 priceMoney = (betMoney * (100 - chancePerc))/100;                    
                }
                if (Apostado.GetComponent<OnomoStatus>().podio == 2){
                priceMoney = (betMoney * (100 - chancePerc))/100;
               
                }
                if (Apostado.GetComponent<OnomoStatus>().podio == 3){
                priceMoney = (betMoney * (100 - chancePerc))/100;
                
                }
            }
            else{
                if (Apostado.GetComponent<OnomoStatus>().podio == 1){
                 priceMoney = (betMoney * (100 - chancePerc))/10;
                
                
                }
                if (Apostado.GetComponent<OnomoStatus>().podio == 2){
                priceMoney = (betMoney * (100 - chancePerc))/10;
               
                }
                if (Apostado.GetComponent<OnomoStatus>().podio == 3){
                priceMoney = (betMoney * (100 - chancePerc))/10;
                
                }
            }
            
             Gm.totalMoney = Gm.totalMoney + priceMoney;
            PriceMoney.text  = "Você ganhou "+ priceMoney.ToString()+"ml";
            Debug.Log("venceu4"+Apostado+Apostado.GetComponent<OnomoStatus>().podio);
        }
        else 
        {
            if (Apostado.GetComponent<OnomoStatus>().podio == 4)
            {
                //priceMoney = betMoney * ((100 - chancePerc) / 10) * 3;       
                priceMoney = betMoney;
            }
            
            if (Apostado.GetComponent<OnomoStatus>().podio == 5)
            {
                //priceMoney = betMoney * ((100 - chancePerc) / 10) * 3;       
                priceMoney = betMoney;

            }

            if (Apostado.GetComponent<OnomoStatus>().podio == 6)
            {
                priceMoney = betMoney; 
                     

            }
            Debug.Log("perdeu2"+Apostado+Apostado.GetComponent<OnomoStatus>().podio);
            Gm.totalMoney = Gm.totalMoney - priceMoney;
             PriceMoney.text  = "Você perdeu "+ priceMoney.ToString()+"ml";
        

           
        }
        //PriceMoney.text  = "O resultado da aposta foi "+ priceMoney.ToString()+"ml";
        
        
    }

    // Executa os calculos da terceira aposta e confere se foi bem sucedida
    public void Exac(int totalMoney, int betMoney, int chancePerc)
    {
        
        if (Apostado.GetComponent<OnomoStatus>().podio == 3 || Apostado.GetComponent<OnomoStatus>().podio == 4)
        {
            if(chancePerc>70){
                priceMoney = (betMoney * (100 - chancePerc) * 3)/100;
            }
            else{
                priceMoney = (betMoney * (100 - chancePerc) * 3)/10;
            }
            Gm.totalMoney = Gm.totalMoney + priceMoney;
            Debug.Log("ganhou");
            PriceMoney.text  = "Você ganhou "+ priceMoney.ToString()+"ml";
        }
        else
        {
            priceMoney = betMoney * 2;
            Gm.totalMoney = Gm.totalMoney - priceMoney;
            Debug.Log("perdeu");
            PriceMoney.text  = "Você perdeu "+ priceMoney.ToString()+"ml";
        }
        //PriceMoney.text  = "O resultado da aposta foi "+ priceMoney.ToString()+"ml";
        
    }

    /*void OnCollisionEnter2D(Collision2D collision)
    {  
       Betcalculator();
        

       
    }*/

}

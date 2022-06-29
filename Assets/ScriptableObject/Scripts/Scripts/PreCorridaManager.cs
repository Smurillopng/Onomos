using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PreCorridaManager : MonoBehaviour
{
    public GameManager gm;

    public GameObject apostado;

    
    public int lugar = 0;

    int replay = 1;
    int DezdeDez = 0;

    public int randy;

    public int Apostadonumero = 0;

    public int faseAtual;

    public CorridaManager CorridaMane;

    public Habilidades HABI;

    

    
    


    public Pista[] pistas;

    public GameObject player;

    public Image[] botoesimagens;
    public Image Onomocole;
    public Image imagemapostado;

    public Button[] Botões;

    public Text[] Popularidade;
    public Text OnomoDisc;

    

    


    
    //SpritRenderer para mudar o SortingOrder dos corredores
    private SpriteRenderer Sprits;

    
    //Lista de Onomos por ScripbleObject
    StageProperties listOnomos;
    public StageProperties listPlayer;

    public GameObject[] NPCS;

    
    //Vetores do local deles na pista
    private Vector2 vPlayer;
    private Vector2 pista1;
    private Vector2 pista2;
    private Vector2 pista3;
    private Vector2 pista4;
    private Vector2 pista5;
    private Vector2 pista6;


    

    

    


    
    // Start is called before the first frame update
    private void Start()
    {
        vPlayer = player.transform.position;
        novojogo();
        CorridaMane.Canvascorrida.SetActive(false);
        

    }

    

    // Update is called once per frame
    void FixedUpdate()
    {
        botoesimagens[5].sprite = player.GetComponentInChildren<SpriteRenderer>().sprite;
        Popularidade[5].text = player.GetComponentInChildren<OnomoStatus>().popularidade.ToString();
        
        if(Apostadonumero != 0)
        {
         if(Apostadonumero < 6)
         {

            imagemapostado.sprite = pistas[Apostadonumero-1].onomo.GetComponent<SpriteRenderer>().sprite;

         }
         else
         {
            imagemapostado.sprite = player.GetComponentInChildren<SpriteRenderer>().sprite;
         }
        }
        
        

        
          
       pista1 = pistas[0].onomo.transform.position;
      
       //Debug.Log(pista1.x);
       pista2 = pistas[1].onomo.transform.position;
       //Debug.Log(pista2.x);
       pista3 = pistas[2].onomo.transform.position;
       //Debug.Log(pista3.x);
       pista4 = pistas[3].onomo.transform.position;
       //Debug.Log(pista4.x);
       pista5 = pistas[4].onomo.transform.position;
       //Debug.Log(pista5.x);
       pista6 = player.transform.position;
       //Debug.Log(pista6.x);
       //Debug.Log(pista1.x, pista2.x, pista3.x, pista4.x,pista5.x, pista6.x);

    }

    //Escolhe o onomo na onomo pedia
    public void EscolhidoPlayer(int botaoEscolhido)
    {
        listPlayer.GetChosen(player, botaoEscolhido);
        botoesimagens[5].sprite = player.GetComponentInChildren<SpriteRenderer>().sprite;

        Onomocole.sprite = player.GetComponentInChildren<SpriteRenderer>().sprite;

        /*if(botaoEscolhido == 0)
        {
            OnomoDisc.text = "Azul";

        }*/
       if(botaoEscolhido == 0)
        {
            OnomoDisc.text = "Onomo Azul\n\n<color=#beb500>Habilidade</color>: Desacelera um onomo. Só afeta onomo vermelho.\n\nUm Onomo bem comum, bem iniciante,  a única diferença especial dele é não ter nada de especial e, bem, ser azul.";

        }if(botaoEscolhido == 1)
        {
            OnomoDisc.text = "Onomo Verde\n\n<color=#beb500>Habilidade</color>: Desacelera um onomo. Só afeta onomo azul.\n\nUm Onomo bem comum, bem iniciante, a única diferença especial dele é não ter nada de especial e, bem, ter a cor do dinheiro.";

        }if(botaoEscolhido == 2)
        {
            OnomoDisc.text = "Onomo Vermelho\n\n<color=#beb500>Habilidade</color>: Desacelera um onomo. Só afeta onomo roxo.\n\nUm Onomo bem comum, bem iniciante, a única diferença especial dele é não ter nada de especial e, bem, ter a mesma descrição do azul.";

        }if(botaoEscolhido == 3)
        {
            OnomoDisc.text = "Onomo Roxo\n\n<color=#beb500>Habilidade</color>: Desacelera um onomo. Só afeta onomo verde.\n\nUm Onomo bem comum, bem iniciante, a única diferença especial dele é não ter nada de especial e, bem, não ser verde.";

        }if(botaoEscolhido == 4)
        {
            OnomoDisc.text = "Onomo Colorido\n\n<color=#beb500>Habilidade:</color> Desacelerar outros onomos ou a si mesmo. Só afeta o onomo azul/vermelho/roxo/verde/colorido.\n\nTambém não muito especial, mas chamativo. Forte influência para os onomos de uma cor só.";

        }if(botaoEscolhido == 5)
        {
            OnomoDisc.text = "Onomo Pão\n\n<color=#beb500>Habilidade:</color> Da um dash de água, mas o atrito das migalhas faz ele parar abruptamente.\n\nÉ dito que enquanto alimentavam patos, algumas migalhas caíram sobre os Onomos Splash e eles viraram esse pão.";

        }if(botaoEscolhido == 6)
        {
            
            OnomoDisc.text = "Onomo Lula\n\n<color=#beb500>Habilidade</color>: Paralisa oponentes por um período de tempo.Não afeta: Onomo Létrico/Gelo/Pedra/Lula. \n \nRelativamente agressivo para um Onomo.  Possui um espinho na ponta de seu tentáculo, não é tão afiado, mas dói. Não gosta do Onomo polvo.";

        }if(botaoEscolhido == 7)
        {
            OnomoDisc.text = "Onomo Caveirinha\n\n<color=#beb500>Habilidade</color>: Assusta um Onomo para longe de si, acelerando se estiver na frente ou fazendo ele dar ré se estiver atrás. Não afeta: caveirinha/caveira vermelha/caveira piche/terror. \n \nEles são até bonitinhos? Talvez esquisitinhos? Enfim, no mínimo causam calafrios.";

        }if(botaoEscolhido == 8)
        {
            OnomoDisc.text = "Onomo Piche\n\n<color=#beb500>Habilidade</color>: Assusta um Onomo para longe de si, acelerando se estiver na frente ou fazendo ele dar ré se estiver atrás. Não afeta: caveira vermelha/caveira piche/terror. \n \nNão se sabe bem da onde as caveiras vem. Provavelmente só grudou neles.";

        }if(botaoEscolhido == 9)
        {
            OnomoDisc.text = "Onomo Melo\n\n<color=#beb500>Habilidade</color>: Solta esporos que fazem um Onomo se mover aleatoriamente. Não afeta: Onomo Melo/Melorom/Fogo/Fogo Grego/Lava. \n \nCapaz de soltar esporos alucinantes de seu corpo, não são letais mas seus sentidos vão ficar meio confusos.";

        }if(botaoEscolhido == 10)
        {
            OnomoDisc.text = "Onomo Splash\n\n<color=#beb500>Habilidade</color>: Da um dash de água. \n \nGeralmente estão perto de lagos, rios, poças, baldes, entram na sua banheira... Enfim, gostam de água. ";

        }if(botaoEscolhido == 11)
        {
            OnomoDisc.text = "Onomo Pedra\n\n<color=#beb500>Habilidade</color>: Petrifica outros Onomos por um tempo. Não afeta: Onomo Létrico/Gelo/Pedra\n \n Duro como gelo. Com estalagmites saindo de sua cabeça esse onomo tem a capacidade de petrificar oponentes com um olhar. Ou com o raio petrificante.";

        }if(botaoEscolhido == 12)
        {
            OnomoDisc.text = "Onomo Melorom\n\n<color=#beb500>Habilidade</color>:Solta esporos que fazem um Onomo se mover aleatoriamente. Não afeta: Onomo Melo/Melorom/Fogo/Fogo Grego/Lava.\n \nCapaz de soltar esporos alucinantes de seu corpo, não são letais mas seus sentidos vão ficar meio confusos.";

        }if(botaoEscolhido == 13)
        {
            OnomoDisc.text = "Onomo Nuvem\n\n<color=#beb500>Habilidade</color>: Gera um tornado que muda um Onomo de lugar aleatoriamente. Afeta todos os Onomos.\n \n Leves e imprevisíveis. Gostam de abusar da sorte.";

        }if(botaoEscolhido == 14)
        {
            OnomoDisc.text = "Onomo Fogo\n\n<color=#beb500>Habilidade</color>:Atrai um Onomo para perto do calor reconfortante. Não afeta: Onomo lava/fogo/fogo grego.\n \nTão quentinhos... E relaxados. Servem como fogueiras em florestas e lareiras em pousadas. ";

        }if(botaoEscolhido == 15)
        {
            OnomoDisc.text = "Onomo Gelo\n\n<color=#beb500>Habilidade</color>:Congela outros Onomos com seu raio congelante. Não afeta: Onomo Létrico/Gelo/Pedra.\n \nFrio como pedra. Com cristais de gelo saindo de sua cabeça esse onomo pode chegar a temperaturas baixíssimas.";

        }if(botaoEscolhido == 16)
        {
            OnomoDisc.text = "Onomo Caveira Vermelha\n\n<color=#beb500>Habilidade</color>: Assusta um Onomo para longe de si, acelerando se estiver na frente ou fazendo ele dar ré se estiver atrás. Não afeta: caveira vermelha/caveira piche/terror.\n \nNão se sabe bem o porquê deles ficarem te encarando com as caveiras, ou da onde elas vem. Enfim, melhor parar de pensar nisso.";

        }if(botaoEscolhido == 17)
        {
            OnomoDisc.text = "Onomo Som\n\n<color=#beb500>Habilidade</color>: Deixa um onomo mais relaxado ou animado por um período tocando a música favorita dele. Afeta todos os Onomos.\n\n Festeiro, barulhento, e sempre sabe a sua musica preferida.";

        }if(botaoEscolhido == 18)
        {
            OnomoDisc.text = "Onomo Polvo\n\n<color=#beb500>Habilidade</color>:Fica invisível aparecendo um pouco há frente na pista. \n \n Muito inteligentes e malandros. Tão esperto que não sabemos como ficam invisível. Gostam de irritar os Onomos lula.";

        }if(botaoEscolhido == 19)
        {
            OnomoDisc.text = "Onomo Létrico\n\n<color=#beb500>Habilidade</color>: Paralisa oponentes por um período de tempo.Não afeta: Onomo Létrico/Gelo/Pedra. \n \nUm dos menores onomos existentes, flutua no meio de uma onda de choque que geralmente acerta quem está por perto.";

        }if(botaoEscolhido == 20)
        {
            OnomoDisc.text = "Onomo Lava\n\n<color=#beb500>Habilidade</color>: Da um dash de lava.\n \nRetém o calor em seu núcleo, não queimando tudo ao seu redor. A única teoria aceita por enquanto. ";

        }if(botaoEscolhido == 21)
        {
            OnomoDisc.text = "Onomo Grego\n\n<color=#beb500>Habilidade</color>:Atrai um Onomo para perto do calor reconfortante. Não afeta: Onomo lava/fogo/fogo grego.\n \nUm fogo eterno... E verde. Geralmente procuram locais fechados para relaxar como fogões. São uma ótima fonte de calor. ";

        }if(botaoEscolhido == 22)
        {
            OnomoDisc.text = "Onomo Bola\n\n<color=#beb500>Habilidade</color>: Trava um pouco atrás de um Onomo escolhido por um tempo. Não afeta: Onomo futebola/bola/ praia.\n \n É só o onomo azul em um formato diferente, e mais rápido. Não sei porque deram outro nome.";

        }if(botaoEscolhido == 23)
        {
            OnomoDisc.text = "Onomo Praia\n\n<color=#beb500>Habilidade</color>:No meio da corrida se joga e trava em um Onomo fazendo ele e a si mesmo desacelerar com o impacto. Não afeta: Onomo futebola/bola/ praia.\n \n Encontrados nas praias e amam se jogar nas pessoas e Onomos em alta velocidade.";

        }if(botaoEscolhido == 24)
        {
            OnomoDisc.text = "Onomo VidaMelo\n\n<color=#beb500>Habilidade</color>: Desacelera a si mesmo enquanto todos os outros Onomos aceleram. Afeta todos os Onomos.\n \nO de bom coração. Seus esporos são medicinais e ajudam a revigorar força de outros Onomos, mas o preço é sua própria força.";

        }if(botaoEscolhido == 25)
        {
            OnomoDisc.text = "Onomo Nitro\n\n<color=#beb500>Habilidade</color>:Da um dash e atrai todos os Onomos para perto.\n \nRelaxado e veloz, muito veloz. Ainda é quentinho pelo menos, mas boa sorte para alcança-lo. ";

        }if(botaoEscolhido == 26)
        {
            OnomoDisc.text = "Onomo Metal\n\n<color=#beb500>Habilidade</color>: Atrai todos os Onomos para perto de si.\n \nFeito de um metal desconhecido, tem propriedades \"magnéticas\" estranhas, podendo atrair coisas para perto de si ";

        }if(botaoEscolhido == 27)
        {
            OnomoDisc.text = "Onomo Planta\n\n<color=#beb500>Habilidade</color>:Paralisam todos os Onomos da corrida temporariamente. Não afeta: Onomo Nitro/Sol/NuvemDourada.\n \nCom raízes fortes, consegue espalha-las pela terra e controlar sua trajetória. São muito sérios e gostam de tomar Sol. ";

        }if(botaoEscolhido == 28)
        {
            OnomoDisc.text = "Onomo NuvemDourada\n\n<color=#beb500>Habilidade</color>:Gera um tornado que muda todos os Onomos de lugar aleatoriamente.\n \n Leve e caótico. Se tudo está perdido, faça vários tornados e vai dar tudo certo. Ou tudo errado, faz parte da diversão.";

        }if(botaoEscolhido == 29)
        {
            OnomoDisc.text = "Onomo FuteBola\n\n<color=#beb500>Habilidade</color>:Trava na um pouco atrás de um Onomo escolhido por um tempo, acelerando os dois. Não afeta: Onomo futebola/bola/ praia.\n \n Dizem que ele invadia estádios de futebol se disfarçando da bola, e lá aprendeu a marcar outros onomos ficando colado atrás deles. ";

        }if(botaoEscolhido == 30)
        {
            OnomoDisc.text = "Onomo Terror\n\n<color=#beb500>Habilidade</color>: Assusta um Onomo para longe de si, acelerando se estiver na frente ou fazendo ele dar ré se estiver atrás, e a si mesmo desacelerando. Afeta todos os Onomos.\n \nMedonho e horrendo. Ver um presencialmente é uma experiência aterrorizante, até para ele mesmo. ";

        }if(botaoEscolhido == 31)
        {
            OnomoDisc.text = "Onomo MarioMelo\n\n<color=#beb500>Habilidade</color>: Afeta todos os Onomos da corrida fazendo eles se moverem aleatoriamente. Não afeta: Onomo Vidamelo/Sol/Nitro.\n \n Sofrem por não são imunes aos próprios esporos alucinantes super contagiosos. ";

        }if(botaoEscolhido == 32)
        {
            OnomoDisc.text = "Onomo Sol\n\n<color=#beb500>Habilidade</color>: Cega todos os Onomos atrás dele com uma emissão Solar, paralisando todos).\n \n Sol, o mais chamativo dos Onomos. Consegue emitir luzes capazes de cegar alguém(na sua força mínima).";

        }

        
        /*if (randy != 5)
        {
            botoesimagens[5].sprite = botoesimagens[randy].sprite;
            botoesimagens[randy].sprite = player.GetComponentInChildren<SpriteRenderer>().sprite;
        }*/
        //else
        //{
            
        //}
        

    }
       
       //Botões que escolhem o onomo para apostar
    public void OnomoApostado(int botaoApostado)
    {
        Apostadonumero = botaoApostado;
        
       if(Apostadonumero==1){
        /*if(randy==0)
        {   
            apostado=player;
        }
        else if(randy!=0)*/
        //{ 
            apostado=NPCS[0];

            imagemapostado.sprite = NPCS[Apostadonumero-1].GetComponent<SpriteRenderer>().sprite;

            
            
        //}
        
            Botões[0].interactable = false;
            Botões[1].interactable = true;
            Botões[2].interactable = true;
            Botões[3].interactable = true;
            Botões[4].interactable = true;
            Botões[5].interactable = true;
         
        

       } 

       if(Apostadonumero==2){
        /*if(randy==1){   
            apostado=player;
        }
        else if(randy!=1)*/
        //{
            
            apostado=NPCS[1];
            imagemapostado.sprite = NPCS[1].GetComponent<SpriteRenderer>().sprite;
        //}
            Botões[0].interactable = true;
            Botões[1].interactable = false;
            Botões[2].interactable = true;
            Botões[3].interactable = true;
            Botões[4].interactable = true;
            Botões[5].interactable = true;
       }

       if(Apostadonumero==3){
        /*if(randy==2){   
            apostado=player;
        }
        else if(randy!=2)*/
        //{
            
            apostado=NPCS[2];
            imagemapostado.sprite = NPCS[2].GetComponent<SpriteRenderer>().sprite;
        //}
            Botões[0].interactable = true;
            Botões[1].interactable = true;
            Botões[2].interactable = false;
            Botões[3].interactable = true;
            Botões[4].interactable = true;
            Botões[5].interactable = true;


       }

       if(Apostadonumero==4){
        /*if(randy==3){   
            apostado=player;

        }
        else if(randy!=3)*/
        //{
            
            apostado=NPCS[3];
            imagemapostado.sprite = NPCS[3].GetComponent<SpriteRenderer>().sprite;
        //}

            Botões[0].interactable = true;
            Botões[1].interactable = true;
            Botões[2].interactable = true;
            Botões[3].interactable = false;
            Botões[4].interactable = true;
            Botões[5].interactable = true;


       }
       
       if(Apostadonumero==5){
        /*if(randy==4){   
            apostado=player;
        }
        else if(randy!=4)*/
        //{
            
            apostado=NPCS[4];
            imagemapostado.sprite = NPCS[4].GetComponent<SpriteRenderer>().sprite;
        //}

            Botões[0].interactable = true;
            Botões[1].interactable = true;
            Botões[2].interactable = true;
            Botões[3].interactable = true;
            Botões[4].interactable = false;
            Botões[5].interactable = true;




       }
       //troca do player
       if(Apostadonumero==6){
           /*if(randy==0)
           {
               apostado=pistas[0].onomo;
           } 
           if(randy==1)
           {
               apostado=pistas[1].onomo;
           }
           if(randy==2)
           {
               apostado=pistas[2].onomo;
           }
           if(randy==3)
           {
               apostado=pistas[3].onomo;
           } 
           if(randy==4)
           {
               apostado=pistas[4].onomo;
           }*/
           //if(randy==5)
           //{
               apostado=player;
               imagemapostado.sprite = player.GetComponentInChildren<SpriteRenderer>().sprite;
           //}

            Botões[0].interactable = true;
            Botões[1].interactable = true;
            Botões[2].interactable = true;
            Botões[3].interactable = true;
            Botões[4].interactable = true;
            Botões[5].interactable = false;
        
       }

            

    }

  

    //Colisor para definir a posição pela linha de chegada
    /* void OnCollisionEnter2D(Collision2D collision)
    {  
       // if (collision.gameObject.tag == "Onomo")
        //{
            
            
          //  collision.gameObject.SendMessage("ApplyDamage", 10);
        //}  
        lugar++;              
        
        if(collision.gameObject.tag == "pista1"){
            pistas[0].onomo.GetComponent<OnomoStatus>().podio = lugar;
            
        }
        if(collision.gameObject.tag == "pista2"){
            pistas[1].onomo.GetComponent<OnomoStatus>().podio = lugar;
            
        }
        if(collision.gameObject.tag == "pista3"){
            pistas[2].onomo.GetComponent<OnomoStatus>().podio = lugar;
            
        }
        if(collision.gameObject.tag == "pista4"){
            pistas[3].onomo.GetComponent<OnomoStatus>().podio = lugar;
            
        }
        if(collision.gameObject.tag == "pista5"){
            pistas[4].onomo.GetComponent<OnomoStatus>().podio = lugar;
             
        }
        if(collision.gameObject.tag == "pista6"){
            pistas[5].onomo.GetComponent<OnomoStatus>().podio = lugar;
             
        }
        //pistas[].onomo.GetComponent<OnomoStatus>().podio = lugar;
        //pistas[0].onomo.Get
        //OnomosStatus.podio=lugar;
    } */ 

    
    
    
    

    public void RetornoP(int [] pista)
    {
        
        
        
        while(true)
        {
        for(int i = 0; i>5; i++)
        {
           pista[i] = Random.Range(0,4);
           //n = pista[0];
            //for(int i = 0; i<6; i++)
            //{
                if(pista[0]!=pista[1] && pista[0]!=pista[2] && pista[0]!=pista[3] && pista[0]!=pista[4] && pista[1]!=pista[2] && pista[1]!=pista[3] && pista[1]!=pista[4] && pista[2]!=pista[3] && pista[2]!=pista[4] && pista[3]!=pista[4])
                {
                    break;
                }
            //}



        }
        }

    }

    public void novojogo()
    {
        
        listOnomos = gm.GetOnomos();
        player.GetComponentInChildren<SpriteRenderer>().sortingOrder = 60;
        player.GetComponentInChildren<OnomoStatus>().pista = 6;
        player.tag = "pista6";

        botoesimagens[5].sprite = player.GetComponentInChildren<SpriteRenderer>().sprite;
        player.GetComponentInChildren<OnomoStatus>().BPista = HABI.BPistas[5];
        
        randy = Random.Range(0, 5);
        replay = 1;

        Botões[0].interactable = true;
        Botões[1].interactable = true;
        Botões[2].interactable = true;
        Botões[3].interactable = true;
        Botões[4].interactable = true;
        Botões[5].interactable = true;

        Apostadonumero = 0;

        
        
        
        
        
        foreach (Pista p in pistas)
        {
            

            p.onomo = listOnomos.GetOnomos(replay);

            

            botoesimagens[replay-1].sprite = p.onomo.GetComponent<SpriteRenderer>().sprite;
            Popularidade[replay-1].text = p.onomo.GetComponent<OnomoStatus>().popularidade.ToString();
            p.onomo.GetComponent<OnomoStatus>().BPista = HABI.BPistas[replay-1];

            

            //GameObject instanceOnomo = Instantiate(onomo, p.NPCSpawnPoint.transform.position, Quaternion.identity, p.NPCSpawnPoint.transform);

            //p.onomo = instanceOnomo;

            

            if(replay == 1)
            {
            pistas[0].onomo.tag = "pista1";
            pistas[0].onomo.GetComponent<OnomoStatus>().pista = replay;
            pistas[0].onomo.GetComponent<SpriteRenderer>().sortingOrder = 10;
             
            }
            if(replay == 2)
            {
            pistas[1].onomo.tag = "pista2";
            pistas[1].onomo.GetComponent<OnomoStatus>().pista = replay;
            pistas[1].onomo.GetComponent<SpriteRenderer>().sortingOrder = 20;
            
             
            }
            if(replay == 3)
            {
            pistas[2].onomo.tag = "pista3";
            pistas[2].onomo.GetComponent<OnomoStatus>().pista = replay;
            pistas[2].onomo.GetComponent<SpriteRenderer>().sortingOrder = 30;
            
             
            }   
            if(replay == 4)
            {
            pistas[3].onomo.tag = "pista4";
            pistas[3].onomo.GetComponent<OnomoStatus>().pista = replay;
            pistas[3].onomo.GetComponent<SpriteRenderer>().sortingOrder = 40;
            
             
            }
            if(replay == 5)
            {
            pistas[4].onomo.tag = "pista5";
            pistas[4].onomo.GetComponent<OnomoStatus>().pista = replay;
            pistas[4].onomo.GetComponent<SpriteRenderer>().sortingOrder = 50;
            
             
            }
            
            replay++;
            DezdeDez=DezdeDez+10;
        }

    

        
        //Onde ira colocar o corredor no scriptbleObject para serem postos na corrida
       

        
        
        /*if (randy != 5)
        {
            botoesimagens[5].sprite = botoesimagens[randy].sprite;
            botoesimagens[randy].sprite = player.GetComponentInChildren<SpriteRenderer>().sprite;
            
            player.GetComponentInChildren<SpriteRenderer>().sortingOrder = pistas[randy].GetComponentInChildren<SpriteRenderer>().sortingOrder;
            pistas[randy].GetComponentInChildren<SpriteRenderer>().sortingOrder = 50;

            player.transform.position = pistas[randy].transform.position;
            pistas[randy].transform.position = vPlayer;

            player.tag = pistas[randy].onomo.tag;
            pistas[randy].onomo.tag = "pista6";

            pistas[randy].onomo.GetComponent<OnomoStatus>().pista = player.GetComponent<OnomoStatus>().pista;
            pistas[randy].onomo.GetComponent<OnomoStatus>().pista = 6;

            
            

        }
        if (randy == 5)
        {
            player.transform.position = vPlayer;
            
        }*/

        

    }
    

    //Setar o numero na fase
    public void SetInt(string Keyname, int Value)
    {
        PlayerPrefs.SetInt(Keyname, Value);
    }
    
    
    //pegar o numero da fase
    public int Getint(string KeyName)
    {
        return PlayerPrefs.GetInt(KeyName);
    }
    
    //Setar a palavra na fase
    public void SetString(string KeyName, string Value)
    {
        Debug.Log("Pistas: " + Value);
        PlayerPrefs.SetString(KeyName, Value);

    }

    //pegar a palavra da fase
    public string GetString(string KeyName)
    {
        Debug.Log("Pistas: " + PlayerPrefs.GetString(KeyName) + KeyName);
        return PlayerPrefs.GetString(KeyName);
    }
    
    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        //collision.tag = "Untagged";
        Debug.Log(" DeeeeeeeeeDeeeeeeeeDeeeeeee");
        pos=Random.Range(0, list.length)
        random = list[pos]
        List.deleteAtIndex(pos)


        
    }*/

    //box1 Status++ posicao=0 pista.[posicao]onomo.podio=status
    //box2 Status++ posicao=1 pista.[posicao]onomo.podio=status
    //box3 Status++ posicao=2 pista.[posicao]onomo.podio=status
    //box4 Status++ posicao=3 pista.[posicao]onomo.podio=status
    //box5 Status++ posicao=4 pista.[posicao]onomo.podio=status
    //box6 Status++ posicao=5 pista.[posicao]onomo.podio=status


}

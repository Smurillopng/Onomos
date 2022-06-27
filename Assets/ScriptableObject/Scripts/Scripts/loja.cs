using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class loja : MonoBehaviour
{
    public List<GameObject> compraveis;
    public List<Sprite> sprites;

    public Image[] imagensdebotõesdesfase1;
    public Image[] imagensdebotõesdesfase2;
    public Image[] imagensdebotõesdesfase3;

    public int totalfase1;
    public int totalfase2;
    public int totalfase3;

    public Text Money;
    
    public Button[] Botõesfase1;
    public Button[] Botõesfase2;
    public Button[] Botõesfase3;
    public Button[] BotõesPlayer;

    [SerializeField] Image Spowpont;

    public Image[] BotõesCole;
    public PistaProperties listPlayer;
    public int pagamento;
    public int qual;
    public int faseAtual;

    public GameManager Gm;
   
    // Start is called before the first frame update
    void Start()
    {
        Money.text = "00 Ml";
        totalfase1 = imagensdebotõesdesfase1.Length;
        totalfase2 = imagensdebotõesdesfase2.Length;
        totalfase3 = imagensdebotõesdesfase3.Length;
        faseAtual = 1;

        for(int i = 0; i<33; i++)
        {

        
        BotõesPlayer[i].interactable = false;
        }
        BotõesPlayer[0].interactable = true;
        
        
    }

    // Update is called once per frame
    void Update()
    {

        faseAtual = Gm.FASE;
        if(faseAtual == 2)
        {
            for(int i = 0; i<imagensdebotõesdesfase2.Length; i++)
            {
                imagensdebotõesdesfase2[i].sprite = compraveis[totalfase1+i].GetComponent<SpriteRenderer>().sprite;
                Botõesfase2[i].interactable = true;
            }


        }

        if(faseAtual == 3)
        {
            for(int i = 0; i<imagensdebotõesdesfase3.Length; i++)
            {
                imagensdebotõesdesfase3[i].sprite = compraveis[totalfase2+totalfase1+i].GetComponent<SpriteRenderer>().sprite;
                Botõesfase3[i].interactable = true;
            }
            
        }

    }

     public void testetrocafase()
     {
        faseAtual++;
     }


    public void BuyOnomo()
    {
        if(listPlayer.Repetido(compraveis[qual], qual))
        {
            Money.text = "ja comprado";
            Debug.Log("Ja foi comprado");
        }
        else if(pagamento<Gm.totalMoney)
        {
        listPlayer.GetPlayer(compraveis[qual], qual);
        Debug.Log("comprado");
        Gm.totalMoney=Gm.totalMoney-pagamento;
        BotõesPlayer[qual].interactable = true;
        BotõesCole[qual].GetComponentInChildren<Image>().sprite = compraveis[qual].GetComponent<SpriteRenderer>().sprite;
        Money.text = "comprado";//escrever comprado
        
        }
        else if(pagamento==Gm.totalMoney)
        {
         Money.text = "Voce quer falir?";
        
        }
        else
        {
            Money.text = "Não tem dinheiro suficiente";
            Debug.Log("Não tem dinheiro");
        }
                

    }
    

    public void selecionarOnomo(int Qual)
    {
        qual = Qual;


        Spowpont.sprite = sprites[qual];
        //pagamento=Pagamento;
        

        pagamento = compraveis[qual].GetComponent<OnomoStatus>().preço;
        Money.text = compraveis[qual].GetComponent<OnomoStatus>().preço.ToString();
        
    }
    /*public void pagamentoOnomo(int Pagamento)
    {
        //Spowpont.sprite = sprites[qual];
        pagamento=Pagamento;
        Money.text = pagamento.ToString();
        
    }*/
}

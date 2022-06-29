using UnityEngine;
using UnityEngine.UI;

public class ApostaManager : MonoBehaviour
{
    public int chooseBet = 3;
    public int chooseSlime;
    public int moneyPrice;
    public int firstPlace;
    public int secondPlace;
    public int betMoney;
    public Text text;
    public Text priceMoney;
    public Text apostexto;
    public Text loko;
    public bool confirm = true;
    public PreCorridaManager preCorrida;
    public CorridaManager corrida;
    public GameObject apostado;
    public GameManager gm;
    public Button[] bottõesApostas;
    public int chancePerc;

    private void Start()
    {
        chooseBet = 3;
        text.text = "0ml";

        //chooseBet = PlayerPrefs.GetInt("ChooseBet");
        if (preCorrida == null)
        {
            preCorrida = GetComponent<PreCorridaManager>();
        }

        if (corrida == null)
        {
            corrida = GetComponent<CorridaManager>();
        }
    }

    private void Update()
    {
        if (preCorrida.apostado != null)
        {
            apostado = preCorrida.apostado;
            if (confirm)
            {
                chancePerc = apostado.GetComponent<OnomoStatus>().popularidade;//Colocar nos botões de escolha de apopsta
                                                                               //Coloca o onomo apostado se a referencia dele for nula
            }
        }
        loko.text = 0 < betMoney ? "To Não" : "To Loko";
        //Vai comparar o onomo a pista no OnomoStatus dos Onomos ate achar o mesmo e depois atualizar ele para assim conseguir o Podio dele ou posição
    }

    public void MakeFinalBet(int escolha)
    {
        chooseBet = escolha;
        switch (escolha)
        {
            case 1:
                bottõesApostas[0].interactable = false;
                bottõesApostas[1].interactable = true;
                bottõesApostas[2].interactable = true;
                apostexto.text = "Esse é o tipo convencional de aposta onde voce coloca uma certa quantidade na aposta e caso o corredor que voce escolheu fique em primeiro voce ira resceber sua recopensa.";
                break;
            case 0:
                bottõesApostas[0].interactable = true;
                bottõesApostas[1].interactable = false;
                bottõesApostas[2].interactable = true;
                apostexto.text = "Esse é a aposta mais segura que pode ser feita onde no terceiro, segundo e primeiro lugar voce podera ganhar ainda assim ate que quanto menor a posição menor o ganho ate chegar no quarto lugar onde nele voce tera perca minima ate o sexto lugar onde vai ter perda maxima.";
                break;
            case -1:
                bottõesApostas[0].interactable = true;
                bottõesApostas[1].interactable = true;
                bottõesApostas[2].interactable = false;
                apostexto.text = "Essa é a aposta mais complicada onde voce tem que escolher o corredor que ira cair em terceira ou quarta posição, mas saiba que nessa aposta o ganha é muito maior so que a quantidade que voce apostar sera aumentada e a perda sera maior.";
                break;
        }
    }

    //botão que aumenta para direita com 10 +
    public void BetMoneyRight10()
    {
        betMoney += 10;
        if (gm.totalMoney < betMoney)
        {
            betMoney -= 10;
        }
        text.text = betMoney.ToString() + "ml";
    }

    public void BetMoneyLeft10()
    {
        betMoney -= 10;
        if (betMoney < 0)
        {
            betMoney = 0;
        }
        text.text = betMoney.ToString() + "ml";
    }

    //Somar 100 e completar o valor total, ou não completar caso passe de 100
    //Ex: 150 aumenta para 200, ou não aumenta pq estouraria o limite 
    public void BetMoneyRight100()
    {
        betMoney += 100;
        if (gm.totalMoney < betMoney)
        {
            betMoney -= 100;
        }
        text.text = betMoney.ToString() + "ml";
    }

    public void BetMoneyLeft100()
    {
        betMoney -= 100;
        if (betMoney < 0)
        {
            betMoney = 0;
        }
        text.text = betMoney.ToString() + "ml";
    }

    public void ToLoko()
    {
        if (0 < betMoney)
        {
            betMoney = 0;
            loko.text = "To loko";
        }
        else
        {
            betMoney = gm.totalMoney;
            loko.text = "To Não";
        }
        text.text = betMoney.ToString() + "ml";
    }

    //BetManager
    public void BetCalculator()
    {
        switch (chooseBet)
        {
            case 1:
                Debug.Log("teste1" + apostado + apostado.GetComponent<OnomoStatus>().podio);
                FirsBet(betMoney, chancePerc);
                break;
            case 0:
                FirstSecondBet(betMoney, chancePerc);
                break;
            case -1:
                Exac(betMoney, chancePerc);
                break;
        }
        //if (ChooseBet == 1)
        //{
        //    Debug.Log("teste1"+Apostado+Apostado.GetComponent<OnomoStatus>().podio);
        //   FirsBet(Gm.totalMoney, BetMoney, ChancePerc);
        //}
        //if (ChooseBet == 0)
        //{
        //    FirstSecondBet(Gm.totalMoney, BetMoney, ChancePerc);
        //}
        //if (ChooseBet == -1)
        //{
        //    Exac(Gm.totalMoney, BetMoney, ChancePerc);
        //}

        text.text = "00Ml";
        betMoney = 0;
        bottõesApostas[0].interactable = true;
        bottõesApostas[1].interactable = true;
        bottõesApostas[2].interactable = true;
        chooseBet = 3;
    }

    // Executa os calculos da primeira aposta e confere se foi bem sucedida
    public void FirsBet(int betMoney, int chancePerc)
    {
        Debug.Log("teste2" + apostado + apostado.GetComponent<OnomoStatus>().podio);
        if (apostado.GetComponent<OnomoStatus>().podio == 1)
        {
            if (chancePerc > 70)
            {
                moneyPrice = (betMoney * (100 - chancePerc) * 2) / 100;
                Debug.Log("venceu1");
            }
            else
            {
                moneyPrice = (betMoney * (100 - chancePerc) * 2) / 10;
                Debug.Log("venceu2");
            }
            //Gm.totalMoney = Gm.totalMoney + 4000;//MoneyPrice;
            print("Ganhou");
            gm.totalMoney += moneyPrice;
            priceMoney.text = "Você ganhou " + moneyPrice.ToString() + "ml";
            Debug.Log("venceu3" + apostado + apostado.GetComponent<OnomoStatus>().podio);
        }
        else
        {
            moneyPrice = betMoney;
            gm.totalMoney -= moneyPrice;
            print("Perdeu");
            priceMoney.text = "Você perdeu " + moneyPrice.ToString() + "ml";
            Debug.Log("perdeu1" + apostado + apostado.GetComponent<OnomoStatus>().podio);
        }
    }

    // Executa os calculos da segunda aposta e confere se foi bem sucedida
    public void FirstSecondBet(int betMoney, int chancePerc)
    {
        if (apostado.GetComponent<OnomoStatus>().podio is 1 or 2 or 3)
        {
            if (chancePerc > 70)
            {
                if (apostado.GetComponent<OnomoStatus>().podio == 1)
                {
                    moneyPrice = (betMoney * (100 - chancePerc)) / 100;
                }
                if (apostado.GetComponent<OnomoStatus>().podio == 2)
                {
                    moneyPrice = (betMoney * (100 - chancePerc)) / 100;
                }
                if (apostado.GetComponent<OnomoStatus>().podio == 3)
                {
                    moneyPrice = (betMoney * (100 - chancePerc)) / 100;
                }
            }
            else
            {
                if (apostado.GetComponent<OnomoStatus>().podio == 1)
                {
                    moneyPrice = (betMoney * (100 - chancePerc)) / 10;
                }
                if (apostado.GetComponent<OnomoStatus>().podio == 2)
                {
                    moneyPrice = (betMoney * (100 - chancePerc)) / 10;
                }
                if (apostado.GetComponent<OnomoStatus>().podio == 3)
                {
                    moneyPrice = (betMoney * (100 - chancePerc)) / 10;
                }
            }

            gm.totalMoney += moneyPrice;
            priceMoney.text = "Você ganhou " + moneyPrice.ToString() + "ml";
            Debug.Log("venceu4" + apostado + apostado.GetComponent<OnomoStatus>().podio);
        }
        else
        {
            if (apostado.GetComponent<OnomoStatus>().podio == 4)
            {
                //MoneyPrice = betMoney * ((100 - chancePerc) / 10) * 3;       
                moneyPrice = betMoney;
            }
            if (apostado.GetComponent<OnomoStatus>().podio == 5)
            {
                //MoneyPrice = betMoney * ((100 - chancePerc) / 10) * 3;       
                moneyPrice = betMoney;
            }
            if (apostado.GetComponent<OnomoStatus>().podio == 6)
            {
                moneyPrice = betMoney;
            }
            Debug.Log("perdeu2" + apostado + apostado.GetComponent<OnomoStatus>().podio);
            gm.totalMoney -= moneyPrice;
            priceMoney.text = "Você perdeu " + moneyPrice.ToString() + "ml";
        }
    }

    // Executa os calculos da terceira aposta e confere se foi bem sucedida
    public void Exac(int betMoney, int chancePerc)
    {
        if (apostado.GetComponent<OnomoStatus>().podio is 3 or 4)
        {
            if (chancePerc > 70)
            {
                moneyPrice = (betMoney * (100 - chancePerc) * 3) / 100;
            }
            else
            {
                moneyPrice = (betMoney * (100 - chancePerc) * 3) / 10;
            }
            gm.totalMoney += moneyPrice;
            Debug.Log("ganhou");
            priceMoney.text = "Você ganhou " + moneyPrice.ToString() + "ml";
        }
        else
        {
            moneyPrice = betMoney * 2;
            gm.totalMoney -= moneyPrice;
            Debug.Log("perdeu");
            priceMoney.text = "Você perdeu " + moneyPrice.ToString() + "ml";
        }
    }
}
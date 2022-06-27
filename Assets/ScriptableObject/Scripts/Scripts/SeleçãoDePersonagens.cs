using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Button))]
public class Player : MonoBehaviour
{
    private GameObject[] CharacterList;
    public PistaProperties jogador;
    public Button[] botao1;
    public Button[] botao2;
    private int characternum;
    

    private void Start()
    {
        characternum = PlayerPrefs.GetInt("CharacterSelected");

        //botao1 = new Button[botoes.transform.childCount];
        CharacterList = new GameObject[transform.childCount];

        //coloca os modelo na lista
        for(int i = 0; i<transform.childCount; i++)
        {
            CharacterList[i] = transform.GetChild(i).gameObject;
        }

        // coloca os botões na lista
        /*for (int i = 0; i < botoes.transform.childCount; i++)
        {
            botao1[i] = botoes.transform.GetChild(i).Button;
        }*/



        //Desliga o GameObject
        foreach (GameObject go in CharacterList)
        {
            go.SetActive(false);
        }


        //liga o GameObject
        if (CharacterList[characternum])
        {
            CharacterList[characternum].SetActive(true);
            botosfunciona(botao2);
        }
    }

    public void esquerda()
    {
        
        
        
        CharacterList[characternum].SetActive(false);

        characternum--;
        if(characternum < 0)
        {
            characternum = CharacterList.Length - 1;
        }


        
        CharacterList[characternum].SetActive(true);
        

        botosfunciona(botao1);
        botosfunciona(botao2);
    }

    public void direita()
    {

        
        CharacterList[characternum].SetActive(false);

        characternum++;
        if (characternum == CharacterList.Length)
        {
            characternum = 0;
        }


        
        CharacterList[characternum].SetActive(true);

        botosfunciona(botao1);
        botosfunciona(botao2);


    }


    public void botosfunciona(Button[] botao)
    {
        for (int i = 0; i < botao1.Length; i++)
        {
            if (botao[i].interactable == true)
            {

                botao[i].interactable = false;
            }
            else
            {
                botao[i].interactable = true;
             
            }
        }

    }
    public void confirmar()
    {
        PlayerPrefs.SetInt("CharacterSelected", characternum);
        SceneManager.LoadScene("fase1");
    }

}

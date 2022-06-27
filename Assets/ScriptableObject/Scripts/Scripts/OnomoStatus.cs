using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class OnomoStatus : MonoBehaviour
{
    
    public int popularidade;
    public int preço;
    public float veloMax = 1f;
    public float veloMin = 0.5f;
    public int sorte;

    public int pista;


    public int podio;

    public bool Apostado;

    public bool Chegada=true;
    public string ID;

    public Button BPista;
     
     
     
    
    public int SetPop(int pop)
    {
        pop = 0;
        return pop;
        
    }

/*
    public int popularidadeChanger(int podio, int popularidade){
        Random = Random.range(1,2);
        if(popularidade ==90 ){
            if(podio<=2){
                popularidade = 90;
                return popularidade;
            }
            if(podio>2){
                if(Random ==1){
                    popularidade = popularidade-10;
                    return popularidade;
                }
                if(Random ==2){
                    popularidade = popularidade-20;
                    return popularidade;
                }
               
            }
        }
        else{
            if(podio==1){
                 if(Random ==1){
                    popularidade = popularidade-10;
                    return popularidade;
                }
                if(Random ==2){
                    popularidade = popularidade-20;
                    return popularidade;
                }
            }
            if(podio==2){
                 if(Random ==1){
                    popularidade = popularidade-10;
                    return popularidade;
                }
                if(Random ==2){
                    popularidade = popularidade-20;
                    return popularidade;
                }
            }
            if(podio==3){
                 if(Random ==1){
                    popularidade = popularidade-10;
                    return popularidade;
                }
                if(Random ==2){
                    popularidade = popularidade-20;
                    return popularidade;
                }
            }
            if(podio==4){
                 if(Random ==1){
                    popularidade = popularidade-10;
                    return popularidade;
                }
                if(Random ==2){
                    popularidade = popularidade-20;
                    return popularidade;
                }
            }
            if(podio==5){
                 if(Random ==1){
                    popularidade = popularidade-10;
                    return popularidade;
                }
                if(Random ==2){
                    popularidade = popularidade-20;
                    return popularidade;
                }
            }
            if(podio==6){
                 if(Random ==1){
                    popularidade = popularidade-10;
                    return popularidade;
                }
                if(Random ==2){
                    popularidade = popularidade-20;
                    return popularidade;
                }
            }
        }
    }*/
     /*private int popularidadeUpdate()
    {
        
       /*Rank   Pontos  Pontos Ganhos
        1       1       -3 
        2       2       -2 
        3       3       -1 
        4       4       +1 
        5       5       +2  
        6       6       +3 */
        /* 
        if (podio == 1)
        {
            popularidade = 70;
        }

        if (podio == 2)
        {
            popularidade = 60;
        }

        if (podio == 3)
        {
            popularidade = 50;
        }

        if (podio == 4)
        {
            popularidade =  40;
        }

        if (podio == 5)
        {
            popularidade = 30;
        }

        if (podio == 6)popularidade
        {
            popularidade =  10;
        }
        if (podio == 6)
        {
            popularidade = 10;
        }
        if (podio == 6)
        {
            popularidade = 10;
        }
        return popularidade;
    }

     */
    
}

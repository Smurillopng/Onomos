using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class seguircamnew : MonoBehaviour
{/*
    #region Enums
    public enum TipoMovi //tipo de jeitos que o carro pode se mover
    {
        MoviDires,
        LerdDires
    }
    #endregion

    #region variaveis public
    public TipoMovi tipo = TipoMovi.MoviDires;//tipo de movimento
    public caminhonew caminho;//referencia do caminho
    public float velo = 1;//velocidade do movimento
    public float DistanciaMaxprox = .1f;//quão perto esta do ponto e troca para outro

    #endregion

    #region variaveis privadas
    private IEnumerator<Transform> pontocami;//usado como referencia de ponto para o proximo

    #endregion

    #region metodo principal

    public void Start()
    {
        if (caminho == null)
        {
            Debug.LogError("Não da para se mover se não tiver um caminho para isso.", gameObject);
            return;
        }

        
        pontocami = caminho.Getproximopontocaminho();
        Debug.Log(pontocami.Current);
        
        pontocami.MoveNext();
        Debug.Log(pontocami.Current);

        if (pontocami.Current == null)
        {
            Debug.LogError("A path must have points in it to follow", gameObject);
            return; //Exit Start() if there is no point to move to
        }

        transform.position = pontocami.Current.position;
    }
    public void Update()
    {
        
        if (pontocami == null || pontocami.Current == null)
        {
            return; //Exit if no path is found
        }

        if (tipo == TipoMovi.MoviDires) //If you are using MoveTowards movement type
        {
            //Move to the next point in path using MoveTowards
            transform.position = Vector3.MoveTowards(transform.position, pontocami.Current.position, Time.deltaTime * velo);
        }
        else if (tipo == TipoMovi.LerdDires) 
        {
            
            transform.position = Vector3.Lerp(transform.position, pontocami.Current.position, Time.deltaTime * velo);
        }

       
        var distanceSquared = (transform.position - pontocami.Current.position).sqrMagnitude;
        if (distanceSquared < DistanciaMaxprox * DistanciaMaxprox) 
        {
            pontocami.MoveNext(); 
        }
        
    }
    #endregion
    */
}

using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class carroeng1 : MonoBehaviour
{
    public GameObject final;

    public GameObject carro;
    public GameObject player;
    public CorridaManager corridaManager;

    private bool _correr;

    public Rigidbody2D rgdb;

    private float _distancia;

    public bool tempo;

    public OnomoStatus velonomo;

    public delegate void DelegatePowerUp();
    public DelegatePowerUp PowerUp;

    //public float speed = 5;
    [Range(0, 100), SerializeField]
    public float velo;

    [Range(0, 100), SerializeField]
    public float veloMax = 1;
    [Range(0, 100), SerializeField]
    public float veloMin = 1;

    public float time;

    public float reservaMaxima;
    public float reservaMinima;

    public Button button;

    //////////////////////////////////

    public Button[] bHabilidades;

    public Button[] botãoashabiinvo;

    public Animator aHabilidade;

    public int numeroPista;

    public float colliderX;

    public float x;

    public int randomico;

    private void Start()
    {
        carro = GetComponent<GameObject>();
        rgdb = GetComponent<Rigidbody2D>();
        _distancia = 0;
        time = 0;
        velonomo = GetComponent<OnomoStatus>();
        botãoashabiinvo = GetComponentInParent<CorridaManager>().AtivarPowerUp;
        player = GetComponentInParent<CorridaManager>().playerpista;
    }

    private void Update()
    {
        randomico = Random.Range(1, 10);
        numeroPista = GetComponentInParent<CorridaManager>().PistaArray;
        colliderX = GetComponentInParent<BoxCollider2D>().offset.x - 0.1f;

        if (tempo == false)
        {
            StartCoroutine(ContrTempo());
        }
        if (tempo == true)
        {
            if (PowerUp != null)
            {
                PowerUp();
                Debug.Log("habilidade em outro onomo1");
                botãoashabiinvo[0].interactable = false;
                Debug.Log("habilidade em outro onomo2");
                if (time > 0)
                {
                    time -= Time.deltaTime;
                }
                else
                {
                    PowerUp = null;
                    Invoke(nameof(InicializaCoolDown), 5.0f);
                    veloMax = reservaMaxima;
                    veloMin = reservaMinima;
                    velo = Random.Range(veloMin, veloMax);
                    time = 0;
                    GetComponentInParent<CorridaManager>().Habilina.SetTrigger("timerhabi");
                }
            }
            else
            {
                Mover();
            }
        }
    }

    public void StarCorrer() => _correr = true;
    
    private Vector2 Pixelvaificarlegal(Vector2 vetorfoda)
    {
        var vetornopixel = new Vector2(
            Mathf.RoundToInt(vetorfoda.x * 64),
            Mathf.RoundToInt(vetorfoda.y * 64));
        return vetornopixel / 64;
    }
    private void Mover()
    {
        velo = Random.Range(veloMin, veloMax);
        rgdb.velocity = new Vector2(velo, rgdb.velocity.y);
    }

    public void InicializaCoolDown()
    {
        GetComponentInParent<CorridaManager>().Habilina.SetTrigger("voltaencher");
        botãoashabiinvo[0].interactable = true;
    }

    private IEnumerator ContrTempo()
    {
        velo = 0;
        yield return new WaitForSecondsRealtime(5);
        tempo = true;
    }
    public void Desacelerar()//onomos azul/roxo/vermelho/verde
    {
        if (time == 0)
        {
            time = 2;
            reservaMaxima = veloMax;
            reservaMinima = veloMin;
        }
        veloMin = 0.5f;
        veloMax = 1f;
        velo = Random.Range(veloMin, veloMax);
        rgdb.velocity = new Vector2(velo, rgdb.velocity.y);
        Debug.Log("habilidade 1 executada");
    }

    public void DashMolhado()//onomo pao
    {
        if (time == 0)
        {
            time = 1f;
            reservaMaxima = veloMax;
            reservaMinima = veloMin;
        }
        if (time > 0.5)
        {
            veloMax = 4f;
            veloMin = 4f;
        }
        else
        {
            veloMax = 0;
            veloMin = 0;
        }
        velo = Random.Range(veloMin, veloMax);
        rgdb.velocity = new Vector2(velo, rgdb.velocity.y);
        Debug.Log("habilidade 2 executada");
    }

    public void DesacelerarOutros()// onomo colorido
    {
        if (time == 0)
        {
            time = 2f;
            reservaMaxima = veloMax;
            reservaMinima = veloMin;
        }
        else
        {
            veloMax = 1f;
            veloMin = 0.5f;

            velo = Random.Range(veloMin, veloMax);
            //rgdb.velocity = new Vector2(velocity, rgdb.velocity.y);
            rgdb.velocity = new Vector2(velo, rgdb.velocity.y);

            Debug.Log("habilidade 3 executada");
        }
    }

    public void Invisivel()//onomo polvo
    {
        Debug.Log("habilidade 4 executada");
        if (time == 0)
        {
            time = 0.1f;
            reservaMaxima = veloMax;
            reservaMinima = veloMin;
        }
        else
        {
            velo = player.transform.position.x + 0.1f;
            player.transform.position = new Vector2(velo, player.transform.position.y);

        }
    }


    public void DashEscorregar()//onomo agua
    {
        Debug.Log("habilidade 5 executada");
        switch (time)
        {
            case 0:
                time = 3.6f;
                reservaMaxima = veloMax;
                reservaMinima = veloMin;
                break;
            case >= 3:
                veloMin = 4;
                veloMax = 4;
                velo = Random.Range(veloMin, veloMax);
                rgdb.velocity = new Vector2(velo, rgdb.velocity.y);
                break;
            case < 3:
                veloMin = reservaMinima;
                veloMax = reservaMaxima;
                velo = Random.Range(veloMin, veloMax);
                rgdb.velocity = new Vector2(velo, rgdb.velocity.y);
                break;
        }
    }
    public void Marcacao()
    {
        Debug.Log("habilidade 6 executada");
        if (time == 0)
        {
            time = 1;
            reservaMaxima = veloMax;
            reservaMinima = veloMin;
        }
        if (player.transform.position.x <= rgdb.transform.position.x)
        {
            veloMin = -0.8f;
            veloMax = -0.6f;
            velo = Random.Range(veloMin, veloMax);
            player.GetComponent<carroeng1>().rgdb.velocity = new Vector2(velo, rgdb.velocity.y);
        }
        if (!(player.transform.position.x > rgdb.transform.position.x)) return;
        veloMin = 4;
        veloMax = 4.5f;
        velo = Random.Range(veloMin, veloMax);
        player.GetComponent<carroeng1>().rgdb.velocity = new Vector2(velo, rgdb.velocity.y);
    }
    public void MarcacaoLenta()//onomo bola/futebola/praia
    {
        Debug.Log("habilidade 6.1 executada");
        if (time == 0)
        {
            time = 1;
            reservaMaxima = veloMax;
            reservaMinima = veloMin;
        }
        veloMax = 1.6f;
        veloMin = 1.4f;

        velo = Random.Range(veloMin, veloMax);
        //rgdb.velocity = new Vector2(velocity, rgdb.velocity.y);

        rgdb.velocity = new Vector2(velo, rgdb.velocity.y);

        if (player.transform.position.x <= rgdb.transform.position.x)
        {
            veloMin = -0.8f;
            veloMax = -0.6f;
            velo = Random.Range(veloMin, veloMax);
            player.GetComponent<carroeng1>().rgdb.velocity = new Vector2(velo, rgdb.velocity.y);

        }
        if (player.transform.position.x > rgdb.transform.position.x)
        {
            veloMin = 3f;
            veloMax = 3.5f;
            velo = Random.Range(veloMin, veloMax);
            player.GetComponent<carroeng1>().rgdb.velocity = new Vector2(velo, rgdb.velocity.y);

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
        if (time == 0)
        {
            time = 1;
            reservaMaxima = veloMax;
            reservaMinima = veloMin;
        }
        veloMax = 4f;
        veloMin = 4f;

        velo = Random.Range(veloMin, veloMax);
        //rgdb.velocity = new Vector2(velocity, rgdb.velocity.y);

        rgdb.velocity = new Vector2(velo, rgdb.velocity.y);

        if (player.transform.position.x >= transform.position.x)
        {
            veloMin = -0.6f;
            veloMax = -0.2f;
            velo = Random.Range(veloMin, veloMax);
            player.GetComponent<carroeng1>().rgdb.velocity = new Vector2(velo, rgdb.velocity.y);

        }
        if (player.transform.position.x < transform.position.x)
        {
            veloMin = 4f;
            veloMax = 4.5f;
            velo = Random.Range(veloMin, veloMax);
            player.GetComponent<carroeng1>().rgdb.velocity = new Vector2(velo, rgdb.velocity.y);

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

        if (time == 0)
        {
            time = 0.5f;
            reservaMaxima = veloMax;
            reservaMinima = veloMin;
        }

        if (player.transform.position.x <= rgdb.transform.position.x)
        {
            veloMin = 3f;
            veloMax = 3.5f;
            velo = Random.Range(veloMin, veloMax);
            rgdb.velocity = new Vector2(velo, rgdb.velocity.y);

        }
        if (player.transform.position.x > rgdb.transform.position.x)
        {
            veloMin = -0.6f;
            veloMax = -0.2f;
            velo = Random.Range(veloMin, veloMax);
            rgdb.velocity = new Vector2(velo, rgdb.velocity.y);

        }


        //velo = Random.Range(velomin, velomax);
        //rgdb.velocity = new Vector2(velocity, rgdb.velocity.y);
        //RGDB.velocity = new Vector2(velo, RGDB.velocity.y);    
    }
    public void Assustar2()// Onomo caveira piche e verde
    {
        Debug.Log("habilidade 7 executada");

        if (time == 0)
        {
            time = 1f;
            reservaMaxima = veloMax;
            reservaMinima = veloMin;
        }

        if (player.transform.position.x <= rgdb.transform.position.x)
        {
            veloMin = 3f;
            veloMax = 3.5f;
            velo = Random.Range(veloMin, veloMax);
            rgdb.velocity = new Vector2(velo, rgdb.velocity.y);

        }
        if (player.transform.position.x > rgdb.transform.position.x)
        {
            veloMin = -0.6f;
            veloMax = -0.2f;
            velo = Random.Range(veloMin, veloMax);
            rgdb.velocity = new Vector2(velo, rgdb.velocity.y);

        }


        //velo = Random.Range(velomin, velomax);
        //rgdb.velocity = new Vector2(velocity, rgdb.velocity.y);
        //RGDB.velocity = new Vector2(velo, RGDB.velocity.y);    
    }
    public void Assustar3()// Onomo terror
    {
        Debug.Log("habilidade 7 executada");

        if (time == 0)
        {
            time = 1;
            reservaMaxima = veloMax;
            reservaMinima = veloMin;
        }

        if (player.transform.position.x <= rgdb.transform.position.x)
        {
            veloMin = 4f;
            veloMax = 4.5f;
            velo = Random.Range(veloMin, veloMax);
            rgdb.velocity = new Vector2(velo, rgdb.velocity.y);

        }
        if (player.transform.position.x > rgdb.transform.position.x)
        {
            veloMin = -0.8f;
            veloMax = -0.4f;
            velo = Random.Range(veloMin, veloMax);
            rgdb.velocity = new Vector2(velo, rgdb.velocity.y);

        }


        //velo = Random.Range(velomin, velomax);
        //rgdb.velocity = new Vector2(velocity, rgdb.velocity.y);
        //RGDB.velocity = new Vector2(velo, RGDB.velocity.y);    
    }

    public void Quentinho()//fogo
    {
        Debug.Log("habilidade 8 executada");

        if (time == 0)
        {
            time = 1;
            reservaMaxima = veloMax;
            reservaMinima = veloMin;
        }
        if (player.transform.position.x <= rgdb.transform.position.x)
        {
            veloMin = -0.6f;
            veloMax = -0.2f;
            velo = Random.Range(veloMin, veloMax);
            rgdb.velocity = new Vector2(velo, rgdb.velocity.y);

        }
        if (player.transform.position.x > rgdb.transform.position.x)
        {
            veloMin = 2.5f;
            veloMax = 3f;
            velo = Random.Range(veloMin, veloMax);
            rgdb.velocity = new Vector2(velo, rgdb.velocity.y);

        }


        //velo = Random.Range(velomin, velomax);
        //rgdb.velocity = new Vector2(velocity, rgdb.velocity.y);
        //RGDB.velocity = new Vector2(velo, RGDB.velocity.y);    
    }
    public void Paralisia()//gelo/pedra/elétrico/planta
    {
        Debug.Log("habilidade 9 executada");

        if (time == 0)
        {
            time = 0.5f;
            reservaMaxima = veloMax;
            reservaMinima = veloMin;
        }
        veloMin = 0;
        veloMax = 0;
        velo = Random.Range(veloMin, veloMax);
        rgdb.velocity = new Vector2(velo, rgdb.velocity.y);

        //velo = Random.Range(velomin, velomax);
        //rgdb.velocity = new Vector2(velocity, rgdb.velocity.y);
        //RGDB.velocity = new Vector2(velo, RGDB.velocity.y);    
    }
    public void Paralisia2()//gelo
    {
        Debug.Log("habilidade 9 executada");

        if (time == 0)
        {
            time = 1.5f;
            reservaMaxima = veloMax;
            reservaMinima = veloMin;
        }
        veloMin = 0;
        veloMax = 0;
        velo = Random.Range(veloMin, veloMax);
        rgdb.velocity = new Vector2(velo, rgdb.velocity.y);

        //velo = Random.Range(velomin, velomax);
        //rgdb.velocity = new Vector2(velocity, rgdb.velocity.y);
        //RGDB.velocity = new Vector2(velo, RGDB.velocity.y);    
    }
    public void Paralisia3()//pedra
    {
        Debug.Log("habilidade 9 executada");

        if (time == 0)
        {
            time = 1.5f;
            reservaMaxima = veloMax;
            reservaMinima = veloMin;
        }
        veloMin = 0;
        veloMax = 0;
        velo = Random.Range(veloMin, veloMax);
        rgdb.velocity = new Vector2(velo, rgdb.velocity.y);

        //velo = Random.Range(velomin, velomax);
        //rgdb.velocity = new Vector2(velocity, rgdb.velocity.y);
        //RGDB.velocity = new Vector2(velo, RGDB.velocity.y);    
    }
    public void Paralisia4()//planta
    {
        Debug.Log("habilidade 9 executada");

        if (time == 0)
        {
            time = 1f;
            reservaMaxima = veloMax;
            reservaMinima = veloMin;
        }
        veloMin = 0;
        veloMax = 0;
        velo = Random.Range(veloMin, veloMax);
        rgdb.velocity = new Vector2(velo, rgdb.velocity.y);

        //velo = Random.Range(velomin, velomax);
        //rgdb.velocity = new Vector2(velocity, rgdb.velocity.y);
        //RGDB.velocity = new Vector2(velo, RGDB.velocity.y);    
    }
    public void Paralisia5()//lula
    {
        Debug.Log("habilidade 9 executada");
        float r = 3;
        if (time == 0)
        {
            time = 0.5f;
            reservaMaxima = veloMax;
            reservaMinima = veloMin;
            r = Random.Range(1, 10);
        }
        if (r > 5 && r != 3)
        {
            veloMin = 0.71f;
            veloMax = 2f;
            velo = Random.Range(veloMin, veloMax);
            rgdb.velocity = new Vector2(velo, rgdb.velocity.y);
        }
        if (r <= 5 && r != 3)
        {
            veloMin = 0;
            veloMax = 0;
            velo = Random.Range(veloMin, veloMax);
            rgdb.velocity = new Vector2(velo, rgdb.velocity.y);
        }


        //velo = Random.Range(velomin, velomax);
        //rgdb.velocity = new Vector2(velocity, rgdb.velocity.y);
        //RGDB.velocity = new Vector2(velo, RGDB.velocity.y);    
    }

    public void DesacelerarBuffado()
    {//Não usada
        Debug.Log("habilidade 10 executada");

        if (time == 0)
        {
            time = 1;
            reservaMaxima = veloMax;
            reservaMinima = veloMin;
        }
        veloMin = -1.5f;
        veloMax = -2;
        velo = Random.Range(veloMin, veloMax);
        rgdb.velocity = new Vector2(velo, rgdb.velocity.y);

        //velo = Random.Range(velomin, velomax);
        //rgdb.velocity = new Vector2(velocity, rgdb.velocity.y);
        //RGDB.velocity = new Vector2(velo, RGDB.velocity.y);    
    }
    public void Confusao()
    {//melo/ melonemo/mario
        Debug.Log("habilidade 11 executada");
        randomico = Random.Range(1, 10);

        if (time == 0)
        {
            time = 1f;
            reservaMaxima = veloMax;
            reservaMinima = veloMin;
        }


        if (randomico <= 5)
        {
            veloMin = Random.Range(-4, -5);
            veloMax = Random.Range(-3, -4);

        }
        else
        {
            veloMin = Random.Range(3, 3);
            veloMax = Random.Range(3.5f, 4);

        }


        velo = Random.Range(veloMin, veloMax);
        rgdb.velocity = new Vector2(velo, rgdb.velocity.y);


        //velo = Random.Range(velomin, velomax);
        //rgdb.velocity = new Vector2(velocity, rgdb.velocity.y);
        //RGDB.velocity = new Vector2(velo, RGDB.velocity.y);    
    }

    public void Tornado()
    {//nuvem/nuvem dourada
        Debug.Log("habilidade 13 executada");

        if (time == 0)
        {
            time = 0.1f;
            reservaMaxima = veloMax;
            reservaMinima = veloMin;
        }

        x = 0;
        if (randomico <= 5)
        {
            x = rgdb.transform.position.x - 0.3f;
        }
        else
        {
            x = rgdb.transform.position.x + 0.3f;
        }

        /*
        if(ColliderX < x)
        {
            x = ColliderX - 0.01f;
        }*/

        rgdb.transform.position = new Vector2(x, rgdb.transform.position.y);

        //velo = Random.Range(velomin, velomax);
        //rgdb.velocity = new Vector2(velocity, rgdb.velocity.y);
        //RGDB.velocity = new Vector2(velo, RGDB.velocity.y);    
    }
    public void Magnetismo()
    {//metal
        Debug.Log("habilidade 14 executada");

        if (time == 0)
        {
            time = 1f;
            reservaMaxima = veloMax;
            reservaMinima = veloMin;
        }

        // for(int i = 0; i<6; i++)
        //{

        if (player.transform.position.x <= rgdb.transform.position.x)
        {

            veloMin = -0.4f;
            veloMax = -0.2f;
            velo = Random.Range(veloMin, veloMax);
            rgdb.velocity = new Vector2(velo, rgdb.velocity.y);

        }
        if (player.transform.position.x > rgdb.transform.position.x)
        {

            veloMin = 3.5f;
            veloMax = 4f;
            velo = Random.Range(veloMin, veloMax);
            rgdb.velocity = new Vector2(velo, rgdb.velocity.y);

        }
        // }
        //velo = velo + Random.Range(4,-3);
        //RGDB.velocity = new Vector2(velo, RGDB.velocity.y);

        //velo = Random.Range(velomin, velomax);
        //rgdb.velocity = new Vector2(velocity, rgdb.velocity.y);
        //RGDB.velocity = new Vector2(velo, RGDB.velocity.y);    
    }
    public void QuentinhoRapido()
    {//nitro
        Debug.Log("habilidade 15 executada");

        if (time == 0)
        {
            time = 0.5f;
            reservaMaxima = veloMax;
            reservaMinima = veloMin;
        }

        if (player.transform.position.x <= rgdb.transform.position.x)
        {
            veloMin = -0.7f;
            veloMax = -0.2f;
            velo = Random.Range(veloMin, veloMax);
            rgdb.velocity = new Vector2(velo, rgdb.velocity.y);

        }
        if (player.transform.position.x > rgdb.transform.position.x)
        {
            veloMin = 4f;
            veloMax = 3.4f;
            velo = Random.Range(veloMin, veloMax);
            rgdb.velocity = new Vector2(velo, rgdb.velocity.y);

        }
        // velomin =+ 2.1f;
        //velomax =+ 3.1f;
        //velo = Random.Range(velomin, velomax);
        //Player.GetComponent<Rigidbody2D>().velocity = new Vector2(velo, Player.GetComponent<Rigidbody2D>().velocity.y);

        //velo = Random.Range(velomin, velomax);
        //rgdb.velocity = new Vector2(velocity, rgdb.velocity.y);
        //RGDB.velocity = new Vector2(velo, RGDB.velocity.y);    
    }
    public void Acelerar()
    {//
        Debug.Log("habilidade 16 executada");

        if (time == 0)
        {
            time = 2f;
            reservaMaxima = veloMax;
            reservaMinima = veloMin;
            veloMin = veloMin + 1.1f;
            veloMax = veloMax;
        }

        velo = Random.Range(veloMin, veloMax);
        rgdb.velocity = new Vector2(velo, rgdb.velocity.y);

        //velo = Random.Range(velomin, velomax);
        //rgdb.velocity = new Vector2(velocity, rgdb.velocity.y);
        //RGDB.velocity = new Vector2(velo, RGDB.velocity.y);    
    }
    public void ConfusaoArea()
    {
        Debug.Log("habilidade 17 executada");

        if (time == 0)
        {
            time = 0.2f;
            reservaMaxima = veloMax;
            reservaMinima = veloMin;
        }
        veloMin = +1.1f;
        veloMax = +2.1f;

        rgdb.velocity = new Vector2(velo, rgdb.velocity.y);

        //velo = Random.Range(velomin, velomax);
        //rgdb.velocity = new Vector2(velocity, rgdb.velocity.y);
        //RGDB.velocity = new Vector2(velo, RGDB.velocity.y);    
    }
    public void DarPassagem()
    {//vidamelo
        Debug.Log("habilidade 17 executada");

        if (time == 0)
        {
            time = 0.2f;
            reservaMaxima = veloMax;
            reservaMinima = veloMin;
        }
        veloMin = 3.6f;
        veloMax = 5f;
        rgdb.velocity = new Vector2(velo, rgdb.velocity.y);

        //velo = Random.Range(velomin, velomax);
        //rgdb.velocity = new Vector2(velocity, rgdb.velocity.y);
        //RGDB.velocity = new Vector2(velo, RGDB.velocity.y);    
    }
    public void TornadoArea()
    {
        Debug.Log("habilidade 17 executada");

        if (time == 0)
        {
            time = 0.2f;
            reservaMaxima = veloMax;
            reservaMinima = veloMin;
        }
        veloMin = +1.1f;
        veloMax = +2.1f;
        rgdb.velocity = new Vector2(velo, rgdb.velocity.y);

        //velo = Random.Range(velomin, velomax);
        //rgdb.velocity = new Vector2(velocity, rgdb.velocity.y);
        //RGDB.velocity = new Vector2(velo, RGDB.velocity.y);    
    }

    public void Cegar()
    {
        Debug.Log("habilidade do Sol executada");

        if (time == 0)
        {
            time = 0.5f;
            reservaMaxima = veloMax;
            reservaMinima = veloMin;
        }
        if (player.transform.position.x > rgdb.transform.position.x)
        {
            veloMin = 0f;
            veloMax = 0f;
        }

        rgdb.velocity = new Vector2(velo, rgdb.velocity.y);

        //velo = Random.Range(velomin, velomax);
        //rgdb.velocity = new Vector2(velocity, rgdb.velocity.y);
        //RGDB.velocity = new Vector2(velo, RGDB.velocity.y);    
    }
    public void Nitro()//onomo nitro
    {
        Debug.Log("habilidade 5 executada");

        if (time == 0)
        {
            time = 3.6f;
            reservaMaxima = veloMax;
            reservaMinima = veloMin;
        }
        if (time >= 3)
        {
            veloMin = 5;
            veloMax = 5;
            velo = Random.Range(veloMin, veloMax);
            rgdb.velocity = new Vector2(velo, rgdb.velocity.y);
        }
        if (time < 3)
        {
            veloMin = reservaMinima;
            veloMax = reservaMaxima;
            velo = Random.Range(veloMin, veloMax);
            rgdb.velocity = new Vector2(velo, rgdb.velocity.y);
        }

        //velo = Random.Range(velomin, velomax);
        //rgdb.velocity = new Vector2(velocity, rgdb.velocity.y);
        //RGDB.velocity = new Vector2(velo, RGDB.velocity.y);    
    }
}
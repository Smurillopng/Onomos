using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PontosAColocar : MonoBehaviour
{
    Text text;

    public static int totalMoney = 100;

    private void Start()
    {
        text = GetComponent<Text>();

    }

    private void Update()
    {
        text.text = totalMoney.ToString();
    }
}

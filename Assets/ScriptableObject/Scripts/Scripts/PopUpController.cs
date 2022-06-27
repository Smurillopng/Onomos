using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PopUpController : MonoBehaviour
{
    public GameObject PopUpBox;
    public Animator animator;
    public TMP_Text popUpTexte;

    public void PopUp(string text)
    {
        PopUpBox.SetActive(true);
        popUpTexte.text = text;
        animator.SetTrigger("open");
    }

    



}

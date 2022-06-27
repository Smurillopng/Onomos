using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Menu_Config : MonoBehaviour
{
    public AudioMixer audioMixer;
    public float soundB;

    //audio sources das fazes
    public AudioSource faseM;
    


    //Musicas das fases
    public AudioClip Fase1Audio;
    public AudioClip Fase2Audio;
    public AudioClip Fase3Audio;

    //GameManager para pegar o dinheiro
    public GameManager GM;

    Resolution [] resolutions;

    public Dropdown resolutionsDropdown;



    //Volume
    public void Start()
    {
      faseM.clip = Fase1Audio;
      faseM.Play();

     
      soundB = PlayerPrefs.GetFloat ("playerVolume");
      
      

      audioMixer.SetFloat("volume", soundB);


      resolutions = Screen.resolutions;
      

      

      resolutionsDropdown.ClearOptions();

      List<string> options = new List<string>();

      int CurrentResolutionIndex = 0;

      for(int i = 0; i < resolutions.Length; i++)
      {
        string option = resolutions[i].width + "x" + resolutions[i].height + "x" + resolutions[i].refreshRate;
        Debug.Log(resolutions[i].width + "x" + resolutions[i].height + " : " + resolutions[i].refreshRate);

        if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
        {
          CurrentResolutionIndex = i;
        }

        options.Add(option);
      }

      resolutionsDropdown.AddOptions(options);
      resolutionsDropdown.value = CurrentResolutionIndex;
      resolutionsDropdown.RefreshShownValue();
      

    }

    public void Update(){
      soundB = PlayerPrefs.GetFloat ("playerVolume");
     
      

      audioMixer.SetFloat("volume", soundB);
      SetFaseMusic ();

    }

    public void SetResolution(int resolutionIndex)
    {

      Resolution resolution = resolutions[resolutionIndex];

      Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);


      

    }

    public void SetFaseMusic ()
    {
      if(GM.FASE == 1)
      {

        faseM.clip = Fase1Audio; 
        if(!faseM.isPlaying)
        {

          faseM.Play();

        }
        


      }


      if(GM.FASE == 2)
      {

        faseM.clip = Fase2Audio; 
        if(!faseM.isPlaying)
        {

          faseM.Play();

        }
        


      }

      if(GM.FASE == 3)
      {

        faseM.clip = Fase3Audio; 
        if(!faseM.isPlaying)
        {

          faseM.Play();

        }
        
        

      }
      

    }


    //Para setar o volume e mudar de fase em fase
    public void SetVolume (float volume)
		{
      soundB = volume;

    	audioMixer.SetFloat("volume", volume);
      PlayerPrefs.SetFloat ("playerVolume", soundB);
		}
    
    //Fullscreen
    public void SetFullscreen (bool isFullscreen)
    {
    	Screen.fullScreen = isFullscreen;
    }
}

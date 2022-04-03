using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SettingManager : MonoBehaviour
{
    [SerializeField]
    Slider masterVolume;

    [SerializeField]
    Slider musicVolume;

    [SerializeField]
    Slider sfxVolume;


    // Start is called before the first frame update
    void Start()
    {
        SoundManager.instance.changeMasterVolume(masterVolume.value);
        masterVolume.onValueChanged.AddListener(val => SoundManager.instance.changeMasterVolume(val));

        SoundManager.instance.changeMusicVolume(musicVolume.value);
        musicVolume.onValueChanged.AddListener(val => SoundManager.instance.changeMusicVolume(val));

        SoundManager.instance.changeSFXVolume(sfxVolume.value);
        sfxVolume.onValueChanged.AddListener(val => SoundManager.instance.changeSFXVolume(val));
    }

    

}

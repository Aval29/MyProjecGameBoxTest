using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;


public class Audio : MonoBehaviour
{

    /// <summary>
    /// звук —нежинки
    /// </summary>
    [SerializeField] private AudioSource AudioSnowFlake ;
    /// <summary>
    /// звук —нежок
    /// </summary>
    [SerializeField] private AudioSource AudioSnowBoll;
    /// <summary>
    /// звук дерево топор
    /// </summary>
    [SerializeField] private AudioSource AudioWoodAxe;
    /// <summary>
    /// звук ќгонь 1
    /// </summary>
    [SerializeField] private AudioSource AudioFire1;
    /// <summary>
    /// звук ќгонь 2
    /// </summary>
    [SerializeField] private AudioSource AudioFire2;
    /// <summary>
    /// звук ќгонь 3
    /// </summary>
    [SerializeField] private AudioSource AudioFire3;




    /// <summary>
    /// музыка 
    /// </summary>
    [SerializeField] private AudioSource MusicBack;



    /// <summary>
    /// јудио миксер Ёффектов
    /// </summary>
    [SerializeField] private AudioMixerGroup MixerEffects;
    /// <summary>    /// јудио миксер ћузыка     /// </summary>
    [SerializeField] private AudioMixerGroup MixerMusic;

    /// <summary>  отключить музыку    /// </summary>
    [SerializeField] private bool _muteMusic;
    /// <summary>  отключить «вуки    /// </summary>
    [SerializeField] private bool _muteSound;
    /// <summary>    ///  нопка «вук     /// </summary>
    //[SerializeField] private GameObject _objButtonMusic;
    /// <summary>   ///  нопка эффекты    /// </summary>
    //  [SerializeField] private GameObject _objButtonSound;









    public void ClickMuteMusic()
    {
        if (_muteMusic == false)
        {
            MixerMusic.audioMixer.SetFloat("MusicVolume", -80);
            _muteMusic = true;
        }
        else
        {
            MixerMusic.audioMixer.SetFloat("MusicVolume", 0);
            _muteMusic = false;
        }


    }

    public void ClickMuteEffects()
    {
        if (_muteSound == false)
        {
            MixerEffects.audioMixer.SetFloat("EffectsVolume", -80);
            _muteSound = true;
        }
        else
        {
            MixerEffects.audioMixer.SetFloat("EffectsVolume", 0);
            _muteSound = false;
        }


    }



















    public void musicAudioSnowFlake()
    {
        AudioSnowFlake.Play();
    }

    public void musicAudioSnowBoll()
    {
        AudioSnowBoll.Play();
    }


    public void musicAudioWoodAxe()
    {
        AudioWoodAxe.Play();
    }

    public void musicAudioFire1()
    {
        AudioFire1.Play();
    }
    public void musicAudioFire2()
    {
        AudioFire2.Play();
    }
    public void musicAudioFire3()
    {
        AudioFire3.Play();
    }










}

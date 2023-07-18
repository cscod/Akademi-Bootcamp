using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.UIElements;

public class MusicPlayer : MonoBehaviour
{
    int currentMusic = 0;
    AudioSource audioSource;
    public AudioClip[] ClipNames;
    public TextMeshProUGUI MusicName;
    public TextMeshProUGUI MusicDuration;
    public UnityEngine.UI.Slider MusicLength;
    private bool stop = false;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        //StartAuidio();  
    }

    // Update is called once per frame
    void Update()
    {
        if (!stop && audioSource.clip != null)
        {
            //MusicLength.value += Time.deltaTime;
            MusicDuration.text = FormatTime(audioSource.time) + " / " + FormatTime(audioSource.clip.length);
            if (MusicLength.value >= audioSource.clip.length)
            {
                currentMusic++;
                if(currentMusic >= ClipNames.Length)
                    currentMusic = 0;
                StartAuidio();
            }
        }
    }

    public void StartAuidio(int changeMusic = 0)
    {
        currentMusic += changeMusic;    
        if(currentMusic >= ClipNames.Length)
        {
            currentMusic = 0;
        }
        else if(currentMusic < 0)
        {
            currentMusic = ClipNames.Length - 1;    
        }

        if(audioSource.isPlaying && changeMusic == 0) 
        {
            return;
        }

        if (stop)
        {
            stop = false;
        }

        audioSource.clip = ClipNames[currentMusic];
        MusicName.text = audioSource.clip.name;
        MusicLength.maxValue = audioSource.clip.length;
        MusicLength.value = 0;
        audioSource.Play();
    }

    public void StopAudio()
    {
        audioSource.Stop(); 
        stop = true;
    }
    
    public void PlaySelectedMusic(int musicIndex)
    {
        currentMusic = musicIndex;
        if (currentMusic >= ClipNames.Length)
        {
            currentMusic = 0;
        }
        else if (currentMusic < 0)
        {
            currentMusic = ClipNames.Length - 1;
        }

        if (stop)
        {
            stop = false;
        }

        audioSource.clip = ClipNames[currentMusic];
        MusicName.text = audioSource.clip.name;
        MusicLength.maxValue = audioSource.clip.length;
        MusicLength.value = 0;
        audioSource.Play();
    }

    public void OnSliderValueChanged()
    {
        audioSource.time = MusicLength.value;
    }

    //private void FixedUpdate()
    //{
    //    MusicLength.value = audioSource.time;
    //}

    private string FormatTime(float time)
    {
        int minute = Mathf.FloorToInt(time / 60);
        int second = Mathf.FloorToInt(time % 60);
        return string.Format("{0:00}:{1:00}", minute, second);
    }
}

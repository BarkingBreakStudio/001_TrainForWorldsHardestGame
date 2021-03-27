using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{

    GameObject MusicGo;
    GameObject MusicSource1Go;

    AudioSource MusicSource1;

    [Header("Debugging")]
    [SerializeField]
    AudioClip backgroundMusic1;
    [SerializeField]
    AudioClip backgroundMusic2;

    [Header("Music")]
    public AudioCueEventChannelSO MusicRequestChannel;
    public AudioMixerGroup MusicMixer;

    [Header("Sound Effect")]
    public AudioCueEventChannelSO SfxRequestChannel;
    public AudioMixerGroup SfxMixer;

    private void Awake()
    {
        MusicGo = new GameObject("Music");
        MusicGo.transform.parent = transform;

        MusicSource1Go = new GameObject("Source1");
        MusicSource1Go.transform.parent = MusicGo.transform;
        MusicSource1 = MusicSource1Go.AddComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {
        var musicReqListener = gameObject.AddComponent<AudioCueEventListener>();
        musicReqListener.OnEventRaised.AddListener(onMusicRequestChannel);
        musicReqListener.SetChannel(MusicRequestChannel);

        var sfxReqListener = gameObject.AddComponent<AudioCueEventListener>();
        sfxReqListener.OnEventRaised.AddListener(onSfxRequestChannel);
        sfxReqListener.SetChannel(SfxRequestChannel);
    }

    private void onMusicRequestChannel(AudioCueEventChannelSO.AudioCueReqest audioRequest)
    {
        PlayMusic(audioRequest.clip);
    }

    private void onSfxRequestChannel(AudioCueEventChannelSO.AudioCueReqest arg0)
    {
        throw new NotImplementedException();
    }

 

    // Update is called once per frame
    void Update()
    {
        
    }

    [ContextMenu("PlayMusic1")]
    void PlayMusic1()
    {
        PlayMusic(backgroundMusic1);
    }

    [ContextMenu("PlayMusic2")]
    void PlayMusic2()
    {
        PlayMusic(backgroundMusic2);
    }

    void PlayMusic(AudioClip clip)
    {
        MusicSource1.clip = clip;
        MusicSource1.Play();
    }
}

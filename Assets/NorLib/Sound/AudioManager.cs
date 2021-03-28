using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{

    GameObject MusicGo;


    [Header("Debugging")]
    [SerializeField]
    AudioClip backgroundMusic1;
    [SerializeField]
    AudioClip backgroundMusic2;

    [Header("Music")]
    [SerializeField]
    private AudioManager4Music musicMgr;

    public AudioCueEventChannelSO MusicRequestChannel;
    public AudioMixerGroup MusicMixer;

    [Header("Sound Effect")]
    public AudioCueEventChannelSO SfxRequestChannel;
    public AudioMixerGroup SfxMixer;

    private void Awake()
    {
        musicMgr = GetComponentInChildren<AudioManager4Music>();
        if (musicMgr == null)
        {
            MusicGo = new GameObject("Music");
            MusicGo.transform.parent = transform;
            musicMgr = MusicGo.AddComponent<AudioManager4Music>();
        }
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
        musicMgr.PlayMusic(clip);
    }
    //MusicSource1.clip = clip;
    //MusicSource1.Play();

}

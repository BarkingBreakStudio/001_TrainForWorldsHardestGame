using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager4Sfx : MonoBehaviour
{

    [SerializeField]
    private int NumOfInitialTracks = 4;
    [SerializeField]
    private int NumOfMusicTracks = 0;

    Queue<AudioSource> unusedTracks = new Queue<AudioSource>();
    List<AudioSource> activeTracks = new List<AudioSource>();

    private void Awake()
    {
        
        for (int i = 0; i < NumOfInitialTracks; i++)
        {
            unusedTracks.Enqueue(CreateNewTrack());
        }
    }


    public virtual void PlayMusic(AudioClip clip)
    {
        AudioSource track = ReserveTrack();
        track.clip = clip;
        track.Play();
        activeTracks.Add(track);
    }

    private AudioSource ReserveTrack()
    {
        if (unusedTracks.Count > 0)
        {
            return unusedTracks.Dequeue();
        }
        else
        {
            return CreateNewTrack();
        }
    }

    private AudioSource CreateNewTrack()
    {
        var gm = new GameObject("Track_" + NumOfMusicTracks++);
        gm.transform.parent = transform;
        AudioSource source = gm.AddComponent<AudioSource>();
        source.playOnAwake = false;
        return source;
    }

    void Update()
    {
        for (int i = activeTracks.Count-1; i >= 0; i--)
        {
            if (!activeTracks[i].isPlaying)
            {
                unusedTracks.Enqueue(activeTracks[i]);
                activeTracks.RemoveAt(i);
            }            
        }
    }
}

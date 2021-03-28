using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager4Music : MonoBehaviour
{


    [SerializeField]
    private int NumOfInitialTracks = 4;
    [SerializeField]
    private int NumOfMusicTracks = 0;

    [System.Serializable]
    struct MusicTrackState
    {
        public AudioSource source;
    }

    [SerializeField]
    private Queue<MusicTrackState> unusedTracks;
    [SerializeField]
    private MusicTrackState? activeTrack;
    [SerializeField]
    private List<MusicTrackState> unloadTracks;

    private void Awake()
    {
        unusedTracks = new Queue<MusicTrackState>();
        unloadTracks = new List<MusicTrackState>();
        activeTrack = null;

        for (int i = 0; i < NumOfInitialTracks; i++)
        {
            unusedTracks.Enqueue(CreateNewTrack());
        }
    }


    public virtual void PlayMusic(AudioClip clip)
    {
        MusicTrackState track = ReserveTrack();
        track.source.clip = clip;
        track.source.Play();
        if(activeTrack.HasValue)
        {
            unloadTracks.Add(activeTrack.Value);
        }
        activeTrack = track;
    }

    private MusicTrackState ReserveTrack()
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

    private MusicTrackState CreateNewTrack()
    {
        MusicTrackState mts = new MusicTrackState();
        var gm = new GameObject("Track_" + NumOfMusicTracks++);
        gm.transform.parent = transform;
        mts.source = gm.AddComponent<AudioSource>();
        mts.source.volume = 0;
        mts.source.loop = true;
        return mts;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (activeTrack.HasValue)
        {
            if(activeTrack.Value.source.volume < 1.0f)
            {
                activeTrack.Value.source.volume += 0.0001f;
            }
        }
        for (int i = unloadTracks.Count-1; i >= 0; i--)
        {
            if(unloadTracks[i].source.volume > 0.01f)
            {
                unloadTracks[i].source.volume -= 0.0001f;
            }
            else
            {
                unloadTracks[i].source.volume = 0;
                unloadTracks[i].source.Stop();
                unusedTracks.Enqueue(unloadTracks[i]);
                unloadTracks.RemoveAt(i);
            }
        }
    }
}

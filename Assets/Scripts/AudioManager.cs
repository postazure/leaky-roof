using UnityEngine;
using System.Collections.Generic;
using System.Collections;


public class AudioManager : MonoBehaviour {
    private static AudioManager _instance;
    public static AudioManager instance { get { return _instance; } }

    public List<AudioClip> chimes = new List<AudioClip>();
    public List<AudioClip> mush = new List<AudioClip>();
    public List<AudioClip> boxBreakdown = new List<AudioClip>();
    public List<AudioClip> trashBreakdown = new List<AudioClip>();
    public AudioClip pushing;

    public enum VFX { Chime, Mush, BoxBreakdown, TrashBreakdown, Pushing }

    private AudioSource source;

    private void Awake() {
        // Singleton
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }

    public void PlayVFX(VFX option)
    {
        AudioClip clip = null;
        switch (option)
        {
            case VFX.Chime:
                clip = chimes[Random.Range(0, chimes.Count)];
                break;
            case VFX.Mush:
                clip = mush[Random.Range(0, mush.Count)];
                break;
            case VFX.BoxBreakdown:
                clip = boxBreakdown[Random.Range(0, boxBreakdown.Count)];
                break;
            case VFX.TrashBreakdown:
                clip = trashBreakdown[Random.Range(0, trashBreakdown.Count)];
                break;
            case VFX.Pushing:
                clip = pushing;
                break;
        }
        source.PlayOneShot(clip);
    }
}
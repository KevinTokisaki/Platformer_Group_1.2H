using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    public static AudioManager instance;
    [SerializeField]
    private AudioSource m_audio;
    [SerializeField]
    private AudioClip[] allAudioClip;
    private void Awake()
    {
        instance = this;
    }
    public void StopAudio()
    {
        m_audio.Stop();
    }
    public void PlayAudio(string soundName)
    {
        m_audio.Stop();
        m_audio.GetComponent<AudioSource>().clip = GetClip(soundName);
        m_audio.Play();
    }

    public AudioClip GetClip(string clipName)
    {
        AudioClip pp = null;
        foreach (AudioClip clip in allAudioClip)
        {
            if (clip.name.Equals(clipName))
            {
                pp = clip;
            }
        }
        return pp;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SoundType
{
    COIN,
    ENDING,
    OVERWORLD,
    UI_HOVER,
    UI_SELECT,
    ROCK_BREAK,
    TROPHY,
    HARP,
    DRUM,
    OBOE
}

public struct Range
{
    public float min;
    public float max;

    public Range(float min, float max)
    {
        this.min = min;
        this.max = max;
    }

    public float RandomValue()
    {
        return UnityEngine.Random.Range(min, max);
    }
}

public class SoundCollection
{
    private AudioClip[] clips;

    public bool HasClips
    {
        get { return clips.Length > 0; }
    }

    public SoundCollection(params string[] soundNames)
    {
        clips = new AudioClip[soundNames.Length];
        for (int i = 0; i < soundNames.Length; i++)
        {
            clips[i] = Resources.Load<AudioClip>(soundNames[i]);
            if (clips[i] == null)
            {
                MonoBehaviour.print($"Can't find clip with name '{soundNames[i]}'");
            }
        }
    }

    public AudioClip RandomClip()
    {
        if (clips.Length == 0)
        {
            return null;
        }
        else
        {
            int index = UnityEngine.Random.Range(0, clips.Length);
            return clips[index];
        }
    }
}

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    public float masterVolumeMult = 1.0f;
    public static readonly Range pitchRange = new Range(0.75f, 1.25f);
    public static readonly Range volRange = new Range(0.75f, 1.0f);

    private AudioSource audioSrc;
    private Dictionary<SoundType, SoundCollection> sounds;

    private void Start()
    {
        audioSrc = GetComponent<AudioSource>();
        sounds = new Dictionary<SoundType, SoundCollection>() {
      {SoundType.COIN, new SoundCollection("coin") },
      {SoundType.ENDING, new SoundCollection("ending") },
      {SoundType.OVERWORLD, new SoundCollection("overworld") },
      {SoundType.UI_HOVER, new SoundCollection("ui_hover") },
      {SoundType.UI_SELECT, new SoundCollection("ui_select") },
      {SoundType.ROCK_BREAK, new SoundCollection("rock_break") },
      {SoundType.TROPHY, new SoundCollection("trophy") },
      {SoundType.HARP, new SoundCollection("harp") },
      {SoundType.DRUM, new SoundCollection("drum") },
      {SoundType.OBOE, new SoundCollection("oboe") }


    };
    }

    public void PlaySound(SoundType type, bool allowPitchShift = true, bool allowVolShift = true)
    {
        PlaySound(type, audioSrc, allowPitchShift, allowVolShift);
    }

    public void PlayOnce(SoundType type, bool allowPitchShift = true, bool allowVolShift = true)
    {
        PlayOnce(type, audioSrc);
    }
    public void PlayMusic(SoundType type, bool allowPitchShift = true, bool allowVolShift = true)
    {
        PlayMusic(type, audioSrc);
    }

    private void PlayOnce(SoundType type, AudioSource audioSrc)
    {
        if (audioSrc == null)
        {
            audioSrc = this.audioSrc;
        }
        if (sounds.ContainsKey(type) && sounds[type].HasClips)
        {
            if (audioSrc.gameObject.activeSelf)
            {
                audioSrc.clip = sounds[type].RandomClip();
                audioSrc.PlayOneShot(audioSrc.clip, 1.0f);
            }
        }
    }

    private void PlaySound(SoundType type, AudioSource audioSrc, bool allowPitchShift = true, bool allowVolShift = true)
    {
        if (audioSrc == null)
        {
            audioSrc = this.audioSrc;
        }
        if (sounds.ContainsKey(type) && sounds[type].HasClips)
        {
            if (audioSrc.gameObject.activeSelf)
            {
                audioSrc.pitch = allowPitchShift ? pitchRange.RandomValue() : 1.0f;
                audioSrc.volume = allowVolShift ? volRange.RandomValue() : 1.0f;
                audioSrc.volume *= masterVolumeMult;
                audioSrc.clip = sounds[type].RandomClip();
                audioSrc.Play();
            }
        }
    }

    private void PlayMusic(SoundType type, AudioSource audioSrc, bool allowPitchShift = true, bool allowVolShift = true)
    {
        if (audioSrc == null)
        {
            audioSrc = this.audioSrc;
        }
        if (sounds.ContainsKey(type) && sounds[type].HasClips)
        {
            if (audioSrc.gameObject.activeSelf)
            {
                audioSrc.volume *= masterVolumeMult;
                audioSrc.clip = sounds[type].RandomClip();
                audioSrc.Play();
            }
        }
    }
}

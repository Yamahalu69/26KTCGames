using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public AudioMixerGroup SFXMixer;

    public Sounds[] sounds;
    public static AudioManager Instance;
    
    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        foreach (Sounds s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.outputAudioMixerGroup = SFXMixer;
            s.source.volume = s.volume;
            s.source.loop = s.loop;
        }
        DontDestroyOnLoad(gameObject);
       
    }

    public void Play(string name)
    {
        Sounds s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }

        //  useRandomPitch �� true �̂Ƃ������s�b�`�������_����
        if (s.useRandomPitch)
            s.source.pitch = UnityEngine.Random.Range(s.minPitch, s.maxPitch);
        else
            s.source.pitch = 1f; // �Œ�ɖ߂��i�܂��� s.pitch ��ǉ����Ă�OK�j

        s.source.Play();
    }

    public void StopPlay(string name)
    {
        Sounds s = Array.Find(sounds, sounds=>sounds.name == name);
        s.source.Stop();
    }
}   
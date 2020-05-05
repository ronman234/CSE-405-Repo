using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance = null;

    public GameObject soundObjectPrefab;
    public AudioClip[] audioClips;
    public AudioMixerGroup[] audioGroups;

    private AudioSource source;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        source = gameObject.GetComponent<AudioSource>();
    }

    public void StopBack()
    {
        Destroy(gameObject);
    }

    public void Play(string audioEvent, string audioType,GameObject obj)
    {
        GameObject soundObject = (GameObject)Instantiate(soundObjectPrefab);
        soundObject.transform.position = obj.transform.position;

        if (audioEvent == "BackGround")
        {
            source.clip = audioClips[0];
            source.outputAudioMixerGroup = audioGroups[0];
        }
        else if(audioEvent == "Player")
        {
            switch (audioType)
            {
                case "BasicAttack":
                    source.clip = audioClips[3];
                    source.outputAudioMixerGroup = audioGroups[1];
                    source.Play();
                    Destroy(soundObject, source.clip.length);
                    break;
                case "SpreadShot":
                    source.clip = audioClips[4];
                    source.outputAudioMixerGroup = audioGroups[1];
                    source.Play();
                    Destroy(soundObject, source.clip.length);
                    break;
                case "Bomb":
                    source.clip = audioClips[5];
                    source.outputAudioMixerGroup = audioGroups[1];
                    source.Play();
                    Destroy(soundObject, source.clip.length);
                    break;
                case "Death":
                    source.clip = audioClips[6];
                    source.outputAudioMixerGroup = audioGroups[1];
                    source.Play();
                    Destroy(soundObject, source.clip.length);
                    break;
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class EnemyAudioManager : MonoBehaviour
{
    public static EnemyAudioManager instance = null;

    public GameObject soundObjectPrefab;
    public AudioClip[] audioClips;
    public AudioMixerGroup audioGroups;
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

    public void Play(string audioEvent, string audioType, GameObject obj)
    {
        GameObject soundObject = (GameObject)Instantiate(soundObjectPrefab);
        soundObject.transform.position = obj.transform.position;

        if (audioEvent == "Enemy")
        {
            switch (audioType)
            {
                case "BasicAttack":
                    source.clip = audioClips[9];
                    source.outputAudioMixerGroup = audioGroups;
                    source.Play();
                    Destroy(soundObject, source.clip.length);
                    break;
                case "SpreadShot":
                    source.clip = audioClips[10];
                    source.outputAudioMixerGroup = audioGroups;
                    source.Play();
                    Destroy(soundObject, source.clip.length);
                    break;
                case "Bomb":
                    source.clip = audioClips[4];
                    source.outputAudioMixerGroup = audioGroups;
                    source.Play();
                    Destroy(soundObject, source.clip.length);
                    break;
                case "Stun":
                    source.clip = audioClips[10];
                    source.outputAudioMixerGroup = audioGroups;
                    source.Play();
                    Destroy(soundObject, source.clip.length);
                    break;
                case "Wave":
                    source.clip = audioClips[14];
                    source.outputAudioMixerGroup = audioGroups;
                    source.Play();
                    Destroy(soundObject, source.clip.length);
                    break;
                case "ObstacleHit":
                    source.clip = audioClips[5];
                    source.outputAudioMixerGroup = audioGroups;
                    source.Play();
                    Destroy(soundObject, source.clip.length);
                    break;
                case "Death":
                    source.clip = audioClips[6];
                    source.outputAudioMixerGroup = audioGroups;
                    source.Play();
                    Destroy(soundObject, source.clip.length);
                    break;
            }
        }
        else if (audioEvent == "Boss")
        {
            source.outputAudioMixerGroup = audioGroups;
        }

    }
}

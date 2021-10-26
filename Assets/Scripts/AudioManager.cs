using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioClip startClip;

    AudioSource track01, track02;
    bool isPlayingTrack01;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        track01 = gameObject.AddComponent<AudioSource>();
        track02 = gameObject.AddComponent<AudioSource>();
        track01.loop = true;
        track02.loop = true;
        isPlayingTrack01 = true;

        SwapTrack(startClip, 1f);
    }

    public void SwapTrack(AudioClip newClip, float timeToFade) 
    {
        StopAllCoroutines();

        StartCoroutine(FadeTrack(newClip, timeToFade));

        isPlayingTrack01 = !isPlayingTrack01;
    }

    public IEnumerator FadeTrack(AudioClip newClip, float timeToFade)
    {
        float timeElasped = 0f;

        if (isPlayingTrack01)
        {
            track02.clip = newClip;
            track02.Play();

            while (timeElasped < timeToFade)
            {
                track02.volume = Mathf.Lerp(0, 1, timeElasped / timeToFade);
                track01.volume = Mathf.Lerp(1, 0, timeElasped / timeToFade);
                timeElasped += Time.deltaTime;
                yield return null;
            }

            track01.Stop();
        }
        else
        {
            track01.clip = newClip;
            track01.Play();

            while (timeElasped < timeToFade)
            {
                track01.volume = Mathf.Lerp(0, 1, timeElasped / timeToFade);
                track02.volume = Mathf.Lerp(1, 0, timeElasped / timeToFade);
                timeElasped += Time.deltaTime;
                yield return null;
            }

            track02.Stop();
        }
    }
}

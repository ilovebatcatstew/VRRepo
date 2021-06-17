using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudioManager : MonoBehaviour
{

    AudioSource playerAudio;
    AudioClip start;
    AudioClip engine;

    // Start is called before the first frame update
    void Start()
    {

        playerAudio = GetComponent<AudioSource>();
        start = Resources.Load("Sounds/engineStart") as AudioClip;
        engine = Resources.Load("Sounds/mixedEngineIdle") as AudioClip;
        playerAudio.volume = .2f;
        StartCoroutine(playEngineSound());
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator playEngineSound()
    {
        playerAudio.clip = start;
        playerAudio.Play();
        yield return new WaitForSeconds((playerAudio.clip.length)-0.5f);
        playerAudio.clip = engine;
        
        playerAudio.Play();
        playerAudio.loop = true;
    }
}

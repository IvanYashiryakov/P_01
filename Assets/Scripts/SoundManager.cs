using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource _drillAudioSource;
    [SerializeField] private AudioSource _musicAudioSource;
    [SerializeField] private AudioClip _drillClip;
    [SerializeField] private AudioClip _introMusic;
    [SerializeField] private AudioClip _gameloopMusic;

    public static SoundManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        _drillAudioSource.clip = _drillClip;
        _musicAudioSource.clip = _gameloopMusic;

        _musicAudioSource.PlayOneShot(_introMusic);
        _musicAudioSource.loop = true;
        _musicAudioSource.PlayDelayed(_introMusic.length);
    }

    public void PlayDrillSound()
    {
        if (_drillAudioSource.isPlaying == false)
            _drillAudioSource.Play();
    }
}

using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup _soundMixer, _musicMixer;
    [SerializeField] private AudioSource _drillAudioSource;
    [SerializeField] private AudioSource _musicAudioSource;
    [SerializeField] private AudioSource _coinAudioSource;
    [SerializeField] private AudioClip _drillClip;
    [SerializeField] private AudioClip _coinClip;
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
        ToggleSound(SaveManager.Instance.Sound);
        ToggleMusic(SaveManager.Instance.Music);

        _drillAudioSource.clip = _drillClip;
        _musicAudioSource.clip = _gameloopMusic;

        _musicAudioSource.PlayOneShot(_introMusic);
        _musicAudioSource.loop = true;
        _musicAudioSource.PlayDelayed(_introMusic.length);
    }

    public void PlayDrillSound()
    {
        if (_drillAudioSource.isPlaying == false)
        {
            _drillAudioSource.pitch = Random.Range(0.9f, 1.1f);
            _drillAudioSource.Play();
        }
    }

    public void PlayCoin()
    {
        _coinAudioSource.pitch = Random.Range(0.9f, 1.1f);
        _coinAudioSource.PlayOneShot(_coinClip);
    }

    public void ToggleMusic(bool value)
    {
        _musicMixer.audioMixer.SetFloat("Music", value ? 0f : -80f);
        SaveManager.Instance.SetMusic(value);
    }

    public void ToggleSound(bool value)
    {
        _soundMixer.audioMixer.SetFloat("Sound", value ? 0f : -80f);
        SaveManager.Instance.SetSound(value);
    }

    public void ToggleMusic()
    {
        ToggleMusic(!SaveManager.Instance.Music);
    }

    public void ToggleSound()
    {
        ToggleSound(!SaveManager.Instance.Sound);
    }
}

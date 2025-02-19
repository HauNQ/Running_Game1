using UnityEngine;

public class AudioManager2 : MonoBehaviour
{
    public static AudioManager2 instance;

    [SerializeField] private AudioSource[] sfx;
    [SerializeField] private AudioSource[] bgm;

    private int bgmIndex;
    private void Awake() => instance = this;

    private void Update()
    {
        if (!bgm[bgmIndex].isPlaying)
            PlayRandomBGM();
    }

    public void PlayRandomBGM()
    {
        bgmIndex = Random.Range(0, bgm.Length);

        PlayBGM(bgmIndex);
    }


    public void PlaySFX(int index)
    {
        if (index < sfx.Length)
        {

            sfx[index].Play();
        }
    }
    public void PlayBGM(int index)
    {
        for (int i = 0; i < bgm.Length; i++)
        {
            bgm[index].Stop();
        }

        bgm[index].Play();
    }

    public void StopBGM()
    {
        for (int i = 0; i < bgm.Length; i++)
        {
            bgm[i].Stop();
        }
    }
}

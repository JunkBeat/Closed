// Decompiled with JetBrains decompiler
// Type: JukeboxMusic
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using UnityEngine;

public class JukeboxMusic : MonoBehaviour
{
  public AudioSource audioSource;
  public static JukeboxMusic jb;
  private AudioClip currentMusic;
  private AudioClip nextMusic;
  private float musicVolume = 0.5f;
  public float currentPlaybackVolume;
  public float targetPlaybackVolume;
  public float step = 0.1f;
  public bool loop = true;
  public float delayMin;
  public float delayMax;
  public float delay;
  public float currentDelay;

  public AudioClip getCurrentMusic() => this.currentMusic;

  private void Awake()
  {
    if ((Object) JukeboxMusic.jb == (Object) null)
    {
      Object.DontDestroyOnLoad((Object) this.gameObject);
      JukeboxMusic.jb = this;
    }
    else
    {
      if (!((Object) JukeboxMusic.jb != (Object) this))
        return;
      Object.Destroy((Object) this.gameObject);
    }
  }

  private void Start()
  {
    this.audioSource.ignoreListenerPause = true;
    this.audioSource.ignoreListenerVolume = true;
  }

  private void Update()
  {
    this.musicVolume = (float) (1.0 * (double) PlayerPrefs.GetInt("music") / 100.0);
    if ((double) this.targetPlaybackVolume > (double) this.currentPlaybackVolume)
      this.currentPlaybackVolume += this.step;
    else if ((double) this.targetPlaybackVolume < (double) this.currentPlaybackVolume)
      this.currentPlaybackVolume -= this.step;
    if ((double) Mathf.Abs(this.targetPlaybackVolume - this.currentPlaybackVolume) <= (double) this.step)
      this.currentPlaybackVolume = this.targetPlaybackVolume;
    this.audioSource.volume = this.currentPlaybackVolume * this.musicVolume;
    if ((double) this.currentPlaybackVolume <= 0.0 && (double) this.targetPlaybackVolume == 0.0 && (Object) this.nextMusic != (Object) null)
    {
      this.currentMusic = this.nextMusic;
      this.nextMusic = (AudioClip) null;
      this.audioSource.clip = this.currentMusic;
      this.audioSource.Play();
      this.audioSource.loop = false;
      this.targetPlaybackVolume = 1f;
    }
    else if ((double) this.currentPlaybackVolume <= 0.0 && (double) this.targetPlaybackVolume == 0.0)
      this.currentMusic = (AudioClip) null;
    if (this.audioSource.isPlaying || !this.loop)
      return;
    this.currentDelay += Time.deltaTime;
    if ((double) this.currentDelay < (double) this.delay)
      return;
    this.currentDelay = 0.0f;
    if ((Object) this.nextMusic != (Object) null)
    {
      this.currentMusic = this.nextMusic;
      this.nextMusic = (AudioClip) null;
      this.audioSource.clip = this.currentMusic;
    }
    this.audioSource.Play();
    this.delay = Random.Range(this.delayMin, this.delayMax);
  }

  public void changeMusic(
    AudioClip newMusic,
    bool looping = true,
    float minTime = 15f,
    float maxTime = 80f,
    float newStep = 0.1f)
  {
    if ((Object) newMusic == (Object) null && !looping && (Object) this.currentMusic != (Object) SoundsManagerController.sm.music_main || !((Object) newMusic != (Object) this.currentMusic))
      return;
    this.step = newStep;
    this.nextMusic = newMusic;
    this.targetPlaybackVolume = 0.0f;
    this.loop = looping;
    if ((double) minTime <= 0.0)
      minTime = 0.1f;
    if ((double) maxTime <= 0.0)
      maxTime = 0.2f;
    this.delayMin = minTime;
    this.delayMax = maxTime;
    if ((double) this.currentDelay != 0.0)
      return;
    this.delay = Random.Range(this.delayMin, this.delayMax);
  }
}

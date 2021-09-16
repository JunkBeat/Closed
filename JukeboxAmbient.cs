// Decompiled with JetBrains decompiler
// Type: JukeboxAmbient
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\Don't Escape 4 Days in a Wasteland\dontescape_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class JukeboxAmbient : MonoBehaviour
{
  public AudioSource audioSource;
  public static JukeboxAmbient jb;
  private AudioClip current;
  private AudioClip next;
  private float ambientVolume = 0.5f;
  private float currentPlaybackVolume;
  private float targetPlaybackVolume;
  private float nextTargetVolume;
  private float step = 0.1f;

  private void Awake()
  {
    if ((Object) JukeboxAmbient.jb == (Object) null)
    {
      JukeboxAmbient.jb = this;
    }
    else
    {
      if (!((Object) JukeboxAmbient.jb != (Object) this))
        return;
      Object.Destroy((Object) this.gameObject);
    }
  }

  private void Start() => this.gameObject.AddComponent<AudioReverbFilter>();

  private void Update()
  {
    this.ambientVolume = 0.5f;
    AudioListener.volume = (float) PlayerPrefs.GetInt("sound") / 100f;
    if ((double) this.targetPlaybackVolume > (double) this.currentPlaybackVolume)
      this.currentPlaybackVolume += this.step;
    else if ((double) this.targetPlaybackVolume < (double) this.currentPlaybackVolume)
      this.currentPlaybackVolume -= this.step;
    if ((double) Mathf.Abs(this.targetPlaybackVolume - this.currentPlaybackVolume) <= (double) this.step)
      this.currentPlaybackVolume = this.targetPlaybackVolume;
    this.audioSource.volume = this.currentPlaybackVolume * this.ambientVolume;
    if ((double) this.audioSource.volume > 0.0 || (double) this.targetPlaybackVolume != 0.0 || !((Object) this.next != (Object) null))
      return;
    this.current = this.next;
    this.next = (AudioClip) null;
    this.audioSource.clip = this.current;
    this.audioSource.Play();
    this.audioSource.loop = true;
    this.targetPlaybackVolume = this.nextTargetVolume;
  }

  public void changeAmbient(AudioClip newAmb, float newVolume, AudioReverbPreset arp = AudioReverbPreset.Off)
  {
    MonoBehaviour.print((object) (newAmb.ToString() + " " + (object) this.current));
    if ((Object) newAmb != (Object) this.current)
    {
      this.next = newAmb;
      this.targetPlaybackVolume = 0.0f;
      this.nextTargetVolume = newVolume;
    }
    else
      this.targetPlaybackVolume = newVolume;
    if ((double) newVolume != (double) this.targetPlaybackVolume)
      this.nextTargetVolume = newVolume;
    this.gameObject.GetComponent<AudioReverbFilter>().reverbPreset = arp;
    MonoBehaviour.print((object) ("NEW AMBIENT!" + (object) this.next + "@" + (object) this.nextTargetVolume + " of " + (object) this.targetPlaybackVolume + " / " + (object) newAmb));
  }
}

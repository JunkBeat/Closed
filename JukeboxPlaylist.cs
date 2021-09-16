// Decompiled with JetBrains decompiler
// Type: JukeboxPlaylist
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\Don't Escape 4 Days in a Wasteland\dontescape_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

public class JukeboxPlaylist : MonoBehaviour
{
  public AudioSource music;
  public JukeboxPlaylist jB;
  private float currentVolume;
  private float targetVolume;
  private float step = 0.1f;
  public List<AudioClip> playList;

  private void Awake()
  {
    if ((Object) this.jB == (Object) null)
    {
      Object.DontDestroyOnLoad((Object) this.gameObject);
      this.jB = this;
    }
    else
    {
      if (!((Object) this.jB != (Object) this))
        return;
      Object.Destroy((Object) this.gameObject);
    }
  }

  private void Start()
  {
    this.music = new AudioSource();
    this.playList = (List<AudioClip>) null;
  }

  private void Update()
  {
    if (this.music.isPlaying || this.playList == null)
      return;
    this.playNextClipOnPlayList();
  }

  private void playNextClipOnPlayList()
  {
    this.music.clip = this.playList[0];
    this.music.Play();
    this.music.loop = false;
    this.targetVolume = 1f;
    AudioClip play = this.playList[0];
    this.playList.RemoveAt(0);
    this.playList.Add(play);
  }

  public void changeMusic(AudioClip newMusic, bool looping)
  {
  }
}

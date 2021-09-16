// Decompiled with JetBrains decompiler
// Type: LocationOutpost11Start
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


using UnityEngine;

public class LocationOutpost11Start : MonoBehaviour
{
  public SpriteMask playerMask;
  public SpriteRenderer playerShadow;
  public SpriteRenderer playerShadow2;

  private void Start()
  {
    PlayerController.wc.shadow.fadeRateV = 0.0f;
    PlayerController.wc.shadow.fadeRateH = 3f / 500f;
    PlayerController.wc.shadowOffsetY = -2;
    PlayerController.wc.shadow.skewFactor = 70f;
    PlayerController.wc.shadow.skewFactor2 = 0.0f;
    PlayerController.wc.shadow.startAlpha = 0.5f;
    PlayerController.wc.shadow.source = 160f;
    PlayerController.ssg.setStepType2(StepSoundGenerator.NORMAL, AudioReverbPreset.Hallway);
    PlayerController.wc.shadow.scaleFactor = 0.25f;
    PlayerController.wc.shadow.downwards = true;
    PlayerController.wc.speed = PlayerController.wc.MAX_SPEED;
    PlayerController.wc.GetComponent<Animator>().speed = 1f;
    PlayerController.pc.copySettingsToNPCs();
    GameDataController.gd.setObjective("visited_outpost11", true);
    JukeboxMusic.jb.changeMusic(SoundsManagerController.sm.music_explore_6a);
  }

  private void Update()
  {
    this.playerMask.sprite = PlayerController.wc.sr.sprite;
    this.playerMask.transform.position = PlayerController.pc.transform.position;
    if (PlayerController.wc.sr.flipX)
      this.playerMask.transform.localScale = new Vector3(-1f, 1f, 1f);
    else
      this.playerMask.transform.localScale = new Vector3(1f, 1f, 1f);
    float num = (PlayerController.wc.currentXY.y - 41f) * 0.01f;
    if ((double) num < 0.0)
      num = 0.0f;
    this.playerShadow.transform.position = PlayerController.pc.transform.position;
    this.playerShadow.transform.position = new Vector3(this.playerShadow.transform.position.x - 0.02f, this.playerShadow.transform.position.y + 0.05f - num, -0.2f);
    this.playerShadow.sprite = PlayerController.wc.sr.sprite;
    this.playerShadow.flipX = PlayerController.wc.sr.flipX;
    this.playerShadow2.transform.position = PlayerController.pc.transform.position;
    this.playerShadow2.transform.position = new Vector3(this.playerShadow2.transform.position.x - 0.01f, this.playerShadow2.transform.position.y + 0.05f - num, -0.2f);
    this.playerShadow2.sprite = PlayerController.wc.sr.sprite;
    this.playerShadow2.flipX = PlayerController.wc.sr.flipX;
    this.playerShadow2.transform.position = ScreenControler.roundToNearestFullPixel2(this.playerShadow2.transform.position);
    this.playerShadow.transform.position = ScreenControler.roundToNearestFullPixel2(this.playerShadow.transform.position);
    this.playerMask.transform.position = ScreenControler.roundToNearestFullPixel2(this.playerMask.transform.position);
  }
}

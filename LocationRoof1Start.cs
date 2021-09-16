// Decompiled with JetBrains decompiler
// Type: LocationRoof1Start
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\Don't Escape 4 Days in a Wasteland\dontescape_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class LocationRoof1Start : MonoBehaviour
{
  public SpriteRenderer moon;
  public SpriteRenderer moong;
  public Sprite moon2;
  public Sprite moon3;
  public Sprite moon4;
  public Sprite moon2g;
  public Sprite moon3g;
  public Sprite moon4g;
  public SpriteRenderer destroyedRoof;

  private void Start()
  {
    PlayerController.wc.shadow.fadeRateV = 0.1f;
    PlayerController.wc.shadow.fadeRateH = 0.0f;
    PlayerController.wc.shadowOffsetY = 0;
    PlayerController.wc.shadow.skewFactor = 0.0f;
    PlayerController.wc.shadow.skewFactor2 = 5f;
    PlayerController.wc.shadow.startAlpha = 0.75f;
    PlayerController.wc.shadow.source = 240f;
    PlayerController.ssg.setStepType(StepSoundGenerator.METAL);
    PlayerController.wc.shadow.scaleFactor = 0.75f;
    PlayerController.wc.shadow.downwards = true;
    PlayerController.wc.speed = PlayerController.wc.MAX_SPEED / 2f;
    PlayerController.wc.GetComponent<Animator>().speed = 0.75f;
    PlayerController.pc.copySettingsToNPCs();
    GameDataController.gd.setObjective("visited_roof1", true);
    JukeboxMusic.jb.changeMusic((AudioClip) null);
    JukeboxAmbient.jb.changeAmbient(SoundsManagerController.sm.ambient_wind_1, 0.5f);
    if (GameDataController.gd.getCurrentDay() == 2)
      this.moon.sprite = this.moon2;
    if (GameDataController.gd.getCurrentDay() == 3)
      this.moon.sprite = this.moon3;
    if (GameDataController.gd.getCurrentDay() == 4)
      this.moon.sprite = this.moon4;
    if (GameDataController.gd.getCurrentDay() == 2)
      this.moong.sprite = this.moon2g;
    if (GameDataController.gd.getCurrentDay() == 3)
      this.moong.sprite = this.moon3g;
    if (GameDataController.gd.getCurrentDay() == 4)
      this.moong.sprite = this.moon4g;
    if (GameDataController.gd.gameTime < 510 || GameDataController.gd.gameTime >= 1050)
      this.moong.enabled = true;
    else
      this.moong.enabled = false;
    this.destroyedRoof.enabled = false;
    if (GameDataController.gd.getCurrentDay() == 4 && GameDataController.gd.getObjectiveDetail("day_3_threat") == 1)
      this.destroyedRoof.enabled = true;
    PlayerController.pc.allowDrop = false;
  }

  private void Update()
  {
  }
}

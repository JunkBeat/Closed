// Decompiled with JetBrains decompiler
// Type: CrossroadStart
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\Don't Escape 4 Days in a Wasteland\dontescape_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class CrossroadStart : MonoBehaviour
{
  public SpriteRenderer heli;
  public SpriteRenderer snow;
  public SpriteRenderer roof;
  public SpriteRenderer ditches;

  private void Start()
  {
    PlayerController.wc.shadow.fadeRateV = 0.0f;
    PlayerController.wc.shadow.fadeRateH = 0.0f;
    PlayerController.wc.shadowOffsetY = 0;
    PlayerController.wc.shadow.skewFactor = 0.0f;
    PlayerController.wc.shadow.skewFactor2 = 5f;
    PlayerController.wc.shadow.startAlpha = 0.25f;
    PlayerController.wc.shadow.source = 160f;
    PlayerController.ssg.setStepType("road");
    PlayerController.wc.shadow.scaleFactor = 0.75f;
    PlayerController.wc.shadow.downwards = true;
    PlayerController.wc.speed = PlayerController.wc.MAX_SPEED;
    PlayerController.wc.GetComponent<Animator>().speed = 1f;
    GameObject.Find("inventory_button").GetComponent<InventoryButtonController>().showFinal();
    PlayerController.wc.shadow.scaleFactor = 0.75f;
    PlayerController.wc.shadowOffsetY = 0;
    PlayerController.pc.copySettingsToNPCs();
    if (!GameDataController.gd.getObjective("visited_crossroad"))
    {
      GameDataController.gd.autoSave();
      PlayerController.wc.currentXY.x = 100f;
      PlayerController.wc.currentXY.y = -70f;
      this.walkThere();
    }
    if (GameDataController.gd.getCurrentDay() == 1)
      this.heli.enabled = false;
    else
      this.heli.enabled = true;
    if (!GameDataController.gd.getObjective("visited_barn"))
      JukeboxMusic.jb.changeMusic(SoundsManagerController.sm.music_main, false);
    else
      JukeboxMusic.jb.changeMusic((AudioClip) null, false);
    JukeboxAmbient.jb.changeAmbient(SoundsManagerController.sm.ambient_wind_1, 1f);
    GameDataController.gd.setObjective("bridge_westside", false);
    if (GameDataController.gd.getCurrentDay() == 3 && GameDataController.gd.getObjectiveDetail("day_2_threat") == 1)
    {
      this.snow.enabled = true;
      this.snow.color = GameDataController.gd.gameTime >= 600 ? (GameDataController.gd.gameTime >= 650 ? (GameDataController.gd.gameTime >= 700 ? (GameDataController.gd.gameTime >= 750 ? (GameDataController.gd.gameTime >= 800 ? new Color(1f, 1f, 1f, 0.1f) : new Color(1f, 1f, 1f, 0.2f)) : new Color(1f, 1f, 1f, 0.4f)) : new Color(1f, 1f, 1f, 0.6f)) : new Color(1f, 1f, 1f, 0.8f)) : new Color(1f, 1f, 1f, 1f);
    }
    else
      this.snow.enabled = false;
    if (GameDataController.gd.getCurrentDay() == 4 && GameDataController.gd.getObjectiveDetail("day_3_threat") == 1 && (!GameDataController.gd.getObjective("lighting_rod_installed") || GameDataController.gd.getObjectiveDetail("day3_complete") < 1))
      this.roof.enabled = true;
    this.ditches.enabled = false;
    if (!GameDataController.gd.getObjective("base_outside_dug"))
      return;
    this.ditches.enabled = true;
  }

  private void walkThere1() => this.Invoke("walkThere", 0.25f);

  private void walkThere()
  {
    this.Invoke("showIntro1", 1f);
    this.Invoke("showIntro1b", 7f);
    PlayerController.wc.speed = 2f;
    PlayerController.wc.currentXY.x = 90f;
    PlayerController.wc.currentXY.y = -70f;
    Vector2 newTarget = new Vector2(90f, 25f);
    PlayerController.wc.setSimpleTarget(newTarget);
    PlayerController.wc.forceAnimation("walk_n");
  }

  private void unlock()
  {
    PlayerController.wc.fullStop();
    PlayerController.wc.speed = PlayerController.wc.MAX_SPEED;
    PlayerController.pc.setBusy(false);
    PlayerController.wc.forceAnimation("action_stnd_n");
    PlayerController.pc.textField.viewText(GameStrings.getString(GameStrings.actions, "crossroad_intro1"), true, mwidth: 80);
  }

  private void showIntro1()
  {
    GameObject.Find("TitleText").GetComponent<TextFieldController>().shift.x = 64f;
    GameObject.Find("TitleText").GetComponent<TextFieldController>().shift.y = -20f;
    if (GameDataController.gd.getObjective("intro_skipped"))
      return;
    GameObject.Find("TitleText").GetComponent<TextFieldController>().viewText(GameStrings.getString(GameStrings.gui, "intro_3"), quick: true, instant: true, mwidth: 180, ba: 0.0f);
  }

  private void showIntro2()
  {
    GameObject.Find("TitleText").GetComponent<TextFieldController>().shift.x = 64f;
    GameObject.Find("TitleText").GetComponent<TextFieldController>().shift.y = -20f;
    GameObject.Find("TitleText").GetComponent<TextFieldController>().viewText(GameStrings.getString(GameStrings.gui, "intro_4"), quick: true, instant: true, mwidth: 180, ba: 0.0f);
  }

  private void showIntro1b() => GameObject.Find("TitleText").GetComponent<TextFieldController>().viewText(" ", quick: true, instant: true, mwidth: 180, r: 0.0f, g: 0.0f, b: 0.0f, ba: 0.0f);

  private void Update()
  {
    if ((double) PlayerController.wc.currentXY.y > 22.0 && !GameDataController.gd.getObjective("visited_crossroad"))
    {
      GameDataController.gd.setObjective("visited_crossroad", true);
      this.unlock();
    }
    if (!GameDataController.gd.getObjective("visited_crossroad"))
    {
      float num = (float) (1.0 + (30.0 + (double) PlayerController.wc.currentXY.y) / 30.0);
      if ((double) num < 0.0)
        num = 0.0f;
      if ((double) num > 1.0)
        num = 1f;
      PlayerController.ssg.volumeMultip = num;
    }
    else
      PlayerController.ssg.volumeMultip = 1f;
  }
}

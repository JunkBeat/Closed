// Decompiled with JetBrains decompiler
// Type: LocationAttic2Start
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\Don't Escape 4 Days in a Wasteland\dontescape_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

public class LocationAttic2Start : MonoBehaviour
{
  public SpriteRenderer destroyed;
  public SpriteRenderer shadow;
  public SpriteRenderer shadow2;
  public SpriteRenderer holes;
  public SpriteRenderer rays;

  private void Start()
  {
    PlayerController.wc.shadow.fadeRateV = 0.04f;
    PlayerController.wc.shadow.fadeRateH = 0.0f;
    PlayerController.wc.shadowOffsetY = 0;
    PlayerController.wc.shadow.skewFactor = 0.0f;
    PlayerController.wc.shadow.skewFactor2 = -20f;
    PlayerController.wc.shadow.startAlpha = 0.75f;
    PlayerController.wc.shadow.source = 140f;
    PlayerController.ssg.setStepType(StepSoundGenerator.WOOD);
    PlayerController.wc.shadow.scaleFactor = 0.75f;
    PlayerController.wc.shadow.downwards = true;
    PlayerController.wc.speed = PlayerController.wc.MAX_SPEED;
    PlayerController.wc.GetComponent<Animator>().speed = 1f;
    PlayerController.pc.copySettingsToNPCs();
    GameDataController.gd.setObjective("visited_attic2", true);
    JukeboxMusic.jb.changeMusic(SoundsManagerController.sm.music_explore_5a);
    JukeboxAmbient.jb.changeAmbient(SoundsManagerController.sm.ambient_wind_1, 0.5f);
    if (!GameDataController.gd.getObjective("dialogue_ginger_intro"))
    {
      PlayerController.pc.setBusy(true);
      this.Invoke("forceTalk0", 0.01f);
      this.Invoke("forceTalk", 1.15f);
      PlayerController.wc.currentXY = (Vector2) ScreenControler.roundToNearestFullPixel(GameObject.Find("WalkToGunStart").transform.position);
    }
    this.destroyed.enabled = false;
    this.shadow.enabled = true;
    this.shadow2.enabled = false;
    if (GameDataController.gd.getCurrentDay() == 4 && GameDataController.gd.getObjectiveDetail("day_3_threat") == 1 && (!GameDataController.gd.getObjective("lighting_rod_installed") || GameDataController.gd.getObjectiveDetail("day3_complete") < 1))
    {
      this.destroyed.enabled = true;
      this.shadow.enabled = false;
      this.shadow2.enabled = true;
      this.holes.enabled = false;
      this.rays.enabled = false;
    }
    else if (GameDataController.gd.getCurrentDay() == 4 && GameDataController.gd.getObjectiveDetail("day_3_threat") == 1)
    {
      this.holes.enabled = true;
      this.rays.enabled = true;
    }
    else
    {
      this.holes.enabled = false;
      this.rays.enabled = false;
    }
    List<DialogueLine> dialogueLines = new List<DialogueLine>();
    if (GameDataController.gd.getObjective("npc3_joined") && GameDataController.gd.getObjective("npc3_alive") && !GameDataController.gd.getObjective("helicopter_cody"))
    {
      GameDataController.gd.setObjective("helicopter_cody", true);
      Vector3 color1 = GingerActionController.getColor();
      Vector3 color2 = Npc3Controller.getColor();
      TextFieldController component = GameObject.Find("Npc3").GetComponent<TextFieldController>();
      DialogueController.dc.initDialogue(dialogueLines, "helicopter_cody", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), GameObject.Find("Ginger").GetComponent<TextFieldController>(), color1, component, color2);
    }
    if (GameDataController.gd.getObjective("npc2_joined") && GameDataController.gd.getObjective("npc2_alive") && !GameDataController.gd.getObjective("helicopter_barry"))
    {
      GameDataController.gd.setObjective("helicopter_barry", true);
      Vector3 color3 = GingerActionController.getColor();
      Vector3 color4 = Npc2Controller.getColor();
      TextFieldController component = GameObject.Find("Npc2").GetComponent<TextFieldController>();
      DialogueController.dc.initDialogue(dialogueLines, "helicopter_barry", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), GameObject.Find("Ginger").GetComponent<TextFieldController>(), color3, component, color4);
    }
    for (int index = 0; index < dialogueLines.Count; ++index)
      Timeline.t.addDialogue(dialogueLines[index]);
  }

  private void Update()
  {
    if (GameDataController.gd.getObjective("dialogue_ginger_intro") || (double) PlayerController.wc.currentXY.x > (double) ScreenControler.roundToNearestFullPixel(GameObject.Find("WalkToGun").transform.position).x)
      return;
    PlayerController.wc.forceAnimation("stand_se", true);
  }

  private void forceTalk0()
  {
    PlayerController.pc.setBusy(true);
    PlayerController.wc.setSimpleTarget((Vector2) ScreenControler.roundToNearestFullPixel(GameObject.Find("WalkToGun").transform.position));
  }

  private void forceTalk()
  {
    PlayerController.pc.setBusy(true);
    GameObject.Find("Ginger").GetComponent<GingerActionController>().npcClickAction(string.Empty);
  }
}

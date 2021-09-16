// Decompiled with JetBrains decompiler
// Type: LocationCaveStart
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\Don't Escape 4 Days in a Wasteland\dontescape_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

public class LocationCaveStart : MonoBehaviour
{
  public SpriteRenderer flag;
  public SpriteRenderer blanket;
  public SpriteRenderer blanketb;
  public SpriteRenderer thermb;
  public SpriteRenderer light1;
  public SpriteRenderer light2;
  public bool codyLives;
  public bool codyTalked;

  private void Start()
  {
    PlayerController.wc.shadow.fadeRateV = 0.05f;
    PlayerController.wc.shadow.fadeRateH = 0.008f;
    PlayerController.wc.shadowOffsetY = -4;
    PlayerController.wc.shadow.skewFactor = 0.0f;
    PlayerController.wc.shadow.skewFactor2 = -30f;
    PlayerController.wc.shadow.startAlpha = 0.75f;
    PlayerController.wc.shadow.source = 80f;
    PlayerController.ssg.setStepType(StepSoundGenerator.ROAD);
    PlayerController.wc.shadow.scaleFactor = 0.3f;
    PlayerController.wc.shadow.downwards = true;
    PlayerController.wc.speed = PlayerController.wc.MAX_SPEED;
    PlayerController.wc.GetComponent<Animator>().speed = 1f;
    PlayerController.pc.copySettingsToNPCs();
    if (!GameDataController.gd.getObjective("visited_cave") || (double) Random.Range(0.0f, 1f) > 0.800000011920929)
      PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "rv_cave_visit"));
    GameDataController.gd.setObjective("visited_cave", true);
    JukeboxMusic.jb.changeMusic(SoundsManagerController.sm.music_explore_5a);
    JukeboxAmbient.jb.changeAmbient(SoundsManagerController.sm.ambient_wind_1, 0.4f);
    if (GameDataController.gd.getObjective("rv_cave_therm"))
      this.thermb.enabled = true;
    else
      this.thermb.enabled = false;
    if (GameDataController.gd.getObjective("rv_cave_blanketb"))
      this.blanketb.enabled = true;
    else
      this.blanketb.enabled = false;
    if (GameDataController.gd.getObjective("rv_cave_blanket"))
      this.blanket.enabled = true;
    else
      this.blanket.enabled = false;
    if (GameDataController.gd.getObjective("rv_cave_flag"))
      this.flag.enabled = true;
    else
      this.flag.enabled = false;
    if (GameDataController.gd.getObjective("rv_cave_therm") || GameDataController.gd.getObjective("rv_cave_blanketb") || GameDataController.gd.getObjective("rv_cave_blanket") || GameDataController.gd.getObjective("rv_cave_flag"))
    {
      this.light1.enabled = false;
      this.light2.enabled = true;
    }
    else
    {
      this.light1.enabled = true;
      this.light2.enabled = false;
    }
    this.codyTalked = GameDataController.gd.getObjective("place_rv_cody");
    this.codyLives = false;
    if (!GameDataController.gd.getObjective("npc3_alive") || !GameDataController.gd.getObjective("npc3_joined"))
      return;
    this.codyLives = true;
  }

  private void Update()
  {
    if (!this.codyTalked || !this.codyLives || !(CursorController.cc.selectedItemName == "shovel"))
      return;
    CursorController.cc.deselectItem();
    InventoryButtonController.ibc.close();
    List<DialogueLine> dialogueLines = new List<DialogueLine>();
    DialogueController.dc.initDialogue(dialogueLines, "dig_treasure", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), GameObject.Find("Ginger").GetComponent<TextFieldController>(), GingerActionController.getColor());
    dialogueLines[dialogueLines.Count - 1].action = new TimelineFunction(this.grantAchievment);
    for (int index = 0; index < dialogueLines.Count; ++index)
      Timeline.t.addDialogue(dialogueLines[index]);
  }

  private void grantAchievment(string s = "") => GameDataController.Achievement("S_TREASURE");
}

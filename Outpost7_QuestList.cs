// Decompiled with JetBrains decompiler
// Type: Outpost7_QuestList
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\Don't Escape 4 Days in a Wasteland\dontescape_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

public class Outpost7_QuestList : ObjectActionController
{
  public Sprite painting;
  public Sprite paintingDE;

  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "action_stnd_n";
    this.animationFlip = false;
    this.useCurrentDirection = false;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "screen_quests";
    this.range = 1f;
  }

  public List<string> quests()
  {
    List<string> stringList = new List<string>();
    stringList.Add(GameStrings.getString(GameStrings.world_labels, "quests_header") + "^" + GameStrings.getString(GameStrings.world_labels, "quests_underline"));
    if (GameDataController.gd.getObjective("outpost_hatch_open"))
      stringList.Add(stringList[stringList.Count - 1] + "^" + GameStrings.getString(GameStrings.world_labels, "quests_hatch_YES"));
    else
      stringList.Add(stringList[stringList.Count - 1] + "^" + GameStrings.getString(GameStrings.world_labels, "quests_hatch_NO"));
    if (GameDataController.gd.getObjectiveDetail("day_4_threat") == 1 && GameDataController.gd.getObjective("outpost_hull_repaired_outside") || GameDataController.gd.getObjectiveDetail("day_4_threat") == 0 && GameDataController.gd.getObjective("outpost_hull_repaired_inside"))
      stringList.Add(stringList[stringList.Count - 1] + "^" + GameStrings.getString(GameStrings.world_labels, "quests_hull_integrity_YES"));
    else
      stringList.Add(stringList[stringList.Count - 1] + "^" + GameStrings.getString(GameStrings.world_labels, "quests_hull_integrity_NO"));
    int num = 0 + GameDataController.gd.getObjectiveDetail("outpost_score_a") + GameDataController.gd.getObjectiveDetail("outpost_score_b") + GameDataController.gd.getObjectiveDetail("outpost_score_c") + GameDataController.gd.getObjectiveDetail("outpost_score_d") + GameDataController.gd.getObjectiveDetail("outpost_score_e");
    if (GameDataController.gd.getObjectiveDetail("day_4_threat") != 0 || num != 0)
      stringList.Add(stringList[stringList.Count - 1] + "^" + GameStrings.getString(GameStrings.world_labels, "quests_air_mixture_YES"));
    else
      stringList.Add(stringList[stringList.Count - 1] + "^" + GameStrings.getString(GameStrings.world_labels, "quests_air_mixture_NO"));
    if (GameDataController.gd.getObjectiveDetail("day_4_threat") != 1 || num != 0)
      stringList.Add(stringList[stringList.Count - 1] + "^" + GameStrings.getString(GameStrings.world_labels, "quests_fuel_mixture_YES"));
    else
      stringList.Add(stringList[stringList.Count - 1] + "^" + GameStrings.getString(GameStrings.world_labels, "quests_fuel_mixture_NO"));
    if (GameDataController.gd.getObjectiveDetail("day_4_threat") != 1 || GameDataController.gd.getObjective("outpost_catalyst_used"))
      stringList.Add(stringList[stringList.Count - 1] + "^" + GameStrings.getString(GameStrings.world_labels, "quests_catalyst_YES"));
    else
      stringList.Add(stringList[stringList.Count - 1] + "^" + GameStrings.getString(GameStrings.world_labels, "quests_catalyst_NO"));
    if (GameDataController.gd.getObjectiveDetail("day_4_threat") == 0)
      stringList.Add(stringList[stringList.Count - 1] + "^" + GameStrings.getString(GameStrings.world_labels, "quests_air_remember_NO"));
    else
      stringList.Add(stringList[stringList.Count - 1] + "^" + GameStrings.getString(GameStrings.world_labels, "quests_air_remember_YES"));
    stringList.Add(stringList[stringList.Count - 1] + "^" + GameStrings.getString(GameStrings.world_labels, "quests_missing"));
    stringList.Add(stringList[stringList.Count - 1] + "^" + GameStrings.getString(GameStrings.world_labels, "quests_underline"));
    return stringList;
  }

  public override void clickAction()
  {
    PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.computer_click2);
    if (PlayerPrefs.GetString("lang") == GameStrings.Language.DE.ToString())
    {
      ExamineSprite.es.textField.shift.x = -105f;
      ExamineSprite.es.textField.shift.y = 55f;
      ExamineSprite.es.readyText(this.quests(), 213, 0.0f, 1f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f);
      ExamineSprite.es.ac = SoundsManagerController.sm.computer_click1;
      ExamineSprite.es.audioVolume = 0.25f;
      ExamineSprite.es.show(this.paintingDE);
    }
    else
    {
      ExamineSprite.es.textField.shift.x = -52f;
      ExamineSprite.es.textField.shift.y = 55f;
      ExamineSprite.es.readyText(this.quests(), 170, 0.0f, 1f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f);
      ExamineSprite.es.ac = SoundsManagerController.sm.computer_click1;
      ExamineSprite.es.audioVolume = 0.25f;
      ExamineSprite.es.show(this.painting);
    }
  }

  public override void updateState() => this.colliderManager.setCollider(0);

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }

  public override void whatOnClick0()
  {
  }

  public override void whatOnClick()
  {
  }
}

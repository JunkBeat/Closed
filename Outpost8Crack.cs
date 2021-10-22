// Decompiled with JetBrains decompiler
// Type: Outpost8Crack
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

public class Outpost8Crack : ObjectActionController
{
  public Sprite crack;
  public Sprite spaw;

  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "action_stnd_ne";
    this.animationFlip = true;
    this.useCurrentDirection = false;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "outpost_ship_crack_out";
    this.range = 0.0f;
  }

  public void yesWeld()
  {
    InventoryController.ic.removeItem("metal_slab");
    GameDataController.gd.setObjective("outpost_hull_repaired_outside", true);
    CurtainController.cc.fadeOut();
  }

  public override void clickAction()
  {
    if (GameDataController.gd.getObjective("outpost_hull_repaired_outside"))
      PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "crack_outside_fixed"));
    else if (GameDataController.gd.getItemData("welder").droppedLocation == "socket_ship_outside")
    {
      if (this.usedItem != string.Empty)
        QuestionController.qc.showQuestion(GameStrings.getString(GameStrings.warnings, "weld_ship_outside"), yesClick: new Button.Delegate(this.yesWeld), time: 30);
      else
        PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "welder_material_needed"));
    }
    else if (this.usedItem != string.Empty)
    {
      PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "welder_needed"));
    }
    else
    {
      Vector3 color_b = new Vector3(0.8078431f, 0.2235294f, 0.1764706f);
      TextFieldController component = GameObject.Find("Ginger").GetComponent<TextFieldController>();
      List<DialogueLine> dialogueLines = new List<DialogueLine>();
      DialogueController.dc.initDialogue(dialogueLines, "outpost_ship_crack_out", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), component, color_b);
      dialogueLines[3].action = new TimelineFunction(this.gingerwalk);
      for (int index = 0; index < dialogueLines.Count; ++index)
        Timeline.t.addDialogue(dialogueLines[index]);
    }
  }

  public void gingerwalk(string var = "") => GameObject.Find("Ginger").GetComponent<NPCWalkController>().setTargetV3(GameObject.Find("GingerWalk").transform.position);

  public override void updateState()
  {
    if (GameDataController.gd.getObjectiveDetail("day_4_threat") != 1)
    {
      this.GetComponent<SpriteRenderer>().enabled = false;
      this.setCollider(-1);
    }
    else
    {
      this.GetComponent<SpriteRenderer>().enabled = true;
      this.setCollider(0);
      if (GameDataController.gd.getObjective("outpost_hull_repaired_outside"))
      {
        this.objectName = "outpost_ship_crack_out_welded";
        this.GetComponent<SpriteRenderer>().sprite = this.spaw;
        this.interactions = new List<ItemInteraction>();
        this.interactions.Add(new ItemInteraction("nails1", GameStrings.getString(GameStrings.actions, "welder_no_need"), anim: string.Empty));
        this.interactions.Add(new ItemInteraction("nails2", GameStrings.getString(GameStrings.actions, "welder_no_need"), anim: string.Empty));
        this.interactions.Add(new ItemInteraction("nails3", GameStrings.getString(GameStrings.actions, "welder_no_need"), anim: string.Empty));
        this.interactions.Add(new ItemInteraction("nails4", GameStrings.getString(GameStrings.actions, "welder_no_need"), anim: string.Empty));
        this.interactions.Add(new ItemInteraction("nails5", GameStrings.getString(GameStrings.actions, "welder_no_need"), anim: string.Empty));
        this.interactions.Add(new ItemInteraction("hammer", GameStrings.getString(GameStrings.actions, "welder_no_need"), anim: string.Empty));
        this.interactions.Add(new ItemInteraction("ducttape", GameStrings.getString(GameStrings.actions, "welder_no_need"), anim: string.Empty));
        this.interactions.Add(new ItemInteraction("gluegun", GameStrings.getString(GameStrings.actions, "welder_no_need"), anim: string.Empty));
        this.interactions.Add(new ItemInteraction("gluegun_powered", GameStrings.getString(GameStrings.actions, "welder_no_need"), anim: string.Empty));
      }
      else
      {
        this.objectName = "outpost_ship_crack_out";
        this.GetComponent<SpriteRenderer>().sprite = this.crack;
        this.interactions = new List<ItemInteraction>();
        this.interactions.Add(new ItemInteraction("metal_slab", string.Empty, anim: string.Empty));
        this.interactions.Add(new ItemInteraction("nails1", GameStrings.getString(GameStrings.actions, "welder_wrong_item"), anim: string.Empty));
        this.interactions.Add(new ItemInteraction("nails2", GameStrings.getString(GameStrings.actions, "welder_wrong_item"), anim: string.Empty));
        this.interactions.Add(new ItemInteraction("nails3", GameStrings.getString(GameStrings.actions, "welder_wrong_item"), anim: string.Empty));
        this.interactions.Add(new ItemInteraction("nails4", GameStrings.getString(GameStrings.actions, "welder_wrong_item"), anim: string.Empty));
        this.interactions.Add(new ItemInteraction("nails5", GameStrings.getString(GameStrings.actions, "welder_wrong_item"), anim: string.Empty));
        this.interactions.Add(new ItemInteraction("hammer", GameStrings.getString(GameStrings.actions, "welder_wrong_item"), anim: string.Empty));
        this.interactions.Add(new ItemInteraction("ducttape", GameStrings.getString(GameStrings.actions, "welder_wrong_item"), anim: string.Empty));
        this.interactions.Add(new ItemInteraction("welder", GameStrings.getString(GameStrings.actions, "welder_plug_it"), anim: string.Empty));
        this.interactions.Add(new ItemInteraction("gluegun", GameStrings.getString(GameStrings.actions, "welder_wrong_item2"), anim: string.Empty));
        this.interactions.Add(new ItemInteraction("gluegun_powered", GameStrings.getString(GameStrings.actions, "welder_wrong_item2"), anim: string.Empty));
      }
    }
  }

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

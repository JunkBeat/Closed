// Decompiled with JetBrains decompiler
// Type: LocationOutpostShipCrack
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


using System.Collections.Generic;
using UnityEngine;

public class LocationOutpostShipCrack : ObjectActionController
{
  public Sprite crack;
  public Sprite spaw;

  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "action_stnd_";
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "outpost_ship_crack_in";
    this.range = 10f;
  }

  public void yesWeld()
  {
    InventoryController.ic.removeItem("metal_slab");
    GameDataController.gd.setObjective("outpost_hull_repaired_inside", true);
    CurtainController.cc.fadeOut();
  }

  public override void clickAction()
  {
    if (GameDataController.gd.getObjective("outpost_hull_repaired_inside"))
      PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "crack_inside_fixed"));
    else if (GameDataController.gd.getItemData("welder").droppedLocation == "socket_ship_inside")
    {
      if (this.usedItem != string.Empty)
        QuestionController.qc.showQuestion(GameStrings.getString(GameStrings.warnings, "weld_ship_inside"), yesClick: new Button.Delegate(this.yesWeld), time: 30);
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
      TextFieldController component = GameObject.Find("ExamineSprite").GetComponent<TextFieldController>();
      ExamineSprite.es.textField.shift.x = -40f;
      ExamineSprite.es.textField.shift.y = 70f;
      ExamineSprite.es.textField.center = true;
      ExamineSprite.es.textField.directionY = -1f;
      List<DialogueLine> dialogueLines = new List<DialogueLine>();
      DialogueController.dc.initDialogue(dialogueLines, "outpost_ship_crack_in", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), component, color_b);
      for (int index = 0; index < dialogueLines.Count; ++index)
        Timeline.t.addDialogue(dialogueLines[index]);
    }
  }

  public override void updateState()
  {
    if (GameDataController.gd.getObjectiveDetail("day_4_threat") != 0)
    {
      this.GetComponent<SpriteRenderer>().enabled = false;
      this.setCollider(-1);
    }
    else
    {
      this.GetComponent<SpriteRenderer>().enabled = true;
      this.setCollider(0);
      if (GameDataController.gd.getObjective("outpost_hull_repaired_inside"))
      {
        this.objectName = "outpost_ship_crack_in_welded";
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
        this.objectName = "outpost_ship_crack_in";
        this.GetComponent<SpriteRenderer>().sprite = this.crack;
        this.interactions = new List<ItemInteraction>();
        this.interactions.Add(new ItemInteraction("metal_slab", string.Empty, anim: string.Empty));
        this.interactions.Add(new ItemInteraction("nails1", GameStrings.getString(GameStrings.actions, "welder_wrong_item"), anim: string.Empty));
        this.interactions.Add(new ItemInteraction("nails2", GameStrings.getString(GameStrings.actions, "welder_wrong_item"), anim: string.Empty));
        this.interactions.Add(new ItemInteraction("nails3", GameStrings.getString(GameStrings.actions, "welder_wrong_item"), anim: string.Empty));
        this.interactions.Add(new ItemInteraction("nails4", GameStrings.getString(GameStrings.actions, "welder_wrong_item"), anim: string.Empty));
        this.interactions.Add(new ItemInteraction("nails5", GameStrings.getString(GameStrings.actions, "welder_wrong_item"), anim: string.Empty));
        this.interactions.Add(new ItemInteraction("hammer", GameStrings.getString(GameStrings.actions, "welder_wrong_item"), anim: string.Empty));
        this.interactions.Add(new ItemInteraction("gluegun", GameStrings.getString(GameStrings.actions, "welder_wrong_item2"), anim: string.Empty));
        this.interactions.Add(new ItemInteraction("gluegun_powered", GameStrings.getString(GameStrings.actions, "welder_wrong_item2"), anim: string.Empty));
        this.interactions.Add(new ItemInteraction("ducttape", GameStrings.getString(GameStrings.actions, "welder_wrong_item"), anim: string.Empty));
        this.interactions.Add(new ItemInteraction("welder", GameStrings.getString(GameStrings.actions, "welder_plug_it"), anim: string.Empty));
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

// Decompiled with JetBrains decompiler
// Type: HouseBInsideBody
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\Don't Escape 4 Days in a Wasteland\dontescape_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

public class HouseBInsideBody : ObjectActionController
{
  public Sprite sprite1;
  public Sprite sprite2;
  public Collider2D pathBlocker;

  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "kneel_";
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "house_b_inside_body";
    this.interactions = new List<ItemInteraction>();
    this.interactions.Add(new ItemInteraction("sheet", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("blanketb", GameStrings.getString(GameStrings.actions, "house_b_wife_wrong_cover"), anim: string.Empty));
    this.interactions.Add(new ItemInteraction("blanket", GameStrings.getString(GameStrings.actions, "house_b_wife_wrong_cover"), anim: string.Empty));
    this.interactions.Add(new ItemInteraction("thermalb", GameStrings.getString(GameStrings.actions, "house_b_wife_wrong_cover"), anim: string.Empty));
    this.interactions.Add(new ItemInteraction("coat1", GameStrings.getString(GameStrings.actions, "house_b_wife_wrong_cover2"), anim: string.Empty));
    this.interactions.Add(new ItemInteraction("coat2", GameStrings.getString(GameStrings.actions, "house_b_wife_wrong_cover2"), anim: string.Empty));
    this.interactions.Add(new ItemInteraction("coat3", GameStrings.getString(GameStrings.actions, "house_b_wife_wrong_cover2"), anim: string.Empty));
    this.interactions.Add(new ItemInteraction("coat4", GameStrings.getString(GameStrings.actions, "house_b_wife_wrong_cover2"), anim: string.Empty));
    this.range = 10f;
  }

  public void pickUpLocket(string val = "")
  {
    if (!InventoryController.ic.pickUpItem(ItemsManager.im.getItem("locket")))
      return;
    GameDataController.gd.setObjective("house_b_wife_note_taken", true);
    this.updateState();
  }

  public override void clickAction()
  {
    if (GameDataController.gd.getCurrentDay() > 2)
    {
      List<DialogueLine> dialogueLineList = new List<DialogueLine>();
      DialogueController.dc.initDialogue(dialogueLineList, "wife_too_late", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), GameObject.Find("Ginger").GetComponent<GingerActionController>().textField, GingerActionController.getColor());
      Timeline.t.addDialogueLines(dialogueLineList);
    }
    else if (!GameDataController.gd.getObjective("house_b_wife_covered") && this.usedItem == "sheet")
    {
      PlayerController.pc.textField.viewText(GameStrings.getString(GameStrings.actions, "house_b_wife_covered"), true);
      GameDataController.gd.setObjective("house_b_wife_covered", true);
      InventoryController.ic.removeItem("sheet");
      this.updateAll();
    }
    else if (GameDataController.gd.getObjective("house_b_wife_covered") && !GameDataController.gd.getObjective("house_b_wife_note_taken"))
    {
      if (!InventoryController.ic.pickUpItem(ItemsManager.im.getItem("sheet")))
        return;
      GameDataController.gd.setObjective("house_b_wife_covered", false);
      this.updateState();
    }
    else if (!GameDataController.gd.getObjective("house_b_wife_note_taken"))
    {
      if (!InventoryController.ic.pickUpItem(ItemsManager.im.getItem("locket")))
        return;
      GameDataController.gd.setObjective("house_b_wife_note_taken", true);
      this.updateState();
    }
    else if (!GameDataController.gd.getObjective("house_b_wife_covered"))
    {
      if (!GameDataController.gd.getObjective("dialogue_npc2_burial"))
        PlayerController.pc.textField.viewText(GameStrings.getString(GameStrings.actions, "house_b_wife_cant_move"), true);
      else
        PlayerController.pc.textField.viewText(GameStrings.getString(GameStrings.actions, "house_b_wife_needs_cover"), true);
    }
    else if (!GameDataController.gd.getObjective("dialogue_npc2_burial"))
    {
      PlayerController.pc.textField.viewText(GameStrings.getString(GameStrings.actions, "house_b_wife_cant_move"), true);
    }
    else
    {
      List<DialogueLine> dialogueLineList = new List<DialogueLine>();
      DialogueController.dc.initDialogue(dialogueLineList, "ginger_move_body1", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), GameObject.Find("Ginger").GetComponent<GingerActionController>().textField, GingerActionController.getColor());
      dialogueLineList[2].action = new TimelineFunction(this.moveBody);
      dialogueLineList[2].actionWithText = false;
      Timeline.t.addDialogueLines(dialogueLineList);
    }
  }

  public void moveBody(string val = "")
  {
    GameDataController.gd.setObjective("house_b_wife_moved", true);
    PlayerController.pc.setBusy(true);
    PlayerController.pc.spawnName = "WaypointHouseBBackBody";
    CurtainController.cc.fadeOut("LocationHouseBBack", WalkController.Direction.W);
    DialogueController.dc.talking = false;
    DialogueController.dc.hide();
    Timeline.t.doNotUnlock = true;
  }

  public override void updateState()
  {
    bool enabled = this.pathBlocker.enabled;
    this.range = 10f;
    if (GameDataController.gd.getObjective("house_b_wife_moved"))
    {
      this.colliderManager.setCollider(-1);
      this.characterAnimationName = "stand_";
      this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
      this.pathBlocker.enabled = false;
    }
    else if (GameDataController.gd.getObjective("house_b_wife_covered"))
    {
      this.objectName = "house_b_back_body";
      this.pathBlocker.enabled = true;
      this.colliderManager.setCollider(0);
      this.characterAnimationName = "kneel_";
      this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
      this.gameObject.GetComponent<SpriteRenderer>().sprite = this.sprite2;
    }
    else
    {
      this.objectName = "house_b_inside_body";
      this.pathBlocker.enabled = true;
      this.colliderManager.setCollider(0);
      this.characterAnimationName = "kneel_";
      this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
      this.gameObject.GetComponent<SpriteRenderer>().sprite = this.sprite1;
      if (GameDataController.gd.getCurrentDay() > 2)
      {
        this.GetComponent<ParticleGenerator>().started = true;
        this.GetComponent<AudioSource>().Play();
        this.characterAnimationName = "action_stnd_";
        this.range = 20f;
      }
    }
    if (enabled == this.pathBlocker.enabled)
      return;
    GameObject.Find("Location").GetComponent<LocationManager>().initNodes();
  }

  public override void whatOnClick()
  {
    if (GameDataController.gd.getCurrentDay() == 2 && (this.usedItem == "sheet" || !GameDataController.gd.getObjective("house_b_wife_note_taken")))
      this.characterAnimationName = "kneel_";
    else
      this.characterAnimationName = "action_stnd_";
  }

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
    if (GameDataController.gd.getCurrentDay() > 2 || GameDataController.gd.getObjective("house_b_wife_covered") && !GameDataController.gd.getObjective("house_b_wife_note_taken") || GameDataController.gd.getObjective("house_b_wife_note_taken") || !(this.usedItem == string.Empty))
      return;
    PlayerController.pc.textField.viewText(GameStrings.getString(GameStrings.actions, "house_b_wife_inspected"), true);
  }
}

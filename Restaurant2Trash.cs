// Decompiled with JetBrains decompiler
// Type: Restaurant2Trash
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\Don't Escape 4 Days in a Wasteland\dontescape_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

public class Restaurant2Trash : ObjectActionController
{
  public GameObject trashCollider;

  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "pull2_w";
    this.animationFlip = false;
    this.useCurrentDirection = false;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "restaurant_trash";
    this.range = 3f;
    this.interactions = new List<ItemInteraction>();
    this.interactions.Add(new ItemInteraction("crowbar", GameStrings.getString(GameStrings.actions, "restaurant_trash_crowbar"), anim: string.Empty));
    this.interactions.Add(new ItemInteraction("rope", GameStrings.getString(GameStrings.actions, "restaurant_trash_crowbar"), anim: string.Empty));
    this.interactions.Add(new ItemInteraction("hook", GameStrings.getString(GameStrings.actions, "restaurant_trash_crowbar"), anim: string.Empty));
    this.interactions.Add(new ItemInteraction("ropehook", GameStrings.getString(GameStrings.actions, "restaurant_trash_crowbar"), anim: string.Empty));
  }

  public override void clickAction()
  {
  }

  public override void updateState()
  {
    if (GameDataController.gd.getObjective("restaurant_trash_moved"))
    {
      this.trashCollider.transform.position = new Vector3(0.485f, 0.031f, 100f);
      this.setCollider(-1);
      this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
    }
    else
    {
      this.trashCollider.transform.position = new Vector3(-0.019f, -0.06f, 100f);
      this.setCollider(0);
      this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
    }
    ItemsManager.im.fixGroundItems(new Vector2(95f, 35f), new Vector2(20f, 10f));
    GameObject.Find("Location").GetComponent<LocationManager>().initNodes();
    ItemsManager.im.initGroundAndInv();
  }

  public override void clickAction2()
  {
    PlayerController.pc.textField.viewText(GameStrings.getString(GameStrings.actions, "restaurant_trash_heavy"), true);
    GameDataController.gd.setObjective("restaurant_trash_tried", true);
  }

  public override void clickAction0()
  {
  }

  public void pushLittleCart_Barry()
  {
    this.pushLittleCart();
    TextFieldController component = GameObject.Find("Npc2").GetComponent<TextFieldController>();
    List<DialogueLine> dialogueLines = new List<DialogueLine>();
    DialogueController.dc.initDialogue(dialogueLines, "barry_pushed_trash", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), component, Npc2Controller.getColor());
    for (int index = 0; index < dialogueLines.Count; ++index)
      Timeline.t.addDialogue(dialogueLines[index]);
  }

  public void pushLittleCart_Cate()
  {
    this.pushLittleCart();
    TextFieldController component = GameObject.Find("Ginger").GetComponent<TextFieldController>();
    List<DialogueLine> dialogueLines = new List<DialogueLine>();
    DialogueController.dc.initDialogue(dialogueLines, "ginger_pushed_trash", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), component, GingerActionController.getColor());
    for (int index = 0; index < dialogueLines.Count; ++index)
      Timeline.t.addDialogue(dialogueLines[index]);
  }

  public void pushLittleCart()
  {
    GameDataController.gd.setObjective("restaurant_trash_moved", !GameDataController.gd.getObjective("restaurant_trash_moved"));
    this.trashCollider.transform.position = !GameDataController.gd.getObjective("restaurant_trash_moved") ? new Vector3(-0.019f, -0.06f, 100f) : new Vector3(0.485f, 0.031f, 100f);
    ItemsManager.im.fixGroundItems(new Vector2(95f, 35f), new Vector2(20f, 10f));
    DialogueController.dc.talking = false;
    DialogueController.dc.hide();
    this.updateState();
    CurtainController.cc.fadeOut(targetDir: WalkController.Direction.S);
  }
}

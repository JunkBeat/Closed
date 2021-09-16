// Decompiled with JetBrains decompiler
// Type: Restaurant2Door
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\Don't Escape 4 Days in a Wasteland\dontescape_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;

public class Restaurant2Door : ObjectActionController
{
  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "action1_e";
    this.animationFlip = false;
    this.useCurrentDirection = false;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "restaurant_backdoor";
    this.range = 1f;
    this.interactions = new List<ItemInteraction>();
    this.interactions.Add(new ItemInteraction("crowbar", GameStrings.getString(GameStrings.actions, "restaurant_door_crowbar"), anim: string.Empty));
    this.interactions.Add(new ItemInteraction("paperclip", GameStrings.getString(GameStrings.actions, "restaurant_door_lockpick"), anim: string.Empty));
  }

  public override void clickAction()
  {
    if (!GameDataController.gd.getObjective("dialogue_cody_intro") && GameDataController.gd.getCurrentDay() == 2)
    {
      PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "restaurant_first_check_front"));
    }
    else
    {
      PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.metal_locked_2);
      PlayerController.pc.textField.viewText(GameStrings.getString(GameStrings.actions, "restaurant_backdoor"), true);
    }
  }

  public override void whatOnClick0()
  {
    if (GameDataController.gd.getObjective("npc3_alive") && !GameDataController.gd.getObjective("dialogue_cody_intro"))
    {
      this.characterAnimationName = "action_stnd_";
      this.animationFlip = false;
      this.useCurrentDirection = true;
      this.range = 200f;
    }
    else
    {
      this.characterAnimationName = "action1_e";
      this.animationFlip = false;
      this.useCurrentDirection = false;
      this.range = 1f;
    }
  }

  public override void updateState()
  {
    if (!GameDataController.gd.getObjective("restaurant_trash_moved"))
      this.setCollider(0);
    else
      this.setCollider(-1);
  }

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }
}

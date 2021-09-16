// Decompiled with JetBrains decompiler
// Type: SiderealF2SCBody
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


using System.Collections.Generic;

public class SiderealF2SCBody : ObjectActionController
{
  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.animationFlip = false;
    this.useCurrentDirection = false;
    this.characterAnimationName = "action_n";
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "sidereal_body";
    this.range = 2f;
    this.updateState();
    this.interactions = new List<ItemInteraction>();
    this.interactions.Add(new ItemInteraction("knife", string.Empty, anim: string.Empty));
  }

  public override void clickAction()
  {
    if (this.usedItem != string.Empty)
    {
      if (GameDataController.gd.getObjective("sidereal_finger_cut"))
        PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "finger_already_cut"));
      else if (!GameDataController.gd.getObjective("visited_outpost4"))
      {
        PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "finger_why_cut"));
      }
      else
      {
        PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "finger_done_cut"));
        InventoryController.ic.pickOrDropItem(ItemsManager.im.getItem("finger"));
        GameDataController.gd.setObjective("sidereal_finger_cut", true);
      }
    }
    else if (!GameDataController.gd.getObjective("sidereal_keys_taken"))
      this.pickItUp((string) null);
    else
      PlayerController.pc.textField.viewText(GameStrings.getString(GameStrings.actions, "sidereal_body"), true);
  }

  private void pickItUp(string param)
  {
    if (!InventoryController.ic.pickUpItem(ItemsManager.im.getItem("sidereal_id_key")))
      return;
    GameDataController.gd.setObjective("sidereal_keys_taken", true);
    this.updateState();
  }

  public override void whatOnClick()
  {
    if (this.usedItem == "knife" && !GameDataController.gd.getObjective("sidereal_finger_cut") && GameDataController.gd.getObjective("visited_outpost4"))
    {
      this.animationFlip = false;
      this.useCurrentDirection = false;
      this.characterAnimationName = "action_n";
      this.range = 2f;
    }
    if (GameDataController.gd.getObjective("sidereal_keys_taken") || this.usedItem != string.Empty && (GameDataController.gd.getObjective("sidereal_finger_cut") || !GameDataController.gd.getObjective("visited_outpost4")))
    {
      this.animationFlip = false;
      this.useCurrentDirection = true;
      this.characterAnimationName = "action_stnd_";
      this.range = 50f;
    }
    else
    {
      this.animationFlip = false;
      this.useCurrentDirection = false;
      this.characterAnimationName = "action_n";
      this.range = 2f;
    }
  }

  public override void updateState()
  {
    if (GameDataController.gd.getObjective("sidereal_keys_taken") || this.usedItem != string.Empty && (GameDataController.gd.getObjective("sidereal_finger_cut") || !GameDataController.gd.getObjective("visited_outpost4")))
    {
      this.animationFlip = false;
      this.useCurrentDirection = true;
      this.characterAnimationName = "action_stnd_";
      this.range = 50f;
    }
    else
    {
      this.animationFlip = false;
      this.useCurrentDirection = false;
      this.characterAnimationName = "action_n";
      this.range = 2f;
    }
  }

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
    if (this.usedItem != string.Empty && !GameDataController.gd.getObjective("sidereal_finger_cut") && GameDataController.gd.getObjective("visited_outpost4"))
      PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "finger_start_cut"));
    if (GameDataController.gd.getObjective("sidereal_keys_taken") || !(this.usedItem == string.Empty))
      return;
    PlayerController.pc.textField.viewText(GameStrings.getString(GameStrings.actions, "sidereal_keys"), true);
  }
}

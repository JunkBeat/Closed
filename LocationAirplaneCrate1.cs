// Decompiled with JetBrains decompiler
// Type: LocationAirplaneCrate1
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


using System.Collections.Generic;
using UnityEngine;

public class LocationAirplaneCrate1 : ObjectActionController
{
  public int number;
  public string item;

  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "action_stnd_";
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "airplane_crate_1";
    this.range = 2f;
    this.interactions = new List<ItemInteraction>();
    this.interactions.Add(new ItemInteraction("crowbar", string.Empty, anim: string.Empty));
  }

  public override void clickAction()
  {
    if (!GameDataController.gd.getObjective("plane_crate_" + (object) this.number))
    {
      if (this.usedItem != string.Empty)
        QuestionController.qc.showQuestion(GameStrings.getString(GameStrings.warnings, "airplane_crate_1") + " " + (object) this.number + GameStrings.getString(GameStrings.warnings, "airplane_crate_2"), yesClick: new Button.Delegate(this.openIt), time: 12, timeSaver: 2);
      else
        PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "crate_locked"));
    }
    else if (this.usedItem != string.Empty)
      PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "generic_opened"));
    else if (!GameDataController.gd.getObjective("plane_crate_" + (object) this.number + "_taken"))
    {
      if (!InventoryController.ic.pickUpItem(ItemsManager.im.getItem(this.item)))
        return;
      GameDataController.gd.setObjective("plane_crate_" + (object) this.number + "_taken", true);
      this.updateState();
    }
    else
      PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "crate_enough_" + (object) GameDataController.gd.getObjectiveDetail("plane_crate_" + (object) this.number)));
  }

  public void openIt()
  {
    GameDataController.gd.setObjective("plane_crate_" + (object) this.number, true);
    AudioClip sound = (AudioClip) null;
    float num = (float) Random.Range(0, 3);
    if ((double) num == 0.0)
      sound = SoundsManagerController.sm.wood_crack_1;
    if ((double) num == 1.0)
      sound = SoundsManagerController.sm.wood_crack_2;
    if ((double) num == 2.0)
      sound = SoundsManagerController.sm.wood_crack_3;
    CurtainController.cc.fadeOut(sound: sound, actionAfterFade: new CurtainController.Delegate(this.sayOpen));
  }

  public void sayOpen()
  {
    int num = 0;
    for (int index = 1; index < 8; ++index)
    {
      if (GameDataController.gd.getObjective("plane_crate_" + (object) index))
        ++num;
    }
    PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "crate_opened_" + (object) num));
  }

  public override void updateState()
  {
    this.colliderManager.setCollider(0);
    if (this.number == 1)
      this.objectName = "airplane_crate_1";
    if (this.number == 2)
      this.objectName = "airplane_crate_2";
    if (this.number == 3)
      this.objectName = "airplane_crate_3";
    if (this.number == 4)
      this.objectName = "airplane_crate_4";
    if (this.number == 5)
      this.objectName = "airplane_crate_5";
    if (this.number == 6)
      this.objectName = "airplane_crate_6";
    if (this.number == 7)
      this.objectName = "airplane_crate_7";
    if (GameDataController.gd.getObjective("plane_crate_" + (object) this.number) && !GameDataController.gd.getObjective("plane_crate_" + (object) this.number + "_taken"))
    {
      this.objectName = "airplane_crate_revealed_" + (object) GameDataController.gd.getObjectiveDetail("plane_crate_" + (object) this.number);
      this.characterAnimationName = "action_n";
      this.animationFlip = false;
      this.useCurrentDirection = false;
    }
    else if (GameDataController.gd.getObjective("plane_crate_" + (object) this.number))
    {
      this.objectName = "airplane_crate_revealed_" + (object) GameDataController.gd.getObjectiveDetail("plane_crate_" + (object) this.number);
      this.characterAnimationName = "action_stnd_";
      this.animationFlip = false;
      this.useCurrentDirection = true;
    }
    else
    {
      this.characterAnimationName = "action_stnd_";
      this.animationFlip = false;
      this.useCurrentDirection = true;
    }
    if (GameDataController.gd.getObjectiveDetail("plane_crate_" + (object) this.number) == 1)
      this.item = "nav_chip";
    if (GameDataController.gd.getObjectiveDetail("plane_crate_" + (object) this.number) == 2)
      this.item = "air_tanks";
    if (GameDataController.gd.getObjectiveDetail("plane_crate_" + (object) this.number) == 3)
      this.item = "voltmeter";
    if (GameDataController.gd.getObjectiveDetail("plane_crate_" + (object) this.number) == 4)
      this.item = "noodles";
    if (GameDataController.gd.getObjectiveDetail("plane_crate_" + (object) this.number) == 5)
      this.item = "gasket";
    if (GameDataController.gd.getObjectiveDetail("plane_crate_" + (object) this.number) == 6)
      this.item = "nuts_and_bolts";
    if (GameDataController.gd.getObjectiveDetail("plane_crate_" + (object) this.number) == 7)
      this.item = "wires";
    if (GameDataController.gd.getObjective("plane_crate_" + (object) this.number))
      this.GetComponent<SpriteRenderer>().enabled = true;
    else
      this.GetComponent<SpriteRenderer>().enabled = false;
  }

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
    if (!GameDataController.gd.getObjective("plane_crate_" + (object) this.number) || GameDataController.gd.getObjective("plane_crate_" + (object) this.number + "_taken"))
      return;
    PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "crate_take_" + (object) GameDataController.gd.getObjectiveDetail("plane_crate_" + (object) this.number)));
  }

  public override void whatOnClick0()
  {
  }

  public override void whatOnClick()
  {
  }
}

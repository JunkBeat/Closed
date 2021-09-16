// Decompiled with JetBrains decompiler
// Type: MoonShipCloset
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\Don't Escape 4 Days in a Wasteland\dontescape_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class MoonShipCloset : ObjectActionController
{
  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "action1_e";
    this.animationFlip = false;
    this.useCurrentDirection = false;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "ship_closet";
    this.actionType = ObjectActionController.Type.NormalAction;
    this.doubleClickCondition = string.Empty;
    this.updateAll();
  }

  public void wearit(string s = "")
  {
    PlayerController.pc.spawnName = nameof (MoonShipCloset);
    CurtainController.cc.fadeOut("MoonShip");
  }

  public override void clickAction()
  {
    if (GameDataController.gd.getObjective("moon_suited_up"))
      PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "already_suited_up"));
    else if (!GameDataController.gd.getObjective("moon_shocked1") && (!GameDataController.gd.getObjective("npc2_alive") || !GameDataController.gd.getObjective("moon_shocked2")) && (!GameDataController.gd.getObjective("npc3_alive") || !GameDataController.gd.getObjective("moon_shocked3")))
    {
      if (!GameDataController.gd.getObjective("moon_closet_open"))
      {
        PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.cabinet_open);
        GameDataController.gd.setObjective("moon_closet_open", true);
        this.updateAll();
      }
      else
      {
        PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.rope);
        GameDataController.gd.setObjective("moon_suited_up", true);
        this.wearit(string.Empty);
      }
    }
    else if (GameDataController.gd.getObjective("npc2_alive") || GameDataController.gd.getObjective("npc3_alive"))
      PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "ship_exit_not_yet_others"));
    else if (GameDataController.gd.getObjective("npc1_alive"))
      PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "ship_exit_not_yet_cate"));
    else
      PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "ship_exit_not_yet_suits"));
  }

  public override void updateState()
  {
    this.characterAnimationName = "action1_e";
    if (GameDataController.gd.getObjective("moon_suited_up"))
      this.characterAnimationName = "suit_action_stnd_e";
    if (!GameDataController.gd.getObjective("moon_suited_up") && GameDataController.gd.getObjective("moon_closet_open"))
      this.GetComponent<SpriteRenderer>().enabled = true;
    else
      this.GetComponent<SpriteRenderer>().enabled = false;
  }

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }
}

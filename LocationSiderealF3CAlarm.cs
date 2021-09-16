// Decompiled with JetBrains decompiler
// Type: LocationSiderealF3CAlarm
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


using System.Collections.Generic;

public class LocationSiderealF3CAlarm : ObjectActionController
{
  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "action_stnd_";
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "sidereal_alarm1";
    this.range = 11f;
    this.teleport = false;
    this.interactions = new List<ItemInteraction>();
    this.interactions.Add(new ItemInteraction("rock", GameStrings.getString(GameStrings.actions, "sidereal_alarm_break"), anim: string.Empty));
    this.interactions.Add(new ItemInteraction("rock2", GameStrings.getString(GameStrings.actions, "sidereal_alarm_break"), anim: string.Empty));
    this.interactions.Add(new ItemInteraction("hammer", GameStrings.getString(GameStrings.actions, "sidereal_alarm_break"), anim: string.Empty));
    this.interactions.Add(new ItemInteraction("crowbar", GameStrings.getString(GameStrings.actions, "sidereal_alarm_break"), anim: string.Empty));
    this.interactions.Add(new ItemInteraction("pipe", GameStrings.getString(GameStrings.actions, "sidereal_alarm_break"), anim: string.Empty));
    this.interactions.Add(new ItemInteraction("wrench", GameStrings.getString(GameStrings.actions, "sidereal_alarm_break"), anim: string.Empty));
    this.interactions.Add(new ItemInteraction("shovel", GameStrings.getString(GameStrings.actions, "sidereal_alarm_break"), anim: string.Empty));
    this.updateState();
  }

  private void Update()
  {
  }

  public override void whatOnClick()
  {
  }

  public override void clickAction()
  {
    PlayerController.pc.sayLine(GameStrings.getString(GameStrings.actions, "sidereal_alarm1"));
    PlayerController.pc.sayLine(GameStrings.getString(GameStrings.actions, "sidereal_alarm2"));
  }

  public override void updateState()
  {
  }

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }
}

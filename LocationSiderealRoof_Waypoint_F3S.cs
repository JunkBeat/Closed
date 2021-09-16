// Decompiled with JetBrains decompiler
// Type: LocationSiderealRoof_Waypoint_F3S
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\Don't Escape 4 Days in a Wasteland\dontescape_Data\Managed\Assembly-CSharp.dll

public class LocationSiderealRoof_Waypoint_F3S : ObjectActionController
{
  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "stop";
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "sidereal_hole";
    this.actionType = ObjectActionController.Type.Transition;
    this.trans_dir = WalkController.Direction.E;
  }

  public override void clickAction()
  {
    int num = 0;
    if (GameDataController.gd.getObjective("npc2_joined") && GameDataController.gd.getObjective("npc2_alive"))
      ++num;
    if (GameDataController.gd.getObjective("npc3_joined") && GameDataController.gd.getObjective("npc3_alive"))
      ++num;
    if (num > 0)
    {
      if (GameDataController.gd.getObjective("sidereal_roof_wait_for_rescue"))
      {
        if (num == 1)
          PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "save_npc_first1"));
        else
          PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "save_npc_first2"));
      }
      else if (GameDataController.gd.getObjective("sidereal_roof_npc_shocked"))
      {
        if (GameDataController.gd.getObjective("npc2_joined") && GameDataController.gd.getObjective("npc2_alive"))
          PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "save_npc_shocked_barry"));
        if (!GameDataController.gd.getObjective("npc3_joined") || !GameDataController.gd.getObjective("npc3_alive"))
          return;
        PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "save_npc_shocked_cody"));
      }
      else
      {
        PlayerController.pc.spawnName = "LocationSiderealF3S_Waypoint_Roof";
        CurtainController.cc.fadeOut("SiderealF3S", WalkController.Direction.E);
      }
    }
    else
    {
      PlayerController.pc.spawnName = "LocationSiderealF3S_Waypoint_Roof";
      CurtainController.cc.fadeOut("SiderealF3S", WalkController.Direction.E);
    }
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

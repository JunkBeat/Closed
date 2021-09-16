// Decompiled with JetBrains decompiler
// Type: LocationAirplane1Waypoint12
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\Don't Escape 4 Days in a Wasteland\dontescape_Data\Managed\Assembly-CSharp.dll

public class LocationAirplane1Waypoint12 : ObjectActionController
{
  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "stop";
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "airplane_exit";
    this.doubleClickCondition = "visited_airplane2";
    this.actionType = ObjectActionController.Type.Transition;
    this.trans_dir = WalkController.Direction.N;
    this.range = 2f;
  }

  public override void clickAction()
  {
    if (GameDataController.gd.getObjective("plane_undig"))
    {
      PlayerController.pc.setBusy(true);
      PlayerController.pc.spawnName = "LocationAirplane2Waypoint21";
      CurtainController.cc.fadeOut("LocationAirplane2", WalkController.Direction.N);
    }
    else
      PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "plane_covered"));
  }

  public override void updateState()
  {
    if (GameDataController.gd.getObjective("plane_undig"))
    {
      this.colliderManager.setCollider(1);
      this.actionType = ObjectActionController.Type.Transition;
      this.characterAnimationName = "action_stnd_";
    }
    else
    {
      this.colliderManager.setCollider(0);
      this.actionType = ObjectActionController.Type.NormalAction;
      this.characterAnimationName = "stop";
    }
  }

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }
}

// Decompiled with JetBrains decompiler
// Type: Waypoint_Outpost3_2
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

public class Waypoint_Outpost3_2 : ObjectActionController
{
  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "stop";
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "outpost_exit";
    this.actionType = ObjectActionController.Type.Transition;
    this.trans_dir = WalkController.Direction.W;
    this.doubleClickCondition = "visited_outpost2";
  }

  public override void clickAction()
  {
    if (!GameDataController.gd.getObjective("outpost_door_powered"))
    {
      PlayerController.pc.spawnName = "Waypoint_Outpost2_3";
      CurtainController.cc.fadeOut("LocationOutpostOutside2", WalkController.Direction.W);
    }
    else
      PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "outpost_door_powered"));
  }

  public override void updateState()
  {
    if (!GameDataController.gd.getObjective("outpost_door_powered"))
    {
      this.characterAnimationName = "stop";
      this.animationFlip = false;
      this.useCurrentDirection = true;
      this.actionType = ObjectActionController.Type.Transition;
      this.trans_dir = WalkController.Direction.N;
      this.doubleClickCondition = "visited_outpost2";
    }
    else
    {
      this.characterAnimationName = "action_stnd_";
      this.animationFlip = false;
      this.useCurrentDirection = true;
      this.actionType = ObjectActionController.Type.NormalAction;
      this.trans_dir = WalkController.Direction.N;
      this.doubleClickCondition = string.Empty;
    }
  }

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }
}

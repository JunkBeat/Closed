// Decompiled with JetBrains decompiler
// Type: WaypointHouseB0
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\Don't Escape 4 Days in a Wasteland\dontescape_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class WaypointHouseB0 : ObjectActionController
{
  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "stop";
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "house_b_waypoint0";
    this.actionType = ObjectActionController.Type.Transition;
    this.doubleClickCondition = "visited_house_b";
    this.range = 10f;
  }

  public override void clickAction()
  {
    if (!GameDataController.gd.getObjective("dialogue_ginger_barry_distracted"))
    {
      this.exitToMap(string.Empty);
    }
    else
    {
      GameObject.Find("Ginger").GetComponent<GingerActionController>().distractBarryEnd();
      Timeline.t.addAction(new TimelineAction()
      {
        function = new TimelineFunction(this.exitToMap),
        actionWithText = true
      });
      PlayerController.pc.setBusy(true);
    }
  }

  public void exitToMap(string val = "")
  {
    PlayerController.pc.setBusy(true);
    Timeline.t.doNotUnlock = true;
    PlayerController.pc.spawnName = "InfoExit";
    CurtainController.cc.fadeOut("LocationMap", WalkController.Direction.E);
  }

  public override void updateState() => this.colliderManager.setCollider(0);

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }
}

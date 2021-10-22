// Decompiled with JetBrains decompiler
// Type: Waypoint_CS3_CS4
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

public class Waypoint_CS3_CS4 : ObjectActionController
{
  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "stop";
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "construction_site_2";
    this.actionType = ObjectActionController.Type.Transition;
    this.trans_dir = WalkController.Direction.N;
    this.range = 10f;
  }

  public override void clickAction()
  {
    if (GameDataController.gd.getObjectiveDetail("day_3_threat") == 1 && GameDataController.gd.getObjective("cs_rain_enter_left") && !GameDataController.gd.getObjective("cs_pack_lifted"))
    {
      PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "cant_reach"));
    }
    else
    {
      if (GameDataController.gd.getObjectiveDetail("day_3_threat") == 0 && GameDataController.gd.getCurrentDay() == 3)
        return;
      PlayerController.pc.spawnName = "Waypoint_CS4_CS3";
      CurtainController.cc.fadeOut("CS4", WalkController.Direction.W);
    }
  }

  public override void updateState()
  {
    if (GameDataController.gd.getObjectiveDetail("day_3_threat") == 1 && GameDataController.gd.getObjective("cs_rain_enter_left") && !GameDataController.gd.getObjective("cs_pack_lifted"))
    {
      this.characterAnimationName = "action_stnd_";
      this.animationFlip = false;
      this.useCurrentDirection = true;
      this.range = 200f;
      this.doubleClickCondition = string.Empty;
    }
    else
    {
      this.characterAnimationName = "stop";
      this.animationFlip = false;
      this.useCurrentDirection = true;
      this.range = 1f;
      this.doubleClickCondition = "visited_cs_3";
    }
    if (GameDataController.gd.getObjectiveDetail("day_3_threat") == 0 && GameDataController.gd.getCurrentDay() == 3)
      this.setCollider(-1);
    else
      this.setCollider(0);
  }

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }
}

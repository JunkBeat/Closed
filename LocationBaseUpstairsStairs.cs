// Decompiled with JetBrains decompiler
// Type: LocationBaseUpstairsStairs
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

public class LocationBaseUpstairsStairs : ObjectActionController
{
  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "stop";
    this.animationFlip = true;
    this.useCurrentDirection = false;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "base_stairs_down";
    this.doubleClickCondition = "visited_location1";
    this.actionType = ObjectActionController.Type.Transition;
    this.trans_dir = WalkController.Direction.S;
  }

  public override void whatOnClick()
  {
    if (GameDataController.gd.getCurrentDay() == 4 && GameDataController.gd.getObjective("thug_to_kill_bathroom"))
    {
      this.doubleClickCondition = "none";
      this.characterAnimationName = "action_stnd_";
      this.animationFlip = false;
      this.useCurrentDirection = true;
    }
    else if (GameDataController.gd.getCurrentDay() == 2 && !GameDataController.gd.getObjective("dialogue_ginger_intro"))
    {
      this.doubleClickCondition = "none";
      this.characterAnimationName = "action_stnd_";
      this.animationFlip = false;
      this.useCurrentDirection = true;
    }
    else
    {
      this.doubleClickCondition = "visited_location1";
      this.characterAnimationName = "stop";
      this.animationFlip = false;
      this.useCurrentDirection = false;
    }
  }

  public override void clickAction()
  {
    if (GameDataController.gd.getCurrentDay() == 4 && GameDataController.gd.getObjective("thug_to_kill_bathroom"))
      PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "day4_start_stairs_no"));
    else if (GameDataController.gd.getCurrentDay() == 2 && !GameDataController.gd.getObjective("dialogue_ginger_intro"))
    {
      PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "heli_crash_check"));
    }
    else
    {
      PlayerController.pc.spawnName = "Stairs_Exit";
      CurtainController.cc.fadeOut("Location1", WalkController.Direction.E);
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

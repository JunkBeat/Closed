// Decompiled with JetBrains decompiler
// Type: Waypoint_CS4_CS1
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

public class Waypoint_CS4_CS1 : ObjectActionController
{
  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "stop";
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "cs_waypoint_4_1";
    this.actionType = ObjectActionController.Type.Transition;
    this.trans_dir = WalkController.Direction.W;
    this.doubleClickCondition = string.Empty;
  }

  public override void clickAction()
  {
    if (GameDataController.gd.getObjective("constructionsite_from_above"))
    {
      PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "cant_reach"));
    }
    else
    {
      PlayerController.pc.spawnName = "CS1_Waypoint_4";
      CurtainController.cc.fadeOut("CS1", WalkController.Direction.S);
    }
  }

  public override void updateState()
  {
    if (!GameDataController.gd.getObjective("constructionsite_from_above"))
    {
      this.range = 1f;
      this.characterAnimationName = "stop";
    }
    else
    {
      this.range = 100f;
      this.characterAnimationName = "action_stnd_";
    }
  }

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }
}

// Decompiled with JetBrains decompiler
// Type: Waypoint_CS4_CS3
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\Don't Escape 4 Days in a Wasteland\dontescape_Data\Managed\Assembly-CSharp.dll

public class Waypoint_CS4_CS3 : ObjectActionController
{
  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "stop";
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "cs_waypoint_4_3";
    this.actionType = ObjectActionController.Type.Transition;
    this.trans_dir = WalkController.Direction.E;
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
      GameDataController.gd.setObjective("cs_rain_enter_left", false);
      PlayerController.pc.spawnName = "Waypoint_CS3_CS4";
      CurtainController.cc.fadeOut("CS3", WalkController.Direction.S);
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

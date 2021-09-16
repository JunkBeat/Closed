// Decompiled with JetBrains decompiler
// Type: Waypoint_GasstationRoom1_GasstationRoom2
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\Don't Escape 4 Days in a Wasteland\dontescape_Data\Managed\Assembly-CSharp.dll

public class Waypoint_GasstationRoom1_GasstationRoom2 : ObjectActionController
{
  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "stop";
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "gasstation_room1_entry";
    this.doubleClickCondition = "visited_gasstationRoom2";
    this.actionType = ObjectActionController.Type.Transition;
    this.trans_dir = WalkController.Direction.E;
  }

  public override void clickAction()
  {
    if (this.characterAnimationName == "stop")
    {
      PlayerController.pc.spawnName = "Waypoint_GasstationRoom2_GasstationRoom1";
      CurtainController.cc.fadeOut("LocationGasstationRoom2", WalkController.Direction.E);
    }
    else
    {
      PlayerController.pc.textField.viewText(GameStrings.getString(GameStrings.actions, "gasstation_nospider"), true);
      PlayerController.wc.dir = WalkController.Direction.E;
      CursorController.cc.showCursor(CursorController.PixelCursor.NORMAL);
    }
  }

  public override void whatOnClick()
  {
    if (GameDataController.gd.getCurrentDay() == 1 && GameDataController.gd.getObjectiveDetail("day_1_threat") == 2 && !GameDataController.gd.getObjective("gasstation_spider_baited") && GameDataController.gd.getObjectiveDetail("gasstation_spider_discovered") == 2)
    {
      PlayerController.wc.speed = PlayerController.wc.MAX_SPEED;
      this.range = 100f;
      this.doubleClickCondition = "gasstation_spider_baited";
    }
    else if (GameDataController.gd.getCurrentDay() == 1 && GameDataController.gd.getObjectiveDetail("day_1_threat") == 2 && !GameDataController.gd.getObjective("gasstation_spider_baited"))
    {
      PlayerController.pc.textField.viewText(GameStrings.getString(GameStrings.actions, "nasty_spider_blocking"), true);
      PlayerController.wc.fullStop(true);
      this.range = 1f;
      this.doubleClickCondition = "gasstation_spider_baited";
    }
    else
      this.doubleClickCondition = "visited_gasstationRoom2";
    if (GameDataController.gd.getCurrentDay() == 1 && GameDataController.gd.getObjective("gasstation_spider_baited") && !GameDataController.gd.getObjective("gasstation_spider_shot"))
    {
      this.characterAnimationName = "action_stnd_";
      this.range = 100f;
      this.doubleClickCondition = "gasstation_spider_shot";
    }
    else
    {
      this.characterAnimationName = "stop";
      this.range = 1f;
      this.doubleClickCondition = "visited_gasstationRoom2";
    }
  }

  public override void whatOnClick0()
  {
  }

  public override void updateState()
  {
    this.colliderManager.setCollider(0);
    if (GameDataController.gd.getCurrentDay() == 1 && GameDataController.gd.getObjective("gasstation_spider_baited") && !GameDataController.gd.getObjective("gasstation_spider_shot"))
      this.range = 100f;
    else
      this.range = 1f;
  }

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }
}

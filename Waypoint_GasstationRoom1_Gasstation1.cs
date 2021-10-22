// Decompiled with JetBrains decompiler
// Type: Waypoint_GasstationRoom1_Gasstation1
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using UnityEngine;

public class Waypoint_GasstationRoom1_Gasstation1 : ObjectActionController
{
  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "stop";
    this.animationFlip = false;
    this.useCurrentDirection = false;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.teleport = false;
    this.dkvs = GameStrings.objects;
    this.objectName = "gasstation_exit";
    this.doubleClickCondition = "visited_gasstation1";
    this.actionType = ObjectActionController.Type.Transition;
    this.trans_dir = WalkController.Direction.N;
    this.range = 1f;
  }

  public override void clickAction()
  {
    if (this.characterAnimationName == "stop")
    {
      PlayerController.pc.spawnName = "Waypoint_Gasstation1_GasstationRoom1";
      if (GameDataController.gd.getCurrentDay() == 1 && GameDataController.gd.getObjective("gasstation_spider_baited") && !GameDataController.gd.getObjective("gasstation_spider_shot") && ItemsManager.im.getItem("rifle_6").dataRef.droppedLocation.ToLower().IndexOf("inventory") != -1)
        CurtainController.cc.fadeOut("LocationGasstation1", WalkController.Direction.W, "sit_fall", flipX: true);
      else
        CurtainController.cc.fadeOut("LocationGasstation1", WalkController.Direction.S);
    }
    else
    {
      PlayerController.pc.setBusy(false);
      PlayerController.pc.textField.viewText(GameStrings.getString(GameStrings.actions, "take_gun_plz"), true);
      PlayerController.wc.dir = WalkController.Direction.N;
      CursorController.cc.showCursor(CursorController.PixelCursor.NORMAL);
    }
  }

  public override void whatOnClick()
  {
    if (GameDataController.gd.getCurrentDay() == 1 && GameDataController.gd.getObjectiveDetail("day_1_threat") == 2 && !GameDataController.gd.getObjective("gasstation_spider_baited") && GameDataController.gd.getObjectiveDetail("gasstation_spider_discovered") == 1)
    {
      PlayerController.wc.speed = PlayerController.wc.MAX_SPEED;
      this.range = 100f;
      Debug.LogWarning((object) "range = 100");
      this.doubleClickCondition = "gasstation_spider_baited";
    }
    else if (GameDataController.gd.getCurrentDay() == 1 && GameDataController.gd.getObjectiveDetail("day_1_threat") == 2 && !GameDataController.gd.getObjective("gasstation_spider_baited"))
    {
      this.range = 1f;
      Debug.LogWarning((object) "range = 1");
      PlayerController.wc.fullStop(true);
      PlayerController.pc.textField.viewText(GameStrings.getString(GameStrings.actions, "nasty_spider_blocking"), true);
      this.doubleClickCondition = "gasstation_spider_baited";
    }
    else
      this.doubleClickCondition = "visited_gasstation1";
    if (GameDataController.gd.getCurrentDay() == 1 && GameDataController.gd.getObjective("gasstation_spider_baited") && ItemsManager.im.getItem("rifle_6").dataRef.droppedLocation.ToLower().IndexOf("inventory") == -1 && !GameDataController.gd.getObjective("gasstation_spider_shot"))
    {
      this.characterAnimationName = "action_stnd_s";
      this.doubleClickCondition = "gasstation_spider_shot";
    }
    else
    {
      this.characterAnimationName = "stop";
      this.doubleClickCondition = "visited_gasstation1";
    }
  }

  public override void whatOnClick0()
  {
  }

  public override void updateState() => this.colliderManager.setCollider(0);

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }
}

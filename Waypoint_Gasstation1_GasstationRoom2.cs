// Decompiled with JetBrains decompiler
// Type: Waypoint_Gasstation1_GasstationRoom2
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

public class Waypoint_Gasstation1_GasstationRoom2 : ObjectActionController
{
  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "stop";
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "gasstation_entry1";
    this.doubleClickCondition = "visited_gasstationRoom2";
    this.actionType = ObjectActionController.Type.Transition;
    this.trans_dir = WalkController.Direction.N;
  }

  public override void clickAction()
  {
    if (GameDataController.gd.getCurrentDay() == 1 && GameDataController.gd.getObjective("gasstation_spider_baited") && !GameDataController.gd.getObjective("gasstation_spider_shot"))
    {
      PlayerController.pc.setBusy(false);
      PlayerController.pc.textField.viewText(GameStrings.getString(GameStrings.actions, "gasstation_nospider"), true);
      CursorController.cc.showCursor(CursorController.PixelCursor.NORMAL);
    }
    else
    {
      PlayerController.pc.spawnName = "Waypoint_GasstationRoom2_Gasstation1";
      CurtainController.cc.fadeOut("LocationGasstationRoom2", WalkController.Direction.S);
    }
  }

  public override void updateState()
  {
    if (GameDataController.gd.getCurrentDay() == 1 && GameDataController.gd.getObjective("gasstation_spider_baited") && !GameDataController.gd.getObjective("gasstation_spider_shot") && ItemsManager.im.getItem("rifle_6").dataRef.droppedLocation.ToLower().IndexOf("inventory") != -1)
      this.colliderManager.setCollider(-1);
    else
      this.colliderManager.setCollider(0);
  }

  public override void whatOnClick0()
  {
    if (GameDataController.gd.getCurrentDay() == 1 && GameDataController.gd.getObjective("gasstation_spider_baited") && !GameDataController.gd.getObjective("gasstation_spider_shot"))
    {
      this.range = 100f;
      this.doubleClickCondition = "gasstation_spider_shot";
    }
    else
    {
      this.doubleClickCondition = "visited_gasstationRoom2";
      this.range = 1f;
    }
  }

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }
}

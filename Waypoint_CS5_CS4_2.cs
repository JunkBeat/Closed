// Decompiled with JetBrains decompiler
// Type: Waypoint_CS5_CS4_2
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

public class Waypoint_CS5_CS4_2 : ObjectActionController
{
  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "stop";
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "cs_rope";
    this.actionType = ObjectActionController.Type.Transition;
    this.trans_dir = WalkController.Direction.S;
    this.doubleClickCondition = string.Empty;
  }

  public override void clickAction()
  {
    GameDataController.gd.setObjective("constructionsite_from_above", true);
    PlayerController.pc.spawnName = "Waypoint_CS4_CS5_2";
    CurtainController.cc.fadeOut("CS4", WalkController.Direction.S);
  }

  public override void updateState()
  {
    if (GameDataController.gd.getObjective("cs_rope_used"))
      this.setCollider(0);
    else
      this.setCollider(-1);
  }

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }
}

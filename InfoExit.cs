// Decompiled with JetBrains decompiler
// Type: InfoExit
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

public class InfoExit : ObjectActionController
{
  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "stop";
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "information_exit";
    this.teleport = true;
    PlayerController.wc.speed = PlayerController.wc.MAX_SPEED;
    this.actionType = ObjectActionController.Type.NormalAction;
    this.trans_dir = WalkController.Direction.S;
  }

  public override void clickAction()
  {
    PlayerController.pc.spawnName = "previous";
    PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.book_close, 0.5f);
    PlayerController.wc.fullStop();
    CurtainController.cc.fadeOut(GameDataController.gd.previousLocation, WalkController.Direction.S, "action_stnd_s");
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

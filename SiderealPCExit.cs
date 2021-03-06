// Decompiled with JetBrains decompiler
// Type: SiderealPCExit
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using UnityEngine;

public class SiderealPCExit : ObjectActionController
{
  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "stop";
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "leave";
    this.teleport = true;
    this.actionType = ObjectActionController.Type.Transition;
    this.trans_dir = WalkController.Direction.S;
  }

  public override void clickAction()
  {
    GameObject.Find("pc_mail_page_caption").GetComponent<WorldCaption>().hide();
    PlayerController.pc.spawnName = "SiderealF2SPC2";
    PlayerController.wc.fullStop();
    CurtainController.cc.fadeOut("SiderealF2S", WalkController.Direction.N);
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

// Decompiled with JetBrains decompiler
// Type: CraneController
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


using UnityEngine;

public class CraneController : ObjectActionController
{
  public SpriteRenderer contrBack;
  public CraneLeverController lever1;
  public CraneLeverController lever2;
  public CraneLeverController lever3;

  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "action_stnd_e";
    this.animationFlip = false;
    this.useCurrentDirection = false;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "cs_crane_controller";
    this.range = 1f;
    this.updateState();
  }

  private void Update()
  {
  }

  public override void clickAction()
  {
    this.contrBack.enabled = true;
    this.lever1.showLever();
    this.lever2.showLever();
    this.lever3.showLever();
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

  public override void whatOnClick0()
  {
  }

  public override void whatOnClick()
  {
  }
}

// Decompiled with JetBrains decompiler
// Type: HuntersLodgeScratches
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\Don't Escape 4 Days in a Wasteland\dontescape_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class HuntersLodgeScratches : ObjectActionController
{
  public Sprite gas;
  public Sprite bugs;
  public Sprite spiders;

  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "kneel_in_n";
    this.animationFlip = false;
    this.useCurrentDirection = false;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "lodge_scratches";
    this.range = 1f;
  }

  public override void clickAction()
  {
    GameDataController.gd.setObjective("hunters_lodge_scratches_found", true);
    Timeline.t.addDialogue(new DialogueLine(PlayerController.pc.textField, new Vector3(1f, 1f, 1f), GameStrings.getString(GameStrings.actions, "hunters_lodge_scratches"), new TimelineFunction(this.standup))
    {
      actionWithText = false
    });
    Timeline.t.doNotUnlock = true;
    this.updateAll();
  }

  private void standup(string param = "")
  {
    PlayerController.pc.setBusy(true);
    PlayerController.wc.forceAnimation("kneel_out_n");
  }

  public override void updateState()
  {
    this.colliderManager.setCollider(0);
    if (!GameDataController.gd.getObjective("hunters_lodge_couch_moved"))
      return;
    this.colliderManager.setCollider(-1);
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

// Decompiled with JetBrains decompiler
// Type: FuseboxLight2
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


using UnityEngine;

public class FuseboxLight2 : ObjectActionController
{
  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "action_stnd_";
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "fuse_elevator";
    this.range = 8000f;
    this.teleport = false;
    this.updateState();
  }

  private void Update()
  {
  }

  public override void whatOnClick()
  {
  }

  public override void clickAction()
  {
    if (!GameDataController.gd.getObjective("outpost_elevator_powered"))
      PlayerController.pc.textField.viewText(GameStrings.getString(GameStrings.actions, "fuse_elevator_off"), true, mwidth: 150);
    else
      PlayerController.pc.textField.viewText(GameStrings.getString(GameStrings.actions, "fuse_elevator_on"), true, mwidth: 150);
  }

  public override void updateState()
  {
    if (!GameDataController.gd.getObjective("outpost_elevator_powered"))
      this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
    else
      this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
  }

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }
}

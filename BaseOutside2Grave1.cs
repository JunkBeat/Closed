// Decompiled with JetBrains decompiler
// Type: BaseOutside2Grave1
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using UnityEngine;

public class BaseOutside2Grave1 : ObjectActionController
{
  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "action_stnd_";
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "grave_cody";
    this.range = 10f;
    this.teleport = false;
    this.updateState();
  }

  private void Update()
  {
  }

  public override void whatOnClick()
  {
  }

  public override void clickAction() => PlayerController.pc.textField.viewText(GameStrings.getString(GameStrings.actions, "grave_cody"), true, mwidth: 150);

  public override void updateState()
  {
    this.setCollider(-1);
    this.GetComponent<SpriteRenderer>().enabled = false;
    if (GameDataController.gd.getCurrentDay() < 3 || !GameDataController.gd.getObjective("npc3_joined") || GameDataController.gd.getObjective("npc3_alive") || GameDataController.gd.getObjectiveDetail("npc3_alive") == 1)
      return;
    this.setCollider(0);
    this.GetComponent<SpriteRenderer>().enabled = true;
    this.objectName = "grave_cody";
  }

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }
}

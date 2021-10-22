// Decompiled with JetBrains decompiler
// Type: Location2Post1
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using UnityEngine;

public class Location2Post1 : ObjectActionController
{
  public Sprite painting;

  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "action_stnd_n";
    this.animationFlip = false;
    this.useCurrentDirection = false;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "base_fridge_note1";
    this.range = 10f;
  }

  public override void clickAction() => PlayerController.pc.textField.viewText(GameStrings.getString(GameStrings.actions, "base_fridge_note1"), true);

  public override void updateState() => this.colliderManager.setCollider(0);

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
    PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.page_turn_04);
    PlayerController.pc.textField.viewText(GameStrings.getString(GameStrings.world_labels, "postnote1"), true, true, true, 200, 0.0f, 0.0f, 0.0f, 0.9294118f, 0.8705882f, 0.6039216f, 1f, mute: true);
  }

  public override void whatOnClick0()
  {
  }

  public override void whatOnClick()
  {
  }
}

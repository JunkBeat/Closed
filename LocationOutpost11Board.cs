// Decompiled with JetBrains decompiler
// Type: LocationOutpost11Board
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using UnityEngine;

public class LocationOutpost11Board : ObjectActionController
{
  private SpriteRenderer sr;
  public SpriteRenderer light1;
  private bool fastcheck;

  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "action_stnd_";
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "outpost_board";
    this.range = 0.0f;
    this.teleport = false;
    this.updateState();
    this.actionType = ObjectActionController.Type.NormalAction;
  }

  private void Update()
  {
  }

  public override void whatOnClick()
  {
  }

  public override void clickAction() => PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "moon_presentation"));

  public override void updateState()
  {
    if (GameDataController.gd.getObjective("outpost_switch_pressed"))
    {
      this.characterAnimationName = "action_stnd_";
      this.animationFlip = false;
      this.useCurrentDirection = true;
      this.range = 30f;
      this.setCollider(0);
    }
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

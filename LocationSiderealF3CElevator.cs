// Decompiled with JetBrains decompiler
// Type: LocationSiderealF3CElevator
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using UnityEngine;

public class LocationSiderealF3CElevator : ObjectActionController
{
  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "action_stnd_";
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "sidereal_elevator_closed";
    this.range = 1f;
    this.teleport = false;
    this.updateState();
  }

  private void Update()
  {
  }

  public override void whatOnClick0()
  {
    if (GameDataController.gd.getObjective("sidereal_elevator_f3_open"))
    {
      this.characterAnimationName = "action_stnd_";
      this.animationFlip = false;
      this.useCurrentDirection = true;
      this.range = 20f;
    }
    else
    {
      this.characterAnimationName = "action1_e";
      this.animationFlip = false;
      this.useCurrentDirection = false;
      this.range = 1f;
    }
  }

  public override void clickAction()
  {
    if (GameDataController.gd.getObjective("sidereal_elevator_f3_open"))
    {
      PlayerController.pc.textField.viewText(GameStrings.getString(GameStrings.actions, "sidereal_elevator3"), true, mwidth: 150);
    }
    else
    {
      PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.metal_creak1);
      GameDataController.gd.setObjective("sidereal_elevator_f3_open", true);
      this.updateState();
    }
  }

  public override void updateState()
  {
    if (GameDataController.gd.getObjective("sidereal_elevator_f3_open"))
    {
      this.objectName = "sidereal_elevator_3";
      this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
      GameObject.Find("Location").transform.Find("f3c_elevator_overlay").GetComponent<SpriteRenderer>().enabled = false;
    }
    else
    {
      this.objectName = "sidereal_elevator_closed";
      this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
      GameObject.Find("Location").transform.Find("f3c_elevator_overlay").GetComponent<SpriteRenderer>().enabled = true;
    }
  }

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }
}

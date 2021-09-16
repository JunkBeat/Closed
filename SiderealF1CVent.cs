// Decompiled with JetBrains decompiler
// Type: SiderealF1CVent
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\Don't Escape 4 Days in a Wasteland\dontescape_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class SiderealF1CVent : ObjectActionController
{
  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "kneel_n";
    this.animationFlip = false;
    this.useCurrentDirection = false;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "sidereal_vent";
  }

  public override void clickAction2()
  {
  }

  public override void updateState()
  {
    this.colliderManager.setCollider(0);
    if (GameDataController.gd.getObjectiveDetail("sidereal_electric_pin_A") != 15 || GameDataController.gd.getObjectiveDetail("sidereal_electric_pin_B") != 40)
    {
      this.setCollider(-1);
    }
    else
    {
      this.setCollider(0);
      if (GameDataController.gd.getObjective("sidereal_vent_open"))
      {
        this.characterAnimationName = "action_stnd_";
        this.animationFlip = false;
        this.useCurrentDirection = true;
        this.range = 100f;
        this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
      }
      else
      {
        this.characterAnimationName = "kneel_n";
        this.animationFlip = false;
        this.useCurrentDirection = false;
        this.range = 1f;
        this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
      }
    }
  }

  public override void clickAction()
  {
    if (!GameDataController.gd.getObjective("sidereal_vent_open"))
      PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.metal_thud2);
    PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "sidereal_vent_too_small"));
    GameDataController.gd.setObjective("sidereal_vent_open", true);
    this.updateAll();
  }

  public override void clickAction0()
  {
  }
}

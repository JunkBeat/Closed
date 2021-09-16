// Decompiled with JetBrains decompiler
// Type: SiderealF1CDarkness
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


using System.Collections.Generic;

public class SiderealF1CDarkness : ObjectActionController
{
  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "action_stnd_e";
    this.animationFlip = true;
    this.useCurrentDirection = false;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "sidereal_darkness";
    this.range = 20f;
    this.interactions = new List<ItemInteraction>();
    this.interactions.Add(new ItemInteraction("lighter", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("flamethrower", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("flamethrower_empty", string.Empty, anim: string.Empty));
  }

  public override void clickAction2()
  {
  }

  public override void updateState()
  {
    this.colliderManager.setCollider(0);
    if (GameDataController.gd.getObjectiveDetail("sidereal_electric_pin_A") != 15 || GameDataController.gd.getObjectiveDetail("sidereal_electric_pin_B") != 40)
      this.setCollider(0);
    else
      this.setCollider(-1);
  }

  private void zapalniczka() => PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.flashlight);

  public override void clickAction()
  {
    if (this.usedItem != string.Empty)
    {
      this.zapalniczka();
      this.Invoke("zapalniczka", 0.3f);
      this.Invoke("zapalniczka", 0.8f);
      PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "sidereal_lighter_failed"));
    }
    else
      PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "too_dark"));
  }

  public override void clickAction0()
  {
  }
}

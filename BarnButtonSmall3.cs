// Decompiled with JetBrains decompiler
// Type: BarnButtonSmall3
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using UnityEngine;

public class BarnButtonSmall3 : ObjectActionController
{
  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = string.Empty;
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "barn_console_air";
    this.teleport = true;
    this.transform.position = ScreenControler.roundToNearestFullPixel2(this.transform.position);
  }

  public override void clickAction()
  {
    PlayerController.pc.textField.viewText(GameStrings.getString(GameStrings.actions, "barn_console_air"), true, true);
    if (GameDataController.gd.getObjective("barn_sprinklers_enabled"))
      return;
    GameDataController.gd.setObjective("barn_sprinklers_enabled", true);
    this.GetComponent<Animator>().Play("b_small_off_on", 0);
    PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.button_click);
  }

  public void updateAfterAnimation() => this.updateAll();

  public override void updateState()
  {
    if (GameDataController.gd.getObjective("barn_sprinklers_enabled"))
      this.GetComponent<Animator>().Play("b_small_on", 0);
    else
      this.GetComponent<Animator>().Play("b_small_off", 0);
  }

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }
}

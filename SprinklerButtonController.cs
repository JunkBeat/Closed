// Decompiled with JetBrains decompiler
// Type: SprinklerButtonController
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using UnityEngine;

public class SprinklerButtonController : ObjectActionController
{
  public string dataRef;
  public SprinklerButtonController connected1;
  public SprinklerButtonController connected2;
  public SprinklerButtonController connected3;
  public SprinklerButtonController connected4;
  public SprinklersArrow arrow;

  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = string.Empty;
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "barn_console_sprinkler";
    this.teleport = true;
    this.transform.position = ScreenControler.roundToNearestFullPixel2(this.transform.position);
  }

  public void changeState() => GameDataController.gd.setObjective(this.dataRef, !GameDataController.gd.getObjective(this.dataRef));

  public override void clickAction()
  {
    if (!GameDataController.gd.getObjective("barn_sprinklers_enabled"))
      return;
    this.arrow.fastUpdate = false;
    this.changeState();
    PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.button_click);
    if ((Object) this.connected1 != (Object) null)
    {
      this.connected1.changeState();
      int num = Random.Range(1, 6);
      MonoBehaviour.print((object) ("RANDOM " + (object) num));
      this.connected1.GetComponent<Animator>().Play("b1_flicker" + (object) num, 0);
    }
    if ((Object) this.connected2 != (Object) null)
    {
      this.connected2.changeState();
      int num = Random.Range(1, 6);
      MonoBehaviour.print((object) ("RANDOM " + (object) num));
      this.connected2.GetComponent<Animator>().Play("b1_flicker" + (object) num, 0);
    }
    if ((Object) this.connected3 != (Object) null)
    {
      this.connected3.changeState();
      int num = Random.Range(1, 6);
      MonoBehaviour.print((object) ("RANDOM " + (object) num));
      this.connected3.GetComponent<Animator>().Play("b1_flicker" + (object) num, 0);
    }
    if ((Object) this.connected4 != (Object) null)
    {
      this.connected4.changeState();
      int num = Random.Range(1, 6);
      MonoBehaviour.print((object) ("RANDOM " + (object) num));
      this.connected4.GetComponent<Animator>().Play("b1_flicker" + (object) num, 0);
    }
    if (!GameDataController.gd.getObjective(this.dataRef))
      this.GetComponent<Animator>().Play("b1_on_off", 0);
    else
      this.GetComponent<Animator>().Play("b1_off_on", 0);
  }

  public void updateAfterAnimation() => this.updateState();

  public override void updateState()
  {
    if (GameDataController.gd.getObjective(this.dataRef))
      this.GetComponent<Animator>().Play("b1_on", 0);
    else
      this.GetComponent<Animator>().Play("b1_off", 0);
  }

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }
}

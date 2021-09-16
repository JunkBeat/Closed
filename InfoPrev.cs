// Decompiled with JetBrains decompiler
// Type: InfoPrev
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\Don't Escape 4 Days in a Wasteland\dontescape_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class InfoPrev : ObjectActionController
{
  private int prevSound;

  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = string.Empty;
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "information_prev";
    this.teleport = true;
    this.actionType = ObjectActionController.Type.Transition;
    this.trans_dir = WalkController.Direction.W;
  }

  public override void clickAction()
  {
    GameObject.Find("TextLeft").GetComponent<TextRightScript>().gotoPrevPage();
    int num = Random.Range(1, 5);
    if (this.prevSound == num)
    {
      ++num;
      if (num > 4)
        num = 1;
    }
    this.prevSound = num;
    AudioClip clip;
    switch (num)
    {
      case 1:
        clip = SoundsManagerController.sm.page_turn_01;
        break;
      case 2:
        clip = SoundsManagerController.sm.page_turn_02;
        break;
      case 3:
        clip = SoundsManagerController.sm.page_turn_03;
        break;
      default:
        clip = SoundsManagerController.sm.page_turn_04;
        break;
    }
    PlayerController.pc.aS.PlayOneShot(clip, 0.5f);
  }

  public override void updateState()
  {
  }

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }
}

// Decompiled with JetBrains decompiler
// Type: PesttruckLocker1
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using UnityEngine;

public class PesttruckLocker1 : ObjectActionController
{
  private AudioClip soundOpen;
  private AudioClip soundClose;

  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.animationFlip = false;
    this.characterAnimationName = "open_n";
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "pesttruck_locker";
  }

  public override void clickAction() => PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.locker_01);

  public override void updateState()
  {
    if (GameDataController.gd.getObjective("pesttruck_locker1_open"))
    {
      this.characterAnimationName = "open_n";
      this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
      this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
      this.colliderManager.setCollider(-1);
    }
    else
    {
      this.characterAnimationName = "open_n";
      this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
      this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
      this.colliderManager.setCollider(0);
    }
  }

  public override void clickAction2()
  {
    GameDataController.gd.setObjective("pesttruck_locker1_open", true);
    this.updateState();
    this.updateAll();
  }

  public override void clickAction0()
  {
  }
}

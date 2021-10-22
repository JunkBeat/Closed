// Decompiled with JetBrains decompiler
// Type: HouseBCloset
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using UnityEngine;

public class HouseBCloset : ObjectActionController
{
  public Sprite shadow1;
  public Sprite shadow2;

  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "open_n";
    this.animationFlip = false;
    this.useCurrentDirection = false;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "house_b_inside_closet";
  }

  public override void clickAction()
  {
    if (GameDataController.gd.getObjective("house_b_closet_open"))
      return;
    PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.door_open_01);
    GameDataController.gd.setObjective("house_b_closet_open", true);
    this.updateAll();
  }

  public override void updateState()
  {
    this.colliderManager.setCollider(0);
    if (GameDataController.gd.getObjective("house_b_closet_open"))
    {
      this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
      this.colliderManager.setCollider(-1);
      GameObject.Find("plane00a (1)").GetComponent<SpriteRenderer>().sprite = this.shadow1;
    }
    else
    {
      this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
      GameObject.Find("plane00a (1)").GetComponent<SpriteRenderer>().sprite = this.shadow2;
    }
  }

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }
}

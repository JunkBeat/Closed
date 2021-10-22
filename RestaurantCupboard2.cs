// Decompiled with JetBrains decompiler
// Type: RestaurantCupboard2
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using UnityEngine;

public class RestaurantCupboard2 : ObjectActionController
{
  public Sprite s1;
  public Sprite s2;

  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "kneel_n";
    this.animationFlip = false;
    this.useCurrentDirection = false;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "restaurant_cupboard";
    this.range = 1f;
  }

  public override void clickAction()
  {
    if (GameDataController.gd.getObjective("restaurant_cupboard2_open"))
      return;
    PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.cabinet_1);
    GameDataController.gd.setObjective("restaurant_cupboard2_open", true);
    this.updateState();
  }

  public override void updateState()
  {
    if (GameDataController.gd.getObjective("restaurant_cupboard2_open"))
    {
      this.setCollider(-1);
      this.gameObject.GetComponent<SpriteRenderer>().sprite = this.s2;
    }
    else
    {
      this.setCollider(0);
      this.gameObject.GetComponent<SpriteRenderer>().sprite = this.s1;
    }
  }

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }
}

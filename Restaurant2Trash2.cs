// Decompiled with JetBrains decompiler
// Type: Restaurant2Trash2
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using UnityEngine;

public class Restaurant2Trash2 : ObjectActionController
{
  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "action_stnd_";
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "restaurant_trash";
    this.range = 200f;
  }

  public override void clickAction() => PlayerController.pc.textField.viewText(GameStrings.getString(GameStrings.actions, "restaurant_trash_moved"), true);

  public override void updateState()
  {
    if (!GameDataController.gd.getObjective("restaurant_trash_moved"))
    {
      this.setCollider(-1);
      this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
    }
    else
    {
      this.setCollider(0);
      this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
    }
  }

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }
}

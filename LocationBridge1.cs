// Decompiled with JetBrains decompiler
// Type: LocationBridge1
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using UnityEngine;

public class LocationBridge1 : ObjectActionController
{
  private void Start()
  {
    this.dkvs = GameStrings.objects;
    this.objectName = string.Empty;
  }

  public override void clickAction()
  {
  }

  public override void updateState()
  {
    if (!GameDataController.gd.getObjective("bridge_planks_used_1"))
      this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
    else
      this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
  }

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }
}

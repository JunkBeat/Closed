﻿// Decompiled with JetBrains decompiler
// Type: LocationBridge2
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\Don't Escape 4 Days in a Wasteland\dontescape_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class LocationBridge2 : ObjectActionController
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
    if (!GameDataController.gd.getObjective("bridge_planks_used_2"))
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

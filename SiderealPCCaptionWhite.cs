﻿// Decompiled with JetBrains decompiler
// Type: SiderealPCCaptionWhite
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


using UnityEngine;

public class SiderealPCCaptionWhite : MonoBehaviour
{
  public string nameToDisplay;
  private TextFieldController t;

  private void Start()
  {
    this.t = this.GetComponent<TextFieldController>();
    this.t.viewText(GameStrings.getString(GameStrings.world_labels, this.nameToDisplay), quick: true, instant: true, mwidth: 200, ba: 0.0f);
    this.t.keepAlive = true;
  }

  private void Update()
  {
  }
}

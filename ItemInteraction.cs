﻿// Decompiled with JetBrains decompiler
// Type: ItemInteraction
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using System;

public class ItemInteraction
{
  public string name = string.Empty;
  public string failText = string.Empty;
  public string animation = string.Empty;
  public Action action;
  public int range;

  public ItemInteraction(string n, string fail = "", Action act = null, string anim = "", int rang = 0)
  {
    this.name = n;
    this.failText = fail;
    this.range = rang;
    this.animation = anim;
    this.action = act;
  }
}

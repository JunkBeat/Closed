// Decompiled with JetBrains decompiler
// Type: Objective
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


using System;

[Serializable]
public class Objective
{
  public string id;
  public bool state;
  public int detail;

  public Objective(string _id, bool _state, int _detail = 0)
  {
    this.id = _id;
    this.state = _state;
    this.detail = _detail;
  }
}

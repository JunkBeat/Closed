// Decompiled with JetBrains decompiler
// Type: ItemData
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


using System;

[Serializable]
public class ItemData
{
  public string id;
  public int locX;
  public int locY;
  public string droppedLocation;

  public ItemData(string _id, string _droppedLocation, int _locX, int _locY)
  {
    this.id = _id;
    this.droppedLocation = _droppedLocation;
    this.locX = _locX;
    this.locY = _locY;
  }
}

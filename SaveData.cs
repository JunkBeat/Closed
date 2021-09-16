// Decompiled with JetBrains decompiler
// Type: SaveData
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


using System;
using System.Collections.Generic;

[Serializable]
public class SaveData
{
  public int gameTime;
  public int timeLimit;
  public int traveledTime;
  public int workedTime;
  public int gameDay;
  public DateTime dateTime;
  public List<ItemData> items;
  public List<Objective> objectives;
  public List<Objective> journals;
  public List<Objective> visited;
  public int currentX;
  public int currentY;
  public string location;
  public string usedSpawner;
  public int previousX;
  public int previousY;
  public string previousLocation;
  public string finishingLocation;
  public string journalEntries;
}

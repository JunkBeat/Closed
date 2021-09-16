// Decompiled with JetBrains decompiler
// Type: WallAreaAction1
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\Don't Escape 4 Days in a Wasteland\dontescape_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class WallAreaAction1 : AreaEffect
{
  public bool running;

  public void runrunrun()
  {
    if (!this.running)
      return;
    GameDataController.gd.setObjective("run_hint", true);
    this.running = true;
    GameObject.Find("run_hint").GetComponent<TextFieldController>().setTime(2f);
    GameObject.Find("run_hint").GetComponent<TextFieldController>().keepAlive = false;
  }

  public override void Action(WalkController wc, NPCWalkController npcwc, GroundItemController gic)
  {
    if (this.running || !((Object) wc != (Object) null))
      return;
    this.running = true;
    GameObject.Find("run_hint").GetComponent<TextFieldController>().viewText("[" + GameStrings.getString(GameStrings.gui, "run_hint") + "]", quick: true, mwidth: 150);
    GameObject.Find("run_hint").GetComponent<TextFieldController>().keepAlive = true;
  }

  public override void Action2(
    WalkController wc,
    NPCWalkController npcwc,
    GroundItemController gic)
  {
  }
}

// Decompiled with JetBrains decompiler
// Type: OutpostOutsideRadarKreci
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\Don't Escape 4 Days in a Wasteland\dontescape_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class OutpostOutsideRadarKreci : ObjectActionController
{
  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "action_stnd_";
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "outpost_radar_plate";
    this.range = 100f;
    this.updateAll();
  }

  public override void clickAction()
  {
    if (!GameDataController.gd.getObjective("outpost_radar_repaired"))
      PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "outside_radar_broken"));
    else
      PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "outside_radar_working"));
  }

  public override void updateState()
  {
    if (GameDataController.gd.getObjective("outpost_radar_repaired"))
      this.GetComponent<Animator>().Play("outside_radar1");
    else
      this.GetComponent<Animator>().Play("outside_radar0");
  }

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }

  public override void whatOnClick0()
  {
  }

  public override void whatOnClick()
  {
  }
}

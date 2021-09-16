// Decompiled with JetBrains decompiler
// Type: AtticHatch3
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\Don't Escape 4 Days in a Wasteland\dontescape_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

public class AtticHatch3 : ObjectActionController
{
  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "action_up_n";
    this.animationFlip = false;
    this.useCurrentDirection = false;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "attic_hatch2";
    this.range = 5f;
    this.interactions = new List<ItemInteraction>();
    this.interactions.Add(new ItemInteraction("blanket", GameStrings.getString(GameStrings.actions, "roof_hatch_no_need"), anim: string.Empty));
    this.interactions.Add(new ItemInteraction("blanketb", GameStrings.getString(GameStrings.actions, "roof_hatch_no_need"), anim: string.Empty));
    this.interactions.Add(new ItemInteraction("thermalb", GameStrings.getString(GameStrings.actions, "roof_hatch_no_need"), anim: string.Empty));
    this.interactions.Add(new ItemInteraction("flag", GameStrings.getString(GameStrings.actions, "roof_hatch_no_need"), anim: string.Empty));
    this.trans_dir = WalkController.Direction.N;
  }

  public override void clickAction()
  {
    if (!GameDataController.gd.getObjective("attic_hatch_open"))
      return;
    GameDataController.gd.setObjective("attic_hatch_open", false);
    this.updateAll();
    PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.metal_creak1);
    GameObject.Find("LocationManager").GetComponent<LoctionAttic1Start>().backgroundCheck();
  }

  public override void updateState()
  {
    if (!GameDataController.gd.getObjective("attic_hatch_open"))
      this.setCollider(-1);
    else
      this.setCollider(0);
  }

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }
}

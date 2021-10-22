// Decompiled with JetBrains decompiler
// Type: SiderealLabMixer
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

public class SiderealLabMixer : ObjectActionController
{
  public AudioClip clank;

  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "stop";
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "sidereal_mixer";
    this.actionType = ObjectActionController.Type.NormalAction;
    this.interactions = new List<ItemInteraction>();
    this.interactions.Add(new ItemInteraction("vials1", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("vials2", string.Empty, anim: string.Empty));
  }

  public override void clickAction()
  {
    if (this.usedItem == "vials1")
    {
      InventoryController.ic.removeItem("vials1");
      GameDataController.gd.setObjective("sidereal_components_1", true);
      this.updateAll();
      PlayerController.pc.aS.PlayOneShot(this.clank);
    }
    else if (this.usedItem == "vials2")
    {
      InventoryController.ic.removeItem("vials2");
      GameDataController.gd.setObjective("sidereal_components_2", true);
      this.updateAll();
      PlayerController.pc.aS.PlayOneShot(this.clank);
    }
    else
    {
      PlayerController.pc.spawnName = "LocationMixerExit";
      CurtainController.cc.fadeOut("SiderealMixer", WalkController.Direction.S);
    }
  }

  public override void whatOnClick()
  {
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.characterAnimationName = "stop";
    if (!(this.usedItem != string.Empty))
      return;
    this.characterAnimationName = "action1_e";
    this.animationFlip = true;
    this.useCurrentDirection = false;
  }

  public override void updateState()
  {
  }

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }
}

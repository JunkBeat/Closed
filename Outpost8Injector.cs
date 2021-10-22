// Decompiled with JetBrains decompiler
// Type: Outpost8Injector
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

public class Outpost8Injector : ObjectActionController
{
  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "action_n";
    this.animationFlip = false;
    this.useCurrentDirection = false;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "outpost_injector";
    this.range = 1f;
    this.interactions = new List<ItemInteraction>();
    this.interactions.Add(new ItemInteraction("catalyst", string.Empty, anim: string.Empty));
  }

  public void beep()
  {
    PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.computer_click2);
    this.Invoke("bzzt", 0.2f);
  }

  public void bzzt() => PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.mixer, 0.2f);

  public override void clickAction()
  {
    if (this.usedItem != string.Empty)
    {
      InventoryController.ic.removeItem("catalyst");
      GameDataController.gd.setObjective("outpost_catalyst_used", true);
      PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.liquid_pour_small);
      this.Invoke("beep", 0.2f);
      this.updateAll();
      PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "catalyst_added"));
    }
    else if (GameDataController.gd.getObjective("outpost_catalyst_used"))
    {
      PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "catalyst_already_used"));
    }
    else
    {
      Vector3 color = GingerActionController.getColor();
      TextFieldController component = GameObject.Find("Ginger").GetComponent<TextFieldController>();
      GameObject.Find("Ginger").GetComponent<NPCWalkController>().setTargetV3(GameObject.Find("GingerInlet").transform.position);
      component.viewText(GameStrings.getString(GameStrings.actions, "outpost_injector"), true, mwidth: 150, r: color.x, g: color.y, b: color.z);
    }
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

  public override void whatOnClick0()
  {
    if (this.usedItem == string.Empty)
    {
      this.characterAnimationName = "action_stnd_";
      this.animationFlip = false;
      this.useCurrentDirection = true;
      this.range = 10f;
    }
    else
    {
      this.characterAnimationName = "action_n";
      this.animationFlip = false;
      this.useCurrentDirection = false;
      this.range = 1f;
    }
  }

  public override void whatOnClick()
  {
  }
}

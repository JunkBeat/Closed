// Decompiled with JetBrains decompiler
// Type: HuntersInsideHorns
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

public class HuntersInsideHorns : ObjectActionController
{
  public Sprite antlers1;
  public Sprite antlers2;

  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "action_stnd_";
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "lodge_horns";
    this.range = 1f;
    this.interactions = new List<ItemInteraction>();
    this.interactions.Add(new ItemInteraction("crowbar", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("pipe", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("wrench", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("rifle", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("broom", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("shovel", string.Empty, anim: string.Empty));
  }

  public override void clickAction()
  {
    if (this.usedItem == string.Empty)
      PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "hunters_horns"));
    else
      Timeline.t.addDialogue(new DialogueLine(PlayerController.pc.textField, new Vector3(1f, 1f, 1f), GameStrings.getString(GameStrings.actions, "hunters_horns2"), new TimelineFunction(this.gogo))
      {
        actionWithText = false
      });
  }

  public void gogo(string f)
  {
    if (!GameDataController.gd.getObjective("hunters_lodge_couch_moved"))
    {
      DialogueLine dl = new DialogueLine(PlayerController.pc.textField, new Vector3(1f, 1f, 1f), GameStrings.getString(GameStrings.actions, "hunters_horns3"), (TimelineFunction) null);
      Timeline.t.addDialogue(dl);
    }
    PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.metal_locked_1);
    GameDataController.gd.setObjective("hunters_lodge_horn_pulled", true);
    GameDataController.gd.setObjective("hunters_lodge_chest_opened", true);
    this.updateAll();
  }

  public override void updateState()
  {
    this.colliderManager.setCollider(0);
    if (!GameDataController.gd.getObjective("hunters_lodge_horn_pulled"))
    {
      this.GetComponent<SpriteRenderer>().sprite = this.antlers1;
      this.colliderManager.setCollider(0);
    }
    else
    {
      this.GetComponent<SpriteRenderer>().sprite = this.antlers2;
      this.colliderManager.setCollider(-1);
    }
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

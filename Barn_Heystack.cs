// Decompiled with JetBrains decompiler
// Type: Barn_Heystack
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\Don't Escape 4 Days in a Wasteland\dontescape_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

public class Barn_Heystack : ObjectActionController
{
  private AudioClip soundOpen;
  private AudioClip soundClose;

  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.animationFlip = false;
    this.characterAnimationName = "kick_ne";
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "barn_heystack";
    this.setCollider(0);
    this.interactions = new List<ItemInteraction>();
    this.interactions.Add(new ItemInteraction("ducttape", string.Empty, anim: string.Empty));
  }

  public override void updateState()
  {
    if (!GameDataController.gd.getObjective("barn_haystack_3"))
      this.interactions = new List<ItemInteraction>();
    if (!GameDataController.gd.getObjective("barn_haystack_1"))
    {
      this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
      this.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Locations/Barn/barn_hay1");
      this.setCollider(0);
      this.objectName = "barn_haystack";
    }
    else if (!GameDataController.gd.getObjective("barn_haystack_2"))
    {
      this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
      this.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Locations/Barn/barn_hay2");
      this.setCollider(0);
      this.objectName = "barn_haystack";
    }
    else if (!GameDataController.gd.getObjective("barn_haystack_3"))
    {
      this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
      this.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Locations/Barn/barn_hay3");
      this.setCollider(0);
      this.objectName = "barn_haystack";
    }
    else if (!GameDataController.gd.getObjective("barn_pipe_fixed"))
    {
      this.interactions = new List<ItemInteraction>();
      this.interactions.Add(new ItemInteraction("ducttape", string.Empty, anim: string.Empty));
      this.interactions.Add(new ItemInteraction("window_foil1", GameStrings.getString(GameStrings.actions, "foil_pipe"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("window_foil2", GameStrings.getString(GameStrings.actions, "foil_pipe"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("window_foil3", GameStrings.getString(GameStrings.actions, "foil_pipe"), anim: string.Empty));
      this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
      this.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Locations/Barn/barn_hay4");
      this.objectName = "barn_pipe_broken";
      this.setCollider(1);
    }
    else
    {
      this.interactions = new List<ItemInteraction>();
      this.interactions.Add(new ItemInteraction("ducttape", string.Empty, anim: string.Empty));
      this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
      this.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Locations/Barn/pipe_fixed");
      this.objectName = "barn_pipe_fixed";
      this.setCollider(1);
    }
  }

  public override void whatOnClick()
  {
    if (GameDataController.gd.getObjective("barn_haystack_3"))
      this.characterAnimationName = "action_stnd_n";
    else
      this.characterAnimationName = "kick_ne";
  }

  public override void clickAction()
  {
    if (!GameDataController.gd.getObjective("barn_haystack_1"))
    {
      PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.hay_rustle);
      GameDataController.gd.setObjective("barn_haystack_1", true);
      this.updateState();
    }
    else if (!GameDataController.gd.getObjective("barn_haystack_2"))
    {
      PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.hay_rustle);
      GameDataController.gd.setObjective("barn_haystack_2", true);
      this.updateState();
    }
    else if (!GameDataController.gd.getObjective("barn_haystack_3"))
    {
      PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.hay_rustle);
      GameDataController.gd.setObjective("barn_haystack_3", true);
      this.updateState();
    }
    else if (!GameDataController.gd.getObjective("barn_pipe_fixed"))
    {
      if (this.usedItem == "ducttape")
        QuestionController.qc.showQuestion(GameStrings.getString(GameStrings.warnings, "barn_pipe_broken"), yesClick: new Button.Delegate(this.yesClicked), time: 5);
      else
        PlayerController.pc.textField.viewText(GameStrings.getString(GameStrings.actions, "barn_pipe_broken"), true);
    }
    else
      PlayerController.pc.textField.viewText(GameStrings.getString(GameStrings.actions, "barn_pipe_fixed"), true);
    PlayerController.wc.forceDirection(WalkController.Direction.NE);
  }

  private void yesClicked()
  {
    GameDataController.gd.setObjective("barn_pipe_fixed", true);
    CurtainController.cc.fadeOut(targetDir: WalkController.Direction.N, animation: "kneel_n", sound: SoundsManagerController.sm.duct_tape_use);
  }

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }
}

// Decompiled with JetBrains decompiler
// Type: LocationMoonShipDeadCate
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\Don't Escape 4 Days in a Wasteland\dontescape_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

public class LocationMoonShipDeadCate : ObjectActionController
{
  public TextFieldController tf;
  public Sprite ded;
  public Sprite ded2;
  public Sprite alive;

  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "action_stnd_ne";
    this.animationFlip = true;
    this.useCurrentDirection = false;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "npc_cathy";
    this.range = 1f;
    Vector2 screen = ScreenControler.gameToScreen(new Vector2(120f, 67f));
    Vector3 worldPoint = Camera.main.ScreenToWorldPoint(new Vector3(screen.x, screen.y, 0.0f));
    worldPoint.z = -3f;
    this.tf.transform.position = worldPoint;
  }

  public void playerStandUp(string v = "")
  {
    Timeline.t.doNotUnlock = true;
    PlayerController.pc.forceAnimation("kneel_out_n");
  }

  public void lookAtMe(string s = "") => this.GetComponent<SpriteRenderer>().sprite = this.ded2;

  public void stopLooking(string s = "")
  {
    this.GetComponent<SpriteRenderer>().sprite = this.ded;
    if (GameDataController.gd.getObjective("npc2_alive") && !GameDataController.gd.getObjective("moon_shocked2"))
    {
      GameObject.Find("Npc2").GetComponent<NPCWalkController>().setBusy(false);
      GameObject.Find("Npc2").GetComponent<NPCWalkController>().setTargetV3(GameObject.Find("barry_walk").transform.position);
    }
    if (!GameDataController.gd.getObjective("npc3_alive") || GameDataController.gd.getObjective("moon_shocked3"))
      return;
    GameObject.Find("Npc3").GetComponent<NPCWalkController>().setBusy(false);
    GameObject.Find("Npc3").GetComponent<NPCWalkController>().setTargetV3(GameObject.Find("cody_walk").transform.position);
  }

  public override void clickAction()
  {
    if (!GameDataController.gd.getObjective("moon_shocked1"))
    {
      PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "moon_dead_cate"));
    }
    else
    {
      GameDataController.gd.setObjective("moon_shocked1", false);
      List<DialogueLine> dialogueLines1 = new List<DialogueLine>();
      DialogueController.dc.initDialogue(dialogueLines1, "moon_dead_cate1", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.tf, GingerActionController.getColor());
      dialogueLines1[2].action = new TimelineFunction(this.lookAtMe);
      for (int index = 0; index < dialogueLines1.Count; ++index)
        Timeline.t.addDialogue(dialogueLines1[index]);
      if (GameDataController.gd.getObjective("npc2_alive") && GameDataController.gd.getObjective("npc3_alive"))
      {
        List<DialogueLine> dialogueLines2 = new List<DialogueLine>();
        DialogueController.dc.initDialogue(dialogueLines2, "moon_dead_cate_both", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.tf, GingerActionController.getColor());
        for (int index = 0; index < dialogueLines2.Count; ++index)
          Timeline.t.addDialogue(dialogueLines2[index]);
      }
      if (GameDataController.gd.getObjective("npc2_alive") && !GameDataController.gd.getObjective("npc3_alive"))
      {
        List<DialogueLine> dialogueLines3 = new List<DialogueLine>();
        DialogueController.dc.initDialogue(dialogueLines3, "moon_dead_cate_barry", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.tf, GingerActionController.getColor());
        for (int index = 0; index < dialogueLines3.Count; ++index)
          Timeline.t.addDialogue(dialogueLines3[index]);
      }
      if (!GameDataController.gd.getObjective("npc2_alive") && GameDataController.gd.getObjective("npc3_alive"))
      {
        List<DialogueLine> dialogueLines4 = new List<DialogueLine>();
        DialogueController.dc.initDialogue(dialogueLines4, "moon_dead_cate_cody", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.tf, GingerActionController.getColor());
        for (int index = 0; index < dialogueLines4.Count; ++index)
          Timeline.t.addDialogue(dialogueLines4[index]);
      }
      List<DialogueLine> dialogueLines5 = new List<DialogueLine>();
      DialogueController.dc.initDialogue(dialogueLines5, "moon_dead_cate2", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), this.tf, GingerActionController.getColor());
      dialogueLines5[dialogueLines5.Count - 3].action = new TimelineFunction(this.stopLooking);
      for (int index = 0; index < dialogueLines5.Count; ++index)
        Timeline.t.addDialogue(dialogueLines5[index]);
      if (GameDataController.gd.getObjective("npc2_alive") && !GameDataController.gd.getObjective("moon_shocked2"))
      {
        List<DialogueLine> dialogueLines6 = new List<DialogueLine>();
        DialogueController.dc.initDialogue(dialogueLines6, "moon_dead_cate3_barry", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), GameObject.Find("Npc2").GetComponent<TextFieldController>(), Npc2Controller.getColor());
        for (int index = 0; index < dialogueLines6.Count; ++index)
          Timeline.t.addDialogue(dialogueLines6[index]);
      }
      if (!GameDataController.gd.getObjective("npc3_alive") || GameDataController.gd.getObjective("moon_shocked3"))
        return;
      List<DialogueLine> dialogueLines7 = new List<DialogueLine>();
      DialogueController.dc.initDialogue(dialogueLines7, "moon_dead_cate3_cody", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), GameObject.Find("Npc3").GetComponent<TextFieldController>(), Npc3Controller.getColor());
      for (int index = 0; index < dialogueLines7.Count; ++index)
        Timeline.t.addDialogue(dialogueLines7[index]);
    }
  }

  public override void updateState()
  {
    if (GameDataController.gd.getObjective("npc1_alive"))
    {
      this.GetComponent<SpriteRenderer>().sprite = this.alive;
      this.setCollider(-1);
    }
    else
    {
      this.GetComponent<SpriteRenderer>().sprite = this.ded;
      this.setCollider(0);
    }
    this.characterAnimationName = "action_stnd_ne";
    if (!GameDataController.gd.getObjective("moon_suited_up"))
      return;
    this.characterAnimationName = "suit_action_stnd_ne";
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

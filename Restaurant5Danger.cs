// Decompiled with JetBrains decompiler
// Type: Restaurant5Danger
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

public class Restaurant5Danger : ObjectActionController
{
  public Sprite bugs_dead;
  public Sprite webs_dead;
  public Sprite webs;
  public GameObject zmarker;
  public List<BugFly> flies;

  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "action_stnd_s";
    this.animationFlip = false;
    this.useCurrentDirection = false;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "restaurant_threat_bugs";
    this.actionType = ObjectActionController.Type.NormalAction;
    this.interactions = new List<ItemInteraction>();
    this.interactions.Add(new ItemInteraction("flamethrower", GameStrings.getString(GameStrings.actions, "restaurant_block_flamethrower"), anim: string.Empty));
    this.interactions.Add(new ItemInteraction("chemsuit_dmg_dmg", GameStrings.getString(GameStrings.actions, "restaurant_block_chemsuit"), anim: string.Empty));
    this.interactions.Add(new ItemInteraction("chemsuit_rep_dmg", GameStrings.getString(GameStrings.actions, "restaurant_block_chemsuit"), anim: string.Empty));
    this.interactions.Add(new ItemInteraction("chemsuit_dmg_rep", GameStrings.getString(GameStrings.actions, "restaurant_block_chemsuit"), anim: string.Empty));
    this.interactions.Add(new ItemInteraction("chemsuit_rep_rep", GameStrings.getString(GameStrings.actions, "restaurant_block_chemsuit"), anim: string.Empty));
    this.range = 210f;
  }

  public override void clickAction()
  {
    Vector3 color = GingerActionController.getColor();
    TextFieldController component = GameObject.Find("Ginger").GetComponent<TextFieldController>();
    List<DialogueLine> dialogueLines = new List<DialogueLine>();
    string str = GameDataController.gd.getObjectiveDetail("day_1_threat") != 0 ? (GameDataController.gd.getObjectiveDetail("day_1_threat") != 1 ? "spiders" : "gas") : "bugs";
    DialogueController.dc.initDialogue(dialogueLines, "restaurant_blocked_" + str, PlayerController.pc.textField, new Vector3(1f, 1f, 1f), component, color);
    for (int index = 0; index < dialogueLines.Count; ++index)
      Timeline.t.addDialogue(dialogueLines[index]);
  }

  public override void updateState()
  {
    this.colliderManager.setCollider(0);
    this.GetComponent<SpriteRenderer>().enabled = true;
    if (GameDataController.gd.getCurrentDay() > 2)
    {
      this.colliderManager.setCollider(-1);
      this.GetComponent<Animator>().enabled = false;
      if (GameDataController.gd.getObjectiveDetail("day_1_threat") == 0)
        this.GetComponent<SpriteRenderer>().sprite = this.bugs_dead;
      else if (GameDataController.gd.getObjectiveDetail("day_1_threat") == 1)
      {
        this.GetComponent<SpriteRenderer>().sprite = this.webs_dead;
        this.GetComponent<SpriteRenderer>().enabled = false;
      }
      else
        this.GetComponent<SpriteRenderer>().sprite = this.webs_dead;
    }
    else if (GameDataController.gd.getObjectiveDetail("day_1_threat") == 0)
    {
      this.GetComponent<Animator>().enabled = true;
      this.GetComponent<Animator>().Play("bugs");
      for (int index = 0; index < this.flies.Count; ++index)
        this.flies[index].startFly(0);
      this.objectName = "restaurant_threat_bugs";
      this.interactions.Add(new ItemInteraction("rifle_so_6", GameStrings.getString(GameStrings.actions, "restaurant_block_rifle"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("rifle_so_5", GameStrings.getString(GameStrings.actions, "restaurant_block_rifle"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("rifle_so_4", GameStrings.getString(GameStrings.actions, "restaurant_block_rifle"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("rifle_so_3", GameStrings.getString(GameStrings.actions, "restaurant_block_rifle"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("rifle_so_2", GameStrings.getString(GameStrings.actions, "restaurant_block_rifle"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("rifle_so_1", GameStrings.getString(GameStrings.actions, "restaurant_block_rifle"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("rifle_so_0", GameStrings.getString(GameStrings.actions, "restaurant_block_rifle"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("rifle_s_6", GameStrings.getString(GameStrings.actions, "restaurant_block_rifle"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("rifle_s_5", GameStrings.getString(GameStrings.actions, "restaurant_block_rifle"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("rifle_s_4", GameStrings.getString(GameStrings.actions, "restaurant_block_rifle"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("rifle_s_3", GameStrings.getString(GameStrings.actions, "restaurant_block_rifle"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("rifle_s_2", GameStrings.getString(GameStrings.actions, "restaurant_block_rifle"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("rifle_s_1", GameStrings.getString(GameStrings.actions, "restaurant_block_rifle"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("rifle_s_0", GameStrings.getString(GameStrings.actions, "restaurant_block_rifle"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("rifle_o_6", GameStrings.getString(GameStrings.actions, "restaurant_block_rifle"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("rifle_o_5", GameStrings.getString(GameStrings.actions, "restaurant_block_rifle"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("rifle_o_4", GameStrings.getString(GameStrings.actions, "restaurant_block_rifle"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("rifle_o_3", GameStrings.getString(GameStrings.actions, "restaurant_block_rifle"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("rifle_o_2", GameStrings.getString(GameStrings.actions, "restaurant_block_rifle"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("rifle_o_1", GameStrings.getString(GameStrings.actions, "restaurant_block_rifle"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("rifle_o_0", GameStrings.getString(GameStrings.actions, "restaurant_block_rifle"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("rifle_6", GameStrings.getString(GameStrings.actions, "restaurant_block_rifle"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("rifle_5", GameStrings.getString(GameStrings.actions, "restaurant_block_rifle"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("rifle_4", GameStrings.getString(GameStrings.actions, "restaurant_block_rifle"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("rifle_3", GameStrings.getString(GameStrings.actions, "restaurant_block_rifle"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("rifle_2", GameStrings.getString(GameStrings.actions, "restaurant_block_rifle"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("rifle_1", GameStrings.getString(GameStrings.actions, "restaurant_block_rifle"), anim: string.Empty));
      this.interactions.Add(new ItemInteraction("rifle_0", GameStrings.getString(GameStrings.actions, "restaurant_block_rifle"), anim: string.Empty));
    }
    else if (GameDataController.gd.getObjectiveDetail("day_1_threat") == 1)
    {
      this.GetComponent<Animator>().enabled = true;
      this.GetComponent<Animator>().Play("gas");
      this.objectName = "restaurant_threat_gas";
    }
    else
    {
      this.GetComponent<Animator>().enabled = false;
      this.GetComponent<SpriteRenderer>().sprite = this.webs;
      this.objectName = "restaurant_threat_spiders";
    }
    if (GameDataController.gd.getCurrentDay() > 2)
      this.zmarker.transform.position = new Vector3(this.zmarker.transform.position.x, 0.4f, this.zmarker.transform.position.z);
    else
      this.zmarker.transform.position = new Vector3(this.zmarker.transform.position.x, -0.692f, this.zmarker.transform.position.z);
  }

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }
}

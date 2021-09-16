// Decompiled with JetBrains decompiler
// Type: Location1Chimney
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


using System.Collections.Generic;
using UnityEngine;

public class Location1Chimney : ObjectActionController
{
  public ParticleGenerator smoke;
  public Sprite wood1;
  public Sprite wood2;
  public Sprite wood3;
  public Sprite wood4;
  public Sprite wood0;
  public SpriteRenderer wood;
  public SpriteRenderer charcoal;
  public SpriteRenderer charcoal_bag;
  public SpriteRenderer cash;
  public SpriteRenderer note;
  public SpriteRenderer papers;
  public SpriteRenderer fire1;
  public SpriteRenderer fire2;
  public SpriteRenderer fireLight;
  public SpriteRenderer fireLight2;
  public Location1Start loc;

  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "kneel_in_n";
    this.animationFlip = false;
    this.useCurrentDirection = false;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "base_chimney__";
    this.range = 1f;
    this.teleport = false;
    this.updateState();
    this.interactions = new List<ItemInteraction>();
    this.interactions.Add(new ItemInteraction("charcoal", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("charcoal_empty", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("planks1", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("planks2", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("planks3", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("planks4", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("planks5", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("gas_note", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("pest_note", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("spider_note", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("invoices", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("wad_of_cash", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("lighter", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("flamethrower", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("flamethrower_empty", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("bandage", GameStrings.getString(GameStrings.actions, "bandage_chimney"), anim: string.Empty));
  }

  private void Update()
  {
  }

  public void standSay()
  {
    this.range = 20f;
    this.characterAnimationName = "action_stnd_";
    this.animationFlip = false;
    this.useCurrentDirection = true;
  }

  public void kneel()
  {
    this.range = 1f;
    this.characterAnimationName = "kneel_in_n";
    this.animationFlip = false;
    this.useCurrentDirection = false;
  }

  public override void whatOnClick0()
  {
    if (this.usedItem == string.Empty)
    {
      this.standSay();
    }
    else
    {
      if ((this.usedItem == "pest_note" || this.usedItem == "gas_note" || this.usedItem == "spider_note") && !GameDataController.gd.getObjective("day1_complete"))
        this.standSay();
      else if (this.usedItem == "charcoal_empty" || this.usedItem == "pest_note" || this.usedItem == "gas_note" || this.usedItem == "spider_note" || this.usedItem == "wad_of_cash")
      {
        if (GameDataController.gd.getObjective("chimney_bag") || GameDataController.gd.getObjective("chimney_note") || GameDataController.gd.getObjective("chimney_cash"))
          this.standSay();
        else
          this.kneel();
      }
      if (this.usedItem == "planks1" || this.usedItem == "planks2" || this.usedItem == "planks3" || this.usedItem == "planks4" || this.usedItem == "planks5" || this.usedItem == "charcoal")
      {
        if (GameDataController.gd.getObjectiveDetail("chimney_wood") > 0 || GameDataController.gd.getObjective("chimney_charcoal"))
          this.standSay();
        else
          this.kneel();
      }
      if (!(this.usedItem == "lighter") && !(this.usedItem == "flamethrower_empty") && !(this.usedItem == "flamethrower"))
        return;
      if (GameDataController.gd.getObjective("chimney_note") || GameDataController.gd.getObjective("chimney_bag") || GameDataController.gd.getObjective("chimney_cash") || GameDataController.gd.getObjective("chimney_papers"))
      {
        if (GameDataController.gd.getObjective("base_fireplace_lit"))
          this.standSay();
        else if (GameDataController.gd.getObjective("chimney_charcoal") || GameDataController.gd.getObjectiveDetail("chimney_wood") > 0)
          this.kneel();
        else
          this.standSay();
      }
      else
        this.standSay();
    }
  }

  public void getup(string param = "") => PlayerController.wc.forceAnimation("kneel_out_n");

  public void talkAndGetUp(string say)
  {
    Timeline.t.addAction(new TimelineAction()
    {
      blockG = true,
      textfield = PlayerController.pc.textField,
      actionWithText = false,
      function = new TimelineFunction(this.getup),
      text = say
    });
    Timeline.t.doNotUnlock = true;
  }

  public void startFire()
  {
    GameDataController.gd.setObjective("base_fireplace_lit", true);
    this.updateAll();
    this.getup(string.Empty);
  }

  public void stopFire()
  {
    Timeline.t.addAction(new TimelineAction()
    {
      blockG = true,
      textfield = PlayerController.pc.textField,
      actionWithText = false,
      function = new TimelineFunction(this.stopFire2),
      text = GameStrings.getString(GameStrings.actions, "chimney_cough_cough")
    });
    Timeline.t.doNotUnlock = true;
  }

  public void stopFire2(string a = "")
  {
    this.talkAndGetUp(GameStrings.getString(GameStrings.actions, "chimney_cough_cough2"));
    this.smoke.started = false;
  }

  public override void clickAction()
  {
    if (this.usedItem == string.Empty)
    {
      string str1 = GameStrings.getString(GameStrings.actions, "base_chimney");
      bool flag1 = false;
      bool flag2 = false;
      if (GameDataController.gd.getObjective("chimney_note") || GameDataController.gd.getObjective("chimney_cash") || GameDataController.gd.getObjective("chimney_bag") || GameDataController.gd.getObjective("chimney_papers"))
        flag1 = true;
      if (GameDataController.gd.getObjective("chimney_charcoal") || GameDataController.gd.getObjectiveDetail("chimney_wood") > 0)
        flag2 = true;
      string str2 = !(flag1 | flag2) ? str1 + " " + GameStrings.getString(GameStrings.actions, "base_chimney_empty") : str1 + " " + GameStrings.getString(GameStrings.actions, "base_chimney_has") + " ";
      if (GameDataController.gd.getObjective("chimney_bag"))
        str2 += GameStrings.getString(GameStrings.actions, "base_chimney_bag");
      if (GameDataController.gd.getObjective("chimney_note"))
        str2 += GameStrings.getString(GameStrings.actions, "base_chimney_note");
      if (GameDataController.gd.getObjective("chimney_cash"))
        str2 += GameStrings.getString(GameStrings.actions, "base_chimney_cash");
      if (GameDataController.gd.getObjective("chimney_papers"))
        str2 += GameStrings.getString(GameStrings.actions, "base_chimney_papers");
      if (flag1 & flag2)
        str2 = str2 + " " + GameStrings.getString(GameStrings.actions, "base_chimney_and") + " ";
      if (GameDataController.gd.getObjective("chimney_charcoal"))
        str2 += GameStrings.getString(GameStrings.actions, "base_chimney_charcoal");
      if (GameDataController.gd.getObjectiveDetail("chimney_wood") > 0)
        str2 += GameStrings.getString(GameStrings.actions, "base_chimney_wood");
      if (flag1 | flag2)
        str2 += GameStrings.getString(GameStrings.actions, "base_chimney_has_end");
      Timeline.t.addAction(new TimelineAction(PlayerController.pc.textField)
      {
        text = str2,
        blockG = true
      });
      if (GameDataController.gd.getObjective("chimney_cleaned"))
        return;
      Timeline.t.addAction(new TimelineAction(PlayerController.pc.textField)
      {
        text = GameStrings.getString(GameStrings.actions, "base_chimney_clogged"),
        blockG = true
      });
      if (GameDataController.gd.getCurrentDay() != 1)
        return;
      Timeline.t.addAction(new TimelineAction(PlayerController.pc.textField)
      {
        text = GameStrings.getString(GameStrings.actions, "base_chimney_clogged_d1"),
        blockG = true
      });
    }
    else if (GameDataController.gd.getCurrentDay() == 1)
    {
      PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "base_chimney_d1"));
    }
    else
    {
      if ((this.usedItem == "pest_note" || this.usedItem == "gas_note" || this.usedItem == "spider_note") && !GameDataController.gd.getObjective("day1_complete"))
        PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "this_note_might_be_usefull"));
      else if (this.usedItem == "charcoal_empty" || this.usedItem == "pest_note" || this.usedItem == "gas_note" || this.usedItem == "spider_note" || this.usedItem == "wad_of_cash" || this.usedItem == "invoices")
      {
        if (GameDataController.gd.getObjective("chimney_note") || GameDataController.gd.getObjective("chimney_cash") || GameDataController.gd.getObjective("chimney_bag") || GameDataController.gd.getObjective("chimney_papers"))
        {
          PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "already_kindled"));
        }
        else
        {
          if (this.usedItem == "charcoal_empty")
            GameDataController.gd.setObjective("chimney_bag", true);
          if (this.usedItem == "pest_note" || this.usedItem == "gas_note" || this.usedItem == "spider_note")
            GameDataController.gd.setObjective("chimney_note", true);
          if (this.usedItem == "wad_of_cash")
            GameDataController.gd.setObjective("chimney_cash", true);
          if (this.usedItem == "invoices")
            GameDataController.gd.setObjective("chimney_papers", true);
          InventoryController.ic.removeItem(this.usedItem);
          this.updateAll();
          this.talkAndGetUp(GameStrings.getString(GameStrings.actions, "chimney_kindling1") + " " + GameStrings.getString(GameStrings.items, this.usedItem + "_short_accusative") + " " + GameStrings.getString(GameStrings.actions, "chimney_kindling2"));
        }
      }
      if (this.usedItem == "planks1" || this.usedItem == "planks2" || this.usedItem == "planks3" || this.usedItem == "planks4" || this.usedItem == "planks5" || this.usedItem == "charcoal")
      {
        if (GameDataController.gd.getObjectiveDetail("chimney_wood") > 0 || GameDataController.gd.getObjective("chimney_charcoal"))
        {
          PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "chimney_fueled"));
        }
        else
        {
          if (this.usedItem == "planks1" || this.usedItem == "planks2" || this.usedItem == "planks3" || this.usedItem == "planks4" || this.usedItem == "planks5")
            GameDataController.gd.setObjectiveDetail("chimney_wood", 1);
          if (this.usedItem == "charcoal")
            GameDataController.gd.setObjective("chimney_charcoal", true);
          InventoryController.ic.removeItem(this.usedItem);
          if (this.usedItem == "charcoal")
          {
            this.talkAndGetUp(GameStrings.getString(GameStrings.actions, "put_charcoal") + " " + GameStrings.getString(GameStrings.actions, "chimney_kindling2"));
            InventoryController.ic.pickOrDropItem(ItemsManager.im.getItem("charcoal_empty"));
          }
          else
            this.talkAndGetUp(GameStrings.getString(GameStrings.actions, "chimney_kindling1") + " " + GameStrings.getString(GameStrings.items, this.usedItem + "_short_accusative") + " " + GameStrings.getString(GameStrings.actions, "chimney_kindling2"));
          this.updateAll();
        }
      }
      if (!(this.usedItem == "lighter") && !(this.usedItem == "flamethrower_empty") && !(this.usedItem == "flamethrower"))
        return;
      if (GameDataController.gd.getCurrentDay() == 2 && GameDataController.gd.getObjectiveDetail("day_2_threat") == 0)
      {
        Vector3 color = GingerActionController.getColor();
        TextFieldController component = GameObject.Find("Ginger").GetComponent<TextFieldController>();
        List<DialogueLine> dialogueLines = new List<DialogueLine>();
        DialogueController.dc.initDialogue(dialogueLines, "chimney_dont_want", component, color, PlayerController.pc.textField, new Vector3(1f, 1f, 1f));
        if (GameDataController.gd.getObjective("dialogue_ginger_intro"))
        {
          for (int index = 0; index < dialogueLines.Count; ++index)
            Timeline.t.addDialogue(dialogueLines[index]);
          Timeline.t.actions[Timeline.t.actions.Count - 1].function = new TimelineFunction(this.getup);
          Timeline.t.actions[Timeline.t.actions.Count - 1].blockG = true;
          Timeline.t.actions[Timeline.t.actions.Count - 1].actionWithText = false;
          Timeline.t.doNotUnlock = true;
        }
        else
          PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "check_attic"));
      }
      else if (GameDataController.gd.getObjective("chimney_note") || GameDataController.gd.getObjective("chimney_cash") || GameDataController.gd.getObjective("chimney_bag") || GameDataController.gd.getObjective("chimney_papers"))
      {
        if (!GameDataController.gd.getObjective("chimney_charcoal") && GameDataController.gd.getObjectiveDetail("chimney_wood") <= 0)
          PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "chimney_no_fuel"));
        else if (GameDataController.gd.getObjective("base_fireplace_lit"))
          PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "chimney_already_lit"));
        else if (GameDataController.gd.getObjective("chimney_cleaned"))
        {
          if (this.usedItem == "flamethrower")
            PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "chimney_flamethrower_1"));
          if (this.usedItem == "flamethrower_empty")
            PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "chimney_flamethrower_2"));
          PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.fire_start, 1f);
          this.Invoke("startFire", 1f);
        }
        else
        {
          this.Invoke("stopFire", 3f);
          this.smoke.started = true;
        }
      }
      else
        PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "chimney_no_kindling"));
    }
  }

  public override void updateState()
  {
    if (GameDataController.gd.getObjective("base_fireplace_lit"))
    {
      this.fireLight.enabled = true;
      this.fireLight2.enabled = true;
      this.fire1.enabled = true;
      this.fire2.enabled = true;
    }
    else
    {
      this.fireLight.enabled = false;
      this.fireLight2.enabled = false;
      this.fire1.enabled = false;
      this.fire2.enabled = false;
    }
    this.loc.decideShadows();
    this.colliderManager.setCollider(0);
    this.objectName = "base_chimney_";
    if (GameDataController.gd.getObjective("base_fireplace_lit"))
    {
      this.objectName = "base_chimney_lit";
    }
    else
    {
      this.smoke.started = false;
      if (GameDataController.gd.getObjective("chimney_note"))
      {
        this.note.enabled = true;
        this.objectName += "1";
      }
      else
        this.note.enabled = false;
      if (GameDataController.gd.getObjective("chimney_cash"))
      {
        this.cash.enabled = true;
        this.objectName += "2";
      }
      else
        this.cash.enabled = false;
      if (GameDataController.gd.getObjective("chimney_papers"))
      {
        this.papers.enabled = true;
        this.objectName += "3";
      }
      else
        this.papers.enabled = false;
      if (GameDataController.gd.getObjective("chimney_bag"))
      {
        this.objectName += "4";
        this.charcoal_bag.enabled = true;
      }
      else
        this.charcoal_bag.enabled = false;
      if (GameDataController.gd.getObjective("chimney_charcoal"))
      {
        this.objectName += "A";
        this.charcoal.enabled = true;
      }
      else
        this.charcoal.enabled = false;
      if (GameDataController.gd.getObjectiveDetail("chimney_wood") == 0)
      {
        this.wood.enabled = false;
      }
      else
      {
        this.objectName += "B";
        this.wood.enabled = true;
      }
      if (GameDataController.gd.getObjectiveDetail("chimney_wood") == 1)
        this.wood.sprite = this.wood1;
      else if (GameDataController.gd.getObjectiveDetail("chimney_wood") == 2)
        this.wood.sprite = this.wood2;
      else if (GameDataController.gd.getObjectiveDetail("chimney_wood") == 3)
        this.wood.sprite = this.wood3;
      else
        this.wood.sprite = this.wood4;
    }
  }

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }
}

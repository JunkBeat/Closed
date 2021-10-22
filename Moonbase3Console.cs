// Decompiled with JetBrains decompiler
// Type: Moonbase3Console
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

public class Moonbase3Console : ObjectActionController
{
  public Sprite painting;

  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "action_stnd_n";
    this.animationFlip = false;
    this.useCurrentDirection = false;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "screen_quests";
    this.range = 1f;
    this.interactions = new List<ItemInteraction>();
    this.interactions.Add(new ItemInteraction("disc1", string.Empty, anim: string.Empty));
    this.interactions.Add(new ItemInteraction("disc2", string.Empty, anim: string.Empty));
  }

  public List<string> quests()
  {
    List<string> stringList = new List<string>();
    ExamineSprite.es.lookAction = new ExamineSprite.Delegate(this.ohNo);
    stringList.Add(string.Empty + GameStrings.getString(GameStrings.world_labels, "pod_caption_stats_a"));
    if (!GameDataController.gd.getObjective("moon_disc1_used"))
      stringList.Add(stringList[stringList.Count - 1] + " ^^" + GameStrings.getString(GameStrings.world_labels, "pod_caption_fd1_a"));
    else
      stringList.Add(stringList[stringList.Count - 1] + " ^^" + GameStrings.getString(GameStrings.world_labels, "pod_caption_fd1_b"));
    if (!GameDataController.gd.getObjective("moon_disc2_used"))
      stringList.Add(stringList[stringList.Count - 1] + " ^^" + GameStrings.getString(GameStrings.world_labels, "pod_caption_fd2_a"));
    else
      stringList.Add(stringList[stringList.Count - 1] + " ^^" + GameStrings.getString(GameStrings.world_labels, "pod_caption_fd2_b"));
    if (!GameDataController.gd.getObjective("moon_console_unlocked"))
    {
      stringList.Add(stringList[stringList.Count - 1] + " ^^" + GameStrings.getString(GameStrings.world_labels, "pod_caption_3a"));
    }
    else
    {
      string str1 = GameStrings.getString(GameStrings.world_labels, "pod_caption_2a");
      int num = 52;
      if (GameDataController.gd.getObjective("moon_cate_sleeps"))
        ++num;
      if (GameDataController.gd.getObjective("moon_cody_sleeps"))
        ++num;
      if (GameDataController.gd.getObjective("moon_barry_sleeps"))
        ++num;
      string str2 = str1 + " " + (object) num + string.Empty + GameStrings.getString(GameStrings.world_labels, "pod_caption_2b");
      stringList.Add(stringList[stringList.Count - 1] + " ^^" + GameStrings.getString(GameStrings.world_labels, "pod_caption_3c"));
      stringList.Add(string.Empty + GameStrings.getString(GameStrings.world_labels, "pod_caption_0"));
      stringList.Add(stringList[stringList.Count - 1] + " ^" + GameStrings.getString(GameStrings.world_labels, "pod_caption_1"));
      stringList.Add(stringList[stringList.Count - 1] + " ^" + str2);
      stringList.Add(stringList[stringList.Count - 1] + " ^" + GameStrings.getString(GameStrings.world_labels, "pod_caption_4"));
      stringList.Add(stringList[stringList.Count - 1] + " ^" + GameStrings.getString(GameStrings.world_labels, "pod_caption_5"));
      stringList.Add(stringList[stringList.Count - 1] + " ^" + GameStrings.getString(GameStrings.world_labels, "pod_caption_6"));
      stringList.Add(stringList[stringList.Count - 1] + " ^" + GameStrings.getString(GameStrings.world_labels, "pod_caption_7"));
      if (GameDataController.gd.getObjective("moon_disc1_used"))
        stringList.Add(stringList[stringList.Count - 1] + " ^" + GameStrings.getString(GameStrings.world_labels, "pod_caption_A"));
      if (GameDataController.gd.getObjective("moon_disc2_used"))
        stringList.Add(stringList[stringList.Count - 1] + " ^" + GameStrings.getString(GameStrings.world_labels, "pod_caption_B"));
    }
    stringList.Add(stringList[stringList.Count - 1] + " ^" + GameStrings.getString(GameStrings.world_labels, "quests_underline"));
    return stringList;
  }

  public void failsound(string s = "") => PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.fail1);

  public void examine(string val = "")
  {
    PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.computer_click2);
    ExamineSprite.es.textField.shift.x = -110f;
    ExamineSprite.es.textField.shift.y = 55f;
    ExamineSprite.es.readyText(this.quests(), 210, 0.5f, 0.75f, 1f, 0.0f, 0.0f, 0.0f, 0.0f);
    ExamineSprite.es.ac = SoundsManagerController.sm.computer_click1;
    ExamineSprite.es.audioVolume = 0.25f;
    ExamineSprite.es.show(this.painting);
    ExamineSprite.es.actionOnShow = false;
    if (!(val == "yes"))
      return;
    ExamineSprite.es.lookAction = !GameDataController.gd.getObjective("moon_disc1_used") || !GameDataController.gd.getObjective("moon_disc2_used") ? new ExamineSprite.Delegate(this.say2) : new ExamineSprite.Delegate(this.say1);
    ExamineSprite.es.actionOnShow = false;
  }

  public void say1() => PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "moon_console_disks_inserted"));

  public void say2() => PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "moon_console_disk_inserted"));

  public override void clickAction()
  {
    if (this.usedItem != string.Empty)
    {
      if (GameDataController.gd.getObjective("moon_light_failed") && !GameDataController.gd.getObjective("moon_light_restored"))
        PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "moon_console_disk_no_power"));
      else if (!GameDataController.gd.getObjective("moon_console_unlocked"))
        PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "moon_console_disk_locked"));
      else if (!GameDataController.gd.getObjective("moon_pods_unlocked"))
      {
        PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "moon_console_disk_checked"));
      }
      else
      {
        if (this.usedItem == "disc1")
        {
          GameDataController.gd.setObjective("moon_disc1_used", true);
          Timeline.t.addAction(new TimelineAction(PlayerController.pc.textField)
          {
            text = GameStrings.getString(GameStrings.actions, "moon_console_disk1_inserted"),
            textColor = new Vector3(1f, 1f, 1f),
            function = new TimelineFunction(this.examine),
            param = "yes",
            actionWithText = false
          });
        }
        else if (this.usedItem == "disc2")
        {
          GameDataController.gd.setObjective("moon_disc2_used", true);
          Timeline.t.addAction(new TimelineAction(PlayerController.pc.textField)
          {
            text = GameStrings.getString(GameStrings.actions, "moon_console_disk2_inserted"),
            textColor = new Vector3(1f, 1f, 1f),
            function = new TimelineFunction(this.examine),
            param = "yes",
            actionWithText = false
          });
        }
        InventoryController.ic.removeItem(this.usedItem);
        PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.disk);
      }
    }
    else if (GameDataController.gd.getObjective("moon_light_failed") && !GameDataController.gd.getObjective("moon_light_restored"))
    {
      this.gameObject.transform.Find("TextField").transform.position = ScreenControler.roundToNearestFullPixel3(this.gameObject.transform.Find("TextField").transform.position);
      TimelineAction timelineAction = new TimelineAction();
      Timeline.t.addAction(new TimelineAction()
      {
        textfield = this.gameObject.transform.Find("TextField").GetComponent<TextFieldController>(),
        textColor = new Vector3(1f, 0.0f, 0.0f),
        backgroundColor = new Vector3(0.5f, 0.0f, 0.0f),
        text = GameStrings.getString(GameStrings.actions, "moon_power_failure_2"),
        actionWithText = true,
        function = new TimelineFunction(this.failsound)
      });
    }
    else
    {
      this.examine(string.Empty);
      if (GameDataController.gd.getObjective("moon_console_unlocked"))
      {
        if (GameDataController.gd.getObjective("npc1_alive") && !GameDataController.gd.getObjective("dialogue_pods_intro"))
          ExamineSprite.es.lookAction = new ExamineSprite.Delegate(this.ohNo);
        else if (!GameDataController.gd.getObjective("npc1_alive") && !GameDataController.gd.getObjective("moon_pods_unlocked"))
          ExamineSprite.es.lookAction = new ExamineSprite.Delegate(this.opennocate);
      }
      GameDataController.gd.setObjective("pods_cosnole_inspected", true);
    }
  }

  public void ohNo()
  {
    TextFieldController component = GameObject.Find("Ginger").GetComponent<TextFieldController>();
    string prefix = "ginger_moon_pods_emergency_intro_cate";
    if (!GameDataController.gd.getObjective("npc1_alive"))
      prefix = "ginger_moon_pods_emergency_intro_no_cate";
    List<DialogueLine> dialogueLines = new List<DialogueLine>();
    DialogueController.dc.initDialogue(dialogueLines, prefix, PlayerController.pc.textField, new Vector3(1f, 1f, 1f), component, GingerActionController.getColor());
    if (GameDataController.gd.getObjective("npc1_alive"))
      dialogueLines[dialogueLines.Count - 1].action = new TimelineFunction(this.startDialogue2);
    for (int index = 0; index < dialogueLines.Count; ++index)
      Timeline.t.addDialogue(dialogueLines[index]);
    GameDataController.gd.setObjective("dialogue_pods_intro", true);
  }

  public void opennocate()
  {
    GameDataController.gd.setObjective("moon_pods_unlocked", true);
    GameObject.Find("Moonbase3Pad1").GetComponent<Moonbase3Pod>().openIfNeeded();
    GameObject.Find("Moonbase3Pad2").GetComponent<Moonbase3Pod>().openIfNeeded();
    GameObject.Find("Moonbase3Pad3").GetComponent<Moonbase3Pod>().openIfNeeded();
    GameObject.Find("Moonbase3Pad4").GetComponent<Moonbase3Pod>().openIfNeeded();
  }

  public override void updateState() => this.colliderManager.setCollider(0);

  public void startDialogue2(string str = "") => GameObject.Find("Ginger").GetComponent<GingerActionController>().npcClickAction(string.Empty);

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

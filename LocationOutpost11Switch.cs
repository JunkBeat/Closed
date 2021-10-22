// Decompiled with JetBrains decompiler
// Type: LocationOutpost11Switch
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

public class LocationOutpost11Switch : ObjectActionController
{
  private SpriteRenderer sr;
  public Sprite sprite_on;
  public Sprite sprite_off;
  public Sprite sprite_wr;
  private int liczba;
  public SpriteRenderer light1;
  public SpriteRenderer light2;
  public string thisNumber;
  public bool projectorCutscene;
  public PolygonCollider2D darkness;

  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "action_stnd_";
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "outpost_switch";
    this.range = 1f;
    this.teleport = false;
    this.sr = this.gameObject.GetComponent<SpriteRenderer>();
    this.updateState();
    this.actionType = ObjectActionController.Type.NormalAction;
    this.projectorCutscene = false;
  }

  private void Update()
  {
    if (!this.projectorCutscene || (double) PlayerController.wc.currentXY.x != 100.0)
      return;
    PlayerController.pc.forceAnimation("stand_ne");
    this.projectorCutscene = false;
  }

  public override void whatOnClick()
  {
  }

  public override void clickAction()
  {
    if (!GameDataController.gd.getObjective("outpost_switch_pressed"))
    {
      PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.button_click);
      GameDataController.gd.setObjective("outpost_switch_pressed", true);
      this.updateAll();
      GameObject.Find("Ginger").GetComponent<NPCWalkController>().setTargetV3(GameObject.Find("GingerWalk").transform.position);
      GameObject.Find("Npc2").GetComponent<NPCWalkController>().setTargetV3(GameObject.Find("BarryWalk").transform.position);
      GameObject.Find("Npc3").GetComponent<NPCWalkController>().setTargetV3(GameObject.Find("CodyWalk").transform.position);
    }
    else
      PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "outpost_switch_pressed"));
  }

  public override void updateState()
  {
    if (!GameDataController.gd.getObjective("outpost_switch_pressed"))
    {
      this.characterAnimationName = "action_n_busy";
      this.animationFlip = false;
      this.useCurrentDirection = false;
      this.range = 1f;
      this.light1.enabled = true;
      this.light2.enabled = false;
      this.darkness.enabled = true;
    }
    else
    {
      this.characterAnimationName = "action_stnd_";
      this.animationFlip = false;
      this.useCurrentDirection = true;
      this.range = 200f;
      this.light1.enabled = false;
      this.light2.enabled = true;
      this.darkness.enabled = false;
    }
    GameObject.Find("Location").GetComponent<LocationManager>().initNodes();
  }

  public override void clickAction2()
  {
    PlayerController.pc.forceAnimation("stand_ne");
    this.Invoke("rotate1", 0.2f);
  }

  public void rotate2(string var = "")
  {
    PlayerController.wc.setSimpleTarget(new Vector2(100f, 45f));
    PlayerController.pc.forceAnimation("walk_e");
  }

  public void gingerwalk(string var = "")
  {
    GameObject.Find("Ginger").GetComponent<NPCWalkController>().setTargetV3(GameObject.Find("GingerWalk").transform.position);
    GameObject.Find("Npc2").GetComponent<NPCWalkController>().setTargetV3(GameObject.Find("BarryWalk").transform.position);
    GameObject.Find("Npc3").GetComponent<NPCWalkController>().setTargetV3(GameObject.Find("CodyWalk").transform.position);
  }

  public void rotateLeft(string v = "")
  {
    PlayerController.wc.forceDirection(WalkController.Direction.E);
    PlayerController.wc.forceAnimation("stand_se", true);
    PlayerController.pc.gameObject.GetComponent<SpriteRenderer>().flipX = true;
  }

  public void rotateRight(string v = "")
  {
    PlayerController.wc.forceDirection(WalkController.Direction.W);
    PlayerController.wc.forceAnimation("stand_ne");
    PlayerController.pc.gameObject.GetComponent<SpriteRenderer>().flipX = false;
  }

  public void rotate1()
  {
    PlayerController.pc.forceAnimation("stand_e");
    this.projectorCutscene = true;
    Vector3 color1 = GingerActionController.getColor();
    TextFieldController component1 = GameObject.Find("Ginger").GetComponent<TextFieldController>();
    List<DialogueLine> dialogueLines = new List<DialogueLine>();
    DialogueController.dc.initDialogue(dialogueLines, "moon_reveal", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), component1, color1);
    dialogueLines[10].action = new TimelineFunction(this.rotateLeft);
    dialogueLines[10].actionWithText = true;
    dialogueLines[12].action = new TimelineFunction(this.rotateRight);
    dialogueLines[12].actionWithText = true;
    dialogueLines[17].action = new TimelineFunction(this.rotateLeft);
    dialogueLines[17].actionWithText = true;
    dialogueLines[20].action = new TimelineFunction(this.rotateRight);
    dialogueLines[20].actionWithText = true;
    if (GameDataController.gd.getObjective("npc2_joined") && GameDataController.gd.getObjective("npc2_alive"))
    {
      Vector3 color2 = GingerActionController.getColor();
      Vector3 color3 = Npc2Controller.getColor();
      component1 = GameObject.Find("Ginger").GetComponent<TextFieldController>();
      TextFieldController component2 = GameObject.Find("Npc2").GetComponent<TextFieldController>();
      dialogueLines.Insert(6, new DialogueLine(component2, color3, GameStrings.getString(GameStrings.dialogues, "outpost_travel_reveal_Barry_1"), (TimelineFunction) null));
      dialogueLines.Insert(17, new DialogueLine(component2, color3, GameStrings.getString(GameStrings.dialogues, "outpost_travel_reveal_Barry_2"), (TimelineFunction) null));
      DialogueController.dc.initDialogue(dialogueLines, "moon_reveal_barry", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), component1, color2, component2, color3);
    }
    if (GameDataController.gd.getObjective("npc3_joined") && GameDataController.gd.getObjective("npc3_alive"))
    {
      Vector3 color4 = GingerActionController.getColor();
      Vector3 color5 = Npc3Controller.getColor();
      TextFieldController component3 = GameObject.Find("Npc3").GetComponent<TextFieldController>();
      dialogueLines.Insert(6, new DialogueLine(component3, color5, GameStrings.getString(GameStrings.dialogues, "outpost_travel_reveal_Cody_1"), (TimelineFunction) null));
      DialogueController.dc.initDialogue(dialogueLines, "moon_reveal_cody", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), component1, color4, component3, color5);
    }
    dialogueLines[2].action = new TimelineFunction(this.rotate2);
    dialogueLines[3].action = new TimelineFunction(this.gingerwalk);
    for (int index = 0; index < dialogueLines.Count; ++index)
      Timeline.t.addDialogue(dialogueLines[index]);
  }

  public override void clickAction0()
  {
  }
}

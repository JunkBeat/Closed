// Decompiled with JetBrains decompiler
// Type: Location1Start
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


using System.Collections.Generic;
using UnityEngine;

public class Location1Start : MonoBehaviour
{
  public SpriteRenderer fireLight;
  public SpriteRenderer fireLight2;
  public Sprite memoryOfCrossroad;
  public Sprite darkShadow;
  public Sprite lightShadow;
  public Material normalMat;
  public Material lightMat;
  public SpriteRenderer shadowrenderer;
  private bool memoryGo;

  private void Start()
  {
    this.memoryGo = false;
    this.normalMat = new Material(Shader.Find("Sprites/Default"));
    this.decideShadows();
    PlayerController.wc.speed = PlayerController.wc.MAX_SPEED;
    PlayerController.wc.GetComponent<Animator>().speed = 1f;
    PlayerController.pc.copySettingsToNPCs();
    JukeboxMusic.jb.changeMusic(SoundsManagerController.sm.music_explore_5a);
    if (GameDataController.gd.getObjective("barn_pump_started") && GameDataController.gd.getObjectiveDetail("barn_pump_started") == 1)
    {
      this.shadowrenderer.sprite = this.lightShadow;
      this.shadowrenderer.material = this.lightMat;
      if (GameDataController.gd.getObjective("base_heater_cord_plugged"))
        GameObject.Find("location1_heater").GetComponent<Location1HeaterOrFan>().lightAlfa = 1f;
      else
        GameObject.Find("location1_heater").GetComponent<Location1HeaterOrFan>().lightAlfa = 0.0f;
    }
    else
    {
      this.shadowrenderer.sprite = this.darkShadow;
      this.shadowrenderer.material = this.normalMat;
    }
    if (!GameDataController.gd.getObjective("base_discovered"))
      this.memoryGo = true;
    List<DialogueLine> dialogueLines = new List<DialogueLine>();
    if (GameDataController.gd.getObjective("npc3_joined") && GameDataController.gd.getObjective("npc3_alive") && !GameDataController.gd.getObjective("cody_base_welcome"))
    {
      GameDataController.gd.setObjective("cody_base_welcome", true);
      Vector3 color1 = GingerActionController.getColor();
      Vector3 color2 = Npc3Controller.getColor();
      TextFieldController component = GameObject.Find("Npc3").GetComponent<TextFieldController>();
      DialogueController.dc.initDialogue(dialogueLines, "cody_base_welcome", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), GameObject.Find("Ginger").GetComponent<TextFieldController>(), color1, component, color2);
    }
    if (GameDataController.gd.getObjective("npc2_joined") && GameDataController.gd.getObjective("npc2_alive") && !GameDataController.gd.getObjective("barry_base_welcome"))
    {
      GameDataController.gd.setObjective("barry_base_welcome", true);
      Vector3 color3 = GingerActionController.getColor();
      Vector3 color4 = Npc2Controller.getColor();
      TextFieldController component = GameObject.Find("Npc2").GetComponent<TextFieldController>();
      DialogueController.dc.initDialogue(dialogueLines, "barry_base_welcome", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), GameObject.Find("Ginger").GetComponent<TextFieldController>(), color3, component, color4);
    }
    if (dialogueLines.Count > 0)
    {
      dialogueLines[0].action = new TimelineFunction(this.davidStand);
      dialogueLines[0].actionWithText = true;
    }
    for (int index = 0; index < dialogueLines.Count; ++index)
      Timeline.t.addDialogue(dialogueLines[index]);
  }

  public void davidStand(string s = "") => PlayerController.wc.forceAnimation("stand_se");

  public void decideShadows()
  {
    if (GameDataController.gd.getObjective("base_fireplace_lit"))
    {
      PlayerController.wc.shadow.fadeRateV = 0.005f;
      PlayerController.wc.shadow.fadeRateH = 0.005f;
      PlayerController.wc.shadowOffsetY = 0;
      PlayerController.wc.shadow.skewFactor = 60f;
      PlayerController.wc.shadow.skewFactor2 = 0.0f;
      PlayerController.wc.shadow.startAlpha = 0.5f;
      PlayerController.wc.shadow.source = 100f;
      PlayerController.ssg.setStepType("normal");
      PlayerController.wc.shadow.scaleFactor = 0.75f;
      PlayerController.wc.shadow.downwards = true;
      PlayerController.pc.copySettingsToNPCs();
      JukeboxAmbient.jb.changeAmbient(SoundsManagerController.sm.ambient_fire_1, 1f);
    }
    else if (GameDataController.gd.getObjective("barn_pump_started") && GameDataController.gd.getObjectiveDetail("barn_pump_started") == 1)
    {
      PlayerController.wc.shadow.fadeRateV = 0.005f;
      PlayerController.wc.shadow.fadeRateH = 0.0005f;
      PlayerController.wc.shadowOffsetY = -4;
      PlayerController.wc.shadow.skewFactor = 50f;
      PlayerController.wc.shadow.skewFactor2 = 0.0f;
      PlayerController.wc.shadow.startAlpha = 0.5f;
      PlayerController.wc.shadow.source = 120f;
      PlayerController.ssg.setStepType("normal");
      PlayerController.wc.shadow.scaleFactor = 0.3f;
      PlayerController.wc.shadow.downwards = true;
      PlayerController.pc.copySettingsToNPCs();
      JukeboxAmbient.jb.changeAmbient(SoundsManagerController.sm.ambient_wind_1, 0.25f);
    }
    else
    {
      PlayerController.wc.shadow.fadeRateV = 0.0f;
      PlayerController.wc.shadow.fadeRateH = 0.0035f;
      PlayerController.wc.shadowOffsetY = -4;
      PlayerController.wc.shadow.skewFactor = 0.0f;
      PlayerController.wc.shadow.skewFactor2 = -15f;
      PlayerController.wc.shadow.startAlpha = 0.75f;
      PlayerController.wc.shadow.source = 0.0f;
      PlayerController.ssg.setStepType(StepSoundGenerator.NORMAL);
      PlayerController.wc.shadow.scaleFactor = 0.4f;
      PlayerController.wc.shadow.downwards = true;
      JukeboxAmbient.jb.changeAmbient(SoundsManagerController.sm.ambient_wind_1, 0.25f);
    }
  }

  private void showMemoryOfCrossroad(string param)
  {
    ExamineSprite.es.textField.shift.x = -110f;
    ExamineSprite.es.textField.shift.y = 10f;
    ExamineSprite.es.readyText(new List<string>()
    {
      GameStrings.getString(GameStrings.actions, "story_base3")
    }, 100, 1f, 1f, 1f, 0.0f, 0.0f, 0.0f, 0.75f);
    ExamineSprite.es.show(this.memoryOfCrossroad);
  }

  public void initStory()
  {
    GameDataController.gd.autoSave();
    PlayerController.wc.fullStop(true);
    Timeline.t.addAction(new TimelineAction(PlayerController.pc.textField)
    {
      text = GameStrings.getString(GameStrings.actions, "story_base1")
    });
    Timeline.t.addAction(new TimelineAction(PlayerController.pc.textField)
    {
      text = GameStrings.getString(GameStrings.actions, "story_base2"),
      function = new TimelineFunction(this.showMemoryOfCrossroad)
    });
    GameDataController.gd.setObjective("visited_location1", true);
    GameDataController.gd.setObjective("base_discovered", true);
  }

  private void Update()
  {
    if (this.memoryGo && !PlayerController.wc.busy)
    {
      this.memoryGo = false;
      this.initStory();
    }
    this.fireLight.color = new Color(1f, 1f, 1f, Random.Range(0.85f, 1f));
    this.fireLight2.color = new Color(1f, 1f, 1f, Random.Range(0.85f, 1f));
  }

  private void clockShow(string param) => GameObject.Find("clock").GetComponent<ClockController>().showClock(string.Empty);
}

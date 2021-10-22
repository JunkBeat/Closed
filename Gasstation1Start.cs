// Decompiled with JetBrains decompiler
// Type: Gasstation1Start
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

public class Gasstation1Start : MonoBehaviour
{
  public SpriteRenderer sr;
  public Sprite spiders1;
  public Sprite spiders2;
  public TextFieldController tf1;
  public TextFieldController tf2;
  public Vector3 color1;
  public Vector3 color2;
  private TextFieldController tf;
  private Vector3 color;

  private void Start()
  {
    PlayerController.wc.shadow.fadeRateV = 0.004f;
    PlayerController.wc.shadow.fadeRateH = 0.004f;
    PlayerController.wc.shadowOffsetY = 0;
    PlayerController.wc.shadow.skewFactor = 0.0f;
    PlayerController.wc.shadow.skewFactor2 = 5f;
    PlayerController.wc.shadow.startAlpha = 0.5f;
    PlayerController.wc.shadow.scaleFactor = 0.75f;
    PlayerController.wc.shadow.downwards = true;
    PlayerController.wc.shadow.scaleFactor = 0.75f;
    PlayerController.wc.shadow.downwards = true;
    PlayerController.wc.speed = PlayerController.wc.MAX_SPEED;
    PlayerController.wc.GetComponent<Animator>().speed = 1f;
    PlayerController.wc.shadow.source = 260f;
    PlayerController.ssg.setStepType("road");
    GameDataController.gd.setObjective("visited_gasstation1", true);
    GameDataController.gd.setObjective("bridge_westside", true);
    PlayerController.pc.copySettingsToNPCs();
    if (GameDataController.gd.getObjectiveDetail("map_restaurant_revealed") == TravelAgency.LOCATION_STATUS_UNREACHABLE)
      GameDataController.gd.setObjectiveDetail("map_restaurant_revealed", TravelAgency.LOCATION_STATUS_REACHABLE);
    if (GameDataController.gd.getObjectiveDetail("map_houseb_revealed") == TravelAgency.LOCATION_STATUS_UNREACHABLE)
      GameDataController.gd.setObjectiveDetail("map_houseb_revealed", TravelAgency.LOCATION_STATUS_REACHABLE);
    JukeboxAmbient.jb.changeAmbient(SoundsManagerController.sm.ambient_wind_1, 1f);
    if (GameDataController.gd.getCurrentDay() < 3 && GameDataController.gd.getObjectiveDetail("day_1_threat") == 2)
    {
      GameObject.Find("Column1").GetComponent<SpriteRenderer>().enabled = false;
      GameObject.Find("Column2").GetComponent<SpriteRenderer>().enabled = false;
      GameObject.Find("Column3").GetComponent<SpriteRenderer>().enabled = false;
      GameObject.Find("Location").transform.Find("plane00").GetComponent<SpriteRenderer>().enabled = false;
      GameObject.Find("Column1_spiders").GetComponent<SpriteRenderer>().enabled = true;
      GameObject.Find("Column2_spiders").GetComponent<SpriteRenderer>().enabled = true;
      GameObject.Find("Column3_spiders").GetComponent<SpriteRenderer>().enabled = true;
      GameObject.Find("Location").transform.Find("plane00_spiders").GetComponent<SpriteRenderer>().enabled = true;
      if (GameDataController.gd.getCurrentDay() == 1)
        GameObject.Find("Location").transform.Find("plane00_spiders").GetComponent<SpriteRenderer>().sprite = this.spiders1;
      else
        GameObject.Find("Location").transform.Find("plane00_spiders").GetComponent<SpriteRenderer>().sprite = this.spiders2;
    }
    else
    {
      GameObject.Find("Column1").GetComponent<SpriteRenderer>().enabled = true;
      GameObject.Find("Column2").GetComponent<SpriteRenderer>().enabled = true;
      GameObject.Find("Column3").GetComponent<SpriteRenderer>().enabled = true;
      GameObject.Find("Location").transform.Find("plane00").GetComponent<SpriteRenderer>().enabled = true;
      GameObject.Find("Column1_spiders").GetComponent<SpriteRenderer>().enabled = false;
      GameObject.Find("Column2_spiders").GetComponent<SpriteRenderer>().enabled = false;
      GameObject.Find("Column3_spiders").GetComponent<SpriteRenderer>().enabled = false;
      GameObject.Find("Location").transform.Find("plane00_spiders").GetComponent<SpriteRenderer>().enabled = false;
    }
    if (GameDataController.gd.getCurrentDay() == 3)
    {
      if (GameDataController.gd.getObjectiveDetail("day_2_threat") == 1)
      {
        this.sr.enabled = true;
        this.sr.color = GameDataController.gd.gameTime >= 600 ? (GameDataController.gd.gameTime >= 650 ? (GameDataController.gd.gameTime >= 700 ? (GameDataController.gd.gameTime >= 750 ? (GameDataController.gd.gameTime >= 800 ? new Color(1f, 1f, 1f, 0.1f) : new Color(1f, 1f, 1f, 0.2f)) : new Color(1f, 1f, 1f, 0.4f)) : new Color(1f, 1f, 1f, 0.6f)) : new Color(1f, 1f, 1f, 0.8f)) : new Color(1f, 1f, 1f, 1f);
      }
      else
        this.sr.enabled = false;
    }
    else
      this.sr.enabled = false;
    GameObject.Find("Location").GetComponent<LocationManager>().canPickUpItems();
    GameObject.Find("clock").GetComponent<ClockController>().showFinal();
    if (GameDataController.gd.getCurrentDay() == 1 && GameDataController.gd.getObjective("gasstation_spider_baited") && !GameDataController.gd.getObjective("gasstation_spider_player_fallen") && !GameDataController.gd.getObjective("gasstation_spider_shot") && ItemsManager.im.getItem("rifle_6").dataRef.droppedLocation.ToLower().IndexOf("inventory") != -1)
    {
      GameObject.Find("clock").GetComponent<ClockController>().hide();
      PlayerController.pc.allowDrop = false;
      this.Invoke("spiderAttack2", 1f);
      GameDataController.gd.setObjective("gasstation_spider_player_fallen", true);
      GameObject.Find("Location").GetComponent<LocationManager>().cantPickupItems();
      JukeboxMusic.jb.changeMusic(SoundsManagerController.sm.music_scare, minTime: 0.0f, maxTime: 0.0f);
    }
    else if (GameDataController.gd.getCurrentDay() == 1 && GameDataController.gd.getObjective("gasstation_spider_player_fallen") && !GameDataController.gd.getObjective("gasstation_spider_shot") && !GameDataController.gd.getObjective("gasstation_spider_shot") && ItemsManager.im.getItem("rifle_6").dataRef.droppedLocation.ToLower().IndexOf("inventory") != -1)
    {
      GameObject.Find("clock").GetComponent<ClockController>().hide();
      GameObject.Find("Location").GetComponent<LocationManager>().cantPickupItems();
      PlayerController.pc.allowDrop = false;
      this.spiderAttack2b();
      JukeboxMusic.jb.changeMusic(SoundsManagerController.sm.music_scare, minTime: 0.0f, maxTime: 0.0f);
    }
    else if (GameDataController.gd.getCurrentDay() == 1 && !GameDataController.gd.getObjective("gasstation_spider_shot") && GameDataController.gd.getObjectiveDetail("day_1_threat") == 2)
      JukeboxMusic.jb.changeMusic(SoundsManagerController.sm.music_explore_6a, minTime: 1f, maxTime: 3f);
    else if (GameDataController.gd.getCurrentDay() == 3 && GameDataController.gd.getObjectiveDetail("day_3_threat") == 0 && GameDataController.gd.getObjective("sidereal_base_located") && !GameDataController.gd.getObjective("gasstation_sarge_reason"))
      JukeboxMusic.jb.changeMusic(SoundsManagerController.sm.music_explore_6a);
    else if (GameDataController.gd.getObjective("gasstation_sarge_shot"))
      JukeboxMusic.jb.changeMusic((AudioClip) null);
    else
      JukeboxMusic.jb.changeMusic(SoundsManagerController.sm.music_explore_3a);
    if (GameDataController.gd.getCurrentDay() != 3 || GameDataController.gd.getObjectiveDetail("day_3_threat") != 0 || !GameDataController.gd.getObjective("sidereal_base_located") || GameDataController.gd.getObjective("thugs_gasstation_talk"))
      return;
    GameDataController.gd.setObjectiveDetail("thugs_gasstation_talk", Random.Range(0, 7));
    this.Invoke("thugTalk", 1f);
    GameDataController.gd.setObjective("gasstation_map_warned", true);
    if (GameDataController.gd.getObjective("thugs_gasstation_spotted"))
      return;
    GameDataController.gd.setObjective("thugs_gasstation_spotted", true);
    List<DialogueLine> dialogueLines = new List<DialogueLine>();
    Vector3 color = GingerActionController.getColor();
    TextFieldController component = GameObject.Find("Ginger").GetComponent<TextFieldController>();
    DialogueController.dc.initDialogue(dialogueLines, "gasstation_hear_thugs1", PlayerController.pc.textField, new Vector3(1f, 1f, 1f), component, color);
    if (GameDataController.gd.getObjective("npc2_alive") || GameDataController.gd.getObjective("npc3_alive"))
      dialogueLines[1].text = GameStrings.getString(GameStrings.dialogues, "gasstation_hear_thugs2_2_b");
    for (int index = 0; index < dialogueLines.Count; ++index)
      Timeline.t.addDialogue(dialogueLines[index]);
  }

  private void thugTalk()
  {
    if ((Object) this.tf != (Object) null)
      this.tf.dissmiss();
    if (GameDataController.gd.getObjectiveDetail("thugs_gasstation_talk") == 0 || GameDataController.gd.getObjectiveDetail("thugs_gasstation_talk") == 2 || GameDataController.gd.getObjectiveDetail("thugs_gasstation_talk") == 4 || GameDataController.gd.getObjectiveDetail("thugs_gasstation_talk") == 6)
    {
      this.tf = this.tf1;
      this.color = this.color1;
    }
    else
    {
      this.tf = this.tf2;
      this.color = this.color2;
    }
    string text = GameStrings.getString(GameStrings.dialogues, "thugs_gasstation_talk_" + (object) GameDataController.gd.getObjectiveDetail("thugs_gasstation_talk"));
    float a = Random.Range(0.2f, 0.4f);
    this.tf.setAlpha(a);
    this.tf.viewText(text, quick: true, instant: true, mwidth: 100, r: this.color.x, g: this.color.y, b: this.color.z, ba: 0.25f, mute: true);
    this.tf.setAlpha(a);
    this.Invoke(nameof (thugTalk), (float) text.Length * 0.25f + Random.Range(1f, 2f));
    if (GameDataController.gd.getObjectiveDetail("thugs_gasstation_talk") + 1 > 7)
      GameDataController.gd.setObjectiveDetail("thugs_gasstation_talk", 0);
    else
      GameDataController.gd.setObjectiveDetail("thugs_gasstation_talk", GameDataController.gd.getObjectiveDetail("thugs_gasstation_talk") + 1);
  }

  private void spiderAttack()
  {
    MonoBehaviour.print((object) "SIADAJ FRED");
    PlayerController.pc.setBusy(true);
    PlayerController.wc.speed = 0.0f;
    PlayerController.wc.dir = WalkController.Direction.W;
    PlayerController.wc.forceAnimation("sit_fall", true);
    this.Invoke("spiderAttack2", 0.5f);
    GameObject.Find("clock").GetComponent<ClockController>().hide();
  }

  private void spiderAttack2()
  {
    PlayerController.wc.dir = WalkController.Direction.W;
    PlayerController.pc.gameObject.GetComponent<SpriteRenderer>().flipX = true;
    PlayerController.wc.forceAnimation("sit_strugle", true);
    PlayerController.pc.setBusy(false);
    PlayerController.pc.gameObject.GetComponent<SpriteRenderer>().flipX = true;
    PlayerController.wc.setCurrentAnimClip("sit_strugle");
    PlayerController.wc.speed = 0.0f;
    GameObject.Find("Location").GetComponent<LocationManager>().cantPickupItems();
    GameObject.Find("clock").GetComponent<ClockController>().hide();
  }

  private void spiderAttack2b()
  {
    PlayerController.wc.dir = WalkController.Direction.W;
    PlayerController.pc.gameObject.GetComponent<SpriteRenderer>().flipX = true;
    PlayerController.wc.forceAnimation("sit_strugle", true);
    PlayerController.pc.setBusy(true);
    PlayerController.pc.gameObject.GetComponent<SpriteRenderer>().flipX = true;
    PlayerController.wc.setCurrentAnimClip("sit_strugle");
    PlayerController.wc.speed = 0.0f;
    this.Invoke("spiderAttack2", 0.5f);
    GameObject.Find("clock").GetComponent<ClockController>().hide();
  }

  private void Update()
  {
  }
}

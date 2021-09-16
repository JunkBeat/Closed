// Decompiled with JetBrains decompiler
// Type: NPCActionController
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NPCActionController : ObjectActionController
{
  public Item itemRef;
  protected DialogueOptionController doc;
  public List<DialogueLine> instantLines;
  public TextFieldController textField;
  public List<DialogueLine> randomLines;
  public float randomLinesProbab;
  public bool busyTalkingRandomly;
  public bool rotateToSpeaker = true;
  private int delay;
  private int frame;
  private GameObject inventory;
  public static NPCActionController npcActionControl;

  private void Awake() => this.interactions = new List<ItemInteraction>();

  public void setFlippedL() => this.gameObject.GetComponent<SpriteRenderer>().flipX = true;

  public void setFlippedR() => this.gameObject.GetComponent<SpriteRenderer>().flipX = false;

  public int locationDialogue(int i, Vector3 color, string who)
  {
    string str1 = string.Empty;
    string name = SceneManager.GetActiveScene().name;
    Vector3 color_b = GingerActionController.getColor();
    TextFieldController component = GameObject.Find("Ginger").GetComponent<TextFieldController>();
    if (GameDataController.gd.getObjective("barry_base_family") && GameDataController.gd.getObjective("place_gas_station_barry") && GameDataController.gd.getObjective("place_restaurant_barry") && GameDataController.gd.getObjective("place_bhome_barry") && GameDataController.gd.getObjective("place_road_barry") && (GameDataController.gd.getObjective("place_bridge0_barry") || GameDataController.gd.getObjective("place_bridge1_barry") || GameDataController.gd.getObjective("place_bridge2_barry") || GameDataController.gd.getObjective("place_bridge3_barry")))
      GameDataController.Achievement("S_TOUR");
    if (name.IndexOf("Airplane") != -1)
      str1 = "airplane";
    if (name.IndexOf("LocationBus") != -1)
      str1 = "bus";
    if (name == "Location1" || name == "Location2" || name == "LocationAttic1" || name == "LocationAttic2" || name == "LocationBaseBathroom" || name == "LocationBaseUpstairs")
      str1 = "base";
    if (name == "LocationCrashsite1" || name == "LocationCrossroad")
      str1 = "road";
    if (name == "LocationBridge")
    {
      string str2 = "bridge";
      str1 = !GameDataController.gd.getObjective("bridge_planks_used_2") ? (!GameDataController.gd.getObjective("bridge_planks_used_1") ? str2 + "0" : str2 + "1") : str2 + "2";
    }
    if (name.IndexOf("LocationGasstation") != -1)
      str1 = "gas_station";
    if (name.IndexOf("LocationRestaurant") != -1)
      str1 = "restaurant";
    if (name.IndexOf("HuntersLodge") != -1)
      str1 = "hunters";
    if (name.IndexOf("HuntersLodge") != -1 && who == "cody" && GameDataController.gd.getObjectiveDetail("day_1_threat") == 2)
      str1 = "hunters2";
    if (name.IndexOf("LocationHouseB") != -1)
      str1 = "bhome";
    if (name.IndexOf("SiderealOutside") != -1)
      str1 = "sp_outside";
    else if (name.IndexOf("Sidereal") != -1 && name != "LocationSiderealRoof")
      str1 = "sp_inside";
    if (name.IndexOf("LocationOutpostOutside") != -1)
      str1 = "outpost1";
    else if (name.IndexOf("LocationOutpost") != -1)
      str1 = "outpost2";
    if (name == "LocationRV")
      str1 = "rv";
    if (name == "LocationRV2")
      str1 = "rv2";
    if (name == "LocationCave")
    {
      str1 = "cave";
      if (who == "cody")
      {
        component = GameObject.Find("Echo").GetComponent<TextFieldController>();
        component.setAlpha(0.5f);
        color_b = color;
      }
    }
    if (name == "MoonShip")
      str1 = "moon0";
    if (name == "Moon1" || name == "Moon2")
      str1 = "moon1";
    if (name.IndexOf("LocationMoonbase") != -1)
      str1 = "moon2";
    if (name == "CS1" && GameDataController.gd.getCurrentDay() == 3 && GameDataController.gd.getObjectiveDetail("day_3_threat") == 0)
      str1 = "construction2";
    else if (name == "CS2" || name == "CS3" || name == "CS4" || name == "CS5")
      str1 = "construction1";
    if (str1 == string.Empty)
      return i;
    this.takeDoc(i);
    this.doc.caption = GameStrings.getString(GameStrings.dialogues, "this_place");
    this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/location");
    this.doc.lines = new List<DialogueLine>();
    this.doc.setObjective("place_" + str1 + "_" + who);
    DialogueController.dc.initDialogue(this.doc.lines, "place_" + str1 + "_" + who, PlayerController.pc.textField, new Vector3(1f, 1f, 1f), component, color_b, this.textField, color);
    ++i;
    return i;
  }

  public int dayDialogue(int i, Vector3 color, string who)
  {
    string str1 = "d" + (object) GameDataController.gd.getCurrentDay();
    if (GameDataController.gd.getCurrentDay() > 4 || GameDataController.gd.getCurrentDay() < 2)
      return i;
    string str2 = string.Empty;
    if (GameDataController.gd.getCurrentDay() == 2)
    {
      if (GameDataController.gd.getObjectiveDetail("day_2_threat") == 0)
        str2 = "hot";
      if (GameDataController.gd.getObjectiveDetail("day_2_threat") == 1)
        str2 = "cold";
    }
    if (GameDataController.gd.getCurrentDay() == 3)
    {
      if (GameDataController.gd.getObjective("dialogue_ginger_reunited"))
      {
        if (GameDataController.gd.getObjectiveDetail("day_3_threat") == 0)
          str2 = "thugs";
        if (GameDataController.gd.getObjectiveDetail("day_3_threat") == 1)
          str2 = "storm";
      }
      else if (!GameDataController.gd.getObjective("sidereal_roof_collapsed"))
        str2 = "sidereal";
    }
    if (GameDataController.gd.getCurrentDay() == 4)
      str2 = "ship";
    if (str2 == string.Empty)
      return i;
    Vector3 color1 = GingerActionController.getColor();
    TextFieldController component = GameObject.Find("Ginger").GetComponent<TextFieldController>();
    this.takeDoc(i);
    this.doc.caption = GameStrings.getString(GameStrings.dialogues, "this_day");
    this.doc.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Dialogues/day");
    this.doc.lines = new List<DialogueLine>();
    this.doc.setObjective(str1 + "_" + str2 + "_" + who);
    DialogueController.dc.initDialogue(this.doc.lines, str1 + "_" + str2 + "_" + who, PlayerController.pc.textField, new Vector3(1f, 1f, 1f), component, color1, this.textField, color);
    ++i;
    return i;
  }

  public void decideRandomTopic()
  {
    this.randomLines = new List<DialogueLine>();
    string prefix = string.Empty;
    if (SceneManager.GetActiveScene().name == "LocationSiderealRoof" && GameDataController.gd.getObjective("sidereal_roof_collapsed") && GameDataController.gd.getObjective("sidereal_roof_wait_for_rescue"))
      prefix = !GameDataController.gd.getObjective("npc3_joined") || !GameDataController.gd.getObjective("npc3_alive") || !GameDataController.gd.getObjective("npc2_joined") || !GameDataController.gd.getObjective("npc2_alive") ? (GameDataController.gd.getObjective("npc3_joined") && GameDataController.gd.getObjective("npc3_alive") || !GameDataController.gd.getObjective("npc2_joined") || !GameDataController.gd.getObjective("npc2_alive") ? (!GameDataController.gd.getObjective("npc3_joined") || !GameDataController.gd.getObjective("npc3_alive") || GameDataController.gd.getObjective("npc2_joined") && GameDataController.gd.getObjective("npc2_alive") ? string.Empty : "chitchat_help_cody_01") : "chitchat_help_barry_01") : "chitchat_help_barry_cody_01";
    else if (GameDataController.gd.getCurrentDay() < 5)
    {
      string str1 = "chitchat";
      Scene activeScene = SceneManager.GetActiveScene();
      string id;
      if (activeScene.name != "LocationSiderealRoof")
      {
        activeScene = SceneManager.GetActiveScene();
        if ((activeScene.name != "LocationRestaurant5" || GameDataController.gd.getCurrentDay() > 2) && GameDataController.gd.getObjective("npc3_joined") && GameDataController.gd.getObjective("npc2_joined") && GameDataController.gd.getObjective("npc3_alive") && GameDataController.gd.getObjective("npc2_alive") && !GameDataController.gd.getObjective("barry_warned") && !GameDataController.gd.getObjective("cody_warned"))
        {
          float num = Random.Range(0.0f, 1f);
          id = (double) num >= 0.200000002980232 ? ((double) num >= 0.400000005960464 ? ((double) num >= 0.600000023841858 ? str1 + "_cate_cody_barry" : str1 + "_cate") : str1 + "_cate_barry") : str1 + "_cate_cody";
          goto label_19;
        }
      }
      activeScene = SceneManager.GetActiveScene();
      if (activeScene.name != "LocationSiderealRoof")
      {
        activeScene = SceneManager.GetActiveScene();
        if ((activeScene.name != "LocationRestaurant5" || GameDataController.gd.getCurrentDay() > 2) && GameDataController.gd.getObjective("npc3_joined") && GameDataController.gd.getObjective("npc2_joined") && GameDataController.gd.getObjective("npc3_alive") && !GameDataController.gd.getObjective("npc2_alive"))
        {
          float num = Random.Range(0.0f, 1f);
          id = (double) num >= 0.300000011920929 ? ((double) num >= 0.600000023841858 ? str1 + "_cate_cody" : str1 + "_cate") : str1 + "_cate_cody_deadbarry";
          goto label_19;
        }
      }
      activeScene = SceneManager.GetActiveScene();
      if (activeScene.name != "LocationSiderealRoof")
      {
        activeScene = SceneManager.GetActiveScene();
        if ((activeScene.name != "LocationRestaurant5" || GameDataController.gd.getCurrentDay() > 2) && GameDataController.gd.getObjective("npc3_joined") && GameDataController.gd.getObjective("npc2_joined") && !GameDataController.gd.getObjective("npc3_alive") && GameDataController.gd.getObjective("npc2_alive"))
        {
          float num = Random.Range(0.0f, 1f);
          id = (double) num >= 0.300000011920929 ? ((double) num >= 0.600000023841858 ? str1 + "_cate_barry" : str1 + "_cate") : str1 + "_cate_barry_deadcody";
          goto label_19;
        }
      }
      activeScene = SceneManager.GetActiveScene();
      if (activeScene.name != "LocationSiderealRoof")
      {
        activeScene = SceneManager.GetActiveScene();
        if ((activeScene.name != "LocationRestaurant5" || GameDataController.gd.getCurrentDay() > 2) && GameDataController.gd.getObjective("npc3_joined") && GameDataController.gd.getObjective("npc3_alive") && !GameDataController.gd.getObjective("cody_warned"))
        {
          id = (double) Random.Range(0.0f, 1f) >= 0.5 ? str1 + "_cate_cody" : str1 + "_cate";
          goto label_19;
        }
      }
      activeScene = SceneManager.GetActiveScene();
      if (activeScene.name != "LocationSiderealRoof")
      {
        activeScene = SceneManager.GetActiveScene();
        if ((activeScene.name != "LocationRestaurant5" || GameDataController.gd.getCurrentDay() > 2) && GameDataController.gd.getObjective("npc2_joined") && GameDataController.gd.getObjective("npc2_alive") && !GameDataController.gd.getObjective("barry_warned"))
        {
          id = (double) Random.Range(0.0f, 1f) >= 0.5 ? str1 + "_cate_barry" : str1 + "_cate";
          goto label_19;
        }
      }
      id = str1 + "_cate";
label_19:
      int objectiveDetail = GameDataController.gd.getObjectiveDetail(id);
      string str2 = objectiveDetail.ToString().Substring(0, 1);
      MonoBehaviour.print((object) ("WYBIERAM TEMAT..... " + id + " ........... " + str2));
      objectiveDetail = GameDataController.gd.getObjectiveDetail(id);
      if (objectiveDetail.ToString().Length > 1)
      {
        objectiveDetail = GameDataController.gd.getObjectiveDetail(id);
        string s = objectiveDetail.ToString().Substring(1) + str2;
        MonoBehaviour.print((object) ("NEW STRING TO " + s));
        GameDataController.gd.setObjectiveDetail(id, int.Parse(s));
      }
      prefix = id + str2;
      if (GameDataController.gd.getObjective("previous_disc_barry") || GameDataController.gd.getObjective("previous_disc_cody"))
      {
        if (prefix == "chitchat_cate_cody4")
          prefix = "chitchat_2_cate_cody4";
        if (prefix == "chitchat_cate_cody_barry5")
          prefix = "chitchat_2_cate_cody_barry5";
        if (prefix == "chitchat_cate_cody_barry4")
          prefix = "chitchat_2_cate_cody_barry4";
        if (prefix == "chitchat_cate_cody1")
          prefix = "chitchat_2_cate_cody1";
      }
    }
    if (prefix == string.Empty)
      return;
    DialogueController.dc.initDialogue(this.randomLines, prefix, GameObject.Find("Ginger").GetComponent<TextFieldController>(), GingerActionController.getColor(), GameObject.Find("Npc2").GetComponent<TextFieldController>(), Npc2Controller.getColor(), GameObject.Find("Npc3").GetComponent<TextFieldController>(), Npc3Controller.getColor());
  }

  public void randomLinesTalkOrNot(bool force = false)
  {
    if (PlayerController.wc.busy || CursorController.cc.getCurrentState() == CursorController.PixelCursor.OK)
      return;
    if (!force)
    {
      Scene activeScene = SceneManager.GetActiveScene();
      if (!(activeScene.name == "LocationSiderealRoof"))
      {
        activeScene = SceneManager.GetActiveScene();
        if (!(activeScene.name == "LocationOutpostOutside2") && !PlayerController.wc.busy && !GameObject.Find("Ginger").GetComponent<NPCActionController>().busyTalkingRandomly && !GameObject.Find("Npc2").GetComponent<NPCActionController>().busyTalkingRandomly && !GameObject.Find("Npc3").GetComponent<NPCActionController>().busyTalkingRandomly && this.gameObject.GetComponent<NPCWalkController>().spawned)
          goto label_6;
      }
      MonoBehaviour.print((object) "RANDOM LINES force == false && busyTalkingRandomly");
      return;
    }
label_6:
    if (InventoryButtonController.ibc.isItOpen() || this.busyTalkingRandomly)
      return;
    this.randomLinesProbab = (float) GameDataController.gd.getObjectiveDetail("chitchat") / 100f;
    GameDataController.gd.setObjectiveDetail("chitchat", GameDataController.gd.getObjectiveDetail("chitchat") + 2);
    MonoBehaviour.print((object) ("randomLinesProbab = " + (object) this.randomLinesProbab));
    if (this.busyTalkingRandomly || !force && (double) Random.Range(0.0f, 1f) > (double) this.randomLinesProbab)
      return;
    GameDataController.gd.setObjectiveDetail("chitchat", -25);
    this.busyTalkingRandomly = true;
    this.decideRandomTopic();
    MonoBehaviour.print((object) ("TALK  " + (object) this.randomLines.Count));
    if (this.randomLines == null || this.randomLines.Count <= 0)
      return;
    this.randomLines[this.randomLines.Count - 1].action = new TimelineFunction(this.makeNotBusy);
    for (int index = 0; index < this.randomLines.Count; ++index)
    {
      this.randomLines[index].time = Random.Range(0.1f, 1.5f);
      Timeline.t.addDialogue(this.randomLines[index], (float) (1.0 + (double) this.randomLines[index].text.Length * 0.0750000029802322));
    }
  }

  private void makeNotBusy(string v = "") => this.busyTalkingRandomly = false;

  public void init(Item item) => this.updateState();

  private void Update()
  {
    if (!this.needUpdate)
      return;
    this.needUpdate = false;
    this.updateState();
  }

  public void takeDoc(int i) => this.doc = DialogueController.dc.dialogueOptions[i].GetComponent<DialogueOptionController>();

  private void OnEnable() => this.needUpdate = true;

  private void Start()
  {
    this.textField = this.gameObject.GetComponent<TextFieldController>();
    this.colliderManager.setTarget(this.gameObject);
    this.dkvs = GameStrings.objects;
    this.animationFlip = false;
    this.characterAnimationName = "action_stnd_";
    if (GameDataController.gd.getObjective("moon_suited_up"))
      this.characterAnimationName = "suit_action_stnd_";
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    Sprite sprite = this.gameObject.GetComponent<SpriteRenderer>().sprite;
    BoxCollider2D component = this.gameObject.GetComponent<BoxCollider2D>();
    Vector2 size = (Vector2) this.gameObject.GetComponent<SpriteRenderer>().bounds.size;
    Vector2 vector2 = new Vector2((float) (-(double) size.x * (0.5 - (double) sprite.pivot.x / (double) sprite.rect.width)), (float) ((double) size.y / 2.0 - (double) size.y * ((double) sprite.pivot.y / (double) sprite.rect.height)));
    component.offset = vector2;
    this.continueStart();
  }

  public override void whatOnClick()
  {
  }

  public override void clickAction()
  {
    Timeline.t.stopChitChat();
    if ((Object) GameObject.Find("Ginger") != (Object) null)
      GameObject.Find("Ginger").GetComponent<NPCActionController>().busyTalkingRandomly = false;
    if (this.rotateToSpeaker)
    {
      if ((double) PlayerController.wc.currentXY.x >= (double) this.gameObject.GetComponent<NPCWalkController>().currentXY.x)
      {
        if ((double) PlayerController.wc.currentXY.y >= (double) this.gameObject.GetComponent<NPCWalkController>().currentXY.y)
          this.gameObject.GetComponent<NPCWalkController>().dir = NPCWalkController.Direction.SE;
        else
          this.gameObject.GetComponent<NPCWalkController>().dir = NPCWalkController.Direction.NE;
        this.gameObject.GetComponent<SpriteRenderer>().flipX = false;
      }
      else
      {
        if ((double) PlayerController.wc.currentXY.y >= (double) this.gameObject.GetComponent<NPCWalkController>().currentXY.y)
          this.gameObject.GetComponent<NPCWalkController>().dir = NPCWalkController.Direction.SW;
        else
          this.gameObject.GetComponent<NPCWalkController>().dir = NPCWalkController.Direction.NW;
        this.gameObject.GetComponent<SpriteRenderer>().flipX = true;
      }
    }
    string str = "stand_";
    if (PlayerController.wc.suit)
      str = "suit_" + str;
    string name;
    if ((double) PlayerController.wc.currentXY.x <= (double) this.gameObject.GetComponent<NPCWalkController>().currentXY.x)
    {
      if ((double) PlayerController.wc.currentXY.y >= (double) this.gameObject.GetComponent<NPCWalkController>().currentXY.y)
      {
        PlayerController.wc.dir = WalkController.Direction.SE;
        name = str + "se";
      }
      else
      {
        PlayerController.wc.dir = WalkController.Direction.NE;
        name = str + "ne";
      }
      PlayerController.wc.gameObject.GetComponent<SpriteRenderer>().flipX = false;
    }
    else
    {
      if ((double) PlayerController.wc.currentXY.y >= (double) this.gameObject.GetComponent<NPCWalkController>().currentXY.y)
      {
        PlayerController.wc.dir = WalkController.Direction.SW;
        name = str + "se";
      }
      else
      {
        PlayerController.wc.dir = WalkController.Direction.NW;
        name = str + "ne";
      }
      PlayerController.wc.gameObject.GetComponent<SpriteRenderer>().flipX = true;
    }
    MonoBehaviour.print((object) ("ROTATING TO SPEAKER: " + name));
    PlayerController.wc.forceAnimation(name, PlayerController.wc.gameObject.GetComponent<SpriteRenderer>().flipX);
    this.npcClickAction(this.usedItem);
  }

  public void endTalk(string val = "")
  {
    DialogueController.dc.talking = false;
    DialogueController.dc.hide();
    this.updateState();
  }

  public virtual void npcClickAction(string item = "")
  {
  }

  public virtual void continueStart()
  {
  }

  public override void clickAction2()
  {
  }

  public override void updateState()
  {
  }

  public override void clickAction0()
  {
  }
}

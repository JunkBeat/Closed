// Decompiled with JetBrains decompiler
// Type: Napisy
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


using UnityEngine;

public class Napisy : MonoBehaviour
{
  private void Start()
  {
  }

  private void Update()
  {
  }

  public void showNapisyS(string s = "")
  {
    if (GameDataController.persistentData == null)
    {
      GameDataController.persistentData = new PersistentData();
      GameDataController.gd.initPersistantAchieves();
    }
    if (GameDataController.gd.getObjectiveDetail("day_1_threat") == 0)
      GameDataController.persistentData.chapter1_locust = true;
    if (GameDataController.gd.getObjectiveDetail("day_1_threat") == 1)
      GameDataController.persistentData.chapter1_gas = true;
    if (GameDataController.gd.getObjectiveDetail("day_1_threat") == 2)
      GameDataController.persistentData.chapter1_spiders = true;
    if (GameDataController.gd.getObjectiveDetail("day_2_threat") == 0)
      GameDataController.persistentData.chapter2_hot = true;
    if (GameDataController.gd.getObjectiveDetail("day_2_threat") == 1)
      GameDataController.persistentData.chapter2_cold = true;
    if (GameDataController.gd.getObjectiveDetail("day_3_threat") == 0)
      GameDataController.persistentData.chapter3_bandits = true;
    if (GameDataController.gd.getObjectiveDetail("day_3_threat") == 1)
      GameDataController.persistentData.chapter3_thunderstorm = true;
    if (GameDataController.gd.getObjectiveDetail("day_4_threat") == 0)
      GameDataController.persistentData.chapter4_air = true;
    if (GameDataController.gd.getObjectiveDetail("day_4_threat") == 1)
      GameDataController.persistentData.chapter4_fuel = true;
    GameDataController.persistentData.disc_barry = GameDataController.gd.getObjective("moon_disc1_used");
    GameDataController.persistentData.disc_cody = GameDataController.gd.getObjective("moon_disc2_used");
    GameDataController.gd.PersistentSave();
    this.Invoke("showNapisy1", 3f);
  }

  public void showNapisy1()
  {
    JukeboxAmbient.jb.changeAmbient((AudioClip) null, 0.0f);
    GameObject.Find("credits1").GetComponent<EndCredits>().showDontEscape();
    this.Invoke("showNapisy2", 6f);
  }

  public void showNapisy2()
  {
    GameObject.Find("credits1").GetComponent<EndCredits>().showBlack();
    this.Invoke("showNapisy3", 1f);
  }

  private void showNapisy3()
  {
    GameObject.Find("credits2").GetComponent<TextFieldController>().viewText(GameStrings.getString(GameStrings.gui, "credits_1"), quick: true, instant: true, mwidth: 240, ba: 0.0f);
    GameObject.Find("credits2").GetComponent<TextFieldController>().setTime(6f);
    this.Invoke("showNapisy4", 7f);
  }

  private void showNapisy4()
  {
    GameObject.Find("credits2").GetComponent<TextFieldController>().viewText(GameStrings.getString(GameStrings.gui, "credits_2"), quick: true, instant: true, mwidth: 240, ba: 0.0f);
    GameObject.Find("credits2").GetComponent<TextFieldController>().setTime(6f);
    this.Invoke("showNapisy5", 7f);
  }

  private void showNapisy5()
  {
    GameObject.Find("credits2").GetComponent<TextFieldController>().viewText(GameStrings.getString(GameStrings.gui, "credits_3"), quick: true, instant: true, mwidth: 240, ba: 0.0f);
    GameObject.Find("credits2").GetComponent<TextFieldController>().setTime(6f);
    this.Invoke("showNapisy6", 7f);
  }

  private void showNapisy6()
  {
    GameObject.Find("credits2").GetComponent<TextFieldController>().viewText(GameStrings.getString(GameStrings.gui, "credits_4"), quick: true, instant: true, mwidth: 240, ba: 0.0f);
    GameObject.Find("credits2").GetComponent<TextFieldController>().setTime(6f);
    this.Invoke("showNapisy7", 7f);
  }

  private void showNapisy7()
  {
    GameObject.Find("credits2").GetComponent<TextFieldController>().viewText(GameStrings.getString(GameStrings.gui, "credits_5"), quick: true, instant: true, mwidth: 240, ba: 0.0f);
    GameObject.Find("credits2").GetComponent<TextFieldController>().setTime(11f);
    this.Invoke("showNapisy8", 12f);
  }

  private void showNapisy8()
  {
    GameObject.Find("credits2").GetComponent<TextFieldController>().viewText(GameStrings.getString(GameStrings.gui, "credits_6"), quick: true, instant: true, mwidth: 240, ba: 0.0f);
    GameObject.Find("credits2").GetComponent<TextFieldController>().setTime(11f);
    this.Invoke("showNapisy9", 12f);
  }

  private void showNapisy9()
  {
    GameObject.Find("credits2").GetComponent<TextFieldController>().viewText(GameStrings.getString(GameStrings.gui, "credits_7"), quick: true, instant: true, mwidth: 240, ba: 0.0f);
    GameObject.Find("credits2").GetComponent<TextFieldController>().setTime(7f);
    this.Invoke("showNapisy12", 8f);
  }

  private void showNapisy10()
  {
    GameObject.Find("credits2").GetComponent<TextFieldController>().viewText(GameStrings.getString(GameStrings.gui, "credits_8"), quick: true, instant: true, mwidth: 240, ba: 0.0f);
    GameObject.Find("credits2").GetComponent<TextFieldController>().setTime(7f);
    this.Invoke("showNapisy11", 8f);
  }

  private void showNapisy11()
  {
    GameObject.Find("credits2").GetComponent<TextFieldController>().viewText(GameStrings.getString(GameStrings.gui, "credits_9"), quick: true, instant: true, mwidth: 240, ba: 0.0f);
    GameObject.Find("credits2").GetComponent<TextFieldController>().setTime(7f);
    this.Invoke("showNapisy12", 8f);
  }

  private void showNapisy12()
  {
    PlayerController.wc.fullStop();
    PlayerController.pc.spawnName = "InfoExit";
    CurtainController.cc.fadeOut("MainMenu", WalkController.Direction.S, "action_stnd_s", tSpeed: CurtainController.MENU_CURTAIN_SPEED);
  }
}

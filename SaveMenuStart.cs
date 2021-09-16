// Decompiled with JetBrains decompiler
// Type: SaveMenuStart
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


using System.Globalization;
using System.Threading;
using UnityEngine;

public class SaveMenuStart : MonoBehaviour
{
  private void Start()
  {
    PlayerController.wc.shadow.fadeRateV = 0.0f;
    PlayerController.wc.shadow.fadeRateH = 0.0f;
    PlayerController.wc.shadowOffsetY = 0;
    PlayerController.wc.shadow.skewFactor = 0.0f;
    PlayerController.wc.shadow.skewFactor2 = -5f;
    PlayerController.wc.shadow.startAlpha = 0.0f;
    PlayerController.wc.shadow.source = 10f;
    PlayerController.ssg.setStepType("none");
    PlayerController.pc.copySettingsToNPCs();
    MonoBehaviour.print((object) "............................. LOCATION INFO  ..................................");
    Vector2 screen = ScreenControler.gameToScreen(new Vector2(-999f, -999f));
    Vector3 worldPoint = Camera.main.ScreenToWorldPoint(new Vector3(screen.x, screen.y, 0.0f));
    worldPoint.z = -3f;
    InventoryButtonController.ibc.gameObject.transform.position = worldPoint;
    string text;
    if (GameDataController.wantSave)
    {
      text = GameStrings.getString(GameStrings.gui, "save_select");
      GameObject.Find("Location").transform.Find("save_back").GetComponent<SpriteRenderer>().enabled = true;
      GameObject.Find("Location").transform.Find("load_back").GetComponent<SpriteRenderer>().enabled = false;
    }
    else
    {
      text = GameStrings.getString(GameStrings.gui, "load_select");
      GameObject.Find("Location").transform.Find("save_back").GetComponent<SpriteRenderer>().enabled = false;
      GameObject.Find("Location").transform.Find("load_back").GetComponent<SpriteRenderer>().enabled = true;
    }
    GameObject.Find("Caption_MenuName").transform.position = ScreenControler.roundToNearestFullPixel2(GameObject.Find("Caption_MenuName").transform.position);
    GameObject.Find("Caption_SlotName").transform.position = ScreenControler.roundToNearestFullPixel2(GameObject.Find("Caption_SlotName").transform.position);
    GameObject.Find("Caption_SlotDay").transform.position = ScreenControler.roundToNearestFullPixel2(GameObject.Find("Caption_SlotDay").transform.position);
    GameObject.Find("Caption_SlotDate").transform.position = ScreenControler.roundToNearestFullPixel2(GameObject.Find("Caption_SlotDate").transform.position);
    GameObject.Find("Caption_MenuName").GetComponent<TextFieldController>().viewText(text, quick: true, instant: true, mwidth: 200, ba: 0.0f);
    GameObject.Find("Caption_MenuName").GetComponent<TextFieldController>().keepAlive = true;
    Button component = GameObject.Find("ContinueBtn").GetComponent<Button>();
    component.initButton("[" + GameStrings.getString(GameStrings.gui, "back") + "]");
    component.buttonText.OPTIONAL_MARGIN = 6;
    component.workIfBusy = false;
    component.onClick = new Button.Delegate(this.continueGame);
    GameObject.Find("Location").GetComponent<LocationManager>().escButton = component;
    if (PlayerPrefs.GetString("lang", GameStrings.Language.EN.ToString()) == GameStrings.Language.PL.ToString())
      Thread.CurrentThread.CurrentCulture = new CultureInfo("de-DE");
    else
      Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
  }

  private void continueGame()
  {
    PlayerController.pc.spawnName = "InfoExit";
    PlayerController.wc.fullStop();
    if (GameDataController.gd.previousLocation == "MainMenu")
      CurtainController.cc.fadeOut("MainMenu", WalkController.Direction.S, "action_stnd_s", tSpeed: CurtainController.MENU_CURTAIN_SPEED);
    else
      CurtainController.cc.fadeOut("PauseMenu", WalkController.Direction.S, "action_stnd_s", tSpeed: CurtainController.MENU_CURTAIN_SPEED);
  }

  private void Update()
  {
  }
}

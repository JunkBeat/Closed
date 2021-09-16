// Decompiled with JetBrains decompiler
// Type: CreditsStart
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\Don't Escape 4 Days in a Wasteland\dontescape_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class CreditsStart : MonoBehaviour
{
  public int skipit = 1;
  public float timer;

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
    Button component = GameObject.Find("ContinueBtn").GetComponent<Button>();
    component.buttonEnabled = false;
    component.gameObject.GetComponent<TextFieldController>().OPTIONAL_MARGIN = 6;
    GameObject.Find("LocationManager").GetComponent<Napisy>().showNapisy2();
  }

  private void mainMenu()
  {
    PlayerController.wc.fullStop();
    PlayerController.pc.spawnName = "InfoExit";
    CurtainController.cc.fadeOut("MainMenu", WalkController.Direction.S, "action_stnd_s", tSpeed: CurtainController.MENU_CURTAIN_SPEED);
  }

  public void showButton()
  {
    Button component = GameObject.Find("ContinueBtn").GetComponent<Button>();
    component.initButton("[" + GameStrings.getString(GameStrings.gui, "back") + "]");
    component.workIfBusy = true;
    component.onClick = new Button.Delegate(this.mainMenu);
    component.buttonText.OPTIONAL_MARGIN = 6;
    component.enabled = true;
    component.buttonEnabled = true;
  }

  private void Update()
  {
    if (this.skipit == 2)
    {
      this.timer += Time.deltaTime;
      if ((double) this.timer > 3.0)
      {
        this.timer = 0.0f;
        this.skipit = 1;
        Button component = GameObject.Find("ContinueBtn").GetComponent<Button>();
        component.initButton(" ");
        component.workIfBusy = false;
        component.onClick = (Button.Delegate) null;
        component.buttonEnabled = false;
      }
    }
    if (!Input.GetMouseButtonDown(0) && !Input.GetKeyDown(KeyCode.Escape) || this.skipit != 1)
      return;
    this.skipit = 2;
    this.showButton();
  }
}

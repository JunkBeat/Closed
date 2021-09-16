// Decompiled with JetBrains decompiler
// Type: DemoStartController
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\Don't Escape 4 Days in a Wasteland\dontescape_Data\Managed\Assembly-CSharp.dll

using UnityEngine;
using UnityEngine.SceneManagement;

public class DemoStartController : MonoBehaviour
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
    MonoBehaviour.print((object) "............................. LOCATION INFO  ..................................");
    Vector2 screen = ScreenControler.gameToScreen(new Vector2(-999f, -999f));
    Vector3 worldPoint = Camera.main.ScreenToWorldPoint(new Vector3(screen.x, screen.y, 0.0f));
    worldPoint.z = -3f;
    InventoryButtonController.ibc.gameObject.transform.position = worldPoint;
    GameObject.Find("inventory_button").GetComponent<InventoryButtonController>().hide();
    GameObject.Find("journal").GetComponent<JournalButtonController>().hide();
    this.Invoke("launch", 1f);
  }

  private void launch() => QuestionController.qc.showQuestion("^Don't Escape: 4 Days in a Wasteland ^^ARMOR GAMES DEMO. ^^This demo contains chapters 1 and 2.", yesClick: new Button.Delegate(this.yesClick), noClick: new Button.Delegate(this.noClick), customYesLabel: "Start Game / Continue", customNoLabel: "Options");

  private void yesClick()
  {
  }

  private void newGame(string param)
  {
    PlayerController.pc.spawnName = "InfoExit";
    CurtainController.cc.fadeOut("LocationDreamBugs", WalkController.Direction.N);
  }

  private void noClick()
  {
    PlayerController.wc.fullStop(true);
    if ((double) PlayerController.wc.speed != 0.0)
      PlayerController.wc.forceAnimation("stand_", useCurrentDir: true);
    PlayerController.pc.spawnName = "InfoExit";
    GameDataController.gd.previousLocation = SceneManager.GetActiveScene().name;
    GameDataController.gd.previousX = (int) PlayerController.wc.currentXY.x;
    GameDataController.gd.previousY = (int) PlayerController.wc.currentXY.y;
    CurtainController.cc.fadeOut("PauseMenu", tSpeed: 1f);
    AudioListener.pause = true;
  }

  private void Update()
  {
  }
}

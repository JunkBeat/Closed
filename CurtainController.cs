// Decompiled with JetBrains decompiler
// Type: CurtainController
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\Don't Escape 4 Days in a Wasteland\dontescape_Data\Managed\Assembly-CSharp.dll

using UnityEngine;
using UnityEngine.SceneManagement;

public class CurtainController : MonoBehaviour
{
  private float alpha = 1f;
  public float targetAlpha = 1f;
  private float speed = 0.025f;
  private int delayer;
  private float timeout;
  public static float NORMAL_CURTAIN_SPEED = 0.05f;
  public static float MENU_CURTAIN_SPEED = 0.15f;
  public static CurtainController cc;
  public CurtainController.Delegate onSceneChange;
  public string targetLocaiton = string.Empty;
  private string nextSceneStartAnimation;
  private bool nextSceneStartAnimatioFlip;
  private AudioClip nextSceneStartSound;
  private WalkController.Direction targetWalkDir;
  private LocationManager currentLocationManager;
  private SpriteRenderer sr;

  private void Awake()
  {
    if ((Object) CurtainController.cc == (Object) null)
    {
      Object.DontDestroyOnLoad((Object) this.gameObject);
      CurtainController.cc = this;
      MonoBehaviour.print((object) "Curtain controler initialized");
    }
    else
    {
      if (!((Object) CurtainController.cc != (Object) this))
        return;
      Object.Destroy((Object) this.gameObject);
    }
  }

  private void Start()
  {
    this.sr = this.gameObject.GetComponent<SpriteRenderer>();
    this.targetLocaiton = string.Empty;
    this.transform.position = new Vector3(0.0f, 0.0f, -8f);
    this.fadeIn();
  }

  public float getAlpha() => this.alpha;

  public bool okToGo() => (double) this.alpha < 0.5 && (double) this.targetAlpha <= 0.0;

  private void loadAfterWhile()
  {
    GameDataController.gd.tryLoad(this.nextSceneStartAnimation, true);
    this.nextSceneStartAnimation = (string) null;
  }

  private void updatePreviousLocation()
  {
    string name = SceneManager.GetActiveScene().name;
    if (!(name != "PauseMenu") || !(name != "SaveMenu") || !(name != "LoadMenu"))
      return;
    GameDataController.gd.previousLocation = name;
  }

  private void Update()
  {
    if ((double) Mathf.Abs(this.alpha - this.targetAlpha) <= (double) this.speed && (double) this.alpha != (double) this.targetAlpha)
      this.alpha = this.targetAlpha;
    else if ((double) this.alpha == (double) this.targetAlpha)
    {
      if (this.targetLocaiton == "LOAD")
      {
        this.targetLocaiton = string.Empty;
        this.Invoke("loadAfterWhile", 0.1f);
      }
      else if (this.targetLocaiton != string.Empty)
      {
        if (this.targetLocaiton.Equals("none"))
        {
          ((ObjectActionController) Object.FindObjectsOfType(typeof (ObjectActionController))[0]).updateAll();
          this.fadeIn();
        }
        else
        {
          GameObject.Find("BottomText").GetComponent<TextFieldController>().transform.parent = (Transform) null;
          this.updatePreviousLocation();
          this.loadScene(this.targetLocaiton);
        }
      }
    }
    if (this.delayer > 0)
    {
      --this.delayer;
    }
    else
    {
      if ((double) this.alpha > (double) this.targetAlpha)
        this.alpha -= (float) ((double) this.speed * (double) Time.deltaTime * 60.0);
      if ((double) this.alpha < (double) this.targetAlpha)
        this.alpha += (float) ((double) this.speed * (double) Time.deltaTime * 60.0);
      this.timeout += Time.deltaTime;
      if ((double) this.timeout > 7.0)
      {
        this.alpha = this.targetAlpha;
        this.timeout = 0.0f;
      }
    }
    this.sr.color = new Color(0.0f, 0.0f, 0.0f, this.alpha);
  }

  public void loadScene(string name)
  {
    this.targetLocaiton = name;
    SceneManager.LoadScene(this.targetLocaiton);
    this.targetLocaiton = string.Empty;
  }

  private void OnLevelWasLoaded(int level)
  {
    if (!((Object) this == (Object) CurtainController.cc))
      return;
    this.currentLocationManager = (LocationManager) null;
    MonoBehaviour.print((object) "ON LEVEL WAS LOADED");
    if (this.onSceneChange == null && this.nextSceneStartAnimation == null)
      PlayerController.pc.setBusy(false);
    PlayerController.wc.fullStop();
    PlayerController.wc.dir = this.targetWalkDir;
    this.fadeIn();
  }

  public void fadeOut(
    string target = "none",
    WalkController.Direction targetDir = WalkController.Direction.NULL,
    string animation = null,
    AudioClip sound = null,
    bool flipX = false,
    CurtainController.Delegate actionAfterFade = null,
    float tSpeed = 0.05f)
  {
    this.timeout = 0.0f;
    if (target == "LocationMap")
      GameDataController.gd.autoSave();
    this.speed = tSpeed;
    PlayerController.pc.setBusy(true);
    this.targetAlpha = 1f;
    this.onSceneChange = actionAfterFade;
    this.targetLocaiton = target;
    this.nextSceneStartAnimation = animation;
    this.nextSceneStartAnimatioFlip = flipX;
    this.nextSceneStartSound = sound;
    this.targetWalkDir = PlayerController.wc.dir;
    if (!targetDir.Equals((object) WalkController.Direction.NULL))
      this.targetWalkDir = targetDir;
    PlayerController.pc.setBusy(true);
  }

  public static void fixCameraRect()
  {
    float num1 = (float) Screen.width / (float) Screen.height / 1.777778f;
    Camera component = GameObject.Find("Main Camera").GetComponent<Camera>();
    GameObject gameObject = GameObject.Find("Main Camera(Clone)");
    Camera camera = (Camera) null;
    if ((bool) (Object) gameObject)
      camera = gameObject.GetComponent<Camera>();
    if ((double) num1 < 1.0)
    {
      Rect rect = component.rect;
      rect.width = 1f;
      rect.height = num1;
      rect.x = 0.0f;
      rect.y = (float) ((1.0 - (double) num1) / 2.0);
      component.rect = rect;
      if ((bool) (Object) camera)
        camera.rect = rect;
      ScreenControler.ratioHeight = rect.height;
      ScreenControler.ratioWidth = rect.width;
      ScreenControler.shiftRatioX = rect.x * (float) Screen.width;
      ScreenControler.shiftRatioY = rect.y * (float) Screen.height;
      ScreenControler.shiftX = rect.x;
      ScreenControler.shiftY = rect.y;
    }
    else
    {
      float num2 = 1f / num1;
      Rect rect = component.rect;
      rect.width = num2;
      rect.height = 1f;
      rect.x = (float) ((1.0 - (double) num2) / 2.0);
      rect.y = 0.0f;
      component.rect = rect;
      if ((bool) (Object) camera)
        camera.rect = rect;
      ScreenControler.ratioHeight = rect.height;
      ScreenControler.ratioWidth = rect.width;
      ScreenControler.shiftRatioX = rect.x * (float) Screen.width;
      ScreenControler.shiftRatioY = rect.y * (float) Screen.height;
      ScreenControler.shiftX = rect.x;
      ScreenControler.shiftY = rect.y;
    }
  }

  public void fadeIn()
  {
    InventoryButtonController.ibc.CancelInvoke();
    CurtainController.fixCameraRect();
    if (this.onSceneChange != null)
      this.onSceneChange();
    PlayerController.pc.npcShouldAppearRightOnSpot = false;
    if ((Object) PlayerController.pc != (Object) null && !this.targetLocaiton.Equals("none") && !PlayerController.pc.spawnName.Equals(string.Empty))
    {
      this.delayer = 0;
      if ((Object) this.currentLocationManager == (Object) null)
        this.currentLocationManager = GameObject.Find("Location").GetComponent<LocationManager>();
      if (!PlayerController.pc.spawnName.Equals("previous") && !PlayerController.pc.spawnName.Equals("InfoExit"))
        GameDataController.gd.usedSpawner = PlayerController.pc.spawnName;
      MonoBehaviour.print((object) ("Placing player in " + PlayerController.pc.spawnName));
      if (!PlayerController.pc.spawnName.Equals("previous"))
      {
        Vector2 nearestFullPixel = (Vector2) ScreenControler.roundToNearestFullPixel(GameObject.Find(PlayerController.pc.spawnName).transform.Find("LocationTransitioner").transform.position);
        PlayerController.wc.shadow.clearLastFrame();
        PlayerController.wc.currentXY.x = nearestFullPixel.x;
        PlayerController.wc.currentXY.y = nearestFullPixel.y;
        PlayerController.wc.clearTarget();
        MonoBehaviour.print((object) ("SPAWNING PLAYER at " + (object) PlayerController.wc.currentXY + " (" + (object) GameObject.Find(PlayerController.pc.spawnName).transform.Find("LocationTransitioner").transform.position + " "));
      }
      else
      {
        PlayerController.pc.npcShouldAppearRightOnSpot = true;
        MonoBehaviour.print((object) ("which is  " + (object) GameDataController.gd.previousX + " " + (object) GameDataController.gd.previousY));
        PlayerController.wc.currentXY.x = (float) GameDataController.gd.previousX;
        PlayerController.wc.currentXY.y = (float) GameDataController.gd.previousY;
        PlayerController.wc.clearTarget();
      }
    }
    else
    {
      this.delayer = 30;
      if (SceneManager.GetActiveScene().name != "MainMenu" && SceneManager.GetActiveScene().name != "FontSelector" && SceneManager.GetActiveScene().name != "LoadingScene")
      {
        for (int index1 = 0; index1 < ItemsManager.im.items.Count; ++index1)
        {
          if (ItemsManager.im.items[index1].dataRef.droppedLocation.Equals(SceneManager.GetActiveScene().name))
          {
            GroundItemController[] objectsOfType = Object.FindObjectsOfType<GroundItemController>();
            if (objectsOfType != null)
            {
              for (int index2 = 0; index2 < objectsOfType.Length; ++index2)
              {
                if (objectsOfType[index2].itemRef.dataRef.id == ItemsManager.im.items[index1].dataRef.id)
                {
                  Vector2 screen = ScreenControler.gameToScreen(new Vector2((float) ItemsManager.im.items[index1].dataRef.locX, (float) ItemsManager.im.items[index1].dataRef.locY));
                  Vector3 vector3 = new Vector3(screen.x, screen.y, 0.0f);
                  vector3 = Camera.main.ScreenToWorldPoint((Vector3) screen);
                  objectsOfType[index2].gameObject.transform.position = vector3;
                }
              }
            }
          }
        }
      }
      if ((Object) GameObject.Find("dusk") != (Object) null)
        GameObject.Find("dusk").GetComponent<DuskController>().manualUpdate();
    }
    this.alpha = 1f;
    this.targetAlpha = 0.0f;
    this.targetLocaiton = string.Empty;
    if (this.nextSceneStartAnimation != null)
    {
      PlayerController.wc.forceAnimation(this.nextSceneStartAnimation, this.nextSceneStartAnimatioFlip);
      PlayerController.pc.gameObject.GetComponent<Animator>().enabled = true;
      this.nextSceneStartAnimation = (string) null;
    }
    else
      PlayerController.pc.setBusy(false);
    if ((Object) this.nextSceneStartSound != (Object) null)
      PlayerController.pc.aS.PlayOneShot(this.nextSceneStartSound);
    PlayerController.wc.shadow.clearLastFrame();
  }

  public delegate void Delegate();
}

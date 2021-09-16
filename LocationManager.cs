// Decompiled with JetBrains decompiler
// Type: LocationManager
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LocationManager : MonoBehaviour
{
  private int pixelsW = 240;
  private int pixelsH = 135;
  private int nodesW = 48;
  private int nodesH = 27;
  public Node[,] nodes;
  private bool DEBUG;
  private LayerMask pathLayer;
  private LayerMask blockingLayer;
  public Node startNode;
  public Node endNode;
  private ClockController cc;
  public ObjectActionController esc;
  public Button escButton;
  public Button escButton2;
  public bool walkable = true;
  public bool suit;
  public bool needSpecialCamera = true;
  public GameObject MainCamera;
  public Camera MainCameraC;
  public GameObject UICamera;
  public float needShake;
  public float aaa;
  [Range(-5f, 50f)]
  public float factor;
  public bool showInventory = true;
  private bool itemsHighlighted;
  private Vector3 cameraMoved;
  private Rect previousCameraRect;
  public float thunderDelay;

  public void canPickUpItems()
  {
    foreach (GroundItemController groundItemController in UnityEngine.Object.FindObjectsOfType<GroundItemController>())
      groundItemController.enablePickup();
  }

  public void cantPickupItems()
  {
    foreach (GroundItemController groundItemController in UnityEngine.Object.FindObjectsOfType<GroundItemController>())
      groundItemController.disablePickup();
  }

  private void Start()
  {
    this.suit = GameDataController.gd.getObjective("moon_suited_up");
    PlayerController.wc.suit = this.suit;
    this.cameraMoved = new Vector3(0.0f, 0.01f, -20f);
    MonoBehaviour.print((object) "======== HELLO WORLD =============================================================================");
    this.pathLayer = (LayerMask) LayerMask.GetMask("hitTest");
    this.blockingLayer = (LayerMask) LayerMask.GetMask("obstacleLayer");
    ItemsManager.im.initGroundAndInv();
    PlayerController.pc.gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f);
    Vector2 screen = ScreenControler.gameToScreen(new Vector2(14f, 15f));
    Vector3 worldPoint = Camera.main.ScreenToWorldPoint(new Vector3(screen.x, screen.y, 0.0f));
    worldPoint.z = -3f;
    InventoryButtonController.ibc.gameObject.transform.position = worldPoint;
    Cursor.visible = false;
    CursorController.cc.showCursor(CursorController.PixelCursor.NORMAL);
    GameObject.Find("Main Camera").GetComponent<Camera>().backgroundColor = new Color(0.0f, 0.0f, 0.0f);
    this.MainCamera = GameObject.Find("Main Camera");
    this.MainCamera.GetComponent<Camera>().depth = 0.0f;
    this.MainCameraC = this.MainCamera.GetComponent<Camera>();
    if (this.needSpecialCamera)
    {
      this.UICamera = UnityEngine.Object.Instantiate<GameObject>(this.MainCamera, new Vector3(0.0f, 0.0f, -15f), Quaternion.identity);
      this.UICamera.GetComponent<Camera>().depth = 1f;
      this.UICamera.GetComponent<Camera>().cullingMask = 1 << LayerMask.NameToLayer("UI");
      this.UICamera.GetComponent<Camera>().cullingMask |= 1 << LayerMask.NameToLayer("cursor");
      this.UICamera.GetComponent<Camera>().cullingMask |= 1 << LayerMask.NameToLayer("gui");
      this.UICamera.GetComponent<Camera>().cullingMask |= 1 << LayerMask.NameToLayer("text");
      this.UICamera.GetComponent<Camera>().cullingMask |= 1 << LayerMask.NameToLayer("static");
      this.MainCamera.GetComponent<Camera>().cullingMask &= ~(1 << LayerMask.NameToLayer("UI"));
      this.MainCamera.GetComponent<Camera>().cullingMask &= ~(1 << LayerMask.NameToLayer("cursor"));
      this.MainCamera.GetComponent<Camera>().cullingMask &= ~(1 << LayerMask.NameToLayer("gui"));
      this.MainCamera.GetComponent<Camera>().cullingMask &= ~(1 << LayerMask.NameToLayer("text"));
      this.MainCamera.GetComponent<Camera>().cullingMask &= ~(1 << LayerMask.NameToLayer("static"));
      this.UICamera.GetComponent<AudioListener>().enabled = false;
      this.MainCamera.GetComponent<Camera>().clearFlags = CameraClearFlags.Color;
      this.MainCamera.GetComponent<Camera>().backgroundColor = new Color(0.0f, 0.0f, 0.0f);
      this.UICamera.GetComponent<Camera>().clearFlags = CameraClearFlags.Nothing;
      this.MainCamera.tag = "OriginalCamera";
    }
    CurtainController.fixCameraRect();
    this.previousCameraRect = new Rect(this.MainCameraC.rect.x, this.MainCameraC.rect.y, this.MainCameraC.rect.width, this.MainCameraC.rect.height);
    this.Invoke("checkResolution", 1f);
    PlayerController.pc.allowDrop = true;
    this.initNodes();
    if (SceneManager.GetActiveScene().name != "PauseMenu" && SceneManager.GetActiveScene().name != "SaveMenu")
      AudioListener.pause = false;
    this.Invoke("resetShadow", 0.25f);
    if (this.showInventory)
    {
      if ((UnityEngine.Object) InventoryButtonController.ibc != (UnityEngine.Object) null)
      {
        if (GameDataController.gd.getObjective("tent_backpack_taken"))
          InventoryButtonController.ibc.showFinal();
        else
          InventoryButtonController.ibc.hide();
      }
      if ((UnityEngine.Object) GameObject.Find("journal") != (UnityEngine.Object) null)
      {
        if (GameDataController.gd.getObjective("tent_distance_checked"))
        {
          GameObject.Find("journal").GetComponent<JournalButtonController>().showFinal();
          this.Invoke("blinkMaybe", 0.5f);
        }
        else
          GameObject.Find("journal").GetComponent<JournalButtonController>().hide();
      }
      if ((UnityEngine.Object) GameObject.Find("clock") != (UnityEngine.Object) null)
      {
        if (GameDataController.gd.getObjective("base_discovered"))
          GameObject.Find("clock").GetComponent<ClockController>().showFinal();
        else
          GameObject.Find("clock").GetComponent<ClockController>().hide();
      }
    }
    else
    {
      if ((UnityEngine.Object) InventoryButtonController.ibc != (UnityEngine.Object) null)
        InventoryButtonController.ibc.hide();
      if ((UnityEngine.Object) GameObject.Find("journal") != (UnityEngine.Object) null)
        GameObject.Find("journal").GetComponent<JournalButtonController>().hide();
      if ((UnityEngine.Object) GameObject.Find("clock") != (UnityEngine.Object) null)
        GameObject.Find("clock").GetComponent<ClockController>().hide();
    }
    InventoryController.ic.maxCapacity = 30;
    if (GameDataController.gd.getObjectiveDetail("day1_complete") == 1)
      InventoryController.ic.maxCapacity += 5;
    if (GameDataController.gd.getObjectiveDetail("day2_complete") == 1)
      InventoryController.ic.maxCapacity += 5;
    if (GameDataController.gd.getObjectiveDetail("day3_complete") == 1)
      InventoryController.ic.maxCapacity += 5;
    if (GameDataController.gd.getCurrentDay() == 3 && GameDataController.gd.getObjectiveDetail("day_3_threat") == 1 && GameDataController.gd.isOKtoSave("autosave") && (UnityEngine.Object) GameObject.Find("thunderstorm_generator") == (UnityEngine.Object) null)
    {
      GameObject gameObject = UnityEngine.Object.Instantiate(Resources.Load("Prefabs/thunderstorm_generator"), new Vector3(0.0f, 0.0f, -4.5f), new Quaternion()) as GameObject;
      gameObject.name = "thunderstorm_generator";
      gameObject.GetComponent<lightingblast>().initthis();
    }
    if (SceneManager.GetActiveScene().name != "LocationMap")
      GameDataController.gd.setObjective("car_travel", false);
    Timeline.t.stopChitChat();
  }

  private void checkResolution()
  {
    if (Screen.fullScreen && Screen.currentResolution.width != PlayerPrefs.GetInt("resolution"))
    {
      PlayerPrefs.SetInt("resolution", Screen.currentResolution.width);
      ScreenControler.setWindowedResolution(Screen.currentResolution.width);
      ScreenControler.setWindowedResolution((int) ScreenControler.allowedResolutions[ScreenControler.allowedResolutions.Length - 1].x);
      ScreenControler.setFullScreenResolution();
      CurtainController.fixCameraRect();
      this.Invoke("needFix", 0.5f);
    }
    this.Invoke(nameof (checkResolution), 1f);
  }

  private void needFix()
  {
    ScreenControler.setWindowedResolution((int) ScreenControler.allowedResolutions[ScreenControler.allowedResolutions.Length - 1].x);
    ScreenControler.setFullScreenResolution();
    CurtainController.fixCameraRect();
  }

  private void blinkMaybe() => JournalTexts.pickTexts(GameDataController.gd.getCurrentDay());

  private void Update()
  {
    if (this.showInventory)
    {
      if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.J))
      {
        MonoBehaviour.print((object) "SPACJA ");
        if (InventoryButtonController.ibc.gameObject.GetComponent<BoxCollider2D>().enabled)
          InventoryButtonController.ibc.fakeMouseClick(true);
      }
      if ((Input.GetKeyDown(KeyCode.I) || Input.GetKeyDown(KeyCode.RightControl)) && (UnityEngine.Object) GameObject.Find("journal") != (UnityEngine.Object) null && GameDataController.gd.getObjective("tent_distance_checked"))
        GameObject.Find("journal").GetComponent<JournalButtonController>().fakeClick();
    }
    if (Input.GetKey(KeyCode.LeftAlt) || Input.GetKey(KeyCode.RightAlt) || Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
      this.highlightItems(true);
    else if (this.itemsHighlighted)
      this.highlightItems(false);
    if ((UnityEngine.Object) this.esc != (UnityEngine.Object) null && (Input.GetKeyDown(KeyCode.I) || Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.RightControl)) && !PlayerController.wc.busy)
    {
      this.esc.fakeClick();
      this.esc = (ObjectActionController) null;
    }
    if ((UnityEngine.Object) this.escButton != (UnityEngine.Object) null && Input.GetKeyDown(KeyCode.Escape) && !PlayerController.wc.busy)
    {
      this.escButton.onClick();
      this.escButton = (Button) null;
    }
    if ((UnityEngine.Object) this.escButton2 != (UnityEngine.Object) null && Input.GetKeyDown(KeyCode.Escape) && this.escButton2.buttonEnabled)
    {
      this.escButton2.onClick();
      this.escButton2 = (Button) null;
    }
    if ((UnityEngine.Object) this.MainCamera == (UnityEngine.Object) null)
      this.MainCamera = GameObject.Find("Main Camera");
    if ((double) this.needShake <= 0.0)
    {
      this.MainCamera.transform.position = new Vector3(0.0f, 0.0f, -20f);
    }
    else
    {
      this.needShake -= Time.deltaTime;
      if ((double) this.aaa > 0.0)
      {
        this.aaa -= Time.deltaTime;
      }
      else
      {
        this.aaa = 0.03f;
        if ((UnityEngine.Object) this.MainCamera == (UnityEngine.Object) null)
          this.MainCamera = GameObject.Find("Main Camera");
        if ((double) this.MainCamera.transform.position.y != 0.0)
        {
          this.MainCamera.transform.position = new Vector3(0.0f, 0.0f, -20f);
        }
        else
        {
          this.MainCamera.transform.position = this.cameraMoved;
          TextFieldController.cameraShiftY = this.cameraMoved.y * 1f;
        }
      }
    }
  }

  public void highlightItems(bool show)
  {
    GroundItemController[] objectsOfType = UnityEngine.Object.FindObjectsOfType<GroundItemController>();
    this.itemsHighlighted = show;
    for (int index = 0; index < objectsOfType.Length; ++index)
      objectsOfType[index].frontView.enabled = show;
  }

  public void initNodes()
  {
    if (this.nodes != null)
    {
      for (int index1 = 0; index1 < this.nodesH; ++index1)
      {
        for (int index2 = 0; index2 < this.nodesW; ++index2)
          UnityEngine.Object.Destroy((UnityEngine.Object) this.nodes[index2, index1].gameObject);
      }
    }
    this.nodes = new Node[this.nodesW, this.nodesH];
    for (int index3 = 0; index3 < this.nodesH; ++index3)
    {
      for (int index4 = 0; index4 < this.nodesW; ++index4)
      {
        bool clear = true;
        this.nodes[index4, index3] = new Node(new Vector2((float) index4, (float) index3), new Vector2((float) (index4 * this.pixelsW / this.nodesW), (float) (index3 * this.pixelsH / this.nodesH)), clear);
        bool flag;
        if (!(bool) Physics2D.Linecast((Vector2) Camera.main.ScreenToWorldPoint((Vector3) ScreenControler.gameToScreen(this.nodes[index4, index3].GameLocation)), (Vector2) Camera.main.ScreenToWorldPoint((Vector3) ScreenControler.gameToScreen(this.nodes[index4, index3].GameLocation)), (int) this.pathLayer) || (bool) Physics2D.Linecast((Vector2) Camera.main.ScreenToWorldPoint((Vector3) ScreenControler.gameToScreen(this.nodes[index4, index3].GameLocation)), (Vector2) Camera.main.ScreenToWorldPoint((Vector3) ScreenControler.gameToScreen(this.nodes[index4, index3].GameLocation)), (int) this.blockingLayer))
        {
          flag = false;
          if (this.DEBUG)
            this.nodes[index4, index3].gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Misc/node_0");
          this.nodes[index4, index3].IsWalkable = false;
        }
        else
        {
          flag = true;
          if (this.DEBUG)
            this.nodes[index4, index3].gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Misc/node_1");
          this.nodes[index4, index3].IsWalkable = true;
        }
        Vector2 screen = ScreenControler.gameToScreen(new Vector2(this.nodes[index4, index3].GameLocation.x, this.nodes[index4, index3].GameLocation.y));
        Vector3 worldPoint = Camera.main.ScreenToWorldPoint(new Vector3(screen.x, screen.y, 0.0f));
        this.nodes[index4, index3].gameObject.transform.position = new Vector3(worldPoint.x, worldPoint.y, -5f);
      }
    }
  }

  private void OnMouseOver()
  {
  }

  public static float dist(Vector2 a, Vector2 b) => Mathf.Sqrt(Mathf.Pow(a.x - b.x, 2f) + Mathf.Pow(a.y - b.y, 2f));

  private bool Search(Node currentNode)
  {
    currentNode.State = NodeState.Closed;
    List<Node> adjacentWalkableNodes = this.GetAdjacentWalkableNodes(currentNode);
    adjacentWalkableNodes.Sort((Comparison<Node>) ((node1, node2) => node1.F.CompareTo(node2.F)));
    foreach (Node currentNode1 in adjacentWalkableNodes)
    {
      if (currentNode1.Location == this.endNode.Location)
      {
        MonoBehaviour.print((object) "ZNALEZIONO CEL ");
        return true;
      }
      if (this.Search(currentNode1))
        return true;
    }
    return false;
  }

  public void resetShadow() => PlayerController.wc.shadow.clearLastFrame();

  public Vector2 getNodeLocation(Vector2 sourceLocation)
  {
    Vector2 vector2 = new Vector2();
    vector2.x = Mathf.Floor(sourceLocation.x * (float) this.nodesW / (float) this.pixelsW);
    vector2.y = Mathf.Floor(sourceLocation.y * (float) this.nodesH / (float) this.pixelsH);
    if ((double) vector2.x <= 0.0)
      vector2.x = 0.0f;
    if ((double) vector2.y <= 0.0)
      vector2.y = 0.0f;
    if ((double) vector2.x >= (double) this.nodesW)
      vector2.x = (float) (this.nodesW - 1);
    if ((double) vector2.y >= (double) this.nodesH)
      vector2.y = (float) (this.nodesH - 1);
    return vector2;
  }

  public void setPathStart(Vector2 start) => this.startNode = this.nodes[(int) start.x, (int) start.y];

  public void setPathEnd(Vector2 end)
  {
    this.endNode = this.nodes[(int) end.x, (int) end.y];
    if (!this.DEBUG)
      return;
    this.endNode.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Misc/node_2");
  }

  public Vector2 findNearestClearNode(Vector2 source)
  {
    int num = 0;
    Node node = (Node) null;
    if (!this.walkable)
      return source;
    for (; node == null || num > 200; ++num)
    {
      for (int index1 = -num; index1 <= num; ++index1)
      {
        for (int index2 = -num; index2 <= num; ++index2)
        {
          if ((int) source.x + index1 > 0 && (int) source.x + index1 < this.nodesW && (int) source.y + index2 > 0 && (int) source.y + index2 < this.nodesH && (double) Mathf.Pow((float) index1, 2f) + (double) Mathf.Pow((float) index2, 2f) <= (double) Mathf.Pow((float) num, 2f) && this.nodes[(int) source.x + index1, (int) source.y + index2].IsWalkable)
            node = this.nodes[(int) source.x + index1, (int) source.y + index2];
        }
      }
    }
    return node.Location;
  }

  private List<Vector2> GetAdjacentLocations(Vector2 location) => new List<Vector2>()
  {
    new Vector2(location.x - 1f, location.y),
    new Vector2(location.x + 1f, location.y),
    new Vector2(location.x, location.y + 1f),
    new Vector2(location.x, location.y - 1f),
    new Vector2(location.x + 1f, location.y + 1f),
    new Vector2(location.x - 1f, location.y + 1f),
    new Vector2(location.x + 1f, location.y - 1f),
    new Vector2(location.x - 1f, location.y - 1f)
  };

  private List<Node> GetAdjacentWalkableNodes(Node fromNode)
  {
    List<Node> nodeList = new List<Node>();
    IEnumerable<Vector2> adjacentLocations = (IEnumerable<Vector2>) this.GetAdjacentLocations(fromNode.Location);
    int num = 0;
    foreach (Vector2 vector2 in adjacentLocations)
    {
      ++num;
      int x = (int) vector2.x;
      int y = (int) vector2.y;
      if (x >= 0 && x < this.nodesW && y >= 0 && y < this.nodesH)
      {
        Node node = this.nodes[x, y];
        if (node.IsWalkable && node.State != NodeState.Closed)
        {
          if (node.State == NodeState.Open)
          {
            float traversalCost = Node.GetTraversalCost(node.Location, fromNode.Location);
            if ((double) (fromNode.G + traversalCost) < (double) node.G)
            {
              node.ParentNode = fromNode;
              nodeList.Add(node);
            }
          }
          else
          {
            node.ParentNode = fromNode;
            node.State = NodeState.Open;
            node.H = LocationManager.dist(node.Location, this.endNode.Location);
            node.G = LocationManager.dist(this.startNode.Location, node.Location);
            nodeList.Add(node);
          }
        }
      }
    }
    return nodeList;
  }

  public List<Vector2> FindPath(Vector2 start, Vector2 finish)
  {
    this.setPathStart(start);
    this.setPathEnd(finish);
    MonoBehaviour.print((object) ("SEARCHING FOR PATH FROM " + (object) start + " TO " + (object) finish));
    for (int index1 = 0; index1 < this.nodesH; ++index1)
    {
      for (int index2 = 0; index2 < this.nodesW; ++index2)
      {
        this.nodes[index2, index1].State = NodeState.Untested;
        this.nodes[index2, index1].ParentNode = (Node) null;
      }
    }
    List<Vector2> vector2List = new List<Vector2>();
    bool flag = this.Search(this.startNode);
    MonoBehaviour.print((object) ("sukces = " + (object) flag));
    if (flag)
    {
      Node node1;
      for (Node node2 = this.endNode; node2.ParentNode != null; node1.ParentNode = (Node) null)
      {
        vector2List.Add(node2.Location);
        node2.State = NodeState.Untested;
        node1 = node2;
        node2 = node2.ParentNode;
      }
      vector2List.Reverse();
    }
    if (vector2List != null)
    {
      for (int index = 0; index < vector2List.Count; ++index)
      {
        if (this.DEBUG)
          this.nodes[(int) vector2List[index].x, (int) vector2List[index].y].gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Misc/node_2");
        Vector2 location = this.nodes[(int) vector2List[index].x, (int) vector2List[index].y].Location;
        vector2List[index] = new Vector2(location.x * (float) this.pixelsW / (float) this.nodesW, location.y * (float) this.pixelsH / (float) this.nodesH);
      }
    }
    return vector2List;
  }

  public List<Vector2> Search2(Vector2 start, Vector2 finish)
  {
    this.setPathStart(start);
    this.setPathEnd(finish);
    if (!this.walkable)
      return (List<Vector2>) null;
    for (int index1 = 0; index1 < this.nodesH; ++index1)
    {
      for (int index2 = 0; index2 < this.nodesW; ++index2)
      {
        if (this.DEBUG)
        {
          if (this.nodes[index2, index1].IsWalkable)
            this.nodes[index2, index1].gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Misc/node_1");
          else
            this.nodes[index2, index1].gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Misc/node_0");
        }
        this.nodes[index2, index1].ParentNode = (Node) null;
      }
    }
    List<Node> nodeList1 = new List<Node>();
    nodeList1.Add(this.startNode);
    this.startNode.ParentNode = (Node) null;
    while (nodeList1.Count > 0)
    {
      Node parentNode = nodeList1[0];
      nodeList1.RemoveAt(0);
      if (parentNode == this.endNode)
      {
        List<Node> nodeList2 = new List<Node>();
        List<Vector2> vector2List = new List<Vector2>();
        for (; parentNode != this.startNode; parentNode = parentNode.ParentNode)
          vector2List.Add(parentNode.Location);
        for (int index = 0; index < vector2List.Count; ++index)
        {
          if (this.DEBUG)
            this.nodes[(int) vector2List[index].x, (int) vector2List[index].y].gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bitmaps/Misc/node_2");
          Vector2 location = this.nodes[(int) vector2List[index].x, (int) vector2List[index].y].Location;
          vector2List[index] = new Vector2(location.x * (float) this.pixelsW / (float) this.nodesW, location.y * (float) this.pixelsH / (float) this.nodesH);
        }
        vector2List.Reverse();
        return vector2List;
      }
      foreach (Vector2 adjacentLocation in (IEnumerable<Vector2>) this.GetAdjacentLocations(parentNode.Location))
      {
        int x = (int) adjacentLocation.x;
        int y = (int) adjacentLocation.y;
        if (x >= 0 && x < this.nodesW && y >= 0 && y < this.nodesH)
        {
          Node node = this.nodes[x, y];
          if (node.IsWalkable && node.ParentNode == null)
          {
            node.ParentNode = parentNode;
            nodeList1.Add(node);
          }
        }
      }
    }
    return (List<Vector2>) null;
  }
}

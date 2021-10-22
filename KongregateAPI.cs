// Decompiled with JetBrains decompiler
// Type: KongregateAPI
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using Kongregate;
using UnityEngine;

public class KongregateAPI : MonoBehaviour
{
  private static KongregateAPI instance;
  private readonly uint gameId = 304604;
  private bool car_done;
  private bool disck_done;
  private bool game_done;

  private void Awake()
  {
    if ((Object) KongregateAPI.instance != (Object) null)
    {
      Object.Destroy((Object) this.gameObject);
    }
    else
    {
      Object.DontDestroyOnLoad((Object) this.gameObject);
      KongregateAPI.instance = this;
    }
  }

  private void Start()
  {
    Debug.Log((object) "Initializing KongregateAPI SDK");
    if (KartridgeBindings.KongregateAPI_RestartWithKartridgeIfNeeded(this.gameId))
    {
      Debug.Log((object) "Re-launching via Kartridge");
      Application.Quit();
    }
    if (!KartridgeBindings.KongregateAPI_Initialize((string) null))
      this.Log("Could not initialize API, is Kartridge running?");
    // ISSUE: reference to a compiler-generated field
    if (KongregateAPI.\u003C\u003Ef__mg\u0024cache0 == null)
    {
      // ISSUE: reference to a compiler-generated field
      KongregateAPI.\u003C\u003Ef__mg\u0024cache0 = new KartridgeBindings.KongregateEventListener(KongregateAPI.OnKongregateEvent);
    }
    // ISSUE: reference to a compiler-generated field
    KartridgeBindings.KongregateAPI_SetEventListener(KongregateAPI.\u003C\u003Ef__mg\u0024cache0);
    this.InvokeRepeating("UpdateEverySec", 1f, 1f);
  }

  private void UpdateEverySec()
  {
    KartridgeBindings.KongregateAPI_Update();
    bool flag1 = KartridgeBindings.KongregateAPI_IsReady();
    bool flag2 = KartridgeBindings.KongregateAPI_IsConnected();
    if (!flag1 || !flag2 || !((Object) GameDataController.gd != (Object) null) || GameDataController.persistentData == null)
      return;
    if (GameDataController.persistentData.kong_car && !this.car_done)
    {
      this.submitBadge("car_fixed");
      this.car_done = true;
    }
    if (GameDataController.persistentData.kong_disk && !this.disck_done)
    {
      this.submitBadge("disk_taken");
      this.disck_done = true;
    }
    if (!GameDataController.persistentData.kong_game || this.game_done)
      return;
    this.submitBadge("game_won");
    this.game_done = true;
  }

  private void OnDestroy()
  {
    Debug.Log((object) "Shutting down the Kongregate API");
    KartridgeBindings.KongregateAPI_Shutdown();
  }

  private void HandleKongregateEvent(string name, string payload)
  {
    this.Log("[Event:" + name + "] - " + payload);
    if (name == "user" || !(name == "auth_token"))
      return;
    this.Log("Updated Game Auth Token: " + KartridgeBindings.KongregateServices_GetGameAuthToken());
  }

  private void Log(string text) => Debug.Log((object) text);

  public void submitBadge(string name)
  {
    this.Log("Submitting badge: " + name);
    KartridgeBindings.KongregateStats_Submit(name, 1L);
  }

  [MonoPInvokeCallback(typeof (KartridgeBindings.KongregateEventListener))]
  private static void OnKongregateEvent(string name, string payload) => KongregateAPI.instance.HandleKongregateEvent(name, payload);
}

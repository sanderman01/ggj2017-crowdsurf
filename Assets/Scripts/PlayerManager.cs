using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

    private static PlayerManager instance;
    public static PlayerManager Instance {
        get {
            if (instance == null) {
                instance = new GameObject("PlayerManager").AddComponent<PlayerManager>();
                instance.Init();
            }
            return instance;
        }
    }

    private static readonly Color playerColorBlue = new Color32(0, 0, 255, 0);
    private static readonly Color playerColorRed = new Color32(255, 50, 0, 0);
    private static readonly Color playerColorGreen = new Color32(0, 255, 0, 0);
    private static readonly Color playerColorMagenta = new Color32(255, 0, 255, 0);

    private Color[] playerColors = {
        playerColorBlue,
        playerColorRed,
        playerColorGreen,
        playerColorMagenta
    };

    [SerializeField]
    private Player[] players;
    public static IEnumerable<Player> Players { get { return Instance.players; } }

    void Awake() {
        instance = this;
        instance.Init();
    }

    void OnDestroy() {
        instance = null;
    }

    private void Init() {
        instance = this;
        DontDestroyOnLoad(gameObject);
        CreatePlayers();
    }

    private void CreatePlayers() {
        Debug.Log("CreatePlayers");
        // Only create new players if they didn't already exist.
        players = new Player[4];
        for (int i = 0; i < 4; ++i) {
            Player player = gameObject.AddComponent<Player>();
            player.SetPlayerNumber(i + 1);
            player.color = playerColors[i];
            player.Active = false;
            players[i] = player;
        }
    }
}

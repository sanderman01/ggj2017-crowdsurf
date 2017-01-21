using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages tracking of statistics.
/// </summary>
public static class Stats {

    public enum GameEndedReason { Finished, Failed, Reset }

    public struct GlobalStats {
        private int total_games;
        private int total_games_finished;
        private int total_games_failed;
        private int total_games_reset;

        private float best_duration;
        private float best_distance;

        private int jumps_total;
        private float jumps_longest_airtime;
        private float jumps_highest;

        // TODO More stats here...

        /// <summary>
        /// Apply the last game's stats to the global stats, to update counters and records.
        /// </summary>
        public static GlobalStats ApplyStats(GlobalStats globals, GameStats game) {

            globals.total_games += 1;
            switch (game.game_end_reason) {
                case GameEndedReason.Finished:
                    globals.total_games_finished += 1;
                    break;
                case GameEndedReason.Failed:
                    globals.total_games_failed += 1;
                    break;
                case GameEndedReason.Reset:
                    globals.total_games_reset += 1;
                    break;
            }

            globals.best_duration = Mathf.Max(globals.best_duration, game.game_duration);
            globals.best_distance = Mathf.Max(globals.best_distance, game.game_distance);
            globals.jumps_total += game.jumps_total;
            globals.jumps_longest_airtime = Mathf.Max(globals.jumps_longest_airtime, game.jumps_longest_airtime);
            globals.jumps_highest = Mathf.Max(globals.jumps_highest, game.jumps_highest);

            // TODO More stats here...

            return globals;
        }
    }

    public struct GameStats {
        public float game_begin;
        public float game_end;
        public float game_duration;
        public float game_distance;
        public GameEndedReason game_end_reason;

        public int jumps_total;
        public float jumps_longest_airtime;
        public float jumps_highest;

        // TODO More stats here...
    }

    public static GlobalStats globals = new GlobalStats(); // maybe save/load from file in future?
    public static GameStats currentGame;
    public static GameStats previousGame;

    public static void StartGame() {
        previousGame = currentGame;
        currentGame = new GameStats();

        currentGame.game_begin = Time.time;
    }

    public static void Update() {
        currentGame.game_end = Time.time;
        currentGame.game_duration = currentGame.game_end - currentGame.game_begin;
    }

    public static void EndGame(GameEndedReason reason) {
        currentGame.game_end = Time.time;
        currentGame.game_duration = currentGame.game_end - currentGame.game_begin;
        currentGame.game_end_reason = reason;

        globals = GlobalStats.ApplyStats(globals, currentGame);
    }
}

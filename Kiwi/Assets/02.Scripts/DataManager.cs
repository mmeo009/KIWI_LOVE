using UnityEngine;

public class DataManager : MonoBehaviour
{
    [System.Serializable]
    public class KiwiStats
    {
        public float hp, health, clean, mental;
        public int generation, coin;
        public string recentKiwi;

        /*public KiwiStats(float hp, float health, float clean, float mental, int generation, int coin)
        {
            float rHealth = this.health, rClean = this.clean, rMental = this.mental;
            int rGeneration = this.generation + 1, rCoin = this.coin;
            this.hp = hp;
            this.health = health;
            this.clean = clean;
            this.mental = mental;
            this.generation = generation + 1;
            this.coin = coin;
            string recentKiwi = rHealth.ToString() + rClean.ToString() + rMental.ToString();
            this.recentKiwi = recentKiwi;
        }*/
    }
}



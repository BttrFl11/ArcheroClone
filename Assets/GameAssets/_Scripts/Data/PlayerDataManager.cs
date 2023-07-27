namespace Data
{
    public class PlayerDataManager
    {
        private PlayerConfig _config;
        private PlayerRuntimeData _runtimeData;

        public PlayerDataManager(PlayerConfig playerConfig, PlayerRuntimeData runtimeData) 
        {
            _config = playerConfig;
            _runtimeData = runtimeData;
        }

        public void AddMoney(int amount)
        {
            _runtimeData.Money += amount;
        }
    }
}

using System.Collections.Generic;


namespace BomberPig
{
    public sealed class EnemiesController : IExecute
    {
        private readonly List<EnemyController> _enemyControllers;

        public EnemiesController(EnemiesData data, IBuildPlayer builder, IMapInfo mapInfo, INavigator navigator, IUnitMotor motor)
        {
            _enemyControllers = new List<EnemyController>();

            foreach (var enemyData in data.Enemies)
            {
                _enemyControllers.Add(new EnemyController(enemyData, builder, mapInfo, navigator, motor));
            }
        }

        public void Execute()
        {
            foreach (var enemy in _enemyControllers)
            {
                enemy.Execute();
            }
        }
    }
}

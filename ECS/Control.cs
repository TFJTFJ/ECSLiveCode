namespace ECS
{
    public class Control
    {
        private readonly IHeater _heater;
        private readonly ITempSensor _tempSensor;
        private readonly int _tempThreshold;

        public Control(IHeater heater, ITempSensor tempSensor, int tempThreshold)
        {
            _heater = heater;
            _tempSensor = tempSensor;
            _tempThreshold = tempThreshold;
        }

        public bool RunSelfTest()
        {
            return _heater.RunSelfTest() && _tempSensor.RunSelfTest();
        }

        public void Regulate()
        {
            var temp = _tempSensor.GetTemp();
            if(temp < _tempThreshold) _heater.TurnOn();
            else _heater.TurnOff();
        }
    }
}

namespace ECS
{
    public class Control
    {
        private IHeater _heater;
        private ITempSensor _tempSensor;
        private int _threshold;

        public Control(IHeater heater, ITempSensor tempSensor, int threshold)
        {
            _heater = heater;
            _tempSensor = tempSensor;
            _threshold = threshold;
        }

        public bool RunSelfTest()
        {
            return _heater.RunSelfTest() && _tempSensor.RunSelfTest();
        }

        public void Regulate()
        {
            var temp = _tempSensor.GetTemp();
            if (temp < _threshold) _heater.TurnOn();
            else _heater.TurnOff();
        }
    }
}

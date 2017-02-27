namespace ECS
{
    public interface IHeater
    {
        bool RunSelfTest();
        void TurnOn();
        void TurnOff();
    }
}
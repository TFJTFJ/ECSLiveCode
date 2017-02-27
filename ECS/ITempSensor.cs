namespace ECS
{
    public interface ITempSensor
    {
        bool RunSelfTest();
        int GetTemp();
    }
}
using NSubstitute;
using NUnit.Framework;

namespace ECS.Test.Unit
{
    [TestFixture]
    class ControlUnitTest
    {
        private IHeater _heater;
        private ITempSensor _tempSensor;
        private Control _uut;
        private const int TempThreshold = 20;

        [SetUp]
        public void Setup()
        {
            _heater = Substitute.For<IHeater>();
            _tempSensor = Substitute.For<ITempSensor>();
            _uut = new Control(_heater, _tempSensor, TempThreshold);
        }

        [TestCase(true, true, true)]
        [TestCase(true, false, false)]
        [TestCase(false, true, false)]
        [TestCase(false, false, false)]
        public void RunSelfTest_VariousSubsytemsStatus_ResultCorrect(bool heaterSTResult, bool tempSensorSTResult, bool expectedResult)
        {
        }

        [Test]
        public void Regulate_TempLow_HeaterOnCalled()
        {
        }

        [Test]
        public void Regulate_TempAtThreshold_HeaterOffCalled()
        {
        }
    }
}

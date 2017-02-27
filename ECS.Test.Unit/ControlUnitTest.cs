using NSubstitute;
using NUnit.Framework;

namespace ECS.Test.Unit
{
    [TestFixture]
    class ControlUnitTest
    {
        private Control _uut;
        private IHeater _heater;
        private ITempSensor _tempSensor;

        [SetUp]
        public void SetUp()
        {
            _heater = Substitute.For<IHeater>();
            _tempSensor = Substitute.For<ITempSensor>();
            _uut = new Control(_heater, _tempSensor, 25);
        }

        [TestCase(true, true, true)]
        [TestCase(false, true, false)]
        [TestCase(true, false, false)]
        [TestCase(false, false, false)]
        public void RunSelfTest_VariousResultsFromHeaterAndTempSensor_SelfTestResultsOK(
            bool heaterResult, bool tempSensorResult, bool expectedResult)
        {
            _heater.RunSelfTest().Returns(heaterResult);
            _tempSensor.RunSelfTest().Returns(tempSensorResult);

            Assert.That(_uut.RunSelfTest(), Is.EqualTo(expectedResult));
        }

        [Test]
        public void Regulate_TempLow_HeaterTurnedOn()
        {
            _tempSensor.GetTemp().Returns(24);
            _uut.Regulate();

            _heater.Received().TurnOn();
        }

        [Test]
        public void Regulate_TempLow_HeaterNotTurnedOff()
        {
            _tempSensor.GetTemp().Returns(24);
            _uut.Regulate();

            _heater.DidNotReceive().TurnOff();
        }
        [Test]
        public void Regulate_TempIrrelevant_TempSensorQueried()
        {
            _tempSensor.GetTemp().Returns(24);
            _uut.Regulate();
            _tempSensor.Received().GetTemp();
        }


    }
}

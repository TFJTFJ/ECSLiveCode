using NSubstitute;
using NUnit.Framework;

namespace ECSWithEvents.Test.Unit
{
    [TestFixture]
    public class ECSWithEventsUnitTests
    {
        private int _increaseTempEventsReceived;
        private int _decreaseTempEventsreceived;
        private ITempSource _tempSource;
        private Control _uut;

        [SetUp]
        public void Setup()
        {
            // Initialize event counters
            _increaseTempEventsReceived = 0;
            _decreaseTempEventsreceived = 0;

            _tempSource = Substitute.For<ITempSource>();
            _uut = new Control(_tempSource, 25);    // Control should hook up to event source

            // Initialize anonymous event listeners that listen to events from Control
            // See e.g. http://nsubstitute.github.io/help/raising-events/
            _uut.IncreaseTempEvent += (sender, args) => { ++_increaseTempEventsReceived; };
            _uut.DecreaseTempEvent += (sender, args) => { ++_decreaseTempEventsreceived; };

        }

        [TestCase(26, 1)]
        [TestCase(25, 1)]
        [TestCase(24, 0)]
        public void RegulateTemp_TempAroundThreshold_DecreaseTempEventsProperlyRaisedRaised(int temp, int nTimesDecreaseEventExpected)
        {
            _tempSource.TempChangedEvent += Raise.EventWith<TempChangedEventArgs>(new TempChangedEventArgs() {Temp = temp});
            Assert.That(_decreaseTempEventsreceived, Is.EqualTo(nTimesDecreaseEventExpected));
        }


        [TestCase(26, 0)]
        [TestCase(25, 0)]
        [TestCase(24, 1)]
        public void RegulateTemp_TempAroundThreshold_IncreaseTempEventsProperlyRaisedRaised(int temp, int nTimesIncreaseEventExpected)
        {
            _tempSource.TempChangedEvent += Raise.EventWith<TempChangedEventArgs>(new TempChangedEventArgs() { Temp = temp });
            Assert.That(_increaseTempEventsReceived, Is.EqualTo(nTimesIncreaseEventExpected));
        }
    }
}

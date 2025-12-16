namespace Beyond.Shared
{
    public class Class1
    {

    }

    public sealed class SoilSensorSimulator 
    {
        private NatConnection _connection;
        private readonly string _sensorId;
        private readonly string _fieldId;
        private readonly Random _random = new();

        public SoilSensorSimulator(NatConnection connection, string sensorId, string fieldId)
        {
            _connection = connection;
            _sensorId = sensorId;
            _fieldId = fieldId;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                var reading = new SoilMouistureReading(
                    SensorId: _sensorId,
                    FieldId: _fieldId,
                    MoinsturePercent: 15 + _random.NextDouble() * 20, 
                    TimestampUtc: DateTime.UtcNow);

                var subject = $"sensors.soil.moisture.{_fieldId}";
                await _connection.PublishAsync(subject, reading, cancellationToken);
                await Task.Delay(5000, cancellationToken); // Send data every 5 seconds
            }
        }

        private class NatConnection
        {
            internal async Task PublishAsync(string subject, SoilMouistureReading reading, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }

        private class SoilMouistureReading
        {
            private string sensorId;
            private string fieldId;
            private double moinsturePercent;
            private DateTime timestampUtc;

            public SoilMouistureReading(string SensorId, string FieldId, double MoinsturePercent, DateTime TimestampUtc)
            {
                sensorId = SensorId;
                fieldId = FieldId;
                moinsturePercent = MoinsturePercent;
                timestampUtc = TimestampUtc;
            }
        }
    }
}

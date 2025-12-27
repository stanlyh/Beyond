namespace Beyond.Shared
{
    public class Class1
    {

    }

    public class RelationalPatterns
    {
        private int score = 65;

        public void CheckScore()
        {
            if (score >= 60 && score <= 100)
            {
                Console.WriteLine("Passed");
            }

            if (score is >= 60 and <= 100)
            {
                Console.WriteLine("Passed");
            }
        }
    }

    public sealed class SoilSensorSimulator(SoilSensorSimulator.NatConnection connection, string sensorId, string fieldId)
    {
        private NatConnection _connection = connection;
        private readonly string _sensorId = sensorId;
        private readonly string _fieldId = fieldId;
        private readonly Random _random = new();

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

        public class NatConnection
        {
            internal async Task PublishAsync(string subject, SoilMouistureReading reading, CancellationToken cancellationToken)
            {
                // Simulate publishing the reading to a message broker
                // In a real implementation, this would involve sending the data to a messaging system
                await Task.Run(() =>
                {
                    // Simulated delay for publishing
                    Thread.Sleep(1000);
                    Console.WriteLine($"Published to {subject}: {reading.MoinsturePercent}% moisture");
                }, cancellationToken);
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

            public double MoinsturePercent => moinsturePercent;
        }
    }
}

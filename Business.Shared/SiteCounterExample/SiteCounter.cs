namespace Business.Shared.SiteCounterExample
{
    public class SiteCounter : ISiteCounter
    {
        private int _counter;

        public void AddCounter()
        {
            _counter++;
        }

        public int GetCounter()
        {
            return _counter;
        }
    }
}

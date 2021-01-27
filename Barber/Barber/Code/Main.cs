namespace Barber
{
    public static class Main
    {
        public static void Start()
        {
            DataBaseConnector.Connect();
        }

        public static void Finish()
        {
            DataBaseConnector.Close();
        }
    }
}
namespace Barber.Windows.Reviews
{
    public class ReviewItem
    {
        public int Id;
        public string Text;
        public string Client;
        public int Rating;

        public override string ToString()
        {
            return $"{Id}# - {Text}, Rating = {Rating} ({Client})";
        }
    }
}
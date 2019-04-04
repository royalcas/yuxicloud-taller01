namespace Domain
{
    public class AValue
    {
        public int Id { get; set; }
        public string TheValue { get; }

        public AValue(int id, string value)
        {
            this.Id = id;
            this .TheValue = value;
        }
    }
}
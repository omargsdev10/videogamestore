namespace VGS.Shared.Entities
{
    /// <summary>
    /// Define VideoGame class
    /// </summary>
    public class VideoGameModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Anho { get; set; }
        public int Ranking { get; set; }
        public ConsoleModel Console { get; set; }
        public GenderModel Gender { get; set; }
        public String Base64Image { get; set; }
    }
}

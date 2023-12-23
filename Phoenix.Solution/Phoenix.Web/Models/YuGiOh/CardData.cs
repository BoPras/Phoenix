using static Phoenix.Web.Models.YuGiOh.CardViewModel;

namespace Phoenix.Web.Models.YuGiOh
{
    public class CardData
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string FrameType { get; set; }
        public string Desc { get; set; }
        public string Race { get; set; }
        public string Archetype { get; set; }
        public string YgoprodeckUrl { get; set; }
        public List<CardSet> CardSets { get; set; }
        public List<CardImage> CardImages { get; set; }
        public List<CardPrice> CardPrices { get; set; }
    }
}

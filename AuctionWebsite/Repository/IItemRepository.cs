namespace AuctionWebsite.Repository
{
    public interface IItemRepository
    {
        void AddBid(string name, decimal bidAmount, int itemId);
    }
}
namespace csi5112service.models
{
    public class ShopDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;
        public string ProductCollectionName { get; set; } = null!;
        public string UserCollectionName { get; set; } = null!;
        public string OrderCollectionName { get; set; } = null!;

        public string OrderDetailsCollectionName { get; set; } = null!;

        public string ChatboxCollectionName { get; set; } = null!;

    }
}

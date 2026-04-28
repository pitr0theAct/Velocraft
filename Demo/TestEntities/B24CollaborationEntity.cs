namespace Demo.TestEntities
{
    public class B24CollaborationEntity
    {
        public B24CollaborationEntity(string name, string description)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Description = description ?? throw new ArgumentNullException(nameof(description));
        }

        public string Name { get; set; }
        public string Description { get; set; }
    }
}

namespace App.BusinessLayer.Entities
{
    public abstract record Entity
    {
        protected Entity() 
        { 
            Id = Guid.NewGuid();
        }

        public Guid? Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdateAt { get; set; }

    }
}

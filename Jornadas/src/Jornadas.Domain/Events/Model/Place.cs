namespace Jornadas.Domain
{
    public class Place : ValueObject
    {
        private readonly string name;

        public Coordinates Coordinates { get; }
        public string Description { get; }
        public bool IsMainPlace { get; }

        internal static Place CreateMainPlace(string name, Coordinates coordenates, string description) 
            => new Place(name, coordenates, description, isMainPlace: true);

        internal static Place CreateSecondaryPlace(string name, Coordinates coordenates, string description)
         => new Place(name, coordenates, description, isMainPlace: false);

        private Place(string name, Coordinates coordinates, string description, bool isMainPlace = true)
        {
            Ensure.NotNullOrEmpty(name, "name is mandatory for a place");
            Ensure.NotNull(coordinates, "coordinates are mandatory for a place");
            this.name = name;
            Coordinates = coordinates;
            Description = description;
            IsMainPlace = isMainPlace;
        }

        public override string ToString() => name;
    }
}
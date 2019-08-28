namespace Jornadas.Core
{
    public class Place
    {
        private readonly string name;

        public Coordenates Coordenates { get; }
        public string Description { get; }
        public bool IsMainPlace { get; }

        internal static Place CreatePlace(string name, Coordenates coordenates, string description) 
            => new Place(name, coordenates, description, isMainPlace:false);

        internal Place(string name, Coordenates coordenates, string description, bool isMainPlace = true)
        {
            this.name = name;
            Coordenates = coordenates;
            Description = description;
            IsMainPlace = isMainPlace;
        }

        public override string ToString() => name;
    }
}
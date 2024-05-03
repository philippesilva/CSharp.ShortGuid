namespace Philippe.ShortGuid
{
	public readonly struct ShortGuid
    {
        // Props
        public readonly string Value { get; }
        public readonly Guid Guid { get; }
        public static ShortGuid Empty => new("AAAAAAAAAAAAAAAAAAAAAA==");

        // Constructors

        public ShortGuid()
        {
            Guid = Guid.NewGuid();
            Value = Encode(Guid);
        }

        public ShortGuid(string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException(nameof(value));

            Guid = Decode(value);
            Value = value;
        }

        public ShortGuid(Guid guid)
        {
            Guid = guid;
            Value = Encode(Guid);
        }

        // Methods

        public static ShortGuid NewShortGuid() => new(Guid.NewGuid());

        private static string Encode(Guid guid)
            => Convert.ToBase64String(guid.ToByteArray());

        private static Guid Decode(string value) => new(Convert.FromBase64String(value));

        // Implicit operators

        public static implicit operator ShortGuid(string value) => new(value);
        public static implicit operator ShortGuid(Guid guid) => new(guid);

        // Override

        public override string ToString() => Value;
    }
}

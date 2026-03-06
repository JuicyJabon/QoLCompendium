namespace QoLCompendium.Core
{
    public readonly struct Fraction
    {
        internal readonly int numerator;

        internal readonly int denominator;

        public Fraction(int n, int d)
        {
            numerator = ((n >= 0) ? n : 0);
            denominator = ((d <= 0) ? 1 : d);
        }

        public static implicit operator float(Fraction f)
        {
            return (float)f.numerator / (float)f.denominator;
        }
    }
}

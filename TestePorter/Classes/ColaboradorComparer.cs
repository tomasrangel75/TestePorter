namespace TestePorter.Classes
{
    public class DevComparer : IEqualityComparer<Dev>
    {
        public bool Equals(Dev x, Dev y)
        {
            if (Object.ReferenceEquals(x, y)) 
                return true;

            if (x is null || y is null)
                return false;

            return x.Nome == y.Nome && x.Cargo == y.Cargo;
        }

        public int GetHashCode(Dev dev)
        {
            if (dev is null) return 0;
            int hashDevNome = dev.Nome == null ? 0 : dev.Nome.GetHashCode();
            int hashDevLing = dev.Cargo.GetHashCode();
            return hashDevNome ^ hashDevLing;
        }
    }
}

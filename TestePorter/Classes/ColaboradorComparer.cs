namespace TestePorter.Classes
{
    public class ColaboradorComparer : IEqualityComparer<Colaborador>
    {
        public bool Equals(Colaborador x, Colaborador y)
        {
            if (Object.ReferenceEquals(x, y)) 
                return true;

            if (x is null || y is null)
                return false;

            return x.Nome == y.Nome && x.Cargo == y.Cargo;
        }

        public int GetHashCode(Colaborador colaborador)
        {
            if (colaborador is null) return 0;
            int hashDevNome = colaborador.Nome == null ? 0 : colaborador.Nome.GetHashCode();
            int hashDevLing = colaborador.Cargo.GetHashCode();
            return hashDevNome ^ hashDevLing;
        }
    }
}

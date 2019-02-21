namespace IntroToAspNetCore_Cooked.Services
{
    public class LifeStyleService
    {
        private readonly Singelton _singelton;
        private readonly Scoped _scoped;
        private readonly Transient _transient;

        public LifeStyleService(Singelton singelton, Scoped scoped, Transient transient)
        {
            _singelton = singelton;
            _scoped = scoped;
            _transient = transient;
        }

        public void Print()
        {
            _singelton.IncreaseCount();
            _scoped.IncreaseCount();
            _transient.IncreaseCount();
        }
    }
}
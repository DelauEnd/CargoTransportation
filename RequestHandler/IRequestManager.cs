using RequestHandler.ModelHandlers;

namespace RequestHandler
{
    public interface IRequestManager
    {
        public CargoRequestHandler CargoRequestHandler { get; }
        public AuthenticationRequestHandler AuthenticationRequestHandler { get; }
    }
}

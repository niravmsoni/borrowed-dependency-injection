using System;

namespace DependencyInjection.Services
{
    public class GuidService
    {
        private Guid _guid;

        public GuidService()
        {
            _guid = Guid.NewGuid();
        }

        public string Value => _guid.ToString();
    }
}

using System;

namespace Common
{
    public static class Utility
    {
        public static string GenerateID()
        {
            return Guid.NewGuid().ToString();
        }
    }
}

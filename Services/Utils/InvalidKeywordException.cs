using System;

namespace Services.Utils
{
    public class InvalidKeywordException: Exception
    {
        public InvalidKeywordException() {}

        public InvalidKeywordException(string message) {}
    }
}
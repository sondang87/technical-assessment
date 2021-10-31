namespace Services.Utils
{
    public class Constants
    {
        public struct ERROR_MESSAGE
        {
            public const string KEYWORD_VALUE_IS_EMPTY = "Keyword value is required";
            public const string KEYWORD_NOT_EXISTS = "Keyword does not exist";
            public const string KEYWORD_EXISTS = "Keyword already exists";
            public const string COMMON_ERROR = "There is something wrong. Please try again";
        }

        public struct SUCCESS_MESSAGE
        {
            public const string ADD_KEYWORD_SUCCESS = "Keyword is added successfully";
            public const string DELETE_KEYWORD_SUCCESS = "Keyword is deleted successfully";
            public const string EDIT_KEYWORD_SUCCESS = "Keyword is edited successfully";
        }
    }
}
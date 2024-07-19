namespace DormAPI.Exceptions
{
    public static class ErrorMessages
    {
        public static string WrongCredentials => "WRONG_LOGIN_OR_PASSWORD";
        public static string EmailTaken => "EMAIL_TAKEN";
        public static string UserNameTaken => "USERNAME_TAKEN";
        public static string RoleNotDefined => "ROLE_NOT_DEFINED";
        public static string InvalidTokenRoleMissing => "INVALID_TOKEN_ROLE_MISSING";
        public static string InvalidTokenUserIdMissing => "INVALID_TOKEN_USER_ID_MISSING";
        public static string InvalidTokenPersonIdMissing => "INVALID_TOKEN_PERSON_ID_MISSING";
        public static string RoleNotAllowed => "ROLE_NOT_ALLOWED";
        public static string InvalidStudentMissingValues => "INVALID_STUDENT_MISSING_VALUES";
        public static string ProblemAlreadyReported => "PROBLEM_ALREADY_REPORTED";
        public static string IndexNumberTaken => "INDEX_NUMBER_TAKEN";
    }
}

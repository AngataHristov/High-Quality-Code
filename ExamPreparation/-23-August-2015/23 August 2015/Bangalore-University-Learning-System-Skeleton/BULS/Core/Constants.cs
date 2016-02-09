namespace BangaloreUniversityLearningSystem.Core
{
    public static class Constants
    {
        public const string CourseLengthMsg = "The course name must be at least 5 symbols long.";
        public const string LectureLengthMsg = "The lecture name must be at least 3 symbols long.";
        public const string UserNameLengthMsg = "The userName must be at least 5 symbols long.";
        public const string PasswordLengthMsg = "The Password must be at least 6 symbols long.";

        public const string NoLoggedUserMsg = "There is no currently logged in user.";
        public const string NoAutorizedUserMsg = "The current user is not authorized to perform this operation.";

        public const string NoCoursesWithIDMsg = "There is no course with ID {0}.";
        public const string AlreayEnroledInCourseMsg = "You are already enrolled in this course.";
        public const string NoCurrentlyLoggedUserMsg = "There is no currently logged in user.";
        public const string NotAuthorizedUserMsg = "The current user is not authorized to perform this operation.";

        public const string PasswordNotMatchMsg = "The provided passwords do not match.";
        public const string UserAlreadyExistMsg = "A user with username {0} already exists.";
        public const string UserDoesNotExistMsg = "A user with username {0} does not exist.";
        public const string WrongPasswordMsg = "The provided password is wrong.";
        public const string AlreadyLoggedInUserMsg = "There is already a logged in user.";

        public const string UserRegisteredSuccessfullyMsg = "User {0} registered successfully.";
        public const string UserLoggedInSuccessfullyMsg = "User {0} logged in successfully.";
        public const string UserLoggedOutSuccessfullyMsg = "User {0} logged out successfully.";

        public const string StudentSuccessfullyEnrolledInCourseMsg = "Student successfully enrolled in course {0}.";
        public const string CourseCreatedSuccessfullyMsg = "Course {0} created successfully.";
        public const string LectureSuccessfullyAddedMsg = "Lecture successfully added to course {0}.";

        public const string InvalidProvidetRouteMsg = "The provided route is invalid.";
        public const string NotInCourseMsg = "You are already enrolled in this course.";
    }
}

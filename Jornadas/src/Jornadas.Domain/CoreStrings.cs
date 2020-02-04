namespace Jornadas.Domain
{
    public static class CoreStrings
    {
        public const string InvalidLatitude = "Latitude should be between -90 and 90";
        public const string InvalidLongitude = "Longitude should be between -180 and 180";

        public const string EventInCourse = "Can not change the event dates when it is in course";
        public const string InvalidPastDate = "Date can not be in the past";
        public const string InvalidEventEndDate = "Event end date should be after than begin date";
        public const string InvalidEventRegistrationDate = "Registration date should be erlier than begin date";
        public const string AlreadyRegistrations = "Can not change the registration date because there are already registrations";


        public const string PlaceWithSameName = "Can not add the place, because a place withthe same name already exists in the event";
    }
}

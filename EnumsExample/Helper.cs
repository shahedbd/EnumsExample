using System.ComponentModel;

namespace EnumsExample
{
    public static class Helper
    {
        [Flags]
        public enum FileAccessEnum
        {
            Read = 1,
            Write = 2,
            Execute = 4
        }
        public enum Status
        {
            [Description("Active Status")]
            Active,
            [Description("Inactive Status")]
            Inactive,
            [Description("Pending Status")]
            Pending,
            [Description("InProgress Status")]
            InProgress,
        }
        public enum WeekDays
        {
            Sunday = 1,
            Monday = 2,
            Tuesday = 3,
            Wednesday = 4,
            Thursday = 5,
            Friday = 6,
            Saturday = 7,
        }
        public enum LogLevel
        {
            Info,
            Warning,
            Error
        }

        public enum TrafficLight
        {
            Red,
            Yellow,
            Green
        }


        public static bool IsInProcess(this Status status)
        {
            return status == Status.Pending || status == Status.InProgress;
        }

        public static IEnumerable<string> GetDescriptions<T>()
        {
            var attributes = typeof(T).GetMembers()
                .SelectMany(member => member.GetCustomAttributes(typeof(DescriptionAttribute), true).Cast<DescriptionAttribute>())
                .ToList();

            return attributes.Select(x => x.Description);
        }
    }
}

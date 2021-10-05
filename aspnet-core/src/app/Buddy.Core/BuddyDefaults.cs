using System;

namespace Buddy
{
    public class BuddyDefaults
    {
        public const string Version = "1.00";

        private static readonly Lazy<DateTime> LazyReleaseDate = new Lazy<DateTime>(() => DateTime.Now);
        public static DateTime ReleaseDate => LazyReleaseDate.Value;
    }
}

namespace BA_WinForms.DL
{
    internal static class TimetableDL
    {
        public static string[] Days = { "MONDAY", "TUESDAY", "WEDNESDAY", "THURSDAY", "FRIDAY" };

        public static string[,] TimetableA = {
            { "PF",     "AICIT",  "AP LAB", "------" },
            { "CALC-I", "AP PHY", "DM",     "------" },
            { "------", "DM",     "PF",     "CALC-I" },
            { "AICITL", "AP LAB", "------", "BASIC-M"},
            { "PF",     "------", "------", "------" }
        };

        public static string[,] TimetableB = {
            { "DM",     "PF",     "AICIT",  "------" },
            { "CALC-I", "AP PHY", "------", "DM"     },
            { "PF",     "DM",     "AICIT",  "CALC-I" },
            { "AICITL", "AP LAB", "------", "BASIC-M"},
            { "PF",     "------", "------", "------" }
        };

        public static string[,] TimetableC = {
            { "CALC-I", "PF",     "DM",     "AICIT"  },
            { "AICITL", "AP LAB", "------", "PF"     },
            { "PF",     "DM",     "CALC-I", "AP PHY" },
            { "DM",     "------", "AICIT",  "BASIC-M"},
            { "PF",     "------", "------", "------" }
        };

        public static string[,] GetTimetable(string section)
        {
            if (section == "A") return TimetableA;
            else if (section == "B") return TimetableB;
            else if (section == "C") return TimetableC;
            else return null;
        }

        public static string[] Checkpoints = {
            "IB&M", "Theatre Hall", "Auditorium", "Cafe", "Library",
            "Electrical Dept.", "Admin Block", "Hostels Area", "Aisha Hall",
            "SSC", "GSSC", "Bhoola Cafe", "Annexe", "Annexe Ground",
            "Computing Block", "Saiyalaan", "JJ Stadium", "Football Ground"
        };
    }
}
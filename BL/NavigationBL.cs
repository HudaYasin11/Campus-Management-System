using BA_WinForms.DL;
using System;

namespace BA_WinForms.BL
{
    internal class NavigationBL
    {
        public string GetRoute(string start, string destination)
        {
            string[] checkpoints = TimetableDL.Checkpoints;
            string result = "";

            result += "\n=================================================================\n";
            result += "                         YOUR ROUTE                             \n";
            result += "=================================================================\n";
            result += start;

            int counter = 0;
            for (int i = 0; i < checkpoints.Length; i++)
            {
                if (checkpoints[i] != start && checkpoints[i] != destination)
                {
                    result += " ---> " + checkpoints[i];
                    counter++;
                    if (counter % 5 == 0)
                        result += "\n";
                }
            }
            result += " ---> " + destination;
            result += "\n=================================================================\n";
            return result;
        }

        public string GetTimetable(string section)
        {
            string[,] tt = TimetableDL.GetTimetable(section);
            if (tt == null) return null;

            string[] days = TimetableDL.Days;
            string result = "";

            result += "\n************************************************************************\n";
            result += "*                         TIMETABLE                                   *\n";
            result += "************************************************************************\n";
            result += "|   Day       | 8-9 AM  | 9-10 AM | 10-12 PM | 2-4 PM  |\n";
            result += "--------------------------------------------------------------------------\n";

            for (int i = 0; i < 5; i++)
            {
                result += "| " + days[i].PadRight(10);
                for (int j = 0; j < 4; j++)
                    result += " | " + tt[i, j].PadRight(7);
                result += " |\n";
            }
            result += "--------------------------------------------------------------------------\n";
            return result;
        }

        public string GetCampusMap()
        {
            return @"
===================== UET CAMPUS MAP =====================
                 [ MAIN GATE ]
                      |
                      v
                [ ADMIN BLOCK ]
                      |
          -----------------------------
          |                           |
          v                           v
   [ IB&M Department ]        [ ELECTRICAL Dept. ]
          |                           |
          v                           v
   [ THEATRE HALL ]           [ LIBRARY ]
          |                           |
          v                           v
   [ AUDITORIUM ]             [ CAFETERIA ]
          |                           |
          v                           v
          -----------------------------
                      |
                      v
                [ HOSTELS AREA ]
==========================================================";
        }

        public string GetTips()
        {
            return @"
==============================================================
                      FRESHER TIPS
==============================================================
1.  Attend ORIENTATION WEEK to learn the basics.
2.  Always carry your STUDENT ID.
3.  Explore CAMPUS early: labs, library, cafe, hostels.
4.  Make FRIENDS across departments.
5.  Be punctual and attend all classes.
6.  Join SOCIETIES and CLUBS to improve your skills.
7.  Learn to use LMS and university email properly.
8.  Stay consistent with studies.
9.  Visit the LIBRARY often - its quiet and resourceful.
10. Enjoy university life - it flies by fast!
==============================================================";
        }

        public string GetFAQs()
        {
            return @"
|||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||
              FREQUENTLY ASKED QUESTIONS (FAQs)
|||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||
Q1: What is the best time to visit the cafe?
A1: Avoid 12:00 PM - its the rush hour!

Q2: Where can we study peacefully?
A2: The LIBRARY is best for quiet study.

Q3: Where to hang out with friends?
A3: CAFE, Sports Complex, and JJ Stadium.

Q4: Is there a gymnasium?
A4: Yes, there is one on campus.

Q5: Should you join societies in 1st semester?
A5: Yes, but balance them with studies.

Q6: Is grading system relative or absolute?
A6: Depends on your teacher.

Q7: Is there WiFi available?
A7: Yes, EDUROAM is available after registration.
|||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||";
        }
    }
}
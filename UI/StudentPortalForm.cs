
using BA_WinForms.BL;
using BA_WinForms.DL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BA_WinForms.UI;  // For MapForm

namespace BA_WinForms.UI
{
    public partial class StudentPortalForm : Form
    {
        NavigationBL nav = new NavigationBL();
        public StudentPortalForm()
        {
            InitializeComponent();
        }

        private void btnMap_Click(object sender, EventArgs e)
        {
           /* string url = "https://www.google.com/maps/place/University+of+Engineering+and+Technology,+Lahore/@31.579944,74.354982,17z";
            System.Diagnostics.Process.Start(url);*/

            MapForm mapForm = new MapForm();
            mapForm.ShowDialog();
        }

        private void btnRoute_Click(object sender, EventArgs e)
        {
            string start = Microsoft.VisualBasic.Interaction.InputBox("Enter starting point:", "Route Finder", "Admin Block");
            string dest = Microsoft.VisualBasic.Interaction.InputBox("Enter destination:", "Route Finder", "Library");
            string route = nav.GetRoute(start, dest);
            MessageBox.Show(route, "Your Route", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnTimeTable_Click(object sender, EventArgs e)
        {
            string section = Microsoft.VisualBasic.Interaction.InputBox("Enter section (A/B/C):", "Timetable", "A");
            string timetable = nav.GetTimetable(section);

            if (timetable != null)
                MessageBox.Show(timetable, "Timetable", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Invalid section! Enter A, B, or C.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnTips_Click(object sender, EventArgs e)
        {
            string tips = @"
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
            MessageBox.Show(tips, "Fresher Tips", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnFaqs_Click(object sender, EventArgs e)
        {
            string faqs = @"
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
            MessageBox.Show(faqs, "FAQs", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnCourses_Click(object sender, EventArgs e)
        {
            var courses = CourseDL.GetAllCourses();
            string message = "===== AVAILABLE COURSES =====\n\n";

            if (courses.Count == 0)
            {
                message = "No courses available.";
            }
            else
            {
                foreach (var c in courses)
                {
                    message += $"{c.Code} | {c.Title} | {c.Instructor}\n";
                }
            }

            MessageBox.Show(message, "All Courses", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to logout?", "Confirm",
               MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                StartingForm parent = (StartingForm)this.ParentForm;
                parent.LoadForm(new MainMenuForm());
            }
        }
    }
}

using System.Collections.Generic;

namespace BA_WinForms.BL
{
    internal class Assignment
    {
        private string teacherID;
        private string courseCode;

        public string TeacherID
        {
            get { return teacherID; }
            set { teacherID = value; }
        }

        public string CourseCode
        {
            get { return courseCode; }
            set { courseCode = value; }
        }

        public Assignment(string teacherID, string courseCode)
        {
            this.teacherID = teacherID;
            this.courseCode = courseCode;
        }

        public List<Assignment> GetAllAssignments(List<Assignment> assignmentList)
        {
            return assignmentList;
        }

        public bool AlreadyAssigned(string teacherID, string courseCode, List<Assignment> assignmentList)
        {
            foreach (Assignment a in assignmentList)
            {
                if (a.TeacherID == teacherID && a.CourseCode == courseCode)
                    return true;
            }
            return false;
        }

        public int GetAssignmentCount(List<Assignment> assignmentList)
        {
            return assignmentList.Count;
        }

        public bool AddAssignment(string teacherID, string courseCode, List<Assignment> assignmentList)
        {
            if (string.IsNullOrEmpty(teacherID) || string.IsNullOrEmpty(courseCode))
                return false;

            if (AlreadyAssigned(teacherID, courseCode, assignmentList))
                return false;

            assignmentList.Add(new Assignment(teacherID, courseCode));
            return true;
        }

        public bool ValidateAssignment(Assignment assignment)
        {
            return assignment != null &&
                   !string.IsNullOrEmpty(assignment.TeacherID) &&
                   !string.IsNullOrEmpty(assignment.CourseCode);
        }
    }
}
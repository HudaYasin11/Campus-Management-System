using System.Collections.Generic;

namespace BA_WinForms.BL
{
    internal class Course
    {
        private string code;
        private string title;
        private string instructor;

        public string Code
        {
            get { return code; }
            set { code = value; }
        }

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public string Instructor
        {
            get { return instructor; }
            set { instructor = value; }
        }

        public Course(string code, string title, string instructor)
        {
            this.code = code;
            this.title = title;
            this.instructor = instructor;
        }

        public string AddCourse(string code, string title, string instructor, List<Course> courseList)
        {
            if (code == "" || title == "" || instructor == "")
                return "invalid";

            if (SearchCourse(code, courseList) != null)
                return "duplicate";

            Course c = new Course(code, title, instructor);
            courseList.Add(c);
            return "success";
        }

        public Course SearchCourse(string code, List<Course> courseList)
        {
            foreach (Course c in courseList)
            {
                if (c.Code == code)
                    return c;
            }
            return null;
        }

        public string UpdateCourse(string code, string newTitle, string newInstructor, List<Course> courseList)
        {
            Course c = SearchCourse(code, courseList);
            if (c == null)
                return "not Found";

            if (newTitle != "") { c.Title = newTitle; }
            if (newInstructor != "") { c.Instructor = newInstructor; }
            return "success";
        }

        public string DeleteCourse(string code, List<Course> courseList)
        {
            Course c = SearchCourse(code, courseList);
            if (c != null)
            {
                courseList.Remove(c);
                return "success";
            }
            else
                return "not Found";
        }

        public List<Course> ListCourses(List<Course> courseList)
        {
            return courseList;
        }

        public bool CanAddCourse(string code, List<Course> courseList)
        {
            return SearchCourse(code, courseList) == null;
        }

        public bool ValidateCourse(Course course)
        {
            return course != null &&
                   !string.IsNullOrEmpty(course.Code) &&
                   !string.IsNullOrEmpty(course.Title);
        }

        public int CourseCount(List<Course> courseList)
        {
            return courseList.Count;
        }
    }
}
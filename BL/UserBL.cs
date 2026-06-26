using System.Collections.Generic;

namespace BA_WinForms.BL
{
    internal class UserBL
    {
        public bool IsFirstUser(List<User> userList)
        {
            return userList.Count == 0;
        }

        public string Signup(string username, string password, string roleChoice,
            bool isFirstUser, List<User> userList, List<User> pendingList)
        {
            if (username == "" || password == "")
                return "invalid";

            if (UsernameExists(username, userList))
                return "duplicate";

            string role, status;

            if (roleChoice == "1")
            {
                role = "STUDENT";
                status = "APPROVED";
            }
            else
            {
                role = "ADMIN";
                status = isFirstUser ? "APPROVED" : "PENDING";
            }

            return status == "PENDING" ? "pending" : "success";
        }

        public bool UsernameExists(string username, List<User> userList)
        {
            foreach (User u in userList)
            {
                if (u.Username == username)
                    return true;
            }
            return false;
        }

        public User FindUser(string username, List<User> userList)
        {
            foreach (User u in userList)
            {
                if (u.Username == username)
                    return u;
            }
            return null;
        }

        public string AdminSignIn(string username, string password, List<User> userList)
        {
            User u = FindUser(username, userList);

            if (u == null || u.Password != password)
                return "invalid";
            if (u.Role != "ADMIN")
                return "not_admin";
            if (u.Status != "APPROVED")
                return "pending";

            return "success";
        }

        public string StudentSignIn(string username, string password, List<User> userList)
        {
            User u = FindUser(username, userList);
            if (u == null || u.Password != password)
                return "invalid";
            return "success";
        }

        public List<User> GetPendingAdmins(List<User> userList)
        {
            List<User> pending = new List<User>();

            foreach (User u in userList)
            {
                if (u.Role == "ADMIN" && u.Status == "PENDING")
                    pending.Add(u);
            }
            return pending;
        }

        public bool ApproveAdmin(string username, List<User> userList, List<User> pendingList)
        {
            User u = FindUser(username, userList);
            if (u != null && u.Role == "ADMIN" && u.Status == "PENDING")
            {
                u.Status = "APPROVED";
                pendingList.Remove(u);
                return true;
            }
            return false;
        }

        public User GetUserByUsername(string username, List<User> userList)
        {
            return FindUser(username, userList);
        }

        public int AdminCount(List<User> userList)
        {
            int count = 0;
            foreach (User u in userList)
            {
                if (u.Role == "ADMIN")
                    count++;
            }
            return count;
        }

        public int StudentCount(List<User> userList)
        {
            int count = 0;
            foreach (User u in userList)
            {
                if (u.Role == "STUDENT")
                    count++;
            }
            return count;
        }

        public bool CanAddAdmin(List<User> userList)
        {
            return AdminCount(userList) < 3;
        }

        public bool ValidateUser(User user)
        {
            return user != null &&
                   !string.IsNullOrEmpty(user.Username) &&
                   !string.IsNullOrEmpty(user.Password);
        }
    }
}
using tar1;

namespace tar2.BL
{
    public class User
    {
        string firstName;
        string familyName;
        string email;
        string password;
        bool isActive;
        bool isAdmin;   
        static List<User> usersList = new List<User>();


        public string FirstName { get => firstName; set => firstName = value; }
        public string FamilyName { get => familyName; set => familyName = value; }
        public string Email { get => email; set => email = value; }
        public string Password { get => password; set => password = value; }
        public bool IsActive { get => isActive; set => isActive = value; }
        public bool IsAdmin { get => isAdmin; set => isAdmin = value; }

        public User() { }
        public User(string firstName, string familyName, string email, string password, bool isActive, bool isAdmin)
        {
            FirstName = firstName;
            FamilyName = familyName;
            Email = email;
            Password = password;
            IsActive = isActive;
            IsAdmin = isAdmin;
        }

        public List<User> ReadUser()
        {
            DBservices dbs = new DBservices();
            return dbs.ReadUser();

        }


        //public bool checkEmail()
        //{
        //    foreach (User user in usersList)
        //    {
        //        if (user.Email == this.Email)
        //        {
        //            return false;
        //        }
        //    }
        //    if (this.Email == "" || this.FirstName == "" || this.FamilyName == "" || this.Password=="")
        //    {
        //        return false;
        //    }
        //    usersList.Add(this);
        //    return true;
        //}

        public int Insert()
        {
            DBservices dbs= new DBservices();
            return dbs.Insert(this);

            //return checkEmail();


        }
       public int Delete(string email)
        {
            DBservices dbs = new DBservices();
            return dbs.deleteUser(email);
        }

        public int UpdateDetails(string email)
        {
            DBservices dbs = new DBservices();
            return dbs.InsertUpdatedUser(this, email);

        }

        //Login
        public User Login()
        {
            DBservices dbs = new DBservices();
            return dbs.GetUserByDetails(this);

        }

    }
}

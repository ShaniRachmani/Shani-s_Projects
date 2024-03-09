


using tar1;

namespace tar2.BL
{

    public class Vacation
    {

        int id;
        string userId;
        int flatId;
        DateTime startDate;
        DateTime endDate;
        static List<Vacation> vacationsList = new List<Vacation>();

        public int Id { get => id; set => id = value; }
        public string UserId { get => userId; set => userId = value; }
        public int FlatId { get => flatId; set => flatId = value; }
        public DateTime StartDate { get => startDate; set => startDate = value; }
        public DateTime EndDate { get => endDate; 
            set
            {
                if (StartDate < value)
                {
                    endDate = value;
                }
                else
                {
                    endDate = DateTime.MinValue;
                }
            } 
        }

        public Vacation() { }

        public Vacation(int id, string userId, int flatId, DateTime startDate, DateTime endDate)
        {
            Id = id;
            UserId = userId;
            FlatId = flatId;
            StartDate = startDate;
            EndDate = endDate;
        }


        public List<Vacation> Read()
        {
            DBservices dbs = new DBservices();
            return dbs.GetVacation();

        }
        public List<Vacation> ReadByUserEmail(string email)
        {
            DBservices dbs = new DBservices();
            return dbs.GetVacationByEmail(email);
        }
        public int Insert()
        {
            //foreach (Vacation vacation in vacationsList)
            //{
            //    if (vacation.Id == this.Id)// check if id exist
            //    {
            //        return false;
            //    }
            //    if (vacation.FlatId == this.FlatId)//check if the specific flat is occupied
            //    {
            //        if ((vacation.StartDate >this.EndDate) || (vacation.EndDate <this.StartDate))
            //        {

            //            vacationsList.Add(this);
            //            return true;
            //        }
            //        return false;
            //    }
            //}
            //if (this.EndDate == DateTime.MinValue)//invalid end date
            //{
            //    return false;
            //}
            //if (this.Id==0|| this.FlatId==0|| this.UserId==0)
            //    {
            //        return false;
            //    }
            //vacationsList.Add(this);
            //return true;

            DBservices dbs = new DBservices();
            List<Vacation> vacationList = Read();

            foreach (var v in vacationList)
            {
                if (this.flatId == v.flatId)
                {
                    if (this.startDate > v.endDate || this.endDate < v.startDate)
                    {
                        continue;
                    }
                    return 0;
                }
            }
            return dbs.InsertVacation(this);
        }
        //public List<Vacation> ReadByDates(DateTime startDat, DateTime endDate)
        //{
        //    List<Vacation> selectedList = new List<Vacation>();
        //    foreach (Vacation vacation in vacationsList)
        //    {
        //        if (vacation.StartDate >= startDat && vacation.EndDate<= endDate)
        //            selectedList.Add(vacation);
        //    }
        //    return selectedList;
        //}
    }
}

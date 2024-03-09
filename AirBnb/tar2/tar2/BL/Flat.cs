namespace tar1
{
    public class Flat
    {
        int Id;
        string City;
        string Address;
        double price;
        int NumberOfRoom;
        static List<Flat> FlatsList = new List<Flat>();

        public Flat() { }
        public Flat(int id, string city, string address, double price, int numberOfRoom)
        {
            Id1 = id;
            City1 = city;
            Address1 = address;
            NumberOfRoom1 = numberOfRoom;
            Price1 = price;
        }

        public int Id1 { get => Id; set => Id = value; }
        public string City1 { get => City; set => City = value; }
        public string Address1 { get => Address; set => Address = value; }
        public int NumberOfRoom1 { get => NumberOfRoom; set => NumberOfRoom = value; }
        public double Price1 { get => price;
            set
            {
                price= value;
                price = (NumberOfRoom1 > 1 && Price1 > 100 ? value * 0.9 : value);
            }
        }
        //public List<Flat> Read()
        //{

        //    return FlatsList;

        //}

        //public bool checkId()
        //{
        //    foreach (Flat flat in FlatsList)
        //    {
        //        if (flat.Id1 == this.Id1)
        //        {
        //            return false;
        //        }
        //    }
        //    if (this.Id1 == 0 || this.Address1 == "" || this.City1 == "" || this.price == 0 || this.NumberOfRoom1 == 0)
        //    {
        //        return false;
        //    }
        //    FlatsList.Add(this);
        //   return true;
        //}

        //public bool Insert()
        //{

        //    return checkId();


        //}


        public int Insert()
        {
            DBservices dbs = new DBservices();
            return dbs.InsertFlat(this);
        }
        public static List<Flat> Read()
        {
            DBservices dbs = new DBservices();
            return dbs.GetFlat();
        }

        //public List<Flat> ReadByCity(string city,double price)
        //{
        //    List<Flat> selectedList = new List<Flat>();
        //    foreach (Flat flat in FlatsList)
        //    {
        //        if (flat.City1 == city && flat.Price1 < price)
        //            selectedList.Add(flat);
        //    }
        //    return selectedList;
        //}
    }
}

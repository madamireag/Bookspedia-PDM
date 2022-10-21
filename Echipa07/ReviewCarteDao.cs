using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Echipa07
{
    public class ReviewCarteDao
    {
        SQLiteConnection conn;
        public ReviewCarteDao()
        {
            string caleDB = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "review_carti.db");
            this.conn = new SQLiteConnection(caleDB, false);
            conn.CreateTable<MyReview>();
        }

        public int AdaugaReview(MyReview myReview)
        {
            return conn.Insert(myReview);
        }

        public List<MyReview> ObtineToateInregistrarile()
        {
             return conn.Table<MyReview>().ToList();
        }
    }
}

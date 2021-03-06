﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using BilisimLibrary.Model;
using BilisimLibrary.Exceptions;
namespace ApartYonetim
{
    public class tbl_YoneticiBina : ModelBase
    {
        private const string PARM_ID = "@id";
        private const string PARM_BINA_ID = "@bina_id";
        private const string PARM_YONETICI_ID = "@yonetici_id";
        public tbl_YoneticiBina()
        {
            SQLHelper.BilisimLibraryDbConnectionString = "server =.; Initial Catalog = AYS; Integrated Security = SSPI";
        }
        private int id;
        public int Id
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return id; }
            [System.Diagnostics.DebuggerStepThrough]
            set { id = value; }
        }
        private int bina_id;
        public int Bina_id
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return bina_id; }
            [System.Diagnostics.DebuggerStepThrough]
            set { bina_id = value; }
        }
        private int yonetici_id;
        public int Yonetici_id
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return yonetici_id; }
            [System.Diagnostics.DebuggerStepThrough]
            set { yonetici_id = value; }
        }
        public override int PopulateDataReader(System.Data.Common.DbDataReader reader)
        {
            int i = 0;
            this.id = GetInt32(reader, i++).Value;
            this.bina_id = GetInt32(reader, i++).Value;
            this.yonetici_id = GetInt32(reader, i++).Value;
            return i;
        }

        private static String SQL_FIND_BY_ID = @"SELECT 
                                        id ,
                                        bina_id ,
                                        yonetici_id  FROM tbl_YoneticiBina WITH (NOLOCK) WHERE id = " + PARM_ID;
        public tbl_YoneticiBina FindById(int id)
        {
            SqlParameter[] parms = new SqlParameter[] {
         new SqlParameter(PARM_ID, SqlDbType.Int, 4),
    };
            parms[0].Value = id;

            using (SqlDataReader reader = SQLHelper.ExecuteReader(SQLHelper.BilisimLibraryDbConnectionString, CommandType.Text, SQL_FIND_BY_ID, parms))
            {
                if (reader.Read())
                {
                    tbl_YoneticiBina bilgi = new tbl_YoneticiBina();
                    bilgi.PopulateDataReader(reader);
                    return bilgi;
                }
                else
                {
                    throw new DBKayitBulunamadiException(this.GetType(), "SQL_FIND_BY_ID", id);
                }
            }
        }
        //DataSet Örnek

        //public DataSet yoneticiListele2(int binaID)
        //{
        //    SqlConnection cnn = new SqlConnection(SQLHelper.BilisimLibraryDbConnectionString);
        //    string sorgu = @"SELECT y.yonetici_adi FROM tbl_YoneticiBina yb
        //                                                INNER JOIN tbl_Binalar b ON b.bina_id=yb.bina_id
        //                                                INNER JOIN tbl_Yoneticiler y ON y.yonetici_id=yb.yonetici_id
        //                                                WHERE yb.bina_id= " + binaID;

        //    SqlCommand cmd = new SqlCommand(sorgu, cnn);
        //    cnn.Open();
        //    SqlDataAdapter sda = new SqlDataAdapter(cmd);
        //    DataSet dt = new DataSet();
        //    sda.Fill(dt);
        //    cnn.Close();
        //    return dt;
        //}



        //DataReader Ornek
        public SqlDataReader yoneticiListele(int binaID)
        {
            SqlConnection cnn = new SqlConnection(SQLHelper.BilisimLibraryDbConnectionString);
            string sorgu = @"SELECT y.yonetici_adi FROM tbl_YoneticiBina yb
                                                        INNER JOIN tbl_Binalar b ON b.bina_id=yb.bina_id
                                                        INNER JOIN tbl_Yoneticiler y ON y.yonetici_id=yb.yonetici_id
                                                        WHERE yb.bina_id= " + binaID;

            SqlCommand cmd = new SqlCommand(sorgu, cnn);
            cnn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            return dr;
        }

        public SqlDataReader binaListele()
        {
            SqlConnection cnn = new SqlConnection(SQLHelper.BilisimLibraryDbConnectionString);
            string sorgu = @"SELECT bina_id,bina_adi from tbl_Binalar";

            SqlCommand cmd = new SqlCommand(sorgu, cnn);
            cnn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            return dr;
        }

        //DataReader Ornek
        public SqlDataReader binaListele(int yoneticiID)
        {
            SqlConnection cnn = new SqlConnection(SQLHelper.BilisimLibraryDbConnectionString);
            string sorgu = @"SELECT b.bina_adi,b.bina_id FROM tbl_YoneticiBina yb
                                                        INNER JOIN tbl_Binalar b ON b.bina_id=yb.bina_id
                                                        INNER JOIN tbl_Yoneticiler y ON y.yonetici_id=yb.yonetici_id
                                                        WHERE yb.yonetici_id= " + yoneticiID;

            SqlCommand cmd = new SqlCommand(sorgu, cnn);
            cnn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            return dr;
        }


        // Yöneticilere yetki eklemek için YeniKaydette
        public SqlDataReader newYoneticiID()
        {
            SqlConnection cnn = new SqlConnection(SQLHelper.BilisimLibraryDbConnectionString);
            string sorgu = @"select top(1) yonetici_id as newYoneticiID  from tbl_Yoneticiler order by yonetici_id desc";
            SqlCommand cmd = new SqlCommand(sorgu, cnn);
            cnn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            return dr;
        }

        private static String SQL_LISTE = @"SELECT 
                                        id ,
                                        bina_id ,
                                        yonetici_id  FROM tbl_YoneticiBina WITH (NOLOCK) ";
        public ModelCollection<tbl_YoneticiBina> Listele()
        {
            SqlParameter[] parms = new SqlParameter[] { };
            ModelCollection<tbl_YoneticiBina> liste = new ModelCollection<tbl_YoneticiBina>();
            using (SqlDataReader reader = SQLHelper.ExecuteReader(SQLHelper.BilisimLibraryDbConnectionString, CommandType.Text, SQL_LISTE, parms))
            {
                liste.PopulateReader(reader);
            }
            return liste;
        }

        private static String SQL_YENI_KAYDET = @"INSERT INTO tbl_YoneticiBina( 
                  bina_id ,
                  yonetici_id ) VALUES (" + PARM_BINA_ID + @"," +
                          PARM_YONETICI_ID + @" ) SET  " + PARM_ID + "  = SCOPE_IDENTITY()";
        public int YeniKaydet(tbl_YoneticiBina bilgi)
        {
            SqlParameter[] parms = new SqlParameter[] {
                        new SqlParameter(PARM_ID,SqlDbType.Int,4),
                        new SqlParameter(PARM_BINA_ID,SqlDbType.Int,4),
                        new SqlParameter(PARM_YONETICI_ID,SqlDbType.Int,4),
};
            int index = 0;
            parms[index++].Direction = ParameterDirection.Output;
            parms[index++].Value = bilgi.bina_id;
            parms[index++].Value = bilgi.yonetici_id;
            SQLHelper.ExecuteNonQuery(SQLHelper.BilisimLibraryDbConnectionString, CommandType.Text, SQL_YENI_KAYDET, parms);
            return (int)parms[0].Value;
        }
        private static readonly String SQL_GUNCELLE = @"UPDATE tbl_YoneticiBina SET  
                  bina_id = " + PARM_BINA_ID + @", 
                  yonetici_id = " + PARM_YONETICI_ID + @" WHERE id = " + PARM_ID;
        public tbl_YoneticiBina Guncelle(tbl_YoneticiBina bilgi)
        {
            SqlParameter[] parms = new SqlParameter[] {
                        new SqlParameter(PARM_ID,SqlDbType.Int,4),
                        new SqlParameter(PARM_BINA_ID,SqlDbType.Int,4),
                        new SqlParameter(PARM_YONETICI_ID,SqlDbType.Int,4),
};
            int index = 0;
            parms[index++].Value = bilgi.id;
            parms[index++].Value = bilgi.bina_id;
            parms[index++].Value = bilgi.yonetici_id;
            SQLHelper.ExecuteConcurrentNonQuery(SQLHelper.BilisimLibraryDbConnectionString, CommandType.Text, SQL_GUNCELLE, parms);
            return bilgi;
        }
        private static readonly String SQL_SIL = @"DELETE FROM tbl_YoneticiBina WHERE id=" + PARM_ID;
        public void Sil(int bilgi)
        {
            SqlParameter[] parms = new SqlParameter[] {
                        new SqlParameter(PARM_ID,SqlDbType.Int,4),
};
            int index = 0;
            parms[index++].Value = bilgi;
            SQLHelper.ExecuteConcurrentNonQuery(SQLHelper.BilisimLibraryDbConnectionString, CommandType.Text, SQL_SIL, parms);
        }


       
        public void yetkiSil(int bilgi)
        {
            SqlConnection con = new SqlConnection(SQLHelper.BilisimLibraryDbConnectionString);
            con.Open();
            string sorgu = @"DELETE FROM tbl_YoneticiBina WHERE yonetici_id=" + PARM_ID;
            SqlCommand cmd = new SqlCommand(sorgu,con);
            cmd.Parameters.AddWithValue(PARM_ID, bilgi);
            cmd.ExecuteNonQuery();
          //  SQLHelper.ExecuteConcurrentNonQuery(SQLHelper.BilisimLibraryDbConnectionString, CommandType.Text, SQL_YETKI_SIL, parms);
        }
    }
}

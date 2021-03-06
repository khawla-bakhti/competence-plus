﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TP10.Service;
using System.Data.OleDb;
using System.Windows.Forms;
using CompetancePlus.VO.PGroupes;
using CompetancePlus.BAL.PFilieres;
using CompetancePlus.Outils;

namespace CompetancePlus.DAL.PGroupes
{
    public class GroupeDAO : IGestion<Groupe>
    {
        public  void Add(Groupe g)
        {
            string Requete = "Insert into Groupes values ('" + g.Code + "','" + g.Nom + "')";
            MyConnection.ExecuteNonQuery(Requete);
        }

        public  void Update(Groupe g)
        {
            string Requete = "Update Filieres set Code ='" + g.Code + "',Nom ='" + g.Nom + "' where id =" + g.Id;
            MyConnection.ExecuteNonQuery(Requete);
        }

        public  void Delete(int id)
        {
            string Requete = "Delete From Groupes where id=" + id;
            MyConnection.ExecuteNonQuery(Requete);
        }

        public  List<Groupe> Select()
        {
            string Requete = "Select * from Groupes";
            List<Groupe> ListGroupe = new List<Groupe>();
            OleDbDataReader read = MyConnection.ExecuteReader(Requete);
            while (read.Read())
            {
                Groupe g = new Groupe();
                g.Id = read.GetInt32(0);
                g.Code = read.GetString(1);
                g.Nom = read.GetString(2);
                ListGroupe.Add(g);

            }
            MyConnection.Close();
            return ListGroupe;
        }

        public Groupe FindById(int id)
        {
            string Requete = "Select * from Groupes where id="+id;
            OleDbDataReader read = MyConnection.ExecuteReader(Requete);
            Groupe g = new Groupe();
            read.Read();
            g.Id = read.GetInt32(0);
            g.Code = read.GetString(1);
            g.Nom = read.GetString(2);
            g.Filiere = new FiliereBAO().FindById(read.GetInt32(3));
            MyConnection.Close();
            return g; 
        }
        public Groupe FindByName(string Name)
        {
            string Requete = "Select * from Groupes where Nom='Groupe 1'";
       
            OleDbDataReader read = MyConnection.ExecuteReader(Requete);
            read.Read();
            Groupe g = new Groupe();
            g.Id = read.GetInt32(0);
            g.Code = read.GetString(1);
            g.Nom = read.GetString(2);
            g.Filiere = new FiliereBAO().FindById(read.GetInt32(3));
            MyConnection.Close();
            return g;
        }


         
    }
}

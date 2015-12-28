using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web.Security;

namespace faktury.Models.Modele
{
    public class UzytkownikModel
    {
        public static List<Uzytkownicy> PobierzListeUzytkownikow()
        {
            using (FakturyDBEntitiess db = new FakturyDBEntitiess())
            {
                var uzytkownik = (from u in db.Uzytkownicy
                                  where object.Equals(u.DataZablokowania, null)
                                  orderby u.Login
                                  select u).ToList<Uzytkownicy>();
                foreach (Uzytkownicy user in uzytkownik)
                {
                    user.Role = db.Role.SingleOrDefault(r => r.RolaID == user.RolaID);
                }
                return uzytkownik;
            }
        }

        public static bool SprawdzListeUzytkownikow()
        {
            using (FakturyDBEntitiess db = new FakturyDBEntitiess())
            {
                if ((from u in db.Uzytkownicy select u).ToList<Uzytkownicy>().Count > 0)
                    return false;
                else
                    return true;
            }
        }

        internal static bool ZmienHaslo(Uzytkownicy u, string stareHaslo, string noweHaslo, string potwierdzenieNowegoHasla)
        {
            if (noweHaslo != potwierdzenieNowegoHasla)
            {
                return false;
            }

            if (u.Haslo != StworzHaslo(stareHaslo, u.HasloSzum))
            {
                return false;
            }
            using (FakturyDBEntitiess db = new FakturyDBEntitiess())
            {
                Uzytkownicy user = db.Uzytkownicy.SingleOrDefault(u1 => u1.UzytkownikID == u.UzytkownikID);
                user.HasloSzum = StworzSol();
                user.Haslo = StworzHaslo(noweHaslo, user.HasloSzum);
                db.SaveChanges();
                db.AcceptAllChanges();
            }
            return true;
        }

        internal static Uzytkownicy PobierzUzytkownikaPoID(int id)
        {
            using (FakturyDBEntitiess db = new FakturyDBEntitiess())
            {
                Uzytkownicy uzytkownik = db.Uzytkownicy.SingleOrDefault(u => u.UzytkownikID == id);
                uzytkownik.KodyPocztowe3 = db.KodyPocztowe.SingleOrDefault(k => k.KodPocztowyID == uzytkownik.KodPocztowyID);
                uzytkownik.Role = db.Role.SingleOrDefault(r => r.RolaID == uzytkownik.RolaID);
                uzytkownik.KodyPocztowe3.Miejscowosci = db.Miejscowosci.SingleOrDefault(m => m.MiejscowoscID == uzytkownik.KodyPocztowe3.MiejscowoscID);
                return uzytkownik;
            }
        }

        public static void DodajUzytkownika(Uzytkownicy u)
        {
            using (FakturyDBEntitiess db = new FakturyDBEntitiess())
            {
                u.HasloSzum = StworzSol();
                u.Haslo = StworzHaslo(u.Haslo, u.HasloSzum);
                db.Uzytkownicy.AddObject(u);
                db.SaveChanges();
            }
        }

        internal static string[] PobierzRoleUzytkownika(string login)
        {
            using (FakturyDBEntitiess db = new FakturyDBEntitiess())
            {
                string[] role = (from u in db.Uzytkownicy join r in db.Role on u.RolaID equals r.RolaID where u.Login == login select r.Nazwa).ToArray<string>();
                return role;
            }
        }

        internal static Uzytkownicy PobierzUzytkownikaPoLoginie(string login)
        {
            using (FakturyDBEntitiess db = new FakturyDBEntitiess())
            {
                return db.Uzytkownicy.SingleOrDefault(u => u.Login == login);
            }
        }

        private static string StworzSol()
        {
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] buff = new byte[32];
            rng.GetBytes(buff);

            return Convert.ToBase64String(buff);
        }

        private static string StworzHaslo(string pwd, string salt)
        {
            string saltAndPwd = String.Concat(pwd, salt);
            string hashedPwd =
                    FormsAuthentication.HashPasswordForStoringInConfigFile(saltAndPwd, "sha1");
            return hashedPwd;
        }

        internal static void Pierwszy()
        {
            using (FakturyDBEntitiess db = new FakturyDBEntitiess())
            {
                if (!((from u in db.Role select u).ToList<Role>().Count > 0))
                {
                    Role r = new Role();
                    r.RolaID = 1;
                    r.Nazwa = "Administrator";
                    db.Role.AddObject(r);
                    db.SaveChanges();
                    r = new Role();
                    r.RolaID = 2;
                    r.Nazwa = "Uzytkownik";
                    db.Role.AddObject(r);
                    db.SaveChanges();
                }
            }
        }

        internal static int ZwrocNrAdministratora()
        {
            using (FakturyDBEntitiess db = new FakturyDBEntitiess())
            {
                Role rola = db.Role.SingleOrDefault(o => object.Equals(o.Nazwa, "Administrator"));
                return rola.RolaID;
            }
        }

        internal static bool EdytujUzytkownika(int id, Uzytkownicy user, int Rola, int KodPocztowy)
        {
            try
            {
                using (FakturyDBEntitiess db = new FakturyDBEntitiess())
                {
                    Uzytkownicy edycjaUzytkownika = db.Uzytkownicy.SingleOrDefault(u => u.UzytkownikID == id);
                    edycjaUzytkownika.ModyfikujacyID = user.ModyfikujacyID;
                    edycjaUzytkownika.DataModyfikacji = DateTime.Now;
                    edycjaUzytkownika.RolaID = Rola;
                    edycjaUzytkownika.KodPocztowyID = KodPocztowy;
                    edycjaUzytkownika.Imie=user.Imie;
                    edycjaUzytkownika.Nazwisko=user.Nazwisko;
                    edycjaUzytkownika.Ulica=user.Ulica;
                    edycjaUzytkownika.NrDomu=user.NrDomu;
                    edycjaUzytkownika.NrMieszkania=user.NrMieszkania;
                    edycjaUzytkownika.Nip=user.Nip;
                    edycjaUzytkownika.Pesel=user.Pesel;
                    edycjaUzytkownika.Email=user.Email;
                    edycjaUzytkownika.Uwagi=user.Uwagi;
                    db.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
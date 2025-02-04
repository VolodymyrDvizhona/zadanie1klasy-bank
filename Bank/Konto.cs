﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    class Osoba
    {
        public string Imie;
        public string Nazwisko;
    }
    internal class Konto
    {
        public Osoba Wlasciciel;
        private decimal saldo = 0;
        private int pin = 0;

        private bool SprawdzPin(int pin)
        {
            if (this.pin == pin)
            {
                return true;
            }
            return false;
        }

        public void DokonajWplaty(decimal kwota)
        {
            if (kwota < 0)
            {
                throw new ArgumentException("Wplacana kwota nie moze byc mniejsza od zera");
            }
            saldo += kwota;

            Console.WriteLine("Aktualne saldo na koncie: {0}", saldo);
        }

        public string DokonajWyplaty(decimal kwota, int pin)
        {
            if(!SprawdzPin(pin) || saldo < kwota)
            {
                return "Operacja anulowana";
            }
            saldo -= kwota;
            return "Operacje zakonczono pomyslnie";
        }

        public bool ZmienPin(int nowy, int stary)
        {
            if (SprawdzPin(stary))
            {
                pin = nowy;
                return true;
            }
            return false;
        }

        public string PobierzInformacje(int pin)
        {
            if (SprawdzPin(pin))
            {
                return string.Format("Pan(i) {0} {1} posiada na koncie: {2}",
                    Wlasciciel.Imie, Wlasciciel.Nazwisko, saldo);
            }
            return "Brak Dostepu";
        }
    }
}

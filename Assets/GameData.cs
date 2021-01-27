using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public static class GameData
{

    public static float money, maxenergy, disease, energy, hour, food, maxfood;
    public static int day, b, f, c, m, dayswofood, daysnprent, dayswomedicine, incorrect;
    public static bool isill, firstload, hasmask, late, coworker, comask, ase, bse, cse, fse, bese, firstloadhouse;

    public static bool IsIll
    {
        get
        {
            return isill;
        }
        set
        {
            isill = value;
        }
    }public static bool FirstLoadHouse
    {
        get
        {
            return firstloadhouse;
        }
        set
        {
            firstloadhouse = value;
        }
    } public static float Food
    {
        get
        {
            return food;
        }
        set
        {
            food = value;
        }
    } 
    public static bool ASE
    {
        get
        {
            return ase;
        }
        set
        {
            ase = value;
        }
    }public static bool BESE
    {
        get
        {
            return bese;
        }
        set
        {
            bese = value;
        }
    }    public static bool BSE
    {
        get
        {
            return bse;
        }
        set
        {
            bse = value;
        }
    }    public static bool CSE
    {
        get
        {
            return cse;
        }
        set
        {
            cse = value;
        }
    }    public static bool FSE
    {
        get
        {
            return fse;
        }
        set
        {
            fse = value;
        }
    }
    public static bool CoWorker
    {
        get
        {
            return coworker;
        }
        set
        {
            coworker = value;
        }
    }
    public static bool FirstLoad
    {
        get
        {
            return firstload;
        }
        set
        {
            firstload = value;
        }
    }    
    public static bool HasMask
    {
        get
        {
            return hasmask;
        }
        set
        {
            hasmask = value;
        }
    }    public static bool Late
    {
        get
        {
            return late;
        }
        set
        {
            late = value;
        }
    }

    public static float Money {
        get
        {
            return money;
        }
        set
        {
            money = value;
        }
    } public static float MaxFood {
        get
        {
            return maxfood;
        }
        set
        {
            maxfood = value;
        }
    }
    public static float Hour {
        get
        {
            return hour;
        }
        set
        {
            hour = value;
        }
    }
    public static float Maxenergy {
        get
        {
            return maxenergy;
        }
        set
        {
            maxenergy = value;
        }
    }
    public static float Disease {
        get
        {
            return disease;
        }
        set
        {
            disease = value;
        }
    }
    public static float Energy {
        get
        {
            return energy;
        }
        set
        {
            energy = value;
        }
    }
    public static int Day {
        get
        {
            return day;
        }
        set
        {
            day = value;
        }
    }    public static int Incorrect {
        get
        {
            return incorrect;
        }
        set
        {
            incorrect = value;
        }
    }    public static int B {
        get
        {
            return b;
        }
        set
        {
            b = value;
        }
    }    public static int F {
        get
        {
            return f;
        }
        set
        {
            f = value;
        }
    }    public static int C {
        get
        {
            return c;
        }
        set
        {
            c = value;
        }
    }public static int DaysWOMedicine {
        get
        {
            return dayswomedicine;
        }
        set
        {
            dayswomedicine = value;
        }
    }public static int DaysWOFood {
        get
        {
            return dayswofood;
        }
        set
        {
            dayswofood = value;
        }
    }public static int DaysNPRent {
        get
        {
            return daysnprent;
        }
        set
        {
            daysnprent = value;
        }
    }    public static int M {
        get
        {
            return m;
        }
        set
        {
            m = value;
        }
    }
}

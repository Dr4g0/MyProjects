using System;
using System.Threading;

public class TestIDNumber
{
    public static void Main()
    {
        string userID = Console.ReadLine();
        if (!TestEGN(userID))
        {
            Console.WriteLine("Wrong IDNumber");
        }
        else
        {
            Console.WriteLine("Correct IDNumber");
        }
        string userEIK = Console.ReadLine();
        if (!ValidateBulstatFull(userEIK))
        {
            Console.WriteLine("Wrong EIK");
        }
        else
        {
            Console.WriteLine("Correct EIK");
        }
    }

    private static bool TestEGN(string userIDNumber)
    {
        if (userIDNumber.Length != 10)
        {
            return false;
        }
        foreach (char digit in userIDNumber)
        {
            if (!Char.IsDigit(digit))
            {
                return false;
            }
        }
        int month = int.Parse(userIDNumber.Substring(2, 2));
        int year = 0;
        if (month < 13)
        {
            year = int.Parse("19" + userIDNumber.Substring(0, 2));
        }
        else if (month < 33)
        {
            month -= 20;
            year = int.Parse("18" + userIDNumber.Substring(0, 2));
        }
        else
        {
            month -= 40;
            year = int.Parse("20" + userIDNumber.Substring(0, 2));
        }
        int day = int.Parse(userIDNumber.Substring(4, 2));
        DateTime dateOfBirth = new DateTime();
        if (!DateTime.TryParse(String.Format("{0}/{1}/{2}", day, month, year), out dateOfBirth))
        {
            return false;
        }
        int[] weights = new int[] { 2, 4, 8, 5, 10, 9, 7, 3, 6 };
        int totalControlSum = 0;
        for (int i = 0; i < 9; i++)
        {
            totalControlSum += weights[i] * (userIDNumber[i] - '0');
        }
        int controlDigit = 0;
        int reminder = totalControlSum % 11;
        if (reminder < 10)
        {
            controlDigit = reminder;
        }
        int lastDigitFromIDNumber = int.Parse(userIDNumber.Substring(9));
        if (lastDigitFromIDNumber != controlDigit)
        {
            return false;
        }
        return true;
    }

    public static bool ValidateBulstat(string bulstat)
    {
        if (bulstat.Length != 9 && bulstat.Length != 13)
        {
            return false;
        }
        int checkSum1 = 0;
        int checkSum2 = 0;
        for (int i = 0; i < 8; i++)
        {
            int ch = 0;
            ch = Convert.ToInt16(bulstat[i]);
            if (ch < 48 || ch > 57)
            {
                return false;
            }
            ch -= 48;
            checkSum1 += ch * (i + 1);
            checkSum2 += ch * (i + 3);
        }
        int controlDigit = checkSum1 % 11;
        if (controlDigit == 10)
            controlDigit = checkSum2 % 11;
        if (controlDigit == 10)
            controlDigit = 0;
        if (Convert.ToInt16(bulstat[8]) != controlDigit + 48)
        {
            return false;
        }
        if (bulstat.Length == 13)
        {
            int[] weight1 = { 2, 7, 3, 5 };
            int[] weight2 = { 4, 9, 5, 7 };
            checkSum1 = 0;
            checkSum2 = 0;
            for (int i = 8; i < 13; i++)
            {
                int ch = 0;
                ch = Convert.ToInt16(bulstat);
                if (ch < 48 || ch > 57)
                {
                    return false;
                }
                ch -= 48;
                checkSum1 += ch * weight1[i - 8];
                checkSum2 += ch * weight2[i - 8];
            }
            if (controlDigit + 48 != Convert.ToInt16(bulstat[12]))
            {
                return false;
            }
        }
        return true;
    }

    public static bool ValidateBulstatFull(string bulstat)
    {
        bulstat = bulstat.Trim();
        switch (bulstat.Length)
        {
            case 9:
                if (!ValidateBulstat(bulstat))
                {
                    return false;
                }
                return true;
            case 13:
                if (!ValidateBulstat(bulstat))
                {
                    return false;
                }
                return true;
        }
        if (bulstat.Length != 10 && bulstat.Length != 14)
        {
            return false;
        }
        char f = "А"[0];
        char l = "Я"[0];
        if (bulstat[0] < f || bulstat[0] > l)
        {
            return false;
        }
        if (!ValidateBulstat(bulstat.Substring(1, bulstat.Length - 1)))
        {
            return false;
        }
        return true;
    }
}
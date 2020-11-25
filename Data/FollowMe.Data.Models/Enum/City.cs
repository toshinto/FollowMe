using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FollowMe.Data.Models.Enum
{
    public enum City
    {
        Blagoevgrad = 1,
        Burgas = 2,
        Varna = 3,
        [Display(Name = "Veliko Tarnovo")]
        VelikoTarnovo = 4,
        Vidin = 5,
        Vraca = 6,
        Gabrovo = 7,
        Dobrich = 8,
        Kardzhali = 9,
        Kustendil = 10,
        Lovech = 11,
        Montana = 12,
        Pazardzhik = 13,
        Pernik = 14,
        Pleven = 15,
        Plovdiv = 16,
        Razgrad = 17,
        Ruse = 18,
        Silistra = 19,
        Sliven = 20,
        Smolqn = 21,
        Sofia = 22,
        [Display(Name = "Stara Zagora")]
        StaraZagora = 23,
        Targovishte = 24,
        Haskovo = 25,
        Shumen = 26,
        Qmbol = 27,
        Other = 28,
    }
}

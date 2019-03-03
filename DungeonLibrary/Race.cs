using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    //we can't add an ENUM through Visual Studios interface. If we want to create enum, we make a class and then chage the word class to enum and make it PUBLIC
    public enum Race
    {
        //single values, NO spaces in the value
        //Comma separate
        Deow,
        Idex,
        Orc,
        Elf,
        Gnome,
        Dale,
        Human,
        Dwarf,
        Khajiit,
    }
}

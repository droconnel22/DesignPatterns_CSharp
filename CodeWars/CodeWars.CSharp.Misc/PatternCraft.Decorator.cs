using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWars.CodeWars.CSharp.Misc
{
    public interface IMarine
    {
        int Damage { get; set; }
        int Armor { get; set; }
    }


    public class Marine : IMarine
    {
        private int _damage;
        private int _armor;


        public Marine(int damage, int armor)
        {
            this._damage = damage;
            this._armor = armor;
        }

        public int Damage
        {
            get { return _damage; }
            set { _damage = value; }
        }

        public int Armor
        {
            get { return _armor; }
            set { _armor = value; }
        }
    }


    public class MarineWeaponUpgrade : IMarine
    {
        private int _damage;
        private int _armor;

        public MarineWeaponUpgrade(IMarine marine)
        {
            this._damage = marine.Damage + 1;
            this._armor = marine.Armor;
        }

        public int Damage
        {
            get { return _damage; }
            set { _damage = value; }
        }

        public int Armor
        {
            get { return _armor; }
            set { _armor = value; }
        }
    }

    public class MarineArmorUpgrade : IMarine
    {
        private int _damage;
        private int _armor;

        public MarineArmorUpgrade(IMarine marine)
        {
            this._armor = marine.Armor + 1;
            this._damage = marine.Damage;
        }

        public int Damage
        {
            get { return _damage; }
            set { _damage = value; }
        }

        public int Armor
        {
            get { return _armor; }
            set { _armor = value; }
        }
    }
}

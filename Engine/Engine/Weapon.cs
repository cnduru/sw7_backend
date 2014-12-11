using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine {
    class Weapon {
        private int _range;
        private int _damage;
        private int _id;

        public Weapon(int weaponId) {
            switch(weaponId){
                case 1:
                    //Pistol
                    SetId(1);
                    SetDamage(20);
                    SetRange(25);
                    break;
                case 2:
                    //Shotgun
                    SetId(2);
                    SetDamage(60);
                    SetRange(15);
                    break;
                case 3:
                    //Sniper
                    SetId(3);
                    SetDamage(70);
                    SetRange(40);
                    break;
                default:
                    throw new ArgumentOutOfRangeException("WeaponId must be between 1-3");
            }
        }

        private void SetId(int id) {
            _id = id;
        }

        private void SetRange(int range) {
            _range = range;
        }

        private void SetDamage(int damage) {
            _damage = damage;
        }

        public int GetId() {
            return _id;
        }

        public int GetDamage() {
            return _range;
        }

        public int GetRange() {
            return _damage;
        }






    }
}

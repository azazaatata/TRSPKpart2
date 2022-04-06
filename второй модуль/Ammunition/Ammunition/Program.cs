using System;

namespace Ammunition
{

    abstract class Ammunition
    {
        protected string _name;
        protected bool _isDefense;
        protected int _lifetime;
        protected int _value;
        protected int _range;

        public int Lifetime //Определение продолжительности действия предмета
        {
            get
            {
                return _lifetime;
            }
            set
            {
                _lifetime += value;
                //Отправлять сообщение юниту если лайфтайм равен нулю
            }
        }

        public string Name => _name;//Название предмета
        public bool IsDefense => _isDefense;//Переменная определяющая атакующий предмет или защищающий
        public int Value => _value;//Определение значения(величины) накладываемого бафа
        public int Range => _range;//Определение дистанции действия абилки
    }

    class Hemlet : Ammunition
    {
        public Hemlet()
        {
            _name = "Шлем";
            _isDefense = true;
            _lifetime = 2;
            _value = 1;
            _range = 0;
        }
    }

    class Shield : Ammunition
    {
        public Shield()
        {
            _name = "Щит";
            _isDefense = true;
            _lifetime = 1;
            _value = 2;
            _range = 0;
        }
    }

    class Peak : Ammunition
    {
        public Peak()
        {
            _name = "Пика";
            _isDefense = false;
            _lifetime = 1;
            _value = 0;
            _range = 2;
        }
    }

    class Horse : Ammunition
    {
        public Horse()
        {
            _name = "Коняшка";
            _isDefense = false;
            _lifetime = 2;
            _value = 1;
            _range = 1;
        }
    }
}
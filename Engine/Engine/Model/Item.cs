using System;
using System.Data;

namespace Engine
{
	public class Item
	{
        private int _id, _itemType, _effect;

		public Item (DataRow row)
		{
			_id = row.Field<int> ("id");
			_itemType = row.Field<int> ("item_type");
			_effect = row.Field<int> ("effect");
		}

		public Item (int itemType, int effect)
		{
            _id = 0;
            _itemType = itemType;
            _effect = effect;
		}

        public int id
        {
            get { return _id; }
        }

        public int itemType
        {
            get { return _itemType; }
        }

        public int effect
        {
            get { return _effect; }
        }
	}
}


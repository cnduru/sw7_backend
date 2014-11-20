using System;

namespace Engine
{
	public class Item
	{
        private int _id, _itemType, _effect;

		public Item (int id, int itemType, int effect)
		{
            _id = id;
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


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server {
    class BoundingBox {

        Coordinate BoxCornerA;
        Coordinate BoxCornerB;

        public BoundingBox(Coordinate boxCornerA, Coordinate boxCornerB) {
            BoxCornerA = boxCornerA;
            BoxCornerB = boxCornerB;
        }

        public Coordinate GetBoxCornerA() {
            return BoxCornerA;
        }

        public Coordinate GetBoxCornerB() {
            return BoxCornerB;
        }
    }
}

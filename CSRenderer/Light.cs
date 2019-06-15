using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSRenderer {
    interface Light {
        float Sample(InterResult inter, Collider c);
    }
}

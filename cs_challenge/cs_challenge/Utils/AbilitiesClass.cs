using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs_challenge.Utils;

public class AbilitiesClass {
    public Dictionary<string, string>? ability { get; set; }
    public int? slot { get; set; }
    public override string ToString() {
        return ability!["name"];
    }
}


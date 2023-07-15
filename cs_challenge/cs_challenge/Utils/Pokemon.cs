using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cs_challenge.Utils;

namespace cs_challenge.Utils;

public class Pokemon {
    public string? name { get; set; }
    public string? url { get; set; }
    public int? height { get; set; }
    public int? weight { get; set; }
    public List<AbilitiesClass>? abilities { get; set; }
    /*public List<string>? types { get; set; }*/
    public override string ToString() {
        if (name == null) { return string.Empty; }
        if (height == null) { return name; }
        return $"Name: {name}\nHeight: {height}\nWeight: {weight}\nAbilities:\n{string.Join('\n', abilities!)}";
    }
}
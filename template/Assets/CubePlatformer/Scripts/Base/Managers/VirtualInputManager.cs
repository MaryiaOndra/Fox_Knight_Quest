using CubePlatformer.Core;

namespace CubePlatformer
{
    public class VirtualInputManager : BaseManager<VirtualInputManager>
    {
        public float MoveVertical { get;  set; }
        public float MoveHorizontal { get;  set; }
        public bool Attack { get;  set; }
        public bool Defend { get;  set; }       
    }
}

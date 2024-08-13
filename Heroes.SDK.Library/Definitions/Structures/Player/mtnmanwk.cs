using System;
using System.Runtime.InteropServices;

namespace Heroes.SDK.Definitions.Structures.Player
{
    [Equals(DoNotAddEqualityOperators = true)]
    [StructLayout(LayoutKind.Sequential)] //0x70
    public unsafe struct mtnmanwk
    {
        public Int16 mtnmode;
        public Int16 reqaction;
        public Int16 action;
        public Int16 lastaction;
        public Int16 nextaction;
        public Int16 acttimer;
        public Int16 flag;
        public Int16 blendaction;
        public Int16 nextblendaction;
        public Int16 dummy;
        public float nframe;
        public float last_frame;
        public float start_frame;
        public float blendratio;
        public float nextblendratio;
        public float* spdp;
        public float* workp;
        public PL_MOTION* plmotptr;
        public void* pClump;
        public void* pNHAH;
        public void* pTHAH;
        public void* pIHAH;
        public fixed Int16 mot[14];
        public fixed byte mot_timer[14];
    }

}


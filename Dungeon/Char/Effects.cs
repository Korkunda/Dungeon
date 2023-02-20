using Dungeon.Battling;

namespace Dungeon.Char
{
    public class Effects
    {

        public List<IEffect> EffectList { get; set; }

        public Effects()
        {
            //correct the assignment
            EffectList = new List<IEffect>();
            
        }

        public bool AddEffects(IEffect effect)
        {
            if(EffectList.Contains(effect))
            {
                return false;
            }
            else
            {
                EffectList.Add(effect);
                return true;
            }
        }       

        public bool RemovePlayerEffect(IEffect effect)
        {
            if (EffectList.Contains(effect))
            {
                EffectList.Remove(effect);
                return true;
            }
            else
            {
                return false;
            }
        }

        public void RemoveExpiredEffects()
        {

            foreach (var effect in EffectList.ToList())
            {
                if (effect.TurnsLeftOfEffect == 0)
                {
                    EffectList.Remove(effect);
                }
            }


        }
    }
}
